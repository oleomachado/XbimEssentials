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
	public partial class @IfcWindow : IIfcWindow
	{
		Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcWindow.OverallHeight 
		{ 
			get
			{
				if (OverallHeight == null) return null;
				return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure((double)OverallHeight);
			} 
		}
		Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcWindow.OverallWidth 
		{ 
			get
			{
				if (OverallWidth == null) return null;
				return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure((double)OverallWidth);
			} 
		}
		Xbim.Ifc4.SharedBldgElements.IfcWindowTypeEnum? IIfcWindow.PredefinedType 
		{ 
			get
			{
				throw new System.NotImplementedException();
			} 
		}
		Xbim.Ifc4.SharedBldgElements.IfcWindowTypePartitioningEnum? IIfcWindow.PartitioningType 
		{ 
			get
			{
				throw new System.NotImplementedException();
			} 
		}
		Xbim.Ifc4.MeasureResource.IfcLabel? IIfcWindow.UserDefinedPartitioningType 
		{ 
			get
			{
				throw new System.NotImplementedException();
			} 
		}
	}
}