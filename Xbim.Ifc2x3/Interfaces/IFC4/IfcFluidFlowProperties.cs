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
namespace Xbim.Ifc2x3.SharedBldgServiceElements
{
	public partial class @IfcFluidFlowProperties : IIfcPropertySetDefinition
	{
		IEnumerable<IIfcTypeObject> IIfcPropertySetDefinition.DefinesType 
		{ 
			get
			{
				return Model.Instances.Where<IIfcTypeObject>(e => e.HasPropertySets != null &&  e.HasPropertySets.Contains(this));
			} 
		}
		IEnumerable<IIfcRelDefinesByTemplate> IIfcPropertySetDefinition.IsDefinedBy 
		{ 
			get
			{
				return Model.Instances.Where<IIfcRelDefinesByTemplate>(e => e.RelatedPropertySets != null &&  e.RelatedPropertySets.Contains(this));
			} 
		}
		IEnumerable<IIfcRelDefinesByProperties> IIfcPropertySetDefinition.DefinesOccurrence 
		{ 
			get
			{
				return Model.Instances.Where<IIfcRelDefinesByProperties>(e => (e.RelatingPropertyDefinition as IfcFluidFlowProperties) == this);
			} 
		}
	}
}