// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool Xbim.CodeGeneration 
//  
//     Changes to this file may cause incorrect behaviour and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using Xbim.Ifc4.Interfaces;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Xbim.Ifc2x3.MaterialPropertyResource
{
	public partial class @IfcThermalMaterialProperties : IIfcMaterialProperties
	{
		IIfcMaterialDefinition IIfcMaterialProperties.Material 
		{ 
			get
			{
				throw new System.NotImplementedException();
			} 
		}
		Xbim.Ifc4.MeasureResource.IfcIdentifier? IIfcExtendedProperties.Name 
		{ 
			get
			{
				throw new System.NotImplementedException();
			} 
		}
		Xbim.Ifc4.MeasureResource.IfcText? IIfcExtendedProperties.Description 
		{ 
			get
			{
				throw new System.NotImplementedException();
			} 
		}
		IEnumerable<IIfcProperty> IIfcExtendedProperties.Properties 
		{ 
			get
			{
				throw new System.NotImplementedException();
			} 
		}
		IEnumerable<IIfcExternalReferenceRelationship> IIfcPropertyAbstraction.HasExternalReferences 
		{ 
			get
			{
				return Model.Instances.Where<IIfcExternalReferenceRelationship>(e => e.RelatedResourceObjects != null &&  e.RelatedResourceObjects.Contains(this));
			} 
		}
	}
}