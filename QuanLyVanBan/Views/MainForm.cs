using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyVanBan.Views
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			
		}

		//private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
		//{
		//	Font fntTab;
		//	Brush bshBack;
		//	Brush bshFore;
		//	if (e.Index == this.tabControl1.SelectedIndex)
		//	{
		//		fntTab = new Font(e.Font, FontStyle.Bold);
		//		bshBack = new System.Drawing.Drawing2D.LinearGradientBrush(e.Bounds, Color.LightSkyBlue, Color.LightGreen, System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal);
		//		bshFore = Brushes.Blue;
		//	}
		//	else
		//	{
		//		fntTab = e.Font;
		//		bshBack = new SolidBrush(Color.White);
		//		bshFore = new SolidBrush(Color.Black);
		//	}
		//	string tabName = this.tabControl1.TabPages[e.Index].Text;
		//	StringFormat sftTab = new StringFormat(StringFormatFlags.NoClip);
		//	sftTab.Alignment = StringAlignment.Center;
		//	sftTab.LineAlignment = StringAlignment.Center;
		//	e.Graphics.FillRectangle(bshBack, e.Bounds);
		//	Rectangle recTab = e.Bounds;
		//	recTab = new Rectangle(recTab.X, recTab.Y + 4, recTab.Width, recTab.Height - 4);
		//	e.Graphics.DrawString(tabName, fntTab, bshFore, recTab, sftTab);
		//}

	}
}
