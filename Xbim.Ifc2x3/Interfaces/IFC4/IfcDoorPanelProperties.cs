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
	public partial class @IfcDoorPanelProperties : IIfcDoorPanelProperties
	{
		Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcDoorPanelProperties.PanelDepth 
		{ 
			get
			{
				if (PanelDepth == null) return null;
				return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure((double)PanelDepth);
			} 
		}
		Xbim.Ifc4.ArchitectureDomain.IfcDoorPanelOperationEnum IIfcDoorPanelProperties.PanelOperation 
		{ 
			get
			{
				throw new System.NotImplementedException();
			} 
		}
		Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure? IIfcDoorPanelProperties.PanelWidth 
		{ 
			get
			{
				if (PanelWidth == null) return null;
				return new Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure((double)PanelWidth);
			} 
		}
		Xbim.Ifc4.ArchitectureDomain.IfcDoorPanelPositionEnum IIfcDoorPanelProperties.PanelPosition 
		{ 
			get
			{
				throw new System.NotImplementedException();
			} 
		}
		IIfcShapeAspect IIfcDoorPanelProperties.ShapeAspectStyle 
		{ 
			get
			{
				return ShapeAspectStyle as IIfcShapeAspect;
			} 
		}
	}
}