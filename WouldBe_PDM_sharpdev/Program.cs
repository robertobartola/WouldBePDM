/*
 * Created by SharpDevelop.
 * User: RoBartol
 * Date: 30/11/2015
 * Time: 18:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace wina
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
//			Application.Run(new WouldBe_PDM_sharpdev.WouldBe_data());
//			Application.Run(new WouldBe_PDM_sharpdev.retsegge());

			Application.Run(new WouldBe_PDM_sharpdev.SplashScreen());
			Application.Run(new MainForm());
		}
		
//private static void main2(string[] args)
//		{
//			Application.EnableVisualStyles();
//			Application.SetCompatibleTextRenderingDefault(false);
//			Application.Run(new MainForm());
////			Application.Run(new WouldBe_PDM_sharpdev.SplashScreen());
//		}
		
		
	}
}
