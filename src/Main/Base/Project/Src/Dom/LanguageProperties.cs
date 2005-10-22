﻿// <file>
//     <copyright see="prj:///doc/copyright.txt">2002-2005 AlphaSierraPapa</copyright>
//     <license see="prj:///doc/license.txt">GNU General Public License</license>
//     <owner name="Daniel Grunwald" email="daniel@danielgrunwald.de"/>
//     <version>$Revision$</version>
// </file>

using System;
using ICSharpCode.SharpDevelop.Refactoring;

namespace ICSharpCode.SharpDevelop.Dom
{
	public class LanguageProperties
	{
		public readonly static LanguageProperties CSharp = new LanguageProperties(StringComparer.InvariantCulture, CSharpCodeGenerator.Instance);
		public readonly static LanguageProperties VBNet = new VBNetProperties();
		
		StringComparer nameComparer;
		
		public LanguageProperties(StringComparer nameComparer, CodeGenerator codeGenerator)
		{
			this.nameComparer = nameComparer;
			this.codeGenerator = codeGenerator;
		}
		
		public StringComparer NameComparer {
			get {
				return nameComparer;
			}
		}
		
		CodeGenerator codeGenerator;
		
		public CodeGenerator CodeGenerator {
			get {
				return codeGenerator;
			}
		}
		
		/// <summary>
		/// Gets if namespaces can be imported (i.e. Imports System, Dim a As Collections.ArrayList)
		/// </summary>
		public virtual bool ImportNamespaces {
			get {
				return false;
			}
		}
		
		/// <summary>
		/// Gets if modules are imported with their namespace (i.e. Microsoft.VisualBasic.Randomize()).
		/// </summary>
		public virtual bool ImportModules {
			get {
				return false;
			}
		}
		
		/// <summary>
		/// Gets if classes can be imported (i.e. Imports System.Math)
		/// </summary>
		public virtual bool CanImportClasses {
			get {
				return false;
			}
		}
		
		/// <summary>
		/// Allow invoking an object constructor outside of ExpressionContext.ObjectCreation.
		/// Used for Boo, which creates instances like this: 'self.Size = Size(10, 20)'
		/// </summary>
		public virtual bool AllowObjectConstructionOutsideContext {
			get {
				return false;
			}
		}
		
		public virtual bool ShowInNamespaceCompletion(IClass c)
		{
			return true;
		}
		
		public virtual bool ShowMember(IMember member, bool showStatic)
		{
			if (member is IProperty && ((IProperty)member).IsIndexer) {
				return false;
			}
			return member.IsStatic == showStatic;
		}
		
		public override string ToString()
		{
			if (GetType() == typeof(LanguageProperties) && nameComparer == StringComparer.InvariantCulture)
				return "[LanguageProperties: C#]";
			else
				return "[" + base.ToString() + "]";
		}
		
		private class VBNetProperties : LanguageProperties
		{
			public VBNetProperties() : base(StringComparer.InvariantCultureIgnoreCase, VBNetCodeGenerator.Instance) {}
			
			public override bool ShowMember(IMember member, bool showStatic)
			{
				if (member is ArrayReturnType.ArrayIndexer) {
					return false;
				}
				return member.IsStatic || !showStatic;
			}
			
			public override bool ImportNamespaces {
				get {
					return true;
				}
			}
			
			public override bool ImportModules {
				get {
					return true;
				}
			}
			
			public override bool CanImportClasses {
				get {
					return true;
				}
			}
			
			public override bool ShowInNamespaceCompletion(IClass c)
			{
				foreach (IAttribute attr in c.Attributes) {
					if (NameComparer.Equals(attr.Name, "Microsoft.VisualBasic.HideModuleNameAttribute"))
						return false;
					if (NameComparer.Equals(attr.Name, "HideModuleNameAttribute"))
						return false;
					if (NameComparer.Equals(attr.Name, "Microsoft.VisualBasic.HideModuleName"))
						return false;
					if (NameComparer.Equals(attr.Name, "HideModuleName"))
						return false;
				}
				return base.ShowInNamespaceCompletion(c);
			}
			
			public override string ToString()
			{
				return "[LanguageProperties: VB.NET]";
			}
		}
	}
}
