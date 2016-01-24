/*
 * Created by SharpDevelop.
 * User: RoBartol
 * Date: 18/01/2016
 * Time: 09:08
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WouldBe_PDM_sharpdev
{
	/// <summary>
	/// Description of retsegge.
	/// </summary>
	public partial class retsegge : Form
	{
		public retsegge()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void RetseggeLoad(object sender, EventArgs e)
		{
//	this.Close();
		}
		void RetseggeClick(object sender, EventArgs e)
		{this.Close();}
		void Label1Click(object sender, EventArgs e)
		{this.Close();}
		void PictureBox1Click(object sender, EventArgs e)
		{this.Close();}
		
		
	}
}
