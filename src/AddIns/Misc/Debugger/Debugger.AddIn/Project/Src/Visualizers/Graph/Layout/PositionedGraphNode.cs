﻿// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Martin Koníček" email="martin.konicek@gmail.com"/>
//     <version>$Revision$</version>
// </file>
using System;
using System.Collections.Generic;
using Debugger.AddIn.Visualizers.Graph.Drawing;
using System.Windows;
using System.Linq;

namespace Debugger.AddIn.Visualizers.Graph.Layout
{
	/// <summary>
	/// ObjectNode with added position information.
	/// </summary>
	public class PositionedGraphNode
	{
		/// <summary>
		/// Creates new PositionedNode.
		/// </summary>
		/// <param name="objectNode">Underlying ObjectNode.</param>
		public PositionedGraphNode(ObjectGraphNode objectNode)
		{
			this.objectNode = objectNode;
			createVisualControl();
		}
		
		public event EventHandler<PositionedPropertyEventArgs> PropertyExpanded;
		public event EventHandler<PositionedPropertyEventArgs> PropertyCollapsed;
		
		private ObjectGraphNode objectNode;
		/// <summary>
		/// Underlying ObjectNode.
		/// </summary>
		public ObjectGraphNode ObjectNode
		{
			get { return objectNode; }
		}
		
		/// <summary>
		/// Tree-of-properties content of this node.
		/// </summary>
		public NestedNodeViewModel Content 
		{ 
			get; set;
		}
		
		private PositionedGraphNodeControl nodeVisualControl;
		/// <summary>
		/// Visual control to be shown for this node.
		/// </summary>
		public PositionedGraphNodeControl NodeVisualControl
		{
			get
			{
				return this.nodeVisualControl;
			}
		}
		
		// TODO posNodeForObjectGraphNode will be a service, that will return existing posNodes or create empty new
		public void InitContentFromObjectNode()
		{
			this.Content = new NestedNodeViewModel(this);
			this.Content.InitFrom(this.ObjectNode.Content);
			this.nodeVisualControl.Root = this.Content;
		}
		
		private void createVisualControl()
		{
			this.nodeVisualControl = new PositionedGraphNodeControl();
			this.nodeVisualControl.MaxHeight = 200;
			
			this.nodeVisualControl.PropertyExpanded += new EventHandler<PositionedPropertyEventArgs>(NodeVisualControl_Expanded);
			this.nodeVisualControl.PropertyCollapsed += new EventHandler<PositionedPropertyEventArgs>(NodeVisualControl_Collapsed);
		}
		
		public IEnumerable<PositionedNodeProperty> Properties
		{
			get
			{
				return this.Content.FlattenProperties();
			}
		}
		
		public virtual IEnumerable<PositionedEdge> Edges
		{
			get
			{
				foreach	(PositionedNodeProperty property in this.Properties)
				{
					if (property.Edge != null)
						yield return property.Edge;
				}
			}
		}
		
		public void Measure()
		{
			this.nodeVisualControl.Measure(new Size(500, 500));
		}
		
		public double Left { get; set; }
		public double Top { get; set; }
		public double Width
		{
			get { return NodeVisualControl.DesiredSize.Width; }
		}
		public double Height
		{
			get { return NodeVisualControl.DesiredSize.Height; }
		}
		
		public Point LeftTop
		{
			get { return new Point(Left, Top); }
		}
		
		public Point Center
		{
			get { return new Point(Left + Width / 2, Top + Height / 2); }
		}
		
		public Rect Rect { get {  return new Rect(Left, Top, Width, Height); } }
		
		#region event helpers
		private void NodeVisualControl_Expanded(object sender, PositionedPropertyEventArgs e)
		{
			// propagage event
			OnPropertyExpanded(this, e);
		}
		
		private void NodeVisualControl_Collapsed(object sender, PositionedPropertyEventArgs e)
		{
			// propagate event
			OnPropertyCollapsed(this, e);
		}
		
		protected virtual void OnPropertyExpanded(object sender, PositionedPropertyEventArgs propertyArgs)
		{
			if (this.PropertyExpanded != null)
			{
				this.PropertyExpanded(sender, propertyArgs);
			}
		}

		protected virtual void OnPropertyCollapsed(object sender, PositionedPropertyEventArgs propertyArgs)
		{
			if (this.PropertyCollapsed != null)
			{
				this.PropertyCollapsed(sender, propertyArgs);
			}
		}
		#endregion
	}
}
