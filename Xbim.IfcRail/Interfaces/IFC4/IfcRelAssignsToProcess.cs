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
using Xbim.Common;

// ReSharper disable once CheckNamespace
namespace Xbim.IfcRail.Kernel
{
	public partial class @IfcRelAssignsToProcess : IIfcRelAssignsToProcess
	{

		[CrossSchemaAttribute(typeof(IIfcRelAssignsToProcess), 7)]
		IIfcProcessSelect IIfcRelAssignsToProcess.RelatingProcess 
		{ 
			get
			{
				if (RelatingProcess == null) return null;
				var ifcprocess = RelatingProcess as IfcProcess;
				if (ifcprocess != null) 
					return ifcprocess;
				var ifctypeprocess = RelatingProcess as IfcTypeProcess;
				if (ifctypeprocess != null) 
					return ifctypeprocess;
				return null;
			} 
			set
			{
				if (value == null)
				{
					RelatingProcess = null;
					return;
				}	
				var ifcprocess = value as IfcProcess;
				if (ifcprocess != null) 
				{
					RelatingProcess = ifcprocess;
					return;
				}
				var ifctypeprocess = value as IfcTypeProcess;
				if (ifctypeprocess != null) 
				{
					RelatingProcess = ifctypeprocess;
					return;
				}
				
			}
		}

		[CrossSchemaAttribute(typeof(IIfcRelAssignsToProcess), 8)]
		IIfcMeasureWithUnit IIfcRelAssignsToProcess.QuantityInProcess 
		{ 
			get
			{
				return QuantityInProcess;
			} 
			set
			{
				QuantityInProcess = value as MeasureResource.IfcMeasureWithUnit;
				
			}
		}
	//## Custom code
	//##
	}
}