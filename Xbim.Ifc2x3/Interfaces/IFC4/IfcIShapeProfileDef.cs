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
namespace Xbim.Ifc2x3.ProfileResource
{
	public partial class @IfcIShapeProfileDef : IIfcIShapeProfileDef
	{
		Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcIShapeProfileDef.OverallWidth 
		{ 
			get
			{
				return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure((double)OverallWidth);
			} 
		}
		Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcIShapeProfileDef.OverallDepth 
		{ 
			get
			{
				return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure((double)OverallDepth);
			} 
		}
		Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcIShapeProfileDef.WebThickness 
		{ 
			get
			{
				return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure((double)WebThickness);
			} 
		}
		Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcIShapeProfileDef.FlangeThickness 
		{ 
			get
			{
				return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure((double)FlangeThickness);
			} 
		}
		Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure? IIfcIShapeProfileDef.FilletRadius 
		{ 
			get
			{
				if (FilletRadius == null) return null;
				return new Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure((double)FilletRadius);
			} 
		}
		Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure? IIfcIShapeProfileDef.FlangeEdgeRadius 
		{ 
			get
			{
				throw new System.NotImplementedException();
			} 
		}
		Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure? IIfcIShapeProfileDef.FlangeSlope 
		{ 
			get
			{
				throw new System.NotImplementedException();
			} 
		}
	}
}