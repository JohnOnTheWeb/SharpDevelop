﻿/*
 * Created by SharpDevelop.
 * User: Peter Forstmeier
 * Date: 17.03.2013
 * Time: 17:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using ICSharpCode.Reporting.Globals;

namespace ICSharpCode.Reporting.Items
{
	/// <summary>
	/// Description of ReportSettings.
	/// </summary>
	public class ReportSettings
	{
		
		
		public ReportSettings()
		{
			this.pageSize = Globals.GlobalValues.DefaultPageSize;
			BaseValues();
		}
		
		
		void BaseValues()
		{
			
//			this.UseStandardPrinter = true;
//			this.GraphicsUnit = GraphicsUnit.Pixel;
//			this.Padding = new Padding(5);
//			this.DefaultFont = GlobalValues.DefaultFont;
//			this.ReportType = GlobalEnums.ReportType.FormSheet;
//			
			this.DataModel = GlobalEnums.PushPullModel.FormSheet;
//			
//			this.CommandType =  System.Data.CommandType.Text;
//			this.ConnectionString = String.Empty;
//			this.CommandText = String.Empty;
//			
//			this.TopMargin = GlobalValues.DefaultPageMargin.Left;
//			this.BottomMargin = GlobalValues.DefaultPageMargin.Bottom;
//			this.LeftMargin = GlobalValues.DefaultPageMargin.Left;
//			this.RightMargin = GlobalValues.DefaultPageMargin.Right;
//			
//			this.availableFields = new AvailableFieldsCollection();
//			this.groupingsCollection = new GroupColumnCollection();
//			this.sortingCollection = new SortColumnCollection();
//			this.sqlParameters = new SqlParameterCollection();
//			this.parameterCollection = new ParameterCollection();
//			this.NoDataMessage = "No Data for this Report";
		}
		
		
		private string reportName;
		
//		[Category("Base Settings")]
//		[DefaultValueAttribute ("")]
		public string ReportName
		{
			get {
				if (string.IsNullOrEmpty(reportName)) {
					reportName = Globals.GlobalValues.DefaultReportName;
				}
				return reportName;
			}
			set {
				if (reportName != value) {
					reportName = value;
				}
			}
		}
		
		private Size pageSize;
		
		public Size PageSize {
			get {
				if (!Landscape) {
					return pageSize;
				} else {
					return new Size(pageSize.Height,pageSize.Width);
				}
				 }
			set { pageSize = value; }
		}
		
//		[Category("Page Settings")]
//		public Size PageSize {get;set;}
		
//		[Category("Page Settings")]
		public bool Landscape {get;set;}
		
//		[Category("Data")]
		public GlobalEnums.PushPullModel DataModel {get;set;}
	}
}
