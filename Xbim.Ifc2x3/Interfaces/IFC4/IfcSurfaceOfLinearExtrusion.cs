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
namespace Xbim.Ifc2x3.GeometryResource
{
	public partial class @IfcSurfaceOfLinearExtrusion : IIfcSurfaceOfLinearExtrusion
	{
		IIfcDirection IIfcSurfaceOfLinearExtrusion.ExtrudedDirection 
		{ 
			get
			{
				return ExtrudedDirection as IIfcDirection;
			} 
		}
		Xbim.Ifc4.MeasureResource.IfcLengthMeasure IIfcSurfaceOfLinearExtrusion.Depth 
		{ 
			get
			{
				return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure((double)Depth);
			} 
		}
	}
}