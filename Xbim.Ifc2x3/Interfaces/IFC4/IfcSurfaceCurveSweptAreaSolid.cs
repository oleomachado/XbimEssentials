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
namespace Xbim.Ifc2x3.GeometricModelResource
{
	public partial class @IfcSurfaceCurveSweptAreaSolid : IIfcSurfaceCurveSweptAreaSolid
	{
		IIfcCurve IIfcSurfaceCurveSweptAreaSolid.Directrix 
		{ 
			get
			{
				return Directrix as IIfcCurve;
			} 
		}
		Xbim.Ifc4.MeasureResource.IfcParameterValue? IIfcSurfaceCurveSweptAreaSolid.StartParam 
		{ 
			get
			{
				return new Xbim.Ifc4.MeasureResource.IfcParameterValue((double)StartParam);
			} 
		}
		Xbim.Ifc4.MeasureResource.IfcParameterValue? IIfcSurfaceCurveSweptAreaSolid.EndParam 
		{ 
			get
			{
				return new Xbim.Ifc4.MeasureResource.IfcParameterValue((double)EndParam);
			} 
		}
		IIfcSurface IIfcSurfaceCurveSweptAreaSolid.ReferenceSurface 
		{ 
			get
			{
				return ReferenceSurface as IIfcSurface;
			} 
		}
	}
}