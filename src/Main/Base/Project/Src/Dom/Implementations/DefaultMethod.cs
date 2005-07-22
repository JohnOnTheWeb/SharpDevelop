﻿// <file>
//     <copyright see="prj:///doc/copyright.txt">2002-2005 AlphaSierraPapa</copyright>
//     <license see="prj:///doc/license.txt">GNU General Public License</license>
//     <owner name="Mike Krüger" email="mike@icsharpcode.net"/>
//     <version>$Revision$</version>
// </file>

using System;
using System.Text;
using System.Reflection;
using System.Collections.Generic;

namespace ICSharpCode.SharpDevelop.Dom
{
	[Serializable]
	public class Constructor : DefaultMethod
	{
		public Constructor(ModifierEnum m, IRegion region, IRegion bodyRegion, IClass declaringType)
			: base("#ctor", declaringType.DefaultReturnType,
			       m, region, bodyRegion, declaringType)
		{
		}
		
		public Constructor(ModifierEnum m, IReturnType returnType)
			: base("#ctor", returnType, m, null, null, null)
		{
		}
		
		/// <summary>
		/// Creates a default constructor for the class.
		/// The constructor has the region of the class and a documentation comment saying
		/// it is a default constructor.
		/// </summary>
		public static Constructor CreateDefault(IClass c)
		{
			Constructor con = new Constructor(ModifierEnum.Public, c.Region, c.Region, c);
			con.Documentation = "Default constructor of " + c.Name;
			return con;
		}
	}
	
	[Serializable]
	public class Destructor : DefaultMethod
	{
		public Destructor(IRegion region, IRegion bodyRegion, IClass declaringType)
			: base("#dtor", null, ModifierEnum.None, region, bodyRegion, declaringType)
		{
		}
	}
	
	[Serializable]
	public class DefaultMethod : AbstractMember, IMethod
	{
		protected IRegion bodyRegion;
		
		List<IParameter> parameters = null;
		List<ITypeParameter> typeParameters = null;
		
		public override IMember Clone()
		{
			DefaultMethod p = new DefaultMethod(Name, ReturnType, Modifiers, Region, BodyRegion, DeclaringType);
			p.parameters = DefaultParameter.Clone(this.Parameters);
			p.typeParameters = this.typeParameters;
			p.documentationTag = DocumentationTag;
			return p;
		}
		
		public override string DotNetName {
			get {
				if (typeParameters == null || typeParameters.Count == 0)
					return base.DotNetName;
				else
					return base.DotNetName + "``" + typeParameters.Count;
			}
		}
		
		string documentationTag;
		
		public override string DocumentationTag {
			get {
				if (documentationTag == null) {
					string dotnetName = this.DotNetName;
					StringBuilder b = new StringBuilder("M:", dotnetName.Length + 2);
					b.Append(dotnetName);
					List<IParameter> paras = this.Parameters;
					if (paras.Count > 0) {
						b.Append('(');
						for (int i = 0; i < paras.Count; ++i) {
							if (i > 0) b.Append(',');
							IReturnType rt = paras[i].ReturnType;
							if (rt != null) {
								b.Append(rt.DotNetName);
							}
						}
						b.Append(')');
					}
					documentationTag = b.ToString();
				}
				return documentationTag;
			}
		}
		
		public virtual IRegion BodyRegion {
			get {
				return bodyRegion;
			}
		}
		
		public virtual List<ITypeParameter> TypeParameters {
			get {
				if (typeParameters == null) {
					typeParameters = new List<ITypeParameter>();
				}
				return typeParameters;
			}
		}
		
		public virtual List<IParameter> Parameters {
			get {
				if (parameters == null) {
					parameters = new List<IParameter>();
				}
				return parameters;
			}
			set {
				parameters = value;
			}
		}
		
		public virtual bool IsConstructor {
			get {
				return ReturnType == null || Name == "#ctor";
			}
		}
		
		public DefaultMethod(IClass declaringType, string name) : base(declaringType, name)
		{
		}
		
		public DefaultMethod(string name, IReturnType type, ModifierEnum m, IRegion region, IRegion bodyRegion, IClass declaringType) : base(declaringType, name)
		{
			this.ReturnType = type;
			this.Region     = region;
			this.bodyRegion = bodyRegion;
			Modifiers = m;
		}
		
		public override string ToString()
		{
			return String.Format("[AbstractMethod: FullyQualifiedName={0}, ReturnType = {1}, IsConstructor={2}, Modifier={3}]",
			                     FullyQualifiedName,
			                     ReturnType,
			                     IsConstructor,
			                     base.Modifiers);
		}
		
		public virtual int CompareTo(IMethod value)
		{
			int cmp;
			
			cmp = base.CompareTo((IDecoration)value);
			
			if (cmp != 0) {
				return cmp;
			}
			
			if (FullyQualifiedName != null) {
				cmp = FullyQualifiedName.CompareTo(value.FullyQualifiedName);
				if (cmp != 0) {
					return cmp;
				}
			}
			
			cmp = this.TypeParameters.Count - value.TypeParameters.Count;
			if (cmp != 0) {
				return cmp;
			}
			
			return DiffUtility.Compare(Parameters, value.Parameters);
		}
		
		int IComparable.CompareTo(object value)
		{
			if (value == null) {
				return 0;
			}
			return CompareTo((IMethod)value);
		}
	}
}
