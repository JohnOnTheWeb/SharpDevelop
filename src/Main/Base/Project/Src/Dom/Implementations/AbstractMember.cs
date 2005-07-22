// <file>
//     <copyright see="prj:///doc/copyright.txt">2002-2005 AlphaSierraPapa</copyright>
//     <license see="prj:///doc/license.txt">GNU General Public License</license>
//     <owner name="Daniel Grunwald" email="daniel@danielgrunwald.de"/>
//     <version>$Revision$</version>
// </file>

using System;

namespace ICSharpCode.SharpDevelop.Dom
{
	[Serializable]
	public abstract class AbstractMember : AbstractNamedEntity, IMember
	{
		IReturnType returnType;
		IRegion     region;
		
		public virtual IRegion Region {
			get {
				return region;
			}
			set {
				region = value;
			}
		}
		
		public virtual IReturnType ReturnType {
			get {
				return returnType;
			}
			set {
				returnType = value;
			}
		}
		
		public AbstractMember(IClass declaringType, string name) : base(declaringType, name)
		{
		}
		
		public abstract IMember Clone();
		
		object ICloneable.Clone()
		{
			return this.Clone();
		}
	}
}
