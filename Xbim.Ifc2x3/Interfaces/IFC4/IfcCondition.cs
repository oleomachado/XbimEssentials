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
namespace Xbim.Ifc2x3.FacilitiesMgmtDomain
{
	public partial class @IfcCondition : IIfcGroup
	{
		IEnumerable<IIfcRelAssignsToGroup> IIfcGroup.IsGroupedBy 
		{ 
			get
			{
				return Model.Instances.Where<IIfcRelAssignsToGroup>(e => (e.RelatingGroup as IfcCondition) == this);
			} 
		}
	}
}