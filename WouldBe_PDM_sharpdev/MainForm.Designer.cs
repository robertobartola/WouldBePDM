/*
 * Created by SharpDevelop.
 * User: RoBartol
 * Date: 30/11/2015
 * Time: 18:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace wina
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ComboBox FAM_Box;
		private System.Windows.Forms.ComboBox PRJ_Box;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ComboBox PROD_Box;
		private System.Windows.Forms.ComboBox PART_Box;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox PartIndexText;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button generatePDFbutton;
		private System.Windows.Forms.Button generateSTEPbuttron;
		private System.Windows.Forms.Button openPDFbutton;
		private System.Windows.Forms.Button OpenSTEPbutton;
		private System.Windows.Forms.TextBox PdfBox;
		private System.Windows.Forms.TextBox StepBox;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button where2Dbutton;
		private System.Windows.Forms.Button whereUSEDbutton;
		private System.Windows.Forms.Button open2Dbutton;
		private System.Windows.Forms.Button OpenCADbutton;
		private System.Windows.Forms.TextBox TwodBox;
		private System.Windows.Forms.TextBox ThreedBox;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button WhereUsed;
		private System.Windows.Forms.TextBox DesignerBox;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox DateBox;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox RevBox;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox StatusBox;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox NameBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox CodeBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.TextBox projectstatusBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox projectManagerBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox ProjectCodeBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox famstatusBox;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox drawingBox;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox drawingRevBox;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox drawingdateBox;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.TextBox drawingfilenameBox;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox coatingBox;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.TextBox ttreatmentBox;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.TextBox materialBox;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox weightBox;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox supplierBox;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Button CheckOut_pdf;
		private System.Windows.Forms.Button CheckOut_Step;
		private System.Windows.Forms.Button Checkout_2D;
		private System.Windows.Forms.Button Checkout_3D;
		private System.Windows.Forms.Button button18;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage FindFilesTab;
		private System.Windows.Forms.TabPage ConfigTab;
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.TextBox JPGdirBox;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.TextBox StepDirBox;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.TextBox PDFdirBox;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.TextBox CADdirTextbox;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.GroupBox groupBox10;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.TextBox ProdDrawingDIR;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Button button13;
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.FAM_Box = new System.Windows.Forms.ComboBox();
			this.PRJ_Box = new System.Windows.Forms.ComboBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.PROD_Box = new System.Windows.Forms.ComboBox();
			this.PART_Box = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.PartIndexText = new System.Windows.Forms.TextBox();
			this.button3 = new System.Windows.Forms.Button();
			this.generatePDFbutton = new System.Windows.Forms.Button();
			this.generateSTEPbuttron = new System.Windows.Forms.Button();
			this.openPDFbutton = new System.Windows.Forms.Button();
			this.OpenSTEPbutton = new System.Windows.Forms.Button();
			this.PdfBox = new System.Windows.Forms.TextBox();
			this.StepBox = new System.Windows.Forms.TextBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.CheckOut_pdf = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.CheckOut_Step = new System.Windows.Forms.Button();
			this.where2Dbutton = new System.Windows.Forms.Button();
			this.whereUSEDbutton = new System.Windows.Forms.Button();
			this.open2Dbutton = new System.Windows.Forms.Button();
			this.OpenCADbutton = new System.Windows.Forms.Button();
			this.TwodBox = new System.Windows.Forms.TextBox();
			this.ThreedBox = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.Checkout_2D = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.Checkout_3D = new System.Windows.Forms.Button();
			this.WhereUsed = new System.Windows.Forms.Button();
			this.DesignerBox = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.DateBox = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.RevBox = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.StatusBox = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.NameBox = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.CodeBox = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.supplierBox = new System.Windows.Forms.TextBox();
			this.label21 = new System.Windows.Forms.Label();
			this.coatingBox = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.ttreatmentBox = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.materialBox = new System.Windows.Forms.TextBox();
			this.label18 = new System.Windows.Forms.Label();
			this.weightBox = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.famstatusBox = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.projectstatusBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.projectManagerBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.ProjectCodeBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.button18 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.drawingfilenameBox = new System.Windows.Forms.TextBox();
			this.drawingdateBox = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.drawingRevBox = new System.Windows.Forms.TextBox();
			this.drawingBox = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.button5 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.button10 = new System.Windows.Forms.Button();
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.FindFilesTab = new System.Windows.Forms.TabPage();
			this.ConfigTab = new System.Windows.Forms.TabPage();
			this.groupBox10 = new System.Windows.Forms.GroupBox();
			this.label26 = new System.Windows.Forms.Label();
			this.JPGdirBox = new System.Windows.Forms.TextBox();
			this.label24 = new System.Windows.Forms.Label();
			this.StepDirBox = new System.Windows.Forms.TextBox();
			this.PDFdirBox = new System.Windows.Forms.TextBox();
			this.label25 = new System.Windows.Forms.Label();
			this.CADdirTextbox = new System.Windows.Forms.TextBox();
			this.label23 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.button11 = new System.Windows.Forms.Button();
			this.button12 = new System.Windows.Forms.Button();
			this.button9 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.ProdDrawingDIR = new System.Windows.Forms.TextBox();
			this.label27 = new System.Windows.Forms.Label();
			this.button13 = new System.Windows.Forms.Button();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.groupBox6.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.groupBox9.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.FindFilesTab.SuspendLayout();
			this.ConfigTab.SuspendLayout();
			this.groupBox10.SuspendLayout();
			this.SuspendLayout();
			// 
			// FAM_Box
			// 
			this.FAM_Box.FormattingEnabled = true;
			this.FAM_Box.Location = new System.Drawing.Point(6, 12);
			this.FAM_Box.Name = "FAM_Box";
			this.FAM_Box.Size = new System.Drawing.Size(270, 21);
			this.FAM_Box.TabIndex = 0;
			this.FAM_Box.Text = "Select a Family";
			this.FAM_Box.SelectedIndexChanged += new System.EventHandler(this.ComboBox1SelectedIndexChanged);
			// 
			// PRJ_Box
			// 
			this.PRJ_Box.FormattingEnabled = true;
			this.PRJ_Box.Location = new System.Drawing.Point(6, 17);
			this.PRJ_Box.Name = "PRJ_Box";
			this.PRJ_Box.Size = new System.Drawing.Size(270, 21);
			this.PRJ_Box.TabIndex = 1;
			this.PRJ_Box.Text = "Select a Project";
			this.PRJ_Box.SelectedIndexChanged += new System.EventHandler(this.PRJ_BoxSelectedIndexChanged);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(612, 591);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox1.Size = new System.Drawing.Size(279, 63);
			this.textBox1.TabIndex = 3;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(535, 610);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 5;
			this.button1.Text = "Write";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(535, 581);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 7;
			this.button2.Text = "Read";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// PROD_Box
			// 
			this.PROD_Box.FormattingEnabled = true;
			this.PROD_Box.Location = new System.Drawing.Point(6, 15);
			this.PROD_Box.Name = "PROD_Box";
			this.PROD_Box.Size = new System.Drawing.Size(270, 21);
			this.PROD_Box.TabIndex = 9;
			this.PROD_Box.Text = "Select a Product";
			this.PROD_Box.SelectedIndexChanged += new System.EventHandler(this.PROD_BoxSelectedIndexChanged);
			// 
			// PART_Box
			// 
			this.PART_Box.Enabled = false;
			this.PART_Box.FormattingEnabled = true;
			this.PART_Box.Location = new System.Drawing.Point(892, 26);
			this.PART_Box.Name = "PART_Box";
			this.PART_Box.Size = new System.Drawing.Size(270, 21);
			this.PART_Box.TabIndex = 11;
			this.PART_Box.Text = "Select a Component";
			this.PART_Box.SelectedIndexChanged += new System.EventHandler(this.PART_BoxSelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(892, 11);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 12;
			this.label4.Text = "Component";
			// 
			// PartIndexText
			// 
			this.PartIndexText.Location = new System.Drawing.Point(433, 591);
			this.PartIndexText.Multiline = true;
			this.PartIndexText.Name = "PartIndexText";
			this.PartIndexText.Size = new System.Drawing.Size(96, 42);
			this.PartIndexText.TabIndex = 13;
			this.PartIndexText.Visible = false;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(531, 618);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 14;
			this.button3.Text = "button3";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// generatePDFbutton
			// 
			this.generatePDFbutton.Enabled = false;
			this.generatePDFbutton.Location = new System.Drawing.Point(172, 44);
			this.generatePDFbutton.Name = "generatePDFbutton";
			this.generatePDFbutton.Size = new System.Drawing.Size(75, 23);
			this.generatePDFbutton.TabIndex = 82;
			this.generatePDFbutton.Text = "Generate";
			this.generatePDFbutton.UseVisualStyleBackColor = true;
			// 
			// generateSTEPbuttron
			// 
			this.generateSTEPbuttron.Enabled = false;
			this.generateSTEPbuttron.Location = new System.Drawing.Point(172, 44);
			this.generateSTEPbuttron.Name = "generateSTEPbuttron";
			this.generateSTEPbuttron.Size = new System.Drawing.Size(75, 23);
			this.generateSTEPbuttron.TabIndex = 77;
			this.generateSTEPbuttron.Text = "Generate";
			this.generateSTEPbuttron.UseVisualStyleBackColor = true;
			// 
			// openPDFbutton
			// 
			this.openPDFbutton.Enabled = false;
			this.openPDFbutton.Location = new System.Drawing.Point(10, 44);
			this.openPDFbutton.Name = "openPDFbutton";
			this.openPDFbutton.Size = new System.Drawing.Size(75, 23);
			this.openPDFbutton.TabIndex = 80;
			this.openPDFbutton.Text = "OpenFile";
			this.openPDFbutton.UseVisualStyleBackColor = true;
			this.openPDFbutton.Click += new System.EventHandler(this.OpenPDFbuttonClick);
			// 
			// OpenSTEPbutton
			// 
			this.OpenSTEPbutton.Enabled = false;
			this.OpenSTEPbutton.Location = new System.Drawing.Point(10, 44);
			this.OpenSTEPbutton.Name = "OpenSTEPbutton";
			this.OpenSTEPbutton.Size = new System.Drawing.Size(75, 23);
			this.OpenSTEPbutton.TabIndex = 75;
			this.OpenSTEPbutton.Text = "OpenFile";
			this.OpenSTEPbutton.UseVisualStyleBackColor = true;
			this.OpenSTEPbutton.Click += new System.EventHandler(this.OpenSTEPbuttonClick);
			// 
			// PdfBox
			// 
			this.PdfBox.Location = new System.Drawing.Point(6, 18);
			this.PdfBox.Name = "PdfBox";
			this.PdfBox.Size = new System.Drawing.Size(373, 20);
			this.PdfBox.TabIndex = 79;
			// 
			// StepBox
			// 
			this.StepBox.Location = new System.Drawing.Point(9, 18);
			this.StepBox.Name = "StepBox";
			this.StepBox.Size = new System.Drawing.Size(388, 20);
			this.StepBox.TabIndex = 74;
			// 
			// groupBox3
			// 
			this.groupBox3.BackColor = System.Drawing.SystemColors.Control;
			this.groupBox3.Controls.Add(this.CheckOut_pdf);
			this.groupBox3.Controls.Add(this.PdfBox);
			this.groupBox3.Controls.Add(this.openPDFbutton);
			this.groupBox3.Controls.Add(this.generatePDFbutton);
			this.groupBox3.Location = new System.Drawing.Point(423, 204);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(389, 81);
			this.groupBox3.TabIndex = 83;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "2D - PDF file";
			// 
			// CheckOut_pdf
			// 
			this.CheckOut_pdf.Enabled = false;
			this.CheckOut_pdf.Location = new System.Drawing.Point(91, 37);
			this.CheckOut_pdf.Name = "CheckOut_pdf";
			this.CheckOut_pdf.Size = new System.Drawing.Size(64, 37);
			this.CheckOut_pdf.TabIndex = 97;
			this.CheckOut_pdf.Text = "CheckOut\r\npdf";
			this.CheckOut_pdf.UseVisualStyleBackColor = true;
			this.CheckOut_pdf.Click += new System.EventHandler(this.CheckOut_pdfClick);
			// 
			// groupBox4
			// 
			this.groupBox4.BackColor = System.Drawing.SystemColors.Control;
			this.groupBox4.Controls.Add(this.CheckOut_Step);
			this.groupBox4.Controls.Add(this.OpenSTEPbutton);
			this.groupBox4.Controls.Add(this.generateSTEPbuttron);
			this.groupBox4.Controls.Add(this.StepBox);
			this.groupBox4.Location = new System.Drawing.Point(11, 204);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(404, 81);
			this.groupBox4.TabIndex = 78;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "3D - STEP file";
			// 
			// CheckOut_Step
			// 
			this.CheckOut_Step.Enabled = false;
			this.CheckOut_Step.Location = new System.Drawing.Point(100, 38);
			this.CheckOut_Step.Name = "CheckOut_Step";
			this.CheckOut_Step.Size = new System.Drawing.Size(64, 37);
			this.CheckOut_Step.TabIndex = 97;
			this.CheckOut_Step.Text = "CheckOut\r\nStep";
			this.CheckOut_Step.UseVisualStyleBackColor = true;
			this.CheckOut_Step.Click += new System.EventHandler(this.CheckOut_StepClick);
			// 
			// where2Dbutton
			// 
			this.where2Dbutton.Enabled = false;
			this.where2Dbutton.Location = new System.Drawing.Point(172, 44);
			this.where2Dbutton.Name = "where2Dbutton";
			this.where2Dbutton.Size = new System.Drawing.Size(75, 23);
			this.where2Dbutton.TabIndex = 72;
			this.where2Dbutton.Text = "Where Used";
			this.where2Dbutton.UseVisualStyleBackColor = true;
			// 
			// whereUSEDbutton
			// 
			this.whereUSEDbutton.Enabled = false;
			this.whereUSEDbutton.Location = new System.Drawing.Point(172, 40);
			this.whereUSEDbutton.Name = "whereUSEDbutton";
			this.whereUSEDbutton.Size = new System.Drawing.Size(75, 23);
			this.whereUSEDbutton.TabIndex = 66;
			this.whereUSEDbutton.Text = "Where Used";
			this.whereUSEDbutton.UseVisualStyleBackColor = true;
			// 
			// open2Dbutton
			// 
			this.open2Dbutton.Enabled = false;
			this.open2Dbutton.Location = new System.Drawing.Point(10, 44);
			this.open2Dbutton.Name = "open2Dbutton";
			this.open2Dbutton.Size = new System.Drawing.Size(75, 23);
			this.open2Dbutton.TabIndex = 70;
			this.open2Dbutton.Text = "OpenFile";
			this.open2Dbutton.UseVisualStyleBackColor = true;
			this.open2Dbutton.Click += new System.EventHandler(this.Open2DbuttonClick);
			// 
			// OpenCADbutton
			// 
			this.OpenCADbutton.Enabled = false;
			this.OpenCADbutton.Location = new System.Drawing.Point(10, 44);
			this.OpenCADbutton.Name = "OpenCADbutton";
			this.OpenCADbutton.Size = new System.Drawing.Size(75, 23);
			this.OpenCADbutton.TabIndex = 64;
			this.OpenCADbutton.Text = "OpenFile";
			this.OpenCADbutton.UseVisualStyleBackColor = true;
			this.OpenCADbutton.Click += new System.EventHandler(this.OpenCADbuttonClick);
			// 
			// TwodBox
			// 
			this.TwodBox.Location = new System.Drawing.Point(10, 18);
			this.TwodBox.Name = "TwodBox";
			this.TwodBox.Size = new System.Drawing.Size(373, 20);
			this.TwodBox.TabIndex = 69;
			// 
			// ThreedBox
			// 
			this.ThreedBox.Location = new System.Drawing.Point(9, 19);
			this.ThreedBox.Name = "ThreedBox";
			this.ThreedBox.Size = new System.Drawing.Size(388, 20);
			this.ThreedBox.TabIndex = 63;
			// 
			// groupBox2
			// 
			this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
			this.groupBox2.Controls.Add(this.Checkout_2D);
			this.groupBox2.Controls.Add(this.TwodBox);
			this.groupBox2.Controls.Add(this.open2Dbutton);
			this.groupBox2.Controls.Add(this.where2Dbutton);
			this.groupBox2.Location = new System.Drawing.Point(423, 117);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(389, 81);
			this.groupBox2.TabIndex = 73;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "2D - CAD file";
			// 
			// Checkout_2D
			// 
			this.Checkout_2D.Enabled = false;
			this.Checkout_2D.Location = new System.Drawing.Point(91, 44);
			this.Checkout_2D.Name = "Checkout_2D";
			this.Checkout_2D.Size = new System.Drawing.Size(64, 37);
			this.Checkout_2D.TabIndex = 97;
			this.Checkout_2D.Text = "CheckOut\r\n2D";
			this.Checkout_2D.UseVisualStyleBackColor = true;
			this.Checkout_2D.Click += new System.EventHandler(this.Checkout_2DClick);
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
			this.groupBox1.Controls.Add(this.Checkout_3D);
			this.groupBox1.Controls.Add(this.ThreedBox);
			this.groupBox1.Controls.Add(this.OpenCADbutton);
			this.groupBox1.Controls.Add(this.whereUSEDbutton);
			this.groupBox1.Location = new System.Drawing.Point(11, 117);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(404, 81);
			this.groupBox1.TabIndex = 68;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "3D - CAD file";
			// 
			// Checkout_3D
			// 
			this.Checkout_3D.Enabled = false;
			this.Checkout_3D.Location = new System.Drawing.Point(100, 40);
			this.Checkout_3D.Name = "Checkout_3D";
			this.Checkout_3D.Size = new System.Drawing.Size(64, 37);
			this.Checkout_3D.TabIndex = 96;
			this.Checkout_3D.Text = "CheckOut\r\n3D";
			this.Checkout_3D.UseVisualStyleBackColor = true;
			this.Checkout_3D.Click += new System.EventHandler(this.Checkout_3DClick);
			// 
			// WhereUsed
			// 
			this.WhereUsed.Location = new System.Drawing.Point(7, 60);
			this.WhereUsed.Name = "WhereUsed";
			this.WhereUsed.Size = new System.Drawing.Size(75, 23);
			this.WhereUsed.TabIndex = 67;
			this.WhereUsed.Text = "Where Used";
			this.WhereUsed.UseVisualStyleBackColor = true;
			// 
			// DesignerBox
			// 
			this.DesignerBox.Location = new System.Drawing.Point(689, 33);
			this.DesignerBox.Name = "DesignerBox";
			this.DesignerBox.Size = new System.Drawing.Size(126, 20);
			this.DesignerBox.TabIndex = 61;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(689, 17);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(100, 23);
			this.label10.TabIndex = 62;
			this.label10.Text = "Designer";
			// 
			// DateBox
			// 
			this.DateBox.Location = new System.Drawing.Point(596, 33);
			this.DateBox.Name = "DateBox";
			this.DateBox.Size = new System.Drawing.Size(87, 20);
			this.DateBox.TabIndex = 59;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(595, 16);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(100, 23);
			this.label9.TabIndex = 60;
			this.label9.Text = "Date";
			// 
			// RevBox
			// 
			this.RevBox.Location = new System.Drawing.Point(525, 33);
			this.RevBox.Name = "RevBox";
			this.RevBox.Size = new System.Drawing.Size(64, 20);
			this.RevBox.TabIndex = 57;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(525, 17);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(100, 23);
			this.label8.TabIndex = 58;
			this.label8.Text = "Rev";
			// 
			// StatusBox
			// 
			this.StatusBox.Location = new System.Drawing.Point(394, 33);
			this.StatusBox.Name = "StatusBox";
			this.StatusBox.Size = new System.Drawing.Size(126, 20);
			this.StatusBox.TabIndex = 55;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(395, 17);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 23);
			this.label7.TabIndex = 56;
			this.label7.Text = "Status";
			// 
			// NameBox
			// 
			this.NameBox.Location = new System.Drawing.Point(111, 34);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(278, 20);
			this.NameBox.TabIndex = 53;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(112, 18);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 23);
			this.label6.TabIndex = 54;
			this.label6.Text = "Name";
			// 
			// CodeBox
			// 
			this.CodeBox.Location = new System.Drawing.Point(6, 34);
			this.CodeBox.Name = "CodeBox";
			this.CodeBox.Size = new System.Drawing.Size(100, 20);
			this.CodeBox.TabIndex = 51;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(7, 18);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 23);
			this.label5.TabIndex = 52;
			this.label5.Text = "CODE";
			// 
			// groupBox5
			// 
			this.groupBox5.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.groupBox5.Controls.Add(this.DesignerBox);
			this.groupBox5.Controls.Add(this.label10);
			this.groupBox5.Controls.Add(this.NameBox);
			this.groupBox5.Controls.Add(this.DateBox);
			this.groupBox5.Controls.Add(this.WhereUsed);
			this.groupBox5.Controls.Add(this.groupBox3);
			this.groupBox5.Controls.Add(this.label9);
			this.groupBox5.Controls.Add(this.supplierBox);
			this.groupBox5.Controls.Add(this.label21);
			this.groupBox5.Controls.Add(this.coatingBox);
			this.groupBox5.Controls.Add(this.groupBox4);
			this.groupBox5.Controls.Add(this.label20);
			this.groupBox5.Controls.Add(this.ttreatmentBox);
			this.groupBox5.Controls.Add(this.label19);
			this.groupBox5.Controls.Add(this.materialBox);
			this.groupBox5.Controls.Add(this.label18);
			this.groupBox5.Controls.Add(this.groupBox2);
			this.groupBox5.Controls.Add(this.weightBox);
			this.groupBox5.Controls.Add(this.label17);
			this.groupBox5.Controls.Add(this.CodeBox);
			this.groupBox5.Controls.Add(this.label5);
			this.groupBox5.Controls.Add(this.label6);
			this.groupBox5.Controls.Add(this.StatusBox);
			this.groupBox5.Controls.Add(this.label7);
			this.groupBox5.Controls.Add(this.RevBox);
			this.groupBox5.Controls.Add(this.label8);
			this.groupBox5.Controls.Add(this.groupBox1);
			this.groupBox5.Enabled = false;
			this.groupBox5.Location = new System.Drawing.Point(7, 223);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(882, 305);
			this.groupBox5.TabIndex = 84;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Component attributes";
			// 
			// supplierBox
			// 
			this.supplierBox.Location = new System.Drawing.Point(650, 75);
			this.supplierBox.Name = "supplierBox";
			this.supplierBox.Size = new System.Drawing.Size(162, 20);
			this.supplierBox.TabIndex = 92;
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(650, 59);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(100, 23);
			this.label21.TabIndex = 93;
			this.label21.Text = "Supplier";
			// 
			// coatingBox
			// 
			this.coatingBox.Location = new System.Drawing.Point(501, 75);
			this.coatingBox.Name = "coatingBox";
			this.coatingBox.Size = new System.Drawing.Size(143, 20);
			this.coatingBox.TabIndex = 90;
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(501, 59);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(100, 23);
			this.label20.TabIndex = 91;
			this.label20.Text = "Coating";
			// 
			// ttreatmentBox
			// 
			this.ttreatmentBox.Location = new System.Drawing.Point(377, 75);
			this.ttreatmentBox.Name = "ttreatmentBox";
			this.ttreatmentBox.Size = new System.Drawing.Size(118, 20);
			this.ttreatmentBox.TabIndex = 90;
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(377, 59);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(100, 23);
			this.label19.TabIndex = 91;
			this.label19.Text = "Termal Treatment";
			// 
			// materialBox
			// 
			this.materialBox.Location = new System.Drawing.Point(237, 75);
			this.materialBox.Name = "materialBox";
			this.materialBox.Size = new System.Drawing.Size(134, 20);
			this.materialBox.TabIndex = 90;
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(237, 59);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(100, 23);
			this.label18.TabIndex = 91;
			this.label18.Text = "Material";
			// 
			// weightBox
			// 
			this.weightBox.Location = new System.Drawing.Point(111, 75);
			this.weightBox.Name = "weightBox";
			this.weightBox.Size = new System.Drawing.Size(120, 20);
			this.weightBox.TabIndex = 88;
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(111, 59);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(100, 23);
			this.label17.TabIndex = 89;
			this.label17.Text = "Weight";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(16, 13);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(175, 175);
			this.pictureBox1.TabIndex = 88;
			this.pictureBox1.TabStop = false;
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.famstatusBox);
			this.groupBox6.Controls.Add(this.label11);
			this.groupBox6.Controls.Add(this.FAM_Box);
			this.groupBox6.Location = new System.Drawing.Point(6, 10);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(279, 98);
			this.groupBox6.TabIndex = 85;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Family";
			// 
			// famstatusBox
			// 
			this.famstatusBox.Enabled = false;
			this.famstatusBox.Location = new System.Drawing.Point(6, 56);
			this.famstatusBox.Name = "famstatusBox";
			this.famstatusBox.Size = new System.Drawing.Size(126, 20);
			this.famstatusBox.TabIndex = 88;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(6, 40);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(100, 23);
			this.label11.TabIndex = 89;
			this.label11.Text = "Status";
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.ProjectCodeBox);
			this.groupBox7.Controls.Add(this.projectstatusBox);
			this.groupBox7.Controls.Add(this.label3);
			this.groupBox7.Controls.Add(this.projectManagerBox);
			this.groupBox7.Controls.Add(this.label2);
			this.groupBox7.Controls.Add(this.label1);
			this.groupBox7.Controls.Add(this.PRJ_Box);
			this.groupBox7.Enabled = false;
			this.groupBox7.Location = new System.Drawing.Point(288, 11);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(283, 167);
			this.groupBox7.TabIndex = 86;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Project";
			// 
			// projectstatusBox
			// 
			this.projectstatusBox.Location = new System.Drawing.Point(6, 91);
			this.projectstatusBox.Name = "projectstatusBox";
			this.projectstatusBox.Size = new System.Drawing.Size(126, 20);
			this.projectstatusBox.TabIndex = 59;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 75);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 60;
			this.label3.Text = "Status";
			// 
			// projectManagerBox
			// 
			this.projectManagerBox.Location = new System.Drawing.Point(6, 132);
			this.projectManagerBox.Name = "projectManagerBox";
			this.projectManagerBox.Size = new System.Drawing.Size(270, 20);
			this.projectManagerBox.TabIndex = 57;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(2, 116);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 58;
			this.label2.Text = "Project Manager";
			// 
			// ProjectCodeBox
			// 
			this.ProjectCodeBox.Location = new System.Drawing.Point(6, 56);
			this.ProjectCodeBox.Name = "ProjectCodeBox";
			this.ProjectCodeBox.Size = new System.Drawing.Size(270, 20);
			this.ProjectCodeBox.TabIndex = 55;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(2, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 56;
			this.label1.Text = "Project Code";
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.button18);
			this.groupBox8.Controls.Add(this.button6);
			this.groupBox8.Controls.Add(this.drawingfilenameBox);
			this.groupBox8.Controls.Add(this.drawingdateBox);
			this.groupBox8.Controls.Add(this.label16);
			this.groupBox8.Controls.Add(this.label15);
			this.groupBox8.Controls.Add(this.drawingRevBox);
			this.groupBox8.Controls.Add(this.drawingBox);
			this.groupBox8.Controls.Add(this.label14);
			this.groupBox8.Controls.Add(this.textBox3);
			this.groupBox8.Controls.Add(this.label13);
			this.groupBox8.Controls.Add(this.PROD_Box);
			this.groupBox8.Controls.Add(this.label12);
			this.groupBox8.Enabled = false;
			this.groupBox8.Location = new System.Drawing.Point(576, 11);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(310, 206);
			this.groupBox8.TabIndex = 87;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Product";
			// 
			// button18
			// 
			this.button18.Enabled = false;
			this.button18.Location = new System.Drawing.Point(214, 53);
			this.button18.Name = "button18";
			this.button18.Size = new System.Drawing.Size(64, 37);
			this.button18.TabIndex = 95;
			this.button18.Text = "CheckOut\r\nPRJ";
			this.button18.UseVisualStyleBackColor = true;
			this.button18.Click += new System.EventHandler(this.Button18Click);
			// 
			// button6
			// 
			this.button6.Enabled = false;
			this.button6.Location = new System.Drawing.Point(137, 55);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(58, 23);
			this.button6.TabIndex = 94;
			this.button6.Text = "Open 2D";
			this.button6.UseVisualStyleBackColor = true;
			// 
			// drawingfilenameBox
			// 
			this.drawingfilenameBox.Location = new System.Drawing.Point(8, 174);
			this.drawingfilenameBox.Name = "drawingfilenameBox";
			this.drawingfilenameBox.Size = new System.Drawing.Size(270, 20);
			this.drawingfilenameBox.TabIndex = 90;
			// 
			// drawingdateBox
			// 
			this.drawingdateBox.Location = new System.Drawing.Point(140, 135);
			this.drawingdateBox.Name = "drawingdateBox";
			this.drawingdateBox.Size = new System.Drawing.Size(136, 20);
			this.drawingdateBox.TabIndex = 92;
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(4, 158);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(100, 23);
			this.label16.TabIndex = 91;
			this.label16.Text = "Drawing filename";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(140, 119);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(100, 23);
			this.label15.TabIndex = 93;
			this.label15.Text = "Drawing Date";
			// 
			// drawingRevBox
			// 
			this.drawingRevBox.Location = new System.Drawing.Point(8, 135);
			this.drawingRevBox.Name = "drawingRevBox";
			this.drawingRevBox.Size = new System.Drawing.Size(126, 20);
			this.drawingRevBox.TabIndex = 90;
			// 
			// drawingBox
			// 
			this.drawingBox.Location = new System.Drawing.Point(8, 96);
			this.drawingBox.Name = "drawingBox";
			this.drawingBox.Size = new System.Drawing.Size(270, 20);
			this.drawingBox.TabIndex = 88;
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(8, 119);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(100, 23);
			this.label14.TabIndex = 91;
			this.label14.Text = "Drawing Rev";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(6, 55);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(126, 20);
			this.textBox3.TabIndex = 88;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(4, 80);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(100, 23);
			this.label13.TabIndex = 89;
			this.label13.Text = "Drawing";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(6, 39);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(100, 23);
			this.label12.TabIndex = 89;
			this.label12.Text = "Status";
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(17, 114);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(75, 23);
			this.button5.TabIndex = 89;
			this.button5.Text = "CAD dir";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.Button5Click);
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(17, 141);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(75, 23);
			this.button8.TabIndex = 90;
			this.button8.Text = "PDF dir";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.Button8Click);
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(18, 169);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(75, 23);
			this.button10.TabIndex = 91;
			this.button10.Text = "STEP dir";
			this.button10.UseVisualStyleBackColor = true;
			this.button10.Click += new System.EventHandler(this.Button10Click);
			// 
			// groupBox9
			// 
			this.groupBox9.Controls.Add(this.pictureBox1);
			this.groupBox9.Location = new System.Drawing.Point(895, 327);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new System.Drawing.Size(197, 201);
			this.groupBox9.TabIndex = 92;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "picture";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.FindFilesTab);
			this.tabControl1.Controls.Add(this.ConfigTab);
			this.tabControl1.Location = new System.Drawing.Point(1, 6);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1201, 585);
			this.tabControl1.TabIndex = 93;
			// 
			// FindFilesTab
			// 
			this.FindFilesTab.Controls.Add(this.PART_Box);
			this.FindFilesTab.Controls.Add(this.groupBox6);
			this.FindFilesTab.Controls.Add(this.groupBox9);
			this.FindFilesTab.Controls.Add(this.groupBox7);
			this.FindFilesTab.Controls.Add(this.groupBox5);
			this.FindFilesTab.Controls.Add(this.button10);
			this.FindFilesTab.Controls.Add(this.groupBox8);
			this.FindFilesTab.Controls.Add(this.button8);
			this.FindFilesTab.Controls.Add(this.label4);
			this.FindFilesTab.Controls.Add(this.button5);
			this.FindFilesTab.Location = new System.Drawing.Point(4, 22);
			this.FindFilesTab.Name = "FindFilesTab";
			this.FindFilesTab.Padding = new System.Windows.Forms.Padding(3);
			this.FindFilesTab.Size = new System.Drawing.Size(1193, 559);
			this.FindFilesTab.TabIndex = 0;
			this.FindFilesTab.Text = "PDM";
			this.FindFilesTab.UseVisualStyleBackColor = true;
			// 
			// ConfigTab
			// 
			this.ConfigTab.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ConfigTab.BackgroundImage")));
			this.ConfigTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.ConfigTab.Controls.Add(this.groupBox10);
			this.ConfigTab.Location = new System.Drawing.Point(4, 22);
			this.ConfigTab.Name = "ConfigTab";
			this.ConfigTab.Padding = new System.Windows.Forms.Padding(3);
			this.ConfigTab.Size = new System.Drawing.Size(1193, 559);
			this.ConfigTab.TabIndex = 1;
			this.ConfigTab.Text = "Config";
			this.ConfigTab.UseVisualStyleBackColor = true;
			// 
			// groupBox10
			// 
			this.groupBox10.Controls.Add(this.ProdDrawingDIR);
			this.groupBox10.Controls.Add(this.label27);
			this.groupBox10.Controls.Add(this.button13);
			this.groupBox10.Controls.Add(this.label26);
			this.groupBox10.Controls.Add(this.JPGdirBox);
			this.groupBox10.Controls.Add(this.label24);
			this.groupBox10.Controls.Add(this.StepDirBox);
			this.groupBox10.Controls.Add(this.PDFdirBox);
			this.groupBox10.Controls.Add(this.label25);
			this.groupBox10.Controls.Add(this.CADdirTextbox);
			this.groupBox10.Controls.Add(this.label23);
			this.groupBox10.Controls.Add(this.label22);
			this.groupBox10.Controls.Add(this.button11);
			this.groupBox10.Controls.Add(this.button12);
			this.groupBox10.Controls.Add(this.button9);
			this.groupBox10.Controls.Add(this.button7);
			this.groupBox10.Controls.Add(this.button4);
			this.groupBox10.Location = new System.Drawing.Point(3, 200);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new System.Drawing.Size(469, 275);
			this.groupBox10.TabIndex = 27;
			this.groupBox10.TabStop = false;
			this.groupBox10.Text = "Drectories";
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(348, 64);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(113, 134);
			this.label26.TabIndex = 27;
			this.label26.Text = "Note:\r\nI assume that PDF dir, STEP dir and JPG dir are subdir of CAD dir.\r\n\r\nThan" +
	"k you";
			// 
			// JPGdirBox
			// 
			this.JPGdirBox.Location = new System.Drawing.Point(6, 139);
			this.JPGdirBox.Name = "JPGdirBox";
			this.JPGdirBox.Size = new System.Drawing.Size(255, 20);
			this.JPGdirBox.TabIndex = 21;
			// 
			// label24
			// 
			this.label24.Location = new System.Drawing.Point(6, 125);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(100, 23);
			this.label24.TabIndex = 20;
			this.label24.Text = "JPG dir";
			// 
			// StepDirBox
			// 
			this.StepDirBox.Location = new System.Drawing.Point(6, 102);
			this.StepDirBox.Name = "StepDirBox";
			this.StepDirBox.Size = new System.Drawing.Size(255, 20);
			this.StepDirBox.TabIndex = 19;
			// 
			// PDFdirBox
			// 
			this.PDFdirBox.Location = new System.Drawing.Point(6, 66);
			this.PDFdirBox.Name = "PDFdirBox";
			this.PDFdirBox.Size = new System.Drawing.Size(255, 20);
			this.PDFdirBox.TabIndex = 17;
			// 
			// label25
			// 
			this.label25.Location = new System.Drawing.Point(6, 89);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(100, 23);
			this.label25.TabIndex = 18;
			this.label25.Text = "STEP dir";
			// 
			// CADdirTextbox
			// 
			this.CADdirTextbox.Location = new System.Drawing.Point(6, 29);
			this.CADdirTextbox.Name = "CADdirTextbox";
			this.CADdirTextbox.Size = new System.Drawing.Size(255, 20);
			this.CADdirTextbox.TabIndex = 15;
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(6, 52);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(100, 23);
			this.label23.TabIndex = 16;
			this.label23.Text = "PDF dir";
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(6, 16);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(100, 23);
			this.label22.TabIndex = 14;
			this.label22.Text = "CAD dir";
			// 
			// button11
			// 
			this.button11.Location = new System.Drawing.Point(267, 139);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(75, 23);
			this.button11.TabIndex = 25;
			this.button11.Text = "Change";
			this.button11.UseVisualStyleBackColor = true;
			this.button11.Click += new System.EventHandler(this.Button11Click);
			// 
			// button12
			// 
			this.button12.Location = new System.Drawing.Point(6, 246);
			this.button12.Name = "button12";
			this.button12.Size = new System.Drawing.Size(75, 23);
			this.button12.TabIndex = 26;
			this.button12.Text = "Save cfg";
			this.button12.UseVisualStyleBackColor = true;
			this.button12.Click += new System.EventHandler(this.Button12Click);
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(267, 102);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(75, 23);
			this.button9.TabIndex = 24;
			this.button9.Text = "Change";
			this.button9.UseVisualStyleBackColor = true;
			this.button9.Click += new System.EventHandler(this.Button9Click);
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(267, 64);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(75, 23);
			this.button7.TabIndex = 23;
			this.button7.Text = "Change";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.Button7Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(267, 27);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 23);
			this.button4.TabIndex = 22;
			this.button4.Text = "Change";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.Button4Click);
			// 
			// ProdDrawingDIR
			// 
			this.ProdDrawingDIR.Location = new System.Drawing.Point(6, 199);
			this.ProdDrawingDIR.Name = "ProdDrawingDIR";
			this.ProdDrawingDIR.Size = new System.Drawing.Size(255, 20);
			this.ProdDrawingDIR.TabIndex = 29;
			// 
			// label27
			// 
			this.label27.Location = new System.Drawing.Point(6, 185);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(255, 23);
			this.label27.TabIndex = 28;
			this.label27.Text = "Product (customer) drawing dir";
			// 
			// button13
			// 
			this.button13.Location = new System.Drawing.Point(267, 199);
			this.button13.Name = "button13";
			this.button13.Size = new System.Drawing.Size(75, 23);
			this.button13.TabIndex = 30;
			this.button13.Text = "Change";
			this.button13.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1272, 655);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.PartIndexText);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.tabControl1);
			this.Name = "MainForm";
			this.Text = "Would-be PDM";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			this.groupBox8.ResumeLayout(false);
			this.groupBox8.PerformLayout();
			this.groupBox9.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.FindFilesTab.ResumeLayout(false);
			this.ConfigTab.ResumeLayout(false);
			this.groupBox10.ResumeLayout(false);
			this.groupBox10.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
