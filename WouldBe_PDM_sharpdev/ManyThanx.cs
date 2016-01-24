/*
 * Created by SharpDevelop.
 * User: RoBartol
 * Date: 18/01/2016
 * Time: 11:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WouldBe_PDM_sharpdev
{
	/// <summary>
	/// Description of ManyThanx.
	/// </summary>
	public partial class ManyThanx : Form
	{
		public ManyThanx()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void ManyThanxLoad(object sender, EventArgs e)
		{
	
		}
				void ManyThanxClick(object sender, EventArgs e)
		{this.Close();}
		void Label1Click(object sender, EventArgs e)
		{
			this.Close();
		}

	}
}
