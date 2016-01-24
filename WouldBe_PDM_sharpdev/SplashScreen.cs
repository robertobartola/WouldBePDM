/*
 * Created by SharpDevelop.
 * User: RoBartol
 * Date: 21/12/2015
 * Time: 18:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WouldBe_PDM_sharpdev
{
	
	/// <summary>
	/// Description of SplashScreen.
	/// </summary>
	public partial class SplashScreen : Form
	{
		public 	int counter=0;
		public SplashScreen()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
//			WouldBe_PDM_sharpdev.MainForm Mainfo = new WouldBe_PDM_sharpdev.MainForm();
////		    MessageBox.Show ("Timeout");
//			Mainfo.Show();
//		    WouldBe_PDM_sharpdev.MainForm.ActiveForm.Activate();
//		    Mainfo.Activate();
		
						
		}

				void SplashScreenClick(object sender, EventArgs e)
				{this.Close();}
				
		void Timer1Tick(object sender, EventArgs e)
		{
	 counter++;
    progressBar1.Value = counter *1;
    // label2.Text = (5*counter).ToString();
    if (counter ==100)
    {
        timer1.Stop();
        this.Close();
        
//        	WouldBe_PDM_sharpdev.MainForm Main = new WouldBe_PDM_sharpdev.MainForm();
////		    MessageBox.Show ("Timeout");
//			Main.Show();
//		    WouldBe_PDM_sharpdev.MainForm.ActiveForm.Activate();
//		    Main.Activate();
        
        
        
//             LoadEverything();
//        this.Visible = false;
//        WouldBe_PDM_sharpdev.MainForm mainForm = new WouldBe_PDM_sharpdev.MainForm(LoadedClass);
//        WouldBe_PDM_sharpdev.mainForm.ShowDialog();
        this.Close();
         
    }
		}
	
		
//		private static void main2(string[] args)
//		{
//			Application.EnableVisualStyles();
//			Application.SetCompatibleTextRenderingDefault(false);
//			Application.Run(new MainForm());
////			Application.Run(new WouldBe_PDM_sharpdev.MainForm());
//		}
//		
		
		
		
	}
}

