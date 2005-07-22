﻿// <file>
//     <copyright see="prj:///doc/copyright.txt">2002-2005 AlphaSierraPapa</copyright>
//     <license see="prj:///doc/license.txt">GNU General Public License</license>
//     <owner name="David Srbecký" email="dsrbecky@post.cz"/>
//     <version>$Revision$</version>
// </file>

using System;
using System.Collections.Generic;
using System.Text;

namespace DebuggerLibrary
{
	struct MethodProps
	{
		public uint Token;
		public string Name;
		public uint ClassToken;
		public uint Flags;
		public uint ImplFlags;
		public uint CodeRVA;
		public SignatureStream Signature;

		public bool IsStatic {
			get {
				return (Flags & (uint)CorMethodAttr.mdStatic) != 0;
			}
		}

		public bool HasSpecialName {
			get {
				return (Flags & (uint)CorMethodAttr.mdSpecialName) != 0;
			}
		}
	}
}
