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
namespace Xbim.Ifc2x3.StructuralAnalysisDomain
{
	public partial class @IfcStructuralAnalysisModel : IIfcStructuralAnalysisModel
	{
		Xbim.Ifc4.StructuralAnalysisDomain.IfcAnalysisModelTypeEnum IIfcStructuralAnalysisModel.PredefinedType 
		{ 
			get
			{
				throw new System.NotImplementedException();
			} 
		}
		IIfcAxis2Placement3D IIfcStructuralAnalysisModel.OrientationOf2DPlane 
		{ 
			get
			{
				return OrientationOf2DPlane as IIfcAxis2Placement3D;
			} 
		}
		IEnumerable<IIfcStructuralLoadGroup> IIfcStructuralAnalysisModel.LoadedBy 
		{ 
			get
			{
				throw new System.NotImplementedException();
			} 
		}
		IEnumerable<IIfcStructuralResultGroup> IIfcStructuralAnalysisModel.HasResults 
		{ 
			get
			{
				throw new System.NotImplementedException();
			} 
		}
		IIfcObjectPlacement IIfcStructuralAnalysisModel.SharedPlacement 
		{ 
			get
			{
				throw new System.NotImplementedException();
			} 
		}
	}
}