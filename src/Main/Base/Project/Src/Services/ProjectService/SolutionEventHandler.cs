﻿// <file>
//     <copyright see="prj:///doc/copyright.txt">2002-2005 AlphaSierraPapa</copyright>
//     <license see="prj:///doc/license.txt">GNU General Public License</license>
//     <owner name="Mike Krüger" email="mike@icsharpcode.net"/>
//     <version>$Revision$</version>
// </file>

using System;

namespace ICSharpCode.SharpDevelop.Project
{
	public delegate void SolutionEventHandler(object sender, SolutionEventArgs e);
	
	public class SolutionEventArgs : EventArgs
	{
		Solution solution;
		
		public Solution Solution {
			get {
				return solution;
			}
		}
		
		public SolutionEventArgs(Solution solution)
		{
			this.solution = solution;
		}
	}
}
