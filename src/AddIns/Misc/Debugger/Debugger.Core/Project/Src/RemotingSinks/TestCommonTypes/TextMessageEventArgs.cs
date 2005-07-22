﻿// <file>
//     <copyright see="prj:///doc/copyright.txt">2002-2005 AlphaSierraPapa</copyright>
//     <license see="prj:///doc/license.txt">GNU General Public License</license>
//     <owner name="David Srbecký" email="dsrbecky@post.cz"/>
//     <version>$Revision$</version>
// </file>

using System;
using System.Collections.Generic;
using System.Text;

namespace CustomSinks
{
	public delegate void TextMessageEventHandler (object sender, TextMessageEventArgs args);

	[Serializable]
	public class TextMessageEventArgs : EventArgs
	{
		string message;

		public TextMessageEventArgs(string message)
		{
			this.message = message;
		}

		public string Message {
			get {
				return message;
			}
		}
	}
}
