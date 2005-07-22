﻿// <file>
//     <copyright see="prj:///doc/copyright.txt">2002-2005 AlphaSierraPapa</copyright>
//     <license see="prj:///doc/license.txt">GNU General Public License</license>
//     <owner name="Mike Krüger" email="mike@icsharpcode.net"/>
//     <version>$Revision$</version>
// </file>

namespace ICSharpCode.SharpDevelop.Gui
{
	/// <summary>
	/// This is a basic interface to a "progress bar" type of
	/// control.
	/// </summary>
	public interface IProgressMonitor
	{
		void BeginTask(string name, int totalWork);
		
		int WorkDone {
			get;
			set;
		}
		
		void Done();
		
		string TaskName {
			get;
			set;
		}
	}
}
