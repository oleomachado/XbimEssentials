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
namespace Xbim.Ifc2x3.SharedBldgElements
{
	public partial class @IfcWindowLiningProperties : IIfcWindowLiningProperties
	{
		Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcWindowLiningProperties.LiningDepth 
		{ 
			get
			{
				if (!LiningDepth.HasValue) return null;
				return new Ifc4.MeasureResource.IfcPositiveLengthMeasure(LiningDepth.Value);
			} 
		}
		Ifc4.MeasureResource.IfcNonNegativeLengthMeasure? IIfcWindowLiningProperties.LiningThickness 
		{ 
			get
			{
				if (!LiningThickness.HasValue) return null;
				return new Ifc4.MeasureResource.IfcNonNegativeLengthMeasure(LiningThickness.Value);
			} 
		}
		Ifc4.MeasureResource.IfcNonNegativeLengthMeasure? IIfcWindowLiningProperties.TransomThickness 
		{ 
			get
			{
				if (!TransomThickness.HasValue) return null;
				return new Ifc4.MeasureResource.IfcNonNegativeLengthMeasure(TransomThickness.Value);
			} 
		}
		Ifc4.MeasureResource.IfcNonNegativeLengthMeasure? IIfcWindowLiningProperties.MullionThickness 
		{ 
			get
			{
				if (!MullionThickness.HasValue) return null;
				return new Ifc4.MeasureResource.IfcNonNegativeLengthMeasure(MullionThickness.Value);
			} 
		}
		Ifc4.MeasureResource.IfcNormalisedRatioMeasure? IIfcWindowLiningProperties.FirstTransomOffset 
		{ 
			get
			{
				if (!FirstTransomOffset.HasValue) return null;
				return new Ifc4.MeasureResource.IfcNormalisedRatioMeasure(FirstTransomOffset.Value);
			} 
		}
		Ifc4.MeasureResource.IfcNormalisedRatioMeasure? IIfcWindowLiningProperties.SecondTransomOffset 
		{ 
			get
			{
				if (!SecondTransomOffset.HasValue) return null;
				return new Ifc4.MeasureResource.IfcNormalisedRatioMeasure(SecondTransomOffset.Value);
			} 
		}
		Ifc4.MeasureResource.IfcNormalisedRatioMeasure? IIfcWindowLiningProperties.FirstMullionOffset 
		{ 
			get
			{
				if (!FirstMullionOffset.HasValue) return null;
				return new Ifc4.MeasureResource.IfcNormalisedRatioMeasure(FirstMullionOffset.Value);
			} 
		}
		Ifc4.MeasureResource.IfcNormalisedRatioMeasure? IIfcWindowLiningProperties.SecondMullionOffset 
		{ 
			get
			{
				if (!SecondMullionOffset.HasValue) return null;
				return new Ifc4.MeasureResource.IfcNormalisedRatioMeasure(SecondMullionOffset.Value);
			} 
		}
		IIfcShapeAspect IIfcWindowLiningProperties.ShapeAspectStyle 
		{ 
			get
			{
				return ShapeAspectStyle;
			} 
		}
		Ifc4.MeasureResource.IfcLengthMeasure? IIfcWindowLiningProperties.LiningOffset 
		{ 
			get
			{
				//## Handle return of LiningOffset for which no match was found
				//TODO: Handle return of LiningOffset for which no match was found
				throw new System.NotImplementedException();
				//##
			} 
		}
		Ifc4.MeasureResource.IfcLengthMeasure? IIfcWindowLiningProperties.LiningToPanelOffsetX 
		{ 
			get
			{
				//## Handle return of LiningToPanelOffsetX for which no match was found
				//TODO: Handle return of LiningToPanelOffsetX for which no match was found
				throw new System.NotImplementedException();
				//##
			} 
		}
		Ifc4.MeasureResource.IfcLengthMeasure? IIfcWindowLiningProperties.LiningToPanelOffsetY 
		{ 
			get
			{
				//## Handle return of LiningToPanelOffsetY for which no match was found
				//TODO: Handle return of LiningToPanelOffsetY for which no match was found
				throw new System.NotImplementedException();
				//##
			} 
		}

	//## Custom code
	//##
	}
}