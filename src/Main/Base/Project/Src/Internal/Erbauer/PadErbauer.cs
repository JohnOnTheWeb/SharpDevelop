﻿// <file>
//     <copyright see="prj:///doc/copyright.txt">2002-2005 AlphaSierraPapa</copyright>
//     <license see="prj:///doc/license.txt">GNU General Public License</license>
//     <owner name="Mike Krüger" email="mike@icsharpcode.net"/>
//     <version>$Revision$</version>
// </file>

using System;
using System.Collections;
using System.Reflection;
using ICSharpCode.SharpDevelop.Gui;

namespace ICSharpCode.Core
{
	public class PadErbauer : IErbauer
	{
		public object BuildItem(object caller, Codon codon, ArrayList subItems)
		{
			return new PadDescriptor(codon);
		}
	}
}
