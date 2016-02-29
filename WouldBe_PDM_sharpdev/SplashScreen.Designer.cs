/*
 * Created by SharpDevelop.
 * User: RoBartol
 * Date: 21/12/2015
 * Time: 18:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace WouldBe_PDM_sharpdev
{
	partial class SplashScreen
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(7, 602);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(937, 25);
			this.progressBar1.TabIndex = 0;
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 10;
			this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.SystemColors.Window;
			this.label1.Font = new System.Drawing.Font("Papyrus", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(187, 468);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(591, 77);
			this.label1.TabIndex = 2;
			this.label1.Text = "https://github.com/robertobartola/WouldBePDM\r\nby Roberto Bartola";
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
			this.label2.Font = new System.Drawing.Font("Consolas", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(726, 199);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(218, 42);
			this.label2.TabIndex = 3;
			this.label2.Text = "V 0.0.1.0";
			// 
			// SplashScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(956, 639);
			this.ControlBox = false;
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.progressBar1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "SplashScreen";
			this.Text = "SplashScreen";
			this.Click += new System.EventHandler(this.SplashScreenClick);
			this.ResumeLayout(false);

		}
	}
}
