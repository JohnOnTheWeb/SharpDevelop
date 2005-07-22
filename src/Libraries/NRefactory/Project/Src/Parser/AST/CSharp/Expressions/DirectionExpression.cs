// <file>
//     <copyright see="prj:///doc/copyright.txt">2002-2005 AlphaSierraPapa</copyright>
//     <license see="prj:///doc/license.txt">GNU General Public License</license>
//     <owner name="none" email=""/>
//     <version>$Revision$</version>
// </file>

using System;
using System.Diagnostics;
using System.Collections;

namespace ICSharpCode.NRefactory.Parser.AST 
{	
	public class DirectionExpression : Expression
	{
		FieldDirection fieldDirection;
		Expression     expression;
		
		public FieldDirection FieldDirection {
			get {
				return fieldDirection;
			}
			set {
				fieldDirection = value;
			}
		}
		
		public Expression Expression {
			get {
				return expression;
			}
			set {
				expression = Expression.CheckNull(value);
			}
		}
		
		public DirectionExpression(FieldDirection fieldDirection, Expression expression)
		{
			this.FieldDirection = fieldDirection;
			this.Expression     = expression;
		}
		
		public override object AcceptVisitor(IASTVisitor visitor, object data)
		{
			return visitor.Visit(this, data);
		}
		
		public override string ToString()
		{
			return String.Format("[DirectionExpression: FieldDirection={0}, Expression={1}]",
			                     fieldDirection,
			                     expression);
		}
	}
}
