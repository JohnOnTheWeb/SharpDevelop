﻿// <file>
//     <copyright see="prj:///doc/copyright.txt">2002-2005 AlphaSierraPapa</copyright>
//     <license see="prj:///doc/license.txt">GNU General Public License</license>
//     <owner name="Mike Krüger" email="mike@icsharpcode.net"/>
//     <version>$Revision$</version>
// </file>

using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ICSharpCode.SharpDevelop.Gui
{
	public class ExtTreeViewComparer : IComparer<TreeNode>
	{
		public int Compare(TreeNode x, TreeNode y)
		{
			Debug.Assert(x != null);
			Debug.Assert(y != null);
			ExtTreeNode node1 = x as ExtTreeNode;
			ExtTreeNode node2 = y as ExtTreeNode;
			
			if (node1 == null || node2 == null) {
				return x.Text.CompareTo(y.Text);
			}
			
			if (node1.SortOrder != node2.SortOrder) {
				return Math.Sign(node1.SortOrder - node2.SortOrder);
			}
			
			return node1.CompareString.CompareTo(node2.CompareString);
		}
	}
}
