﻿// <file>
//     <copyright see="prj:///doc/copyright.txt">2002-2005 AlphaSierraPapa</copyright>
//     <license see="prj:///doc/license.txt">GNU General Public License</license>
//     <owner name="Mike Krüger" email="mike@icsharpcode.net"/>
//     <version>$Revision$</version>
// </file>

using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using ICSharpCode.Core;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;

namespace ICSharpCode.SharpDevelop.Bookmarks
{
	/// <summary>
	/// Description of Bookmark.
	/// </summary>
	[TypeConverter(typeof(BookmarkConverter))]
	public class SDBookmark : Bookmark
	{
		string fileName;
		
		public string FileName {
			get {
				return fileName;
			}
			set {
				fileName = value;
			}
		}
		
		public SDBookmark(string fileName, IDocument document, int lineNumber) : base(document, lineNumber)
		{
			this.fileName = fileName;
		}
	}
	
	public class SDBookmarkFactory : IBookmarkFactory
	{
		string fileName;
		ICSharpCode.TextEditor.Document.BookmarkManager manager;
		
		public SDBookmarkFactory(ICSharpCode.TextEditor.Document.BookmarkManager manager)
		{
			this.manager = manager;
		}
		
		public void ChangeFilename(string newFileName)
		{
			fileName = newFileName;
			foreach (Bookmark mark in manager.Marks) {
				SDBookmark sdMark = mark as SDBookmark;
				if (sdMark != null) {
					sdMark.FileName = newFileName;
				}
			}
		}
		
		public Bookmark CreateBookmark(IDocument document, int lineNumber)
		{
			return new SDBookmark(fileName, document, lineNumber);
		}
	}
}
