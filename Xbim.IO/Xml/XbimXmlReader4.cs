﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Common.Metadata;
using Xbim.Common.Step21;
using Xbim.IO.Step21.Parser;

namespace Xbim.IO.Xml
{
    public class XbimXmlReader4
    {
        private readonly ExpressMetaData _metadata;
        private readonly GetOrCreateEntity _getOrCreate;
        private readonly FinishEntity _finish;
        private static readonly Dictionary<string, StepParserType> Primitives;
        private Dictionary<string, int> _idMap;
        private int _lastId;
        private readonly string _xsi = "http://www.w3.org/2001/XMLSchema-instance";

        /// <summary>
        /// Constructor of the reader for IFC2x3 XML. XSD is different for different versions of IFC and there is a major difference
        /// between IFC2x3 and IFC4 to there are two different classes to deal with this.
        /// </summary>x
        /// <param name="getOrCreate">Delegate which will be used to getOrCreate new entities</param>
        /// <param name="finish">Delegate which will be called once the entity is finished (no changes will be made to it)
        /// This is useful for a DB when this is the point when it can be serialized to DB</param>
        /// <param name="metadata">Metadata model used to inspect Express types and their properties</param>
        public XbimXmlReader4(GetOrCreateEntity getOrCreate, FinishEntity finish, ExpressMetaData metadata)
        {
            if (getOrCreate == null) throw new ArgumentNullException("getOrCreate");
            if (finish == null) throw new ArgumentNullException("finish");
            if (metadata == null) throw new ArgumentNullException("metadata");
            _getOrCreate = getOrCreate;
            _finish = finish;
            _metadata = metadata;
        }

        static XbimXmlReader4()
        {
            Primitives = new Dictionary<string, StepParserType>
            {
                {"double-wrapper", StepParserType.Real},
                {"long-wrapper", StepParserType.Integer},
                {"string-wrapper", StepParserType.String},
                {"integer-wrapper", StepParserType.Integer},
                {"boolean-wrapper", StepParserType.Boolean},
                {"logical-wrapper", StepParserType.Boolean},
                {"decimal-wrapper", StepParserType.Real},
                {"hexBinary-wrapper", StepParserType.HexaDecimal},
                {"base64Binary-wrapper", StepParserType.Entity},
                {typeof (double).Name, StepParserType.Real},
                {typeof (long).Name, StepParserType.Integer},
                {typeof (string).Name, StepParserType.String},
                {typeof (int).Name, StepParserType.Integer},
                {typeof (bool).Name, StepParserType.Boolean},
                {"Enum", StepParserType.Enum}
            };

        }

        public StepFileHeader Read(XmlReader input)
        {
            _idMap = new Dictionary<string, int>();
            
            var header = new StepFileHeader(StepFileHeader.HeaderCreationMode.LeaveEmpty);
            var rootElement = true;
            var headerElement = true;
            while (input.Read())
            {
                //skip everything except for element nodes
                if (input.NodeType != XmlNodeType.Element)
                    continue;

                if (rootElement)
                {
                    //do any root element processing here (check namespace, but it might be defined further down)
                    rootElement = false;
                    continue;
                }

                if (headerElement)
                {
                    //header is the first inner node if defined (it is optional)
                    var name = input.LocalName.ToLowerInvariant();
                    if (name == "header" && !input.IsEmptyElement)
                    {
                        header = ReadHeader(input.ReadSubtree());
                        continue;
                    }
                    headerElement = false;
                }

                //process all root entities in the file (that has to be IPersistEntity)
                ReadEntity(input.IsEmptyElement ? input : input.ReadSubtree());
            }

            return header;

        }

        private ExpressType GetExpresType(XmlReader input)
        {
            var typeName = input.LocalName.ToUpperInvariant().Replace("-WRAPPER", "");
            ExpressType expType;
            if (!_metadata.TryGetExpressType(typeName, out expType))
            {
                //try to get type name from the attribute
                typeName = input.GetAttribute("type", _xsi);
                if (typeName == null || !_metadata.TryGetExpressType(typeName.ToUpperInvariant(), out expType))
                    return null;
            }
            return expType;
        }

        private void MoveToElement(XmlReader input)
        {
            if (input.NodeType != XmlNodeType.Element)
            {
                while (input.Read())
                {
                    if (input.NodeType == XmlNodeType.Element) break;
                }
            }
            if (input.NodeType != XmlNodeType.Element)
                throw new XbimParserException("No data to read.");
        }

        private IPersistEntity ReadEntity(XmlReader input)
        {
            MoveToElement(input);

            var typeName = input.LocalName.ToUpperInvariant();
            var expType = GetExpresType(input);
            if (expType == null)
                throw new XbimParserException(typeName + "is not an IPersistEntity type");

            bool isRef;
            var id = GetId(input, out isRef);
            if(!id.HasValue)
                throw new XbimParserException("Wrong entity XML format");

            var entity = _getOrCreate(id.Value, expType.Type);
            if (isRef) return entity;

            //read all attributes
            while (input.MoveToNextAttribute())
            {
                var pInfo = GetMetaProperty(expType, input.LocalName);
                if(pInfo == null) continue;
                SetPropertyFromAttribute(pInfo, entity, input.Value, null);
            }
            input.MoveToElement();

            if (input.IsEmptyElement)
            {
                _finish(entity);
                return entity;
            }

            //read all elements
            while (input.Read())
            {
                if (input.NodeType != XmlNodeType.Element) continue;
                var pInfo = GetMetaProperty(expType, input.LocalName);
                if (pInfo == null) continue;
                SetPropertyFromElement(pInfo, entity, input.IsEmptyElement ? input : input.ReadSubtree(), null);
            }

            //finalize
            _finish(entity);
            return entity;
        }

        private bool InitPropertyValue(Type type, string value, out IPropertyValue propertyValue)
        {
            var propVal = new PropertyValue();
            if (type == typeof (bool))
            {
                propVal.Init(string.CompareOrdinal(value, "true") == 0 ? ".T." : ".F.", StepParserType.Boolean);
                propertyValue = propVal;
                return true;
            }
            if (type == typeof (bool?))
            {
                if (string.CompareOrdinal(value, "unknown") == 0)
                {
                    propertyValue = null;
                    return false;
                }
                propVal.Init(string.CompareOrdinal(value, "true") == 0 ? ".T." : ".F.", StepParserType.Boolean);
                propertyValue = propVal;
                return true;
            }
            if (typeof (string) == type)
            {
                propVal.Init("'"  + value + "'", StepParserType.String);
                propertyValue = propVal;
                return true;
            }
            if (typeof (int) == type || typeof (long) == type)
            {
                propVal.Init(value, StepParserType.Integer);
                propertyValue = propVal;
                return true;
            }
            if (typeof(float) == type || typeof(double) == type)
            {
                propVal.Init(value, StepParserType.Real);
                propertyValue = propVal;
                return true;
            }

            throw new XbimParserException("Unexpected type: " + type.Name);
        }

        private void SetPropertyFromElement(ExpressMetaProperty property, IPersistEntity entity, XmlReader input, int[] pos, ExpressType valueType = null)
        {
            MoveToElement(input);

            var name = input.LocalName;
            var type = valueType != null ? valueType.Type : GetNonNullableType(property.PropertyInfo.PropertyType);
            var pIndex = property.EntityAttribute.Order - 1;
            var expType = valueType ?? GetExpresType(input);
            //select type
            if (typeof (IExpressSelectType).IsAssignableFrom(type) && type.IsInterface)
            {
                //move to inner element which represents the data
                while (input.Read())
                {
                    if(input.NodeType != XmlNodeType.Element) continue;
                    expType = GetExpresType(input);
                    if(expType == null)
                        throw new XbimParserException("Unexpected select data type " + name);

                    if (typeof(IExpressValueType).IsAssignableFrom(expType.Type))
                    {
                        SetPropertyFromElement(property, entity, input.IsEmptyElement ? input : input.ReadSubtree(), pos, expType);
                        return;
                    }

                    if (typeof (IPersistEntity).IsAssignableFrom(expType.Type))
                    {
                        SetPropertyFromElement(property, entity, input.IsEmptyElement ? input : input.ReadSubtree(), pos, expType);
                        return;
                    }

                    //this should either be a defined type or entity
                    throw new XbimParserException("Unexpected select data type " + expType.Name);
                }
                return;
            }

            //defined type
            if (typeof(IExpressValueType).IsAssignableFrom(type))
            {
                var cType = expType.UnderlyingComplexType;

                //if it is just a value we can use 'SetPropertyFromAttribute'
                if (type == property.PropertyInfo.PropertyType && !(cType != null && typeof(IPersistEntity).IsAssignableFrom(cType)))
                {
                    var strValue = input.ReadElementContentAsString();
                    SetPropertyFromAttribute(property, entity, strValue, pos);
                    return;
                }

                if (cType != null)
                {
                    var cInnerValueType = typeof(List<>);
                    cInnerValueType = cInnerValueType.MakeGenericType(cType);
                    var cInnerList = Activator.CreateInstance(cInnerValueType) as IList;
                    if (cInnerList == null)
                        throw new XbimParserException("Initialization of " + cInnerValueType.Name + " failed.");

                    if (typeof(IPersistEntity).IsAssignableFrom(cType))
                    {
                        if (!input.IsEmptyElement)
                        {
                            input = input.ReadSubtree();
                            MoveToElement(input);
                            while (input.Read())
                            {
                                if (input.NodeType != XmlNodeType.Element) continue;
                                var innerEntity = ReadEntity(input.IsEmptyElement ? input : input.ReadSubtree());
                                cInnerList.Add(innerEntity);
                            }
                        }
                    }
                    else
                    {
                        var cValuesString = input.ReadElementContentAsString();
                        var cValues = cValuesString.Split(_separator, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var cValue in cValues)
                        {
                        }
                        throw new NotImplementedException();
                    }

                    var cValueVal = Activator.CreateInstance(expType.Type, cInnerList);
                    var cpValue = new PropertyValue();
                    cpValue.Init(cValueVal);
                    entity.Parse(pIndex, cpValue, null);
                    return;
                }

                //normal defined type has string based constructor which will set the right value
                var sValue = input.ReadElementContentAsString();
                if (property.EnumerableType == expType.Type)
                {
                    IPropertyValue pValue;
                    InitPropertyValue(expType.UnderlyingType, sValue, out pValue);
                    entity.Parse(pIndex, pValue, pos);
                    return;
                }
                else
                {
                    var pValue = new PropertyValue();
                    var pValueVal = Activator.CreateInstance(expType.Type, sValue);
                    pValue.Init(pValueVal);
                    entity.Parse(pIndex, pValue, pos);
                    return;
                }
            }

            if (typeof(IPersistEntity).IsAssignableFrom(type) || 
                (typeof(IEnumerable).IsAssignableFrom(type) && property.EntityAttribute.MaxCardinality == 1))
            {
                var value = ReadEntity(input);
                var pVal = new PropertyValue();

                if (property.IsInverse)
                {
                    pVal.Init(entity);
                    var remotePropName = property.InverseAttributeProperty.RemoteProperty;
                    var remoteProperty = value.ExpressType.Properties.FirstOrDefault(p => p.Value.Name == remotePropName).Value;
                    if(remoteProperty == null)
                        throw new XbimParserException("Non existing counterpart to " + property.Name);
                    value.Parse(remoteProperty.EntityAttribute.Order - 1, pVal, null);
                }
                else
                {
                    pVal.Init(value);
                    entity.Parse(pIndex, pVal, null);    
                }
                return;
            }

            //enumeration or inverse enumeration
            if (typeof (IEnumerable).IsAssignableFrom(type))
            {
                //do nothing with empty list. If it is mandatory it is initialized anyway
                if (input.IsEmptyElement)
                    return;

                //isolate to finish at the end of this element
                input = input.ReadSubtree();
                MoveToElement(input);
                while (input.Read())
                {
                    if (input.NodeType != XmlNodeType.Element) continue;
                    
                    //position is optional
                    var posAttr = input.GetAttribute("pos");
                    pos = null;
                    if (!string.IsNullOrWhiteSpace(posAttr))
                    {
                        var idx = posAttr.Split(_separator, StringSplitOptions.RemoveEmptyEntries)
                            .Select(i => Convert.ToInt32(i)).ToList();
                        //remove the last one as it is not used in Parse function
                        if(idx.Count > 0)
                            idx.RemoveAt(idx.Count-1);
                        //only set if it has any values in
                        if(idx.Count > 0)
                            pos = idx.ToArray();
                    }

                    //it might be a primitive
                    name = input.LocalName;
                    if (Primitives.ContainsKey(input.LocalName))
                    {
                        var iVal = input.ReadElementContentAsString();
                        var pVal = new PropertyValue();
                        pVal.Init(iVal, Primitives[name]);
                        entity.Parse(pIndex, pVal, pos);
                        continue;
                    }

                    var eType = GetExpresType(input);
                    if(eType == null)
                        throw new XbimParserException("Unexpected type " + name);
                    SetPropertyFromElement(property, entity, input.IsEmptyElement ? input : input.ReadSubtree(), pos, eType);
                }
                return;
            }
            throw new XbimParserException("Unexpected type: " + type.Name);
        }

        private readonly char[] _separator = {' '};

        private void SetPropertyFromAttribute(ExpressMetaProperty property, IPersistEntity entity, string value, int[] pos, Type valueType = null)
        {
            var pIndex = property.EntityAttribute.Order - 1;
            var type = valueType ?? property.PropertyInfo.PropertyType;
            type = GetNonNullableType(type);
            var propVal = new PropertyValue();
            
            if (type.IsValueType || type == typeof(string))
            {
                if (typeof(IExpressComplexType).IsAssignableFrom(type))
                {
                    var meta = _metadata.ExpressType(type);
                    var values = value.Split(_separator, StringSplitOptions.RemoveEmptyEntries);
                    var underType = meta.UnderlyingComplexType;
                    foreach (var v in values)
                    {
                        IPropertyValue pv;
                        if(InitPropertyValue(underType, v, out pv))
                            entity.Parse(pIndex, pv, null);
                    }
                    return;
                }
                if (type.IsEnum)
                {
                    propVal.Init(value, StepParserType.Enum);
                    entity.Parse(pIndex, propVal, null);
                    return;
                }

                //handle other value types
                if (typeof(IExpressValueType).IsAssignableFrom(type))
                {
                    var meta = _metadata.ExpressType(type);
                    type = meta.UnderlyingType;
                }
                IPropertyValue pVal;
                if (InitPropertyValue(type, value, out pVal))
                    entity.Parse(pIndex, pVal, null);
                return;
            }

            //lists of value types will be serialized as lists. If this is not an IEnumerable this is not the case
            if (!typeof(IEnumerable).IsAssignableFrom(type) || !type.IsGenericType)
                throw new XbimParserException("Unexpected enumerable type " + type.Name);

            var genType = type.GetGenericArguments()[0];
            if (genType.IsValueType || genType == typeof(string))
            {
                //handle enumerable of value type and string
                var values = value.Split(_separator, StringSplitOptions.RemoveEmptyEntries);
                foreach (var v in values)
                {
                    SetPropertyFromAttribute(property, entity, v, pos, genType);
                }
                return;
            }

            //rectangular nested lists can also be serialized as attribute if defined in configuration
            if (typeof(IEnumerable).IsAssignableFrom(genType))
            {
                //handle rectangular nested lists (like IfcPointList3D)
                throw new NotImplementedException();
            }
        }

        private static Type GetNonNullableType(Type type)
        {
            if (!type.IsValueType)
                return type;
            if (!type.IsGenericType)
                return type;
            if (type.GetGenericTypeDefinition() != typeof(Nullable<>))
                return type;
            return type.GetGenericArguments()[0];
        }

        private static ExpressMetaProperty GetMetaProperty(ExpressType expType, string name)
        {
            var prop = expType.Properties.FirstOrDefault(p => string.CompareOrdinal(p.Value.Name, name) == 0);
            return prop.Value ?? expType.Inverses.FirstOrDefault(p => string.CompareOrdinal(p.Name, name) == 0);
        }


        private int? GetId(XmlReader input, out bool isRefType)
        {
            isRefType = false;
            int? nextId = null;
            ExpressType expressType;
            var strId = input.GetAttribute("id");
            if (string.IsNullOrEmpty(strId))
            {
                strId = input.GetAttribute("ref");
                if (!string.IsNullOrEmpty(strId)) isRefType = true;
            }
            if (!string.IsNullOrEmpty(strId)) //must be a new instance or a reference to an existing one  
            {
                int lookup;
                if (!_idMap.TryGetValue(strId, out lookup))
                {
                    ++_lastId;
                    nextId = _lastId;
                    _idMap.Add(strId, nextId.Value);
                }
                else
                    nextId = lookup;
            }
            else if (
                IsExpressEntity(input.LocalName, out expressType) && 
                !typeof(IExpressValueType).IsAssignableFrom(expressType.Type)) //its a type with no identity, make one
            {
                ++_lastId;
                nextId = _lastId;
            }

            return nextId;
        }

        private bool IsExpressEntity(string elementName, out ExpressType expressType)
        {
            return _metadata.TryGetExpressType(elementName.ToUpperInvariant(), out expressType);
        }

        private StepFileHeader ReadHeader(XmlReader input)
        {
            var header = new StepFileHeader(StepFileHeader.HeaderCreationMode.LeaveEmpty);
            while (input.Read())
            {
                if (input.NodeType != XmlNodeType.Element)
                    continue;
                switch (input.LocalName.ToLowerInvariant())
                {
                    case "name":
                        header.FileName.Name = input.ReadInnerXml();
                        break;
                    case "time_stamp":
                        header.FileName.TimeStamp = input.ReadInnerXml();
                        break;
                    case "author":
                        header.FileName.AuthorName.Add(input.ReadInnerXml());
                        break;
                    case "organization":
                        header.FileName.Organization.Add(input.ReadInnerXml());
                        break;
                    case "preprocessor_version":
                        header.FileName.PreprocessorVersion = input.ReadInnerXml();
                        break;
                    case "originating_system":
                        header.FileName.OriginatingSystem = input.ReadInnerXml();
                        break;
                    case "authorization":
                        header.FileName.AuthorizationName = input.ReadInnerXml();
                        break;
                    case "documentation":
                        header.FileDescription.Description.Add(input.ReadInnerXml());
                        break;
                }
            }
            return header;
        }

        public static XmlSchemaVersion ReadSchemaVersion(XmlReader input)
        {
            //read the root element
            while (input.Read())
            {
                //read namespace
                while (input.MoveToNextAttribute())
                {
                    if (input.Value == "http://www.iai-tech.org/ifcXML/IFC2x3/FINAL")
                        return XmlSchemaVersion.Ifc2x3;

                    if (input.Value == "http://www.buildingsmart-tech.org/ifcXML/MVD4/IFC")
                        return XmlSchemaVersion.Ifc4Add1;

                    if (input.Value == "http://www.buildingsmart-tech.org/ifcXML/IFC4/final")
                        return XmlSchemaVersion.Ifc4;
                }
            }
            return XmlSchemaVersion.Unknown;
        }
    }

    public enum XmlSchemaVersion
    {
        // ReSharper disable once InconsistentNaming
        Ifc2x3,
        Ifc4Add1,
        Ifc4,
        Unknown
    }
}