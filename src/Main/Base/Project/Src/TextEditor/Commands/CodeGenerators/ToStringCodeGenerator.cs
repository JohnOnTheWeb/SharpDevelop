﻿// <file>
//     <copyright see="prj:///doc/copyright.txt">2002-2005 AlphaSierraPapa</copyright>
//     <license see="prj:///doc/license.txt">GNU General Public License</license>
//     <owner name="Mike Krüger" email="mike@icsharpcode.net"/>
//     <version>$Revision$</version>
// </file>

using System;
using System.Collections;
using ICSharpCode.TextEditor;

using ICSharpCode.SharpDevelop.Dom;
using ICSharpCode.Core;

namespace ICSharpCode.SharpDevelop.DefaultEditor.Commands
{
	public class ToStringCodeGenerator : AbstractFieldCodeGenerator
	{
		public override string CategoryName {
			get {
				return "Generate default ToString() method";
			}
		}
		
		public override  string Hint {
			get {
				return "Choose Properties to include in the description";
			}
		}
		public override int ImageIndex {
			get {
				
				return ClassBrowserIconService.MethodIndex;
			}
		}
		
		public ToStringCodeGenerator(IClass currentClass) : base(currentClass)
		{
		}
		
		protected override void StartGeneration(IList items, string fileExtension)
		{
			if (fileExtension == ".vb") {
				editActionHandler.InsertString("Public Overrides Function ToString() As String");
				Return();
			} else {
				editActionHandler.InsertString("public override string ToString()");
			}
			++numOps;
			
			if (fileExtension != ".vb") {
				if (StartCodeBlockInSameLine) {
					editActionHandler.InsertString(" {");++numOps;
				} else {
					Return();
					editActionHandler.InsertString("{");++numOps;
				}
			}
			Return();
			Indent();
			if (fileExtension == ".vb") {
				editActionHandler.InsertString("Return String.Format(\"[");
			} else {
				editActionHandler.InsertString("return String.Format(\"[");
			}
			++numOps;
			editActionHandler.InsertString(base.currentClass.Name);++numOps;
			if (items.Count > 0) {
				editActionHandler.InsertString(":");++numOps;
			}
			for (int i = 0; i < items.Count; ++i) {
				FieldWrapper fieldWrapper = (FieldWrapper)items[i];
				editActionHandler.InsertString(" ");++numOps;
				editActionHandler.InsertString(fieldWrapper.Field.Name);++numOps;
				editActionHandler.InsertString(" = {" + i + "}");++numOps;
				if (i + 1 < items.Count) {
					editActionHandler.InsertString(",");++numOps;
				}
			}
			editActionHandler.InsertString("]\"");++numOps;
			if (items.Count > 0) {
				editActionHandler.InsertString(",");++numOps;
				Return();
			}
			for (int i = 0; i < items.Count; ++i) {
				FieldWrapper fieldWrapper = (FieldWrapper)items[i];
				editActionHandler.InsertString(fieldWrapper.Field.Name);
				if (i + 1 < items.Count) {
					editActionHandler.InsertString(",");++numOps;
					Return();
				}
			}
			if (fileExtension == ".vb") {
				editActionHandler.InsertString(")");
			} else {
				editActionHandler.InsertString(");");
			}
			++numOps;
			Return();
			if (fileExtension == ".vb") {
				editActionHandler.InsertString("End Function");
			} else {
				editActionHandler.InsertString("}");
			}
			++numOps;
			Return();
		}
	}
}
