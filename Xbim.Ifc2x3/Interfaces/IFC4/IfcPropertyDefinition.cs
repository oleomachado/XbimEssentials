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
namespace Xbim.Ifc2x3.Kernel
{
	public partial class @IfcPropertyDefinition : IIfcPropertyDefinition
	{
		IEnumerable<IIfcRelDeclares> IIfcPropertyDefinition.HasContext 
		{ 
			get
			{
				return Model.Instances.Where<IIfcRelDeclares>(e => e.RelatedDefinitions != null &&  e.RelatedDefinitions.Contains(this));
			} 
		}
		IEnumerable<IIfcRelAssociates> IIfcPropertyDefinition.HasAssociations 
		{ 
			get
			{
				return Model.Instances.Where<IIfcRelAssociates>(e => e.RelatedObjects != null &&  e.RelatedObjects.Contains(this));
			} 
		}
	}
}