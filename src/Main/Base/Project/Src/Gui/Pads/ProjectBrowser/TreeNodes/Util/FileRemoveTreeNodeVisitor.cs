﻿// <file>
//     <copyright see="prj:///doc/copyright.txt">2002-2005 AlphaSierraPapa</copyright>
//     <license see="prj:///doc/license.txt">GNU General Public License</license>
//     <owner name="Mike Krüger" email="mike@icsharpcode.net"/>
//     <version>$Revision$</version>
// </file>

using System;
using System.IO;
using ICSharpCode.Core;
using ICSharpCode.SharpDevelop.Gui;

namespace ICSharpCode.SharpDevelop.Project
{
	public class FileRemoveTreeNodeVisitor : ProjectBrowserTreeNodeVisitor
	{
		string fileName;
		
		public FileRemoveTreeNodeVisitor(string fileName)
		{
			this.fileName = fileName;
		}
		
		public override object Visit(SolutionItemNode solutionItemNode, object data)
		{
			if (FileUtility.IsBaseDirectory(fileName, solutionItemNode.FileName)) {
				solutionItemNode.Remove();
			} else {
				solutionItemNode.AcceptChildren(this, data);
			}
			return data;
		}
		
		
		public override object Visit(ProjectNode projectNode, object data)
		{
			if (FileUtility.IsBaseDirectory(projectNode.Directory, fileName)) {
				projectNode.AcceptChildren(this, data);
			}
			return data;
		}
		
		public override object Visit(DirectoryNode directoryNode, object data)
		{
			if (FileUtility.IsBaseDirectory(fileName, directoryNode.Directory)) {
				ExtTreeNode parent = directoryNode.Parent as ExtTreeNode;
				directoryNode.Remove();
				if (parent != null) {
					parent.Refresh();
				}
			} else {
				if (FileUtility.IsBaseDirectory(directoryNode.Directory, fileName)) {
					directoryNode.AcceptChildren(this, data);
				}
			}
			return data;
		}
		
		public override object Visit(FileNode fileNode, object data)
		{
			if (FileUtility.IsBaseDirectory(fileName, fileNode.FileName)) {
				ExtTreeNode parent = fileNode.Parent as ExtTreeNode;
				fileNode.Remove();
				if (parent != null) {
					parent.Refresh();
				}
			} else {
				fileNode.AcceptChildren(this, data);
			}
			return data;
		}
	}
}
