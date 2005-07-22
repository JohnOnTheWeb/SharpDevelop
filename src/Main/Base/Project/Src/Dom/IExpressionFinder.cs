﻿// <file>
//     <copyright see="prj:///doc/copyright.txt">2002-2005 AlphaSierraPapa</copyright>
//     <license see="prj:///doc/license.txt">GNU General Public License</license>
//     <owner name="Mike Krüger" email="mike@icsharpcode.net"/>
//     <version>$Revision$</version>
// </file>

using System;

namespace ICSharpCode.SharpDevelop.Dom
{
	public interface IExpressionFinder
	{
		/// <summary>
		/// Finds an expression before the current offset.
		/// </summary>
		ExpressionResult FindExpression(string text, int offset);
		
		/// <summary>
		/// Finds an expression around the current offset.
		/// </summary>
		ExpressionResult FindFullExpression(string text, int offset);
	}
	
	/// <summary>
	/// Structure containing the result of a call to an expression finder.
	/// </summary>
	public struct ExpressionResult
	{
		/// <summary>The expression that has been found at the specified offset.</summary>
		public string Expression;
		/// <summary>Specifies the context in which the expression was found.</summary>
		public ExpressionContext Context;
		/// <summary>An object carrying additional language-dependend data.</summary>
		public object Tag;
		
		public ExpressionResult(string expression) : this(expression, ExpressionContext.Default, null) {}
		public ExpressionResult(string expression, ExpressionContext context) : this(expression, context, null) {}
		public ExpressionResult(string expression, object tag) : this(expression, ExpressionContext.Default, tag)  {}
		
		public ExpressionResult(string expression, ExpressionContext context, object tag)
		{
			this.Expression = expression;
			this.Context = context;
			this.Tag = tag;
		}
	}
}
