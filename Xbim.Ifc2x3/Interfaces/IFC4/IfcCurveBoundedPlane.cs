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
	public partial class @IfcCurveBoundedPlane : IIfcCurveBoundedPlane
	{
		IIfcPlane IIfcCurveBoundedPlane.BasisSurface 
		{ 
			get
			{
				return BasisSurface as IIfcPlane;
			} 
		}
		IIfcCurve IIfcCurveBoundedPlane.OuterBoundary 
		{ 
			get
			{
				return OuterBoundary as IIfcCurve;
			} 
		}
		IEnumerable<IIfcCurve> IIfcCurveBoundedPlane.InnerBoundaries 
		{ 
			get
			{
				throw new System.NotImplementedException();
			} 
		}
	}
}