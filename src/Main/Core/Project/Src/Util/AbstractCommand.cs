﻿// <file>
//     <copyright see="prj:///doc/copyright.txt">2002-2005 AlphaSierraPapa</copyright>
//     <license see="prj:///doc/license.txt">GNU General Public License</license>
//     <owner name="Mike Krüger" email="mike@icsharpcode.net"/>
//     <version>$Revision$</version>
// </file>

using System;
using System.Collections;
using System.CodeDom.Compiler;
using System.Windows.Forms;

namespace ICSharpCode.Core
{
	/// <summary>
	/// Abstract implementation of the <see cref="ICommand"/> interface.
	/// </summary>
	public abstract class AbstractCommand : ICommand
	{
		object owner = null;
		
		/// <summary>
		/// Returns the owner of the command.
		/// </summary>
		public virtual object Owner {
			get {
				return owner;
			}
			set {
				owner = value;
				OnOwnerChanged(EventArgs.Empty);
			}
		}
		
		/// <summary>
		/// Invokes the command.
		/// </summary>
		public abstract void Run();
		
		
		protected virtual void OnOwnerChanged(EventArgs e) 
		{
			if (OwnerChanged != null) {
				OwnerChanged(this, e);
			}
		}
		
		public event EventHandler OwnerChanged;
	}
}
