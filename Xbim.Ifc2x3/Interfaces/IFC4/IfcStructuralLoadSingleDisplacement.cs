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
	public partial class @IfcStructuralLoadSingleDisplacement : IIfcStructuralLoadSingleDisplacement
	{
		Xbim.Ifc4.MeasureResource.IfcLengthMeasure? IIfcStructuralLoadSingleDisplacement.DisplacementX 
		{ 
			get
			{
				if (DisplacementX == null) return null;
				return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure((double)DisplacementX);
			} 
		}
		Xbim.Ifc4.MeasureResource.IfcLengthMeasure? IIfcStructuralLoadSingleDisplacement.DisplacementY 
		{ 
			get
			{
				if (DisplacementY == null) return null;
				return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure((double)DisplacementY);
			} 
		}
		Xbim.Ifc4.MeasureResource.IfcLengthMeasure? IIfcStructuralLoadSingleDisplacement.DisplacementZ 
		{ 
			get
			{
				if (DisplacementZ == null) return null;
				return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure((double)DisplacementZ);
			} 
		}
		Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure? IIfcStructuralLoadSingleDisplacement.RotationalDisplacementRX 
		{ 
			get
			{
				if (RotationalDisplacementRX == null) return null;
				return new Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure((double)RotationalDisplacementRX);
			} 
		}
		Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure? IIfcStructuralLoadSingleDisplacement.RotationalDisplacementRY 
		{ 
			get
			{
				if (RotationalDisplacementRY == null) return null;
				return new Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure((double)RotationalDisplacementRY);
			} 
		}
		Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure? IIfcStructuralLoadSingleDisplacement.RotationalDisplacementRZ 
		{ 
			get
			{
				if (RotationalDisplacementRZ == null) return null;
				return new Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure((double)RotationalDisplacementRZ);
			} 
		}
	}
}