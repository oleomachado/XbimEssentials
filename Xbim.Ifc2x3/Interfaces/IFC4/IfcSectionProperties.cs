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
namespace Xbim.Ifc2x3.ProfilePropertyResource
{
	public partial class @IfcSectionProperties : IIfcSectionProperties
	{
		Xbim.Ifc4.ProfileResource.IfcSectionTypeEnum IIfcSectionProperties.SectionType 
		{ 
			get
			{
				throw new System.NotImplementedException();
			} 
		}
		IIfcProfileDef IIfcSectionProperties.StartProfile 
		{ 
			get
			{
				return StartProfile as IIfcProfileDef;
			} 
		}
		IIfcProfileDef IIfcSectionProperties.EndProfile 
		{ 
			get
			{
				return EndProfile as IIfcProfileDef;
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