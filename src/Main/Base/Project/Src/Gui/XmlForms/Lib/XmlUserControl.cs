﻿// <file>
//     <copyright see="prj:///doc/copyright.txt">2002-2005 AlphaSierraPapa</copyright>
//     <license see="prj:///doc/license.txt">GNU General Public License</license>
//     <owner name="Mike Krüger" email="mike@icsharpcode.net"/>
//     <version>$Revision$</version>
// </file>

using System;
using System.IO;

using System.Xml;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using ICSharpCode.Core;

namespace ICSharpCode.SharpDevelop.Gui.XmlForms 
{
	/// <summary>
	/// The basic xml generated user control.
	/// </summary>
	public abstract class XmlUserControl : UserControl
	{
		protected XmlLoader xmlLoader;
		
		/// <summary>
		/// Gets the ControlDictionary for this user control.
		/// </summary>
		public Dictionary<string, Control> ControlDictionary {
			get {
				return xmlLoader.ControlDictionary;
			}
		}
		
		public XmlUserControl()
		{
		}
		
//		/// <summary>
//		/// Creates a new instance
//		/// </summary>
//		/// <param name="fileName">
//		/// Name of the xml file which defines this user control.
//		/// </param>
//		public XmlUserControl(string fileName)
//		{
//			SetupFromXml(fileName);
//		}
		
		
		public T Get<T>(string name) where T: System.Windows.Forms.Control
		{
			return xmlLoader.Get<T>(name);
		}
//		
//		protected void SetupFromXml(string fileName)
//		{
//			if (fileName == null) {
//				throw new System.ArgumentNullException("fileName");
//			}
//			
//			using (Stream stream = File.OpenRead(fileName)) {
//				SetupFromXmlStream(stream);
//			}
//		}
		
		protected void SetupFromXmlStream(Stream stream)
		{
			if (stream == null) {
				throw new System.ArgumentNullException("stream");
			}
			
			SuspendLayout();
			xmlLoader = new XmlLoader();
			SetupXmlLoader();
			if (stream != null) {
				xmlLoader.LoadObjectFromStream(this, stream);
			}
			RightToLeftConverter.Convert(this);
			ResumeLayout(false);
		}
		
		protected virtual void SetupXmlLoader()
		{
		}
	}
}
