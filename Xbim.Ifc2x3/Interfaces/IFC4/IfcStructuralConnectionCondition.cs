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
namespace Xbim.Ifc2x3.StructuralLoadResource
{
	public partial class @IfcStructuralConnectionCondition : IIfcStructuralConnectionCondition
	{
		Xbim.Ifc4.MeasureResource.IfcLabel? IIfcStructuralConnectionCondition.Name 
		{ 
			get
			{
				if (Name == null) return null;
				return new Xbim.Ifc4.MeasureResource.IfcLabel((string)Name);
			} 
		}
	}
}