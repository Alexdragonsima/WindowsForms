using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			labelTime.BackColor = Color.AliceBlue;

			this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width, 50);
		}
		void SetVisibility(bool visible)
		{
			cbShowDate.Visible = visible;
			cbShowWeekDay.Visible = visible;
			//contextMenu.Visible = visible;
			btnHideControls.Visible = visible;
			this.TransparencyKey = visible ? Color.Empty : this.BackColor;
			this.FormBorderStyle = visible ? FormBorderStyle.FixedToolWindow : FormBorderStyle.None;
			this.ShowInTaskbar = visible;
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			labelTime.Text = DateTime.Now.ToString
				(
					"hh:mm:ss tt",
					System.Globalization.CultureInfo.InvariantCulture
				);
			if (cbShowDate.Checked)
			{
				labelTime.Text += "\n";
				labelTime.Text += DateTime.Now.ToString("yyyy.MM.dd");
			}
			if (cbShowWeekDay.Checked)
			{
				labelTime.Text += "\n";
				labelTime.Text += DateTime.Now.DayOfWeek;
			}
			notifyIcon.Text = labelTime.Text;
		}



		private void btnHideControls_Click(object sender, EventArgs e)
		{
			//cbShowDate.Visible = false;
			//btnHideControls.Visible = false;
			//this.TransparencyKey = this.BackColor;
			//this.FormBorderStyle = FormBorderStyle.None;
			//labelTime.BackColor = Color.AliceBlue;
			//this.ShowInTaskbar = false;
			SetVisibility(false);
		}

		private void labelTime_DoubleClick(object sender, EventArgs e)
		{
			//MessageBox.Show
			//	(
			//		this,
			//		"Вы два раза щелкнули по времени, и теперь вы управляете временем",
			//		"Info",
			//		MessageBoxButtons.OK,
			//		MessageBoxIcon.Information
			//	);

			//cbShowDate.Visible = true;
			//btnHideControls.Visible = true;
			//this.TransparencyKey = System.Drawing.Color.Empty;
			//this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			//labelTime.BackColor=Color.AliceBlue;
			//this.ShowInTaskbar = true;

			SetVisibility(true);
		}

		private void cmExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void cmTopmost_CheckedChanged(object sender, EventArgs e)
		{
			this.TopMost = cmTopmost.Checked;
		}

		private void cmShowDate_CheckedChanged(object sender, EventArgs e)
		{
			cbShowDate.Checked = cmShowDate.Checked;
		}
		private void cbShowDate_CheckedChanged(object sender, EventArgs e)
		{
			cmShowDate.Checked = cbShowDate.Checked;
		}

		private void cmShowWeekday_CheckedChanged(object sender, EventArgs e)
		{
			cbShowWeekDay.Checked = cmShowWeekday.Checked;
		}

		private void cbShowWeekDay_CheckedChanged(object sender, EventArgs e)
		{
			cmShowWeekday.Checked = cbShowWeekDay.Checked;
		}

		private void notifyIcon_DoubleClick(object sender, EventArgs e)
		{
			if(!this.TopMost)
			{
				this.TopMost = true;
				this.TopMost = false;
			}
		}

		private void redToolStripMenuItem_Click(object sender, EventArgs e)
		{
			labelTime.BackColor = Color.Red;
		}
	}
}
