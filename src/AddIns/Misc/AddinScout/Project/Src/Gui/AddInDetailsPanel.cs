// <file>
//     <copyright see="prj:///doc/copyright.txt">2002-2005 AlphaSierraPapa</copyright>
//     <license see="prj:///doc/license.txt">GNU General Public License</license>
//     <owner name="none" email=""/>
//     <version>$Revision$</version>
// </file>

using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

using ICSharpCode.Core;

namespace AddInScout
{
	public class AddInDetailsPanel : Panel
	{
		ListView addInDetailsListView = new ListView();
		Label addInLabel              = new Label();
		
		public AddInDetailsPanel()
		{
			addInDetailsListView.Dock = DockStyle.Fill;
			addInDetailsListView.GridLines = false;
			addInDetailsListView.View = View.Details;
			addInDetailsListView.MultiSelect = false;
			addInDetailsListView.FullRowSelect = true;
			addInDetailsListView.Activation = ItemActivation.OneClick;
			addInDetailsListView.HeaderStyle = ColumnHeaderStyle.None;
			addInDetailsListView.BorderStyle = BorderStyle.FixedSingle;
			addInDetailsListView.ItemActivate += new EventHandler(AddInDetailsListViewItemActivate);
			addInDetailsListView.Columns.Add("Property",100, HorizontalAlignment.Left);
			addInDetailsListView.Columns.Add("Value", 500, HorizontalAlignment.Left);
			Controls.Add(addInDetailsListView);
			
			addInLabel.Dock =DockStyle.Top;
			addInLabel.Text = "AddIn : ";
			addInLabel.Font = new Font(addInLabel.Font.FontFamily,addInLabel.Font.Size*2);
			addInLabel.Height = addInLabel.Height*2;
			addInLabel.FlatStyle = FlatStyle.Flat;
			addInLabel.TextAlign = ContentAlignment.MiddleLeft;
			addInLabel.BorderStyle = BorderStyle.FixedSingle;
			Controls.Add(addInLabel);
		}
		
		void AddInDetailsListViewItemActivate(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			
			ListViewItem selectedItem = ((ListView)sender).SelectedItems[0];
			
			if (selectedItem.Text.ToLower().Equals("url")) {
				string url = selectedItem.SubItems[1].Text;
				try	 {
					System.Diagnostics.Process.Start(url);
				} catch (Exception) {
// Silent: On my System the browser starts but Process.Start throws an exception. Mike 2.11.2004/Notebook/ICE 1517 on the way to DevCon Europe 2004
//					MessageBox.Show("Unable to Start Browser\n" + ex.ToString());
				}
			} else if (selectedItem.Text.ToLower().Equals("filename")) {
				
				FileService.OpenFile(selectedItem.SubItems[1].Text);
			}
			
			Cursor.Current = Cursors.Default;
		}
		
		public void ShowAddInDetails(AddIn ai)
		{
			addInLabel.Text = "AddIn : " + ai.Properties["name"];
			
			addInDetailsListView.Items.Clear();
			
			ListViewItem[] items = new ListViewItem[] {
				new ListViewItem(new string[] { "Author", ai.Properties["author"] }),
				new ListViewItem(new string[] { "Copyright", ai.Properties["copyright"]}),
				new ListViewItem(new string[] { "Description", ai.Properties["description"] }),
				new ListViewItem(new string[] { "FileName", ai.FileName}),
				new ListViewItem(new string[] { "Url", ai.Properties["url"]}),
				new ListViewItem(new string[] { "Version", ai.Properties["version"]})
			};
			
			// set Filename & Url rows to 'weblink' style
			items[3].Font = items[4].Font = new Font(addInDetailsListView.Font, FontStyle.Underline);
			items[3].ForeColor = items[4].ForeColor = Color.Blue;
			addInDetailsListView.Items.AddRange(items);
			
			foreach (Runtime runtime in ai.Runtimes) {
				ListViewItem newListViewItem = new ListViewItem("Runtime Library");
				newListViewItem.SubItems.Add(runtime.Assembly);
				addInDetailsListView.Items.Add(newListViewItem);
			}
		}
	}
}
