﻿/*
 * Created by SharpDevelop.
 * User: RoBartol
 * Date: 30/11/2015
 * Time: 18:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Text;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32; //for regedit (tortoise)
using System.Data;
using System.Xml; 
using System.Threading; //for splashscreen
//using INFITF;
//using System.Runtime.InteropServices; //INFITF;
//using System.Linq;
namespace wina
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form

	{
		const string Xml_prj_list = ("PRJList.xml");
		const string Xml_prt_list = ("PRTList.xml");
		const string WouldBeXML = ("WouldBeXML.xml");
		const string WouldBeCFG = ("WouldBeCFG.xml");
		const string WouldBeFILTER = ("WouldBeFILTER.xml");
		const string CatiaMacroDir="Macros\\Catia", PdfExportDir="PdfExport", STEPExportDir="STEPExport", JPGExportDir="JPGExport";
		const string temporarylistforpdf="zztmppdf.txt", temporarylistforjpg="zztmpjpg.txt", temporarylistforstp="zztmpstp.txt";
		const string  macroexportPDF="ExportPDF.CATScript", macroexportJPG="ExportJPG.CATScript", macroexportSTEP="ExportSTEP.CATScript"; //todo
		public string CAD_DIR_Location = ("WouldBePDMData");
		public string StepFolder="OUT";
		public string PdfFolder="OUT";
		public string ImageFolder="JPG";
		string PROD_selected = "";
		string PRT_selected = "";
		public int EEcounter=0;
		public string family_node_value, family_node_name, Family_level_name;
		public string prj_proID, prj_proName ;
		public string prod_proID , prod_proName ;
		public string prt_proID , prt_proName ;
		public string SelectedToOpen3D ="", SelectedToOpen2D ="", SelectedToOpenPdf ="" , SelectedToOpenStep ="";
		public string InstallPathSVN = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\TortoiseSVN" , "ProcPath", null);
		public string CATDLLPath_TOP ="";
		public string EnvironmentName_TOP = "", EnvironmentName_Export="Export.txt" , EnvironmentDir_Export=""; 
        public string ApplicationPath_TOP ="" ;
        public string CATDLLPath_LOW = "" ; 
        public string EnvironmentName_LOW = ""; 
        public string ApplicationPath_LOW =""; 
        public string Ug_NX_TOP_exe="";
        public string Ug_NX_LOW_exe="";
		public string filetocheckout = "";
		public DataSet ds = new DataSet();
        public DataTable Famlytable , Prjtable, Prodtable, Parttable, Matchtable, Filtertable, ExportPDFTable, ExportSTEPTable;
        public DataRow Familyrow , Prjrow, Prodrow, Partrow, Matchrow, Filterrow, ExportPDFrow, ExportSTEProw;
        public int famstatusBoxPRE=0, prjstatusBoxPRE=0, prodstatusBoxPRE=0;
        public int Addfamiliystatus=0, Addprojectstatus=0 , Addproductstatus=0 , partwasinvisible=0 , Addpartstatus=0;
        public string Family_pre_update="", Project_pre_update="", Product_pre_update="";
        public string Search1_textfilter="", Search2_textfilter="", Search3_textfilter="", Search4_textfilter="";
        public string Search_codefilter1="", Search_codefilter2="", Search_codefilter3="";
        public string Search_codefilter4="", Search_codefilter5="", Search_codefilter6="";
        public string ExeDirFull=System.AppDomain.CurrentDomain.BaseDirectory.ToString();
        
        
        
               
        
        
        
		public MainForm()
		{

			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}

		void MainFormLoad(object sender, EventArgs e)
			{
			InitializeValues();
//			textBox1.Clear();

			
            Famlytable = new DataTable();
            Famlytable.Columns.Add(new DataColumn("ID", Type.GetType("System.String")));
            Famlytable.Columns.Add(new DataColumn("Name", Type.GetType("System.String")));
            Famlytable.Columns.Add(new DataColumn("Status", Type.GetType("System.String")));
           
            Prjtable = new DataTable();        
            Prjtable.Columns.Add(new DataColumn("ID", Type.GetType("System.String")));
            Prjtable.Columns.Add(new DataColumn("Name", Type.GetType("System.String")));
            Prjtable.Columns.Add(new DataColumn("Status", Type.GetType("System.String")));
            Prjtable.Columns.Add(new DataColumn("prjcode", Type.GetType("System.String")));
            Prjtable.Columns.Add(new DataColumn("IDprjFam", Type.GetType("System.String")));
            Prjtable.Columns.Add(new DataColumn("Customer", Type.GetType("System.String")));
            Prjtable.Columns.Add(new DataColumn("CusCode", Type.GetType("System.String")));
            Prjtable.Columns.Add(new DataColumn("PM", Type.GetType("System.String"))); 
            	
            Prodtable  = new DataTable();
            Prodtable.Columns.Add(new DataColumn("ProductName", Type.GetType("System.String")));
            Prodtable.Columns.Add(new DataColumn("ProductCar", Type.GetType("System.String")));
            Prodtable.Columns.Add(new DataColumn("ProductCode", Type.GetType("System.String")));
            Prodtable.Columns.Add(new DataColumn("ProductStatus", Type.GetType("System.String")));
            Prodtable.Columns.Add(new DataColumn("ProjectCode", Type.GetType("System.String")));
            Prodtable.Columns.Add(new DataColumn("Product2DName", Type.GetType("System.String")));
            Prodtable.Columns.Add(new DataColumn("Product2DFilename", Type.GetType("System.String")));
            Prodtable.Columns.Add(new DataColumn("Product2DREV", Type.GetType("System.String")));
            Prodtable.Columns.Add(new DataColumn("Product2DDate", Type.GetType("System.String")));

            Parttable  = new DataTable();
            Parttable.Columns.Add(new DataColumn("PartCode", Type.GetType("System.String")));
            Parttable.Columns.Add(new DataColumn("PartName", Type.GetType("System.String")));
            Parttable.Columns.Add(new DataColumn("PartStatus", Type.GetType("System.String")));
            Parttable.Columns.Add(new DataColumn("PartRev", Type.GetType("System.String")));
            Parttable.Columns.Add(new DataColumn("PartDate", Type.GetType("System.String")));
            Parttable.Columns.Add(new DataColumn("PartDesigner", Type.GetType("System.String")));
            Parttable.Columns.Add(new DataColumn("PartTHREE_D", Type.GetType("System.String")));
            Parttable.Columns.Add(new DataColumn("PartStep", Type.GetType("System.String")));
            Parttable.Columns.Add(new DataColumn("PartTWO_D", Type.GetType("System.String")));
            Parttable.Columns.Add(new DataColumn("PartPdf", Type.GetType("System.String")));
            Parttable.Columns.Add(new DataColumn("PartWeight", Type.GetType("System.String")));
            Parttable.Columns.Add(new DataColumn("PartMaterial", Type.GetType("System.String")));
            Parttable.Columns.Add(new DataColumn("PartTThreat", Type.GetType("System.String")));
            Parttable.Columns.Add(new DataColumn("PartCoat", Type.GetType("System.String")));
            Parttable.Columns.Add(new DataColumn("PartSupplyer", Type.GetType("System.String")));
            Parttable.Columns.Add(new DataColumn("PartImage", Type.GetType("System.String")));
  
            Matchtable= new DataTable();
            Matchtable.Columns.Add(new DataColumn("PartListed", Type.GetType("System.String")));
            Matchtable.Columns.Add(new DataColumn("ProjectListed", Type.GetType("System.String")));
            
            Filtertable= new DataTable();
            Filtertable.Columns.Add(new DataColumn("Project_Filter", Type.GetType("System.String")));
            Filtertable.Columns.Add(new DataColumn("FilterText1", Type.GetType("System.String")));
            Filtertable.Columns.Add(new DataColumn("FilterText2", Type.GetType("System.String")));
            Filtertable.Columns.Add(new DataColumn("FilterText3", Type.GetType("System.String")));
            Filtertable.Columns.Add(new DataColumn("FilterText4", Type.GetType("System.String")));
            Filtertable.Columns.Add(new DataColumn("FilterCode1", Type.GetType("System.String")));      
            Filtertable.Columns.Add(new DataColumn("FilterCode2", Type.GetType("System.String")));
            Filtertable.Columns.Add(new DataColumn("FilterCode3", Type.GetType("System.String")));
            Filtertable.Columns.Add(new DataColumn("FilterCode4", Type.GetType("System.String")));
            Filtertable.Columns.Add(new DataColumn("FilterCode5", Type.GetType("System.String")));
            Filtertable.Columns.Add(new DataColumn("FilterCode6", Type.GetType("System.String")));
            
            ExportPDFTable= new DataTable();
            ExportPDFTable.Columns.Add(new DataColumn("2Dfile", Type.GetType("System.String")));
            
            ExportSTEPTable= new DataTable();
            ExportSTEPTable.Columns.Add(new DataColumn("3Dfile", Type.GetType("System.String")));
            
            
if (File.Exists(WouldBeXML)){             
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(WouldBeXML);
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/WouldBePDM/FamilyList/Family");
            foreach (XmlNode family_node in nodeList)
            {
			FAM_Box.Items.Add(family_node.SelectSingleNode("FamilyName").InnerText);   //to improve
			Familyrow = Famlytable.NewRow();
			Familyrow["ID"] = family_node.SelectSingleNode("FamilyID").InnerText ;
            Familyrow["Name"] = family_node.SelectSingleNode("FamilyName").InnerText ;
            Familyrow["Status"] = family_node.SelectSingleNode("FamilyStatus").InnerText ;
            Famlytable.Rows.Add(Familyrow);
            }   
            XmlNodeList nodeList2 = xmlDoc.DocumentElement.SelectNodes("/WouldBePDM/ProjectList/Project");
            foreach (XmlNode projectnode in nodeList2)
            {
			Prjrow = Prjtable.NewRow();
			Prjrow["ID"] = projectnode.SelectSingleNode("ProjectID").InnerText ;
            Prjrow["Name"] = projectnode.SelectSingleNode("ProjectName").InnerText ;
            Prjrow["Status"] = projectnode.SelectSingleNode("ProjectStatus").InnerText ;
			Prjrow["prjcode"] = projectnode.SelectSingleNode("ProjectCode").InnerText ;
			Prjrow["IDprjFam"] = projectnode.SelectSingleNode("FamilyID").InnerText ;
			Prjrow["Customer"] = projectnode.SelectSingleNode("CustomerName").InnerText ;
			Prjrow["CusCode"] = projectnode.SelectSingleNode("CustomerCode").InnerText ;
			Prjrow["PM"] = projectnode.SelectSingleNode("ProjectManager").InnerText ;
            Prjtable.Rows.Add(Prjrow);
			}
			XmlNodeList nodeList3 = xmlDoc.DocumentElement.SelectNodes("/WouldBePDM/ProductList/Product");
            foreach (XmlNode product_node in nodeList3)
            {
            	Prodrow=Prodtable.NewRow();
            	Prodrow["ProductName"]= product_node.SelectSingleNode("ProductName").InnerText ;
            	Prodrow["ProductCar"]= product_node.SelectSingleNode("ProductCar").InnerText ;
            	Prodrow["ProductCode"]= product_node.SelectSingleNode("ProductCode").InnerText ;
            	Prodrow["ProductStatus"]= product_node.SelectSingleNode("ProductStatus").InnerText ;
            	Prodrow["ProjectCode"]= product_node.SelectSingleNode("ProjectCode").InnerText ;
            	Prodrow["Product2DName"]= product_node.SelectSingleNode("Product2DName").InnerText ;
            	Prodrow["Product2DFilename"]= product_node.SelectSingleNode("Product2DFilename").InnerText ;
            	Prodrow["Product2DREV"]= product_node.SelectSingleNode("Product2DREV").InnerText ;
            	Prodrow["Product2DDate"]= product_node.SelectSingleNode("Product2DDate").InnerText ;
			Prodtable.Rows.Add(Prodrow);
            }
			XmlNodeList nodeList4 = xmlDoc.DocumentElement.SelectNodes("/WouldBePDM/PartList/Component");
            foreach (XmlNode nodepart in nodeList4) //            foreach (XmlNode nodepart in nodeList)
            {
            	Partrow=Parttable.NewRow();
                Partrow["PartCode"]= nodepart.SelectSingleNode("PartCode").InnerText;
             	Partrow["PartName"]= nodepart.SelectSingleNode("PartName").InnerText ;
				Partrow["PartStatus"]= nodepart.SelectSingleNode("PartStatus").InnerText ;
                Partrow["PartRev"]= nodepart.SelectSingleNode("PartRev").InnerText ;
                Partrow["PartDate"]= nodepart.SelectSingleNode("PartDate").InnerText ;
                Partrow["PartDesigner"]= nodepart.SelectSingleNode("PartDesigner").InnerText ;
              	Partrow["PartTHREE_D"]= nodepart.SelectSingleNode("PartTHREE_D").InnerText ;
                Partrow["PartStep"]= nodepart.SelectSingleNode("PartStep").InnerText ;
                Partrow["PartTWO_D"]= nodepart.SelectSingleNode("PartTWO_D").InnerText ;
                Partrow["PartPdf"]= nodepart.SelectSingleNode("PartPdf").InnerText ;
                Partrow["PartWeight"]= nodepart.SelectSingleNode("PartWeight").InnerText ;
                Partrow["PartMaterial"]= nodepart.SelectSingleNode("PartMaterial").InnerText ;
                Partrow["PartTThreat"]= nodepart.SelectSingleNode("PartTThreat").InnerText ;
                Partrow["PartCoat"]= nodepart.SelectSingleNode("PartCoat").InnerText ;
                Partrow["PartSupplyer"]= nodepart.SelectSingleNode("PartSupplyer").InnerText ;
                Partrow["PartImage"]=nodepart.SelectSingleNode("PartImage").InnerText ;
                Parttable.Rows.Add(Partrow);
               }
            XmlNodeList nodeList5 = xmlDoc.DocumentElement.SelectNodes("/WouldBePDM/PartMatch/ComponentList");
            foreach (XmlNode matchnode in nodeList5)
            {
            Matchrow=Matchtable.NewRow();
            Matchrow["PartListed"]= matchnode.SelectSingleNode("PartListed").InnerText;
			Matchrow["ProjectListed"]= matchnode.SelectSingleNode("ProjectListed").InnerText;    
			Matchtable.Rows.Add(Matchrow);			
            }

            
            ds.Tables.Add(Famlytable); 
            ds.Tables.Add(Prjtable); 
            ds.Tables.Add(Prodtable); 
            ds.Tables.Add(Parttable); 
            ds.Tables.Add(Matchtable); 
        }
			else{FAM_Box.Enabled=false;}
		
		
			
			if (File.Exists(WouldBeFILTER)){             
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(WouldBeFILTER);
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/WouldBeFILTER/FilterList/Filters");
            foreach (XmlNode filetr_node in nodeList)
            {
//			FAM_Box.Items.Add(filetr_node.SelectSingleNode("FamilyName").InnerText);   //to improve
			Filterrow = Filtertable.NewRow();
			Filterrow["Project_Filter"] = filetr_node.SelectSingleNode("Project_Filter").InnerText ;
            Filterrow["FilterText1"] = filetr_node.SelectSingleNode("FilterText1").InnerText ;
            Filterrow["FilterText2"] = filetr_node.SelectSingleNode("FilterText2").InnerText ;
            Filterrow["FilterText3"] = filetr_node.SelectSingleNode("FilterText3").InnerText ;
            Filterrow["FilterText4"] = filetr_node.SelectSingleNode("FilterText4").InnerText ;
            Filterrow["FilterCode1"] = filetr_node.SelectSingleNode("FilterCode1").InnerText ;
            Filterrow["FilterCode2"] = filetr_node.SelectSingleNode("FilterCode2").InnerText ;
            Filterrow["FilterCode3"] = filetr_node.SelectSingleNode("FilterCode3").InnerText ;
            Filterrow["FilterCode4"] = filetr_node.SelectSingleNode("FilterCode4").InnerText ;
            Filterrow["FilterCode5"] = filetr_node.SelectSingleNode("FilterCode5").InnerText ;
            Filterrow["FilterCode6"] = filetr_node.SelectSingleNode("FilterCode6").InnerText ;
            Filtertable.Rows.Add(Filterrow);
            }   
		
			}
			
			
			if (File.Exists(CATDLLPath_TOP + "\\CATStart.exe")){button23.Enabled=true;}else{button23.Enabled=false;}
			if (File.Exists(CATDLLPath_LOW + "\\CATStart.exe")){button3.Enabled=true;}else{button3.Enabled=false;}
			if (File.Exists(Ug_NX_TOP_exe)){button31.Enabled=true;}else{button31.Enabled=false;}
			if (File.Exists(Ug_NX_LOW_exe)){button32.Enabled=true;}else{button32.Enabled=false;}
		
		
		
		
		}
		
		
		
        private void createNode(string pID, string pName, string pPrice, XmlTextWriter writer)
        {
            writer.WriteStartElement("Product");
            writer.WriteStartElement("Product_id");
            writer.WriteString(pID);
            writer.WriteEndElement();
            writer.WriteStartElement("Product_name");
            writer.WriteString(pName);
            writer.WriteEndElement();
            writer.WriteStartElement("Product_price");
            writer.WriteString(pPrice);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
		void Button2Click(object sender, EventArgs e)
		{
//				
			WouldBe_PDM_sharpdev.SplashScreen Splash = new WouldBe_PDM_sharpdev.SplashScreen();
			WouldBe_PDM_sharpdev.retsegge RetseGge = new WouldBe_PDM_sharpdev.retsegge();
//		    MessageBox.Show ("Timeout");
			
			if (EEcounter <= 2){EEcounter++;}
			if (EEcounter == 6){
		    	EEcounter=0;
		    	RetseGge.Show();
		    	WouldBe_PDM_sharpdev.retsegge.ActiveForm.Activate();
		    	RetseGge.Activate();
//		    	Application.Run(new WouldBe_PDM_sharpdev.retsegge());
		    }
			else{
			Splash.Show();
		    WouldBe_PDM_sharpdev.SplashScreen.ActiveForm.Activate();
		    Splash.Activate();
			}


		}//Buttonclick - to delete?
		// start select
		void PRJ_BoxSelectedIndexChanged(object sender, EventArgs e)
		{ GO_PRJ_BoxSelectedIndexChanged();		}  //select prj			
		void GO_PRJ_BoxSelectedIndexChanged()
		{		
			textBox5.Clear();
			
			Project_pre_update=PRJ_Box.SelectedItem.ToString();
            PART_Box.Items.Clear();
			clearprojectboxes();
			clearproductboxes();
			clearboxes();
			groupBox5.Enabled=false;
			button18.Enabled=false;
			button6.Enabled=false;
			textBox5.Text=(PRJ_Box.SelectedItem.ToString());
			string projectselectedID ="";
			button25.Enabled=true;

			PROD_Box.Items.Clear();
		    PROD_Box.Text=("Select a Product");
		    groupBox8.Enabled=true;
		    if (checkBoxPRJ.Checked==false){
		    	PROD_Box.Enabled=true;}
		    PART_Box.Text=("Select a Component");
		    PART_Box.Enabled=false;
//		    checkBoxPRJ.Checked=false;
		    checkBoxPROD.Checked=false;
		    checkBoxPRT.Checked=false;
//		    PartIndexText.Enabled=false;
            		
 foreach(DataRow dr in Prjtable.Rows) // search whole table
 	{
 		if(dr["Name"].ToString() == PRJ_Box.SelectedItem.ToString()) // if id==2  FAM_Box.SelectedItem.ToString()
    	{
        	projectselectedID= dr["ID"].ToString();
        	projectstatusBox.AppendText(dr["Status"].ToString());//---projectstatus);
			ProjectCodeBox.AppendText(dr["prjcode"].ToString());//---projectcode);
			textBox1.AppendText(dr["CusCode"].ToString());
			textBox2.AppendText(dr["Customer"].ToString());
			projectManagerBox.AppendText(dr["PM"].ToString());//---projectmanager);
			prjID.AppendText(projectselectedID);
     	}
	}
 foreach(DataRow dr in Prodtable.Rows) // search whole table
 	{
 	if(dr["ProjectCode"].ToString() == projectselectedID) // if id==2  FAM_Box.SelectedItem.ToString()
   	{PROD_Box.Items.Add(dr["ProductName"].ToString()); }
	}
		}
		void ComboBox1SelectedIndexChanged(object sender, EventArgs e)   //select family
		{Go_ComboBox1SelectedIndexChanged(); 		} // select family
		void Go_ComboBox1SelectedIndexChanged()
		{
		string familyname = "" ;
			string familyselectedID ="";
            string familystatus = "" ;
			famstatusBox.Clear();
			famID.Clear();
			PRJ_Box.Items.Clear();
	    	PRJ_Box.Text=("Select a Project");
	    	PRJ_Box.Enabled=true;
		    groupBox7.Enabled=true;
		    PROD_Box.Text=("Select a Product");
		    groupBox8.Enabled=false;
		    PART_Box.Text=("Select a Component");
		    PART_Box.Enabled=false;
//		    checkBoxPRJ.Checked=false;
//		    checkBoxPROD.Checked=false;
//		    checkBoxPRT.Checked=false;
		    if (checkBoxPRJ.Checked==true){
		    	checkBoxPRJ.Checked=false;
		    	CheckBoxPRJCheckedChanged(null , null);}
		    if (checkBoxPROD.Checked==true){
		    	checkBoxPROD.Checked=false;
		    	CheckBoxPRODCheckedChanged(null , null);}
		    if (checkBoxPRT.Checked==true){
		    	checkBoxPRT.Checked=false;
		    	CheckBoxPRTCheckedChanged(null , null);}
		    		    
//		    PartIndexText.Enabled=false;
		    clearboxes();
		    clearprojectboxes();
		    clearproductboxes();
		    groupBox5.Enabled=false;
            famstatusBox.Enabled=true;
            famID.Enabled=true;
            button19.Enabled=true;
          
 foreach(DataRow dr in Famlytable.Rows) // search whole table
 	{
 		if(dr["Name"].ToString() == FAM_Box.SelectedItem.ToString()) // if id==2  FAM_Box.SelectedItem.ToString()
    	{
    	familyselectedID= dr["ID"].ToString();//familyid;
//    	familyid=familyselectedID;
		familystatus= dr["Status"].ToString();
		familyname=dr["Name"].ToString();
		famstatusBox.AppendText(dr["Status"].ToString());
		famID.AppendText(dr["ID"].ToString());
        //dr["Product_name"] = "cde"; //change the name
        textBox4.Clear();
        textBox4.Text=FAM_Box.SelectedItem.ToString();
        Family_pre_update=FAM_Box.SelectedItem.ToString();
    	}
	}
 foreach(DataRow dr in Prjtable.Rows) // search whole table
 	{
 	if(dr["IDprjFam"].ToString() == familyselectedID) // if id==2  FAM_Box.SelectedItem.ToString()
   	{PRJ_Box.Items.Add(dr["Name"].ToString()); }
	}
		
		
		}		
		void PROD_BoxSelectedIndexChanged(object sender, EventArgs e)
		{GO_PROD_BoxSelectedIndexChanged();}  // select Prod
		void GO_PROD_BoxSelectedIndexChanged()
		{
		    clearboxes();
		    clearproductboxes();
		    PART_Box.Items.Clear();
		    ExportPDFTable.Rows.Clear();
		    ExportSTEPTable.Rows.Clear();
		    groupBox5.Enabled=false;
		    button18.Enabled=true;
		    button6.Enabled=true;
		    button27.Enabled=true;
		    button38.Enabled=true;
		    groupBox20.Enabled=true;

		    if (checkBoxPRJ.Checked==true){
		    	checkBoxPRJ.Checked=false;
		    	CheckBoxPRJCheckedChanged(null , null);}

		    if (checkBoxPRT.Checked==true){
		    	checkBoxPRT.Checked=false;
		    	CheckBoxPRTCheckedChanged(null , null);}

		    PROD_selected = PROD_Box.SelectedItem.ToString() ;

			string projectselectedID ="";

		    PART_Box.Text=("Select a Component");
		    if(checkBoxPROD.Checked==false){
		    	PART_Box.Enabled=true;}
//		    PartIndexText.Enabled=false;
			PROD_selected = PROD_Box.SelectedItem.ToString() ;
	//start copy	
 foreach(DataRow dr in Prodtable.Rows) // search whole table
 	{
 		if(dr["ProductName"].ToString() == PROD_Box.SelectedItem.ToString()) // if id==2  FAM_Box.SelectedItem.ToString()
    	{
			projectselectedID=dr["ProductCode"].ToString(); 
			drawingBox.AppendText(dr["Product2DName"].ToString()); //product2dname);
			drawingRevBox.AppendText(dr["Product2DREV"].ToString()); //product2drev);
			drawingdateBox.AppendText(dr["Product2DDate"].ToString()); //product2ddate);
			textBox3.AppendText(dr["ProductStatus"].ToString()); //productstatus);
			drawingfilenameBox.AppendText(dr["Product2DFilename"].ToString()); //product2dfilename);
			prodID.Text=((dr["ProductCode"].ToString()));
			carBOX.Text=((dr["ProductCar"].ToString()));
//            Prodtable.Columns.Add(new DataColumn("ProductCar", Type.GetType("System.String"))); // To add
//            Prodtable.Columns.Add(new DataColumn("ProductCode", Type.GetType("System.String"))); 
     	}
	}
 
  string drawing_full_file= CAD_DIR_Location + "\\" + PdfFolder + "\\" + drawingfilenameBox.Text.ToString();
  if (File.Exists(drawing_full_file)){button6.Enabled=true;} else{button6.Enabled=false;}
 foreach(DataRow dr in Matchtable.Rows) // search whole table
 	{
 	if(dr["ProjectListed"].ToString() == projectselectedID) // if id==2  FAM_Box.SelectedItem.ToString()
   	{PART_Box.Items.Add(dr["PartListed"].ToString());   	}
	}	
 
 CheckBOM.Enabled=true;

		}
		void PART_BoxSelectedIndexChanged(object sender, EventArgs e)
		{GO_PART_BoxSelectedIndexChanged();} //select part
		void GO_PART_BoxSelectedIndexChanged()
		{
			
//			textBox1.Clear();
//            textBox1.Text=("");
//			PartIndexText.Enabled=true;
//			PartIndexText.Clear() ;
			PRT_selected = PART_Box.SelectedItem.ToString() ;
			clearboxes();
			groupBox5.Enabled=true;
			button28.Enabled=true;
		    if (checkBoxPRJ.Checked==true){
		    	checkBoxPRJ.Checked=false;
		    	CheckBoxPRJCheckedChanged(null , null);}
		    if (checkBoxPROD.Checked==true){
		    	checkBoxPROD.Checked=false;
		    	CheckBoxPRODCheckedChanged(null , null);}
//		    if (checkBoxPRT.Checked==true){
//		    	checkBoxPRT.Checked=false;
//		    	CheckBoxPRTCheckedChanged(null , null);}
			
			
//			checkBoxPRJ.Checked=false;
//		    checkBoxPROD.Checked=false;
////		    checkBoxPRT.Checked=false;
			
//			textBox7.Text=(PART_Box.SelectedItem.ToString());
			 XmlDocument xmlDoc2 = new XmlDocument();
			xmlDoc2.Load(WouldBeXML);  

 foreach(DataRow dr in Parttable.Rows) // search whole table
 			{
 		if(dr["PartCode"].ToString() == PART_Box.SelectedItem.ToString()) //  if (  PRT_selected ==prtcode)
              {			
if (dr["PartCode"].ToString()!="NULL")
{CodeBox.AppendText(dr["PartCode"].ToString());}
if (dr["PartName"].ToString()!="NULL")
{NameBox.AppendText(dr["PartName"].ToString());}
if (dr["PartStatus"].ToString()!="NULL")
{StatusBox.AppendText(dr["PartStatus"].ToString());}
if (dr["PartRev"].ToString()!="NULL")
{RevBox.AppendText(dr["PartRev"].ToString());}
if (dr["PartDate"].ToString()!="NULL")
{DateBox.AppendText(dr["PartDate"].ToString());}
if (dr["PartDesigner"].ToString()!="NULL")
{DesignerBox.AppendText(dr["PartDesigner"].ToString());}
if (dr["PartTHREE_D"].ToString()!="NULL")
{ThreedBox.AppendText(dr["PartTHREE_D"].ToString());
SelectedToOpen3D =dr["PartTHREE_D"].ToString() ;}
if (dr["PartStep"].ToString()!="NULL")
{StepBox.AppendText(dr["PartStep"].ToString());
SelectedToOpenStep =dr["PartStep"].ToString();}
if (dr["PartTWO_D"].ToString()!="NULL")
{TwodBox.AppendText(dr["PartTWO_D"].ToString());
SelectedToOpen2D =dr["PartTWO_D"].ToString() ;}
if (dr["PartPdf"].ToString()!="NULL")
{PdfBox.AppendText(dr["PartPdf"].ToString());
SelectedToOpenPdf =dr["PartPdf"].ToString() ;}
if (dr["PartWeight"].ToString()!="NULL")
{weightBox.AppendText(dr["PartWeight"].ToString());}
if (dr["PartMaterial"].ToString()!="NULL")
{materialBox.AppendText(dr["PartMaterial"].ToString());}
if (dr["PartTThreat"].ToString()!="NULL")
{ttreatmentBox.AppendText(dr["PartTThreat"].ToString());}
if (dr["PartCoat"].ToString()!="NULL")
{coatingBox.AppendText(dr["PartCoat"].ToString());}
if (dr["PartSupplyer"].ToString()!="NULL")
{supplierBox.AppendText(dr["PartSupplyer"].ToString());}
//string twodfulldir=CAD_DIR_Location + "\\" + PdfFolder + "\\";

string fullfilejpgname=CAD_DIR_Location + "\\" + ImageFolder + "\\" + dr["PartImage"].ToString();//partimagefile;
if (File.Exists (fullfilejpgname) ) 
{
	pictureBox1.Image=Image.FromFile(fullfilejpgname);
//	jpegfile.Text=(fullfilejpgname);
	jpegfile.Text=(dr["PartImage"].ToString());
//	textBox1.AppendText(fullfilejpgname);
}
if (SelectedToOpen3D!="")
{Checkout_3D.Enabled=true;
	if (File.Exists(CAD_DIR_Location + "\\" + dr["PartTHREE_D"].ToString() )){OpenCADbutton.Enabled=true;}
//	OpenCADbutton.Enabled=true
//	whereUSEDbutton.Enabled=true;
//	generateSTEPbuttron.Enabled=false;
}
if (SelectedToOpen2D!="")
{Checkout_2D.Enabled=true;
	if (File.Exists(CAD_DIR_Location + "\\" + dr["PartTWO_D"].ToString() )){open2Dbutton.Enabled=true;}
//	open2Dbutton.Enabled=true;
//	where2Dbutton.Enabled=true;
generatePDFbutton.Enabled=true;
}
if (SelectedToOpenPdf!="")
{
	CheckOut_pdf.Enabled=true;
	if (File.Exists(CAD_DIR_Location + "\\" + PdfFolder + "\\" + dr["PartPdf"].ToString())){openPDFbutton.Enabled=true;
		generatePDFbutton.Enabled=false;}else{generatePDFbutton.Enabled=true;}
//	openPDFbutton.Enabled=true;
//generatePDFbutton.Enabled=false;
}
if(SelectedToOpenStep!="")
{
		if (File.Exists(CAD_DIR_Location + "\\" + StepFolder + "\\" + dr["PartStep"].ToString())){OpenSTEPbutton.Enabled=true;}
	CheckOut_Step.Enabled=true;
//	OpenSTEPbutton.Enabled=true;
generateSTEPbuttron.Enabled=false;
}
               }
             }
		}// select prod
		// ene delect
		void Button3Click(object sender, EventArgs e) //dal sito - parser
		{
 System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcesses();
{
   int count = 0;
   bool tooMany = false;
   foreach (System.Diagnostics.Process proc in processes)
   {
      if (proc.ProcessName == "CNEXT")
      {
         count++;
         if (count > 0) { tooMany = true; break; }
      }
   }

   //"ERROR Multiple CATIA";
   if (tooMany == true) { 
   	            MessageBox.Show("CATIA is already running. Please close before opening a new one ");
//   	return false; 
   }
   else
   {
   	
   		DialogResult dialogResult = MessageBox.Show("Start CATIA LOW?", "CATIA Startup", MessageBoxButtons.YesNo);
if(dialogResult == DialogResult.Yes)
{
    //do something
//}
//else if (dialogResult == DialogResult.No)
//{
//    //do something else
//}		
			
//   	MessageBox.Show("Let's start CATIA LOW");// \n " + "\"" + CATDLLPath_LOW + "\\CATStart.exe" + "\"" + " -run \"CNEXT.exe\" -env " + "\"" + ApplicationPath_LOW + "\"" + " -direnv " + "\"" + EnvironmentName_LOW + "\"" + " -nowindow");

                bool AdminMode = false;
                ProcessStartInfo psi = new ProcessStartInfo("\"" + CATDLLPath_LOW + "\\CATStart.exe" + "\"");


                if (!AdminMode)
                {
                    psi.Arguments = " -run \"CNEXT.exe\" -env " + "\"" + ApplicationPath_LOW + "\"" + " -direnv " + "\"" + EnvironmentName_LOW + "\"" + " -nowindow";
                }
                else
                {
                    psi.Arguments = " -run \"CNEXT.exe -admin\" -env " + "\"" + ApplicationPath_LOW + "\"" + " -direnv " + "\"" + EnvironmentName_LOW + "\"" + " -nowindow";
                }
//EnvironmentName_TOP
                Debug.WriteLine(psi.FileName + " " + psi.Arguments);

                IntPtr oCatiaHwnd= IntPtr.Zero;
//                bool bFound = false;

                psi.UseShellExecute = false;
                psi.RedirectStandardOutput = false;
                psi.RedirectStandardError = true;

                
                
   //Prozess starten und auf dessen Ende warten
                //using (Process process = new Process())
                Process process = new Process();
                {
                    process.EnableRaisingEvents = true;
                    process.StartInfo = psi;
                    process.Start();
                    Application.DoEvents();
                    Process[] Ps = Process.GetProcesses();
                    int L = Ps.Length;
                    int timeout = 5000;
                    process.WaitForExit(timeout);
                }
   
    }
else if (dialogResult == DialogResult.No)
{
    //do something else
}		            
                
                
   }
            }  
                
		}
		public void clearfamilyboxes()
{
famstatusBox.Clear();
famID.Clear();
textBox4.Clear();
button19.Enabled=false;
}
		public void clearprojectboxes()
{
ProjectCodeBox.Clear();
textBox5.Clear();
textBox1.Clear();
textBox2.Clear();
projectstatusBox.Clear();
prjID.Clear();
projectManagerBox.Clear();
button25.Enabled=false;
}
		public void clearproductboxes()
{
drawingBox.Clear();
drawingRevBox.Clear();
drawingdateBox.Clear();
drawingfilenameBox.Clear();
textBox3.Clear();
textBox6.Clear();
prodID.Clear();
carBOX.Clear();
button27.Enabled=false;
button38.Enabled=false;
//prodID.ReadOnly=true;
//carBOX.ReadOnly=true;
CheckBOM.Enabled=false;
groupBox20.Enabled=false;


}		
		public void clearboxes()
{
CodeBox.Clear();
NameBox.Clear();
StatusBox.Clear();
RevBox.Clear();
DateBox.Clear();
DesignerBox.Clear();
ThreedBox.Clear();
StepBox.Clear();
TwodBox.Clear();
PdfBox.Clear();
weightBox.Clear();
materialBox.Clear();
ttreatmentBox.Clear();
coatingBox.Clear();
supplierBox.Clear();
//textBox7.Clear();
Checkout_3D.Enabled=false;
OpenCADbutton.Enabled=false;
whereUSEDbutton.Enabled=false;
open2Dbutton.Enabled=false;
where2Dbutton.Enabled=false;
Checkout_2D.Enabled=false;
CheckOut_pdf.Enabled=false;
CheckOut_Step.Enabled=false;
generateSTEPbuttron.Enabled=false;
OpenSTEPbutton.Enabled=false;
openPDFbutton.Enabled=false;
generatePDFbutton.Enabled=false;
//pictureBox1.Image=Image.FromFile("");
  if (pictureBox1.Image != null)
        {
            pictureBox1.Image.Dispose();
            pictureBox1.Image = null;
        }
   }
		public void InitializeValues()
		{
			// clear all
			clearalldata();

		if (File.Exists(WouldBeCFG)){
            XmlDocument xmlDoc0 = new XmlDocument();
            xmlDoc0.Load(WouldBeCFG);
            XmlNodeList nodeList0 = xmlDoc0.DocumentElement.SelectNodes("/WouldBePDM/Config/Directories");
            foreach (XmlNode dir_node in nodeList0)
            {
			CAD_DIR_Location= dir_node.SelectSingleNode("CADdatadir").InnerText ;
			PdfFolder= dir_node.SelectSingleNode("PDFdatadir").InnerText ;
			StepFolder= dir_node.SelectSingleNode("STEPdatadir").InnerText ;
			ImageFolder= dir_node.SelectSingleNode("JPGdatadir").InnerText ;
            }
            
            XmlNodeList nodeList1 = xmlDoc0.DocumentElement.SelectNodes("/WouldBePDM/Config/CAD_PROP");
            foreach (XmlNode dir_node_cad in nodeList1)
            {
			CATDLLPath_TOP= dir_node_cad.SelectSingleNode("CATIA_TOP_EXE").InnerText ;
			EnvironmentName_TOP= dir_node_cad.SelectSingleNode("CATIA_TOP_ENV_Dir").InnerText ;
			
			ApplicationPath_TOP= dir_node_cad.SelectSingleNode("CATIA_TOP_ENV").InnerText ;
			CATDLLPath_LOW= dir_node_cad.SelectSingleNode("CATIA_LOW_EXE").InnerText ;
			EnvironmentName_LOW= dir_node_cad.SelectSingleNode("CATIA_LOW_ENV_Dir").InnerText ;
			ApplicationPath_LOW= dir_node_cad.SelectSingleNode("CATIA_LOW_ENV").InnerText ;
            Ug_NX_TOP_exe=dir_node_cad.SelectSingleNode("UG_TOP_EXE").InnerText ;
            Ug_NX_LOW_exe=dir_node_cad.SelectSingleNode("UG_LOW_EXE").InnerText ;
            }       
			}
		else{
		CAD_DIR_Location = ("WouldBePDMData");
		StepFolder="OUT";
		PdfFolder="OUT";
		ImageFolder="JPG";
		CATDLLPath_TOP = @"C:\Program Files\Dassault Systemes\B24\win_b64\code\bin";
		EnvironmentName_TOP = @"CATIA.V5-6R2014.B24_RB";
		
        ApplicationPath_TOP = @"C:\ProgramData\DassaultSystemes\CATEnv";
        CATDLLPath_LOW = @"C:\Program Files\Dassault Systemes\B19\win_b64\code\bin";
        EnvironmentName_LOW =  @"CATIA.V5R19.B19";
        ApplicationPath_LOW = @"C:\ProgramData\DassaultSystemes\CATEnv";
        Ug_NX_TOP_exe= @"C:\Program Files\Siemens\NX 10.0\UGII\ugraf.exe";
        Ug_NX_LOW_exe= @"C:\swbase\plmsw\nx85\UGII\ugraf.exe";
        EnvironmentName_Export=@"Export.txt";
        
        
		}
			
			EnvironmentDir_Export=EnvironmentName_TOP;  //To improve
		
            CADdirTextbox.Clear();
			CADdirTextbox.Text=(CAD_DIR_Location);
			
			Config_XML_filename.Clear();
			Config_XML_filename.Text=(WouldBeCFG);
			Filter_XML_filename.Clear();
			Filter_XML_filename.Text=(WouldBeFILTER);
			CatiaMacro_Dir.Clear();
			CatiaMacro_Dir.Text=(CatiaMacroDir);
			TempoPDFdir.Text=(PdfExportDir);
			TempoSTEPdir.Text=(STEPExportDir);
			TempoJPGdir.Text=(JPGExportDir);
	
			PDFdirBox.Clear();
			PDFdirBox.Text=(PdfFolder);
			StepDirBox.Clear();
			StepDirBox.Text=(StepFolder);
			JPGdirBox.Clear();
			JPGdirBox.Text=(ImageFolder);			
			CATIA_TOP_EXE.Clear();
			CATIA_TOP_EXE.Text=(CATDLLPath_TOP);
			CATIA_TOP_ENV_Dir.Clear();
			CATIA_TOP_ENV_Dir.Text=(ApplicationPath_TOP);
			CATIA_TOP_ENV.Clear();
			CATIA_TOP_ENV.Text=(EnvironmentName_TOP);
			CATIA_LOW_EXE.Clear();
			CATIA_LOW_EXE.Text=(CATDLLPath_LOW);
			CATIA_LOW_ENV_Dir.Clear();
			CATIA_LOW_ENV_Dir.Text=(ApplicationPath_LOW);		
			CATIA_LOW_ENV.Clear();
			CATIA_LOW_ENV.Text=(EnvironmentName_LOW);
			UG_TOP_EXE.Clear();
			UG_TOP_EXE.Text=(Ug_NX_TOP_exe);
			UG_LOW_exe.Clear();
			UG_LOW_exe.Text=(Ug_NX_LOW_exe);
			
//			initialize_bomview();
			
			
		}
		void Checkout_3DClick(object sender, EventArgs e)
		{
//				textBox1.AppendText(SelectedToOpen3D + " " + SelectedToOpen2D + " " + SelectedToOpenPdf + " " + SelectedToOpenStep + "\n");
		StringBuilder sbError = new StringBuilder();
StringBuilder sbOutput = new StringBuilder();
//string InstallPathSVN = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\TortoiseSVN" , "ProcPath", null);
if (InstallPathSVN != null)
{
string commandtolaunch = "\"" + InstallPathSVN + "\"";
    System.Diagnostics.Process.Start(commandtolaunch, "/command:update " + " /path:" + "\"" + CAD_DIR_Location  + "\\" + SelectedToOpen3D + "\"");
}
if (File.Exists(CAD_DIR_Location + "\\" + ThreedBox.Text.ToString())){OpenCADbutton.Enabled=true;}
GO_PART_BoxSelectedIndexChanged();
		}
	    public static System.Diagnostics.Process ViewFileFolder(string path)
{
    System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo(path);
 
    info.RedirectStandardError = false;
    info.RedirectStandardOutput = false;
    info.UseShellExecute = true;
 
    System.Diagnostics.Process p = new System.Diagnostics.Process();
    p.StartInfo = info;
 
    p.Start();
 
    return p;
}
        public static System.Diagnostics.Process Executeexe(string path)
{
    System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo(path);
 
    info.RedirectStandardError = true;
    info.RedirectStandardOutput = true;
    info.UseShellExecute = false;
 
    System.Diagnostics.Process p = new System.Diagnostics.Process();
    p.StartInfo = info;
 
    p.Start();
 
    return p;
}
		void Checkout_2DClick(object sender, EventArgs e)
		{
		StringBuilder sbError = new StringBuilder();
StringBuilder sbOutput = new StringBuilder();
//string InstallPathSVN = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\TortoiseSVN" , "ProcPath", null);
if (InstallPathSVN != null)
{
string commandtolaunch = "\"" + InstallPathSVN + "\"";
    System.Diagnostics.Process.Start(commandtolaunch, "/command:update " + " /path:" + "\"" + CAD_DIR_Location  + "\\" + SelectedToOpen2D + "\"");
}
if (File.Exists(CAD_DIR_Location + "\\" + TwodBox.Text.ToString() )){open2Dbutton.Enabled=true;}
GO_PART_BoxSelectedIndexChanged();
		}
		void CheckOut_StepClick(object sender, EventArgs e)
		{
	StringBuilder sbError = new StringBuilder();
StringBuilder sbOutput = new StringBuilder();
//string InstallPathSVN = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\TortoiseSVN" , "ProcPath", null);
if (InstallPathSVN != null)
{
string commandtolaunch = "\"" + InstallPathSVN + "\"";
    System.Diagnostics.Process.Start(commandtolaunch, "/command:update " + " /path:" + "\"" + CAD_DIR_Location  + "\\" + StepFolder +"\\" + SelectedToOpenStep + "\"");
}
		if (File.Exists(CAD_DIR_Location + "\\" + StepFolder + "\\" + StepBox.Text.ToString())){OpenSTEPbutton.Enabled=true;}
		GO_PART_BoxSelectedIndexChanged();
		}
		void CheckOut_pdfClick(object sender, EventArgs e)
		{
	StringBuilder sbError = new StringBuilder();
StringBuilder sbOutput = new StringBuilder();
//string InstallPathSVN = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\TortoiseSVN" , "ProcPath", null);
if (InstallPathSVN != null)
{
string commandtolaunch = "\"" + InstallPathSVN + "\"";
    System.Diagnostics.Process.Start(commandtolaunch, "/command:update " + " /path:" + "\"" + CAD_DIR_Location  + "\\" + PdfFolder +"\\" + SelectedToOpenPdf + "\"");
}

if (File.Exists(CAD_DIR_Location + "\\" + PdfFolder + "\\" + PdfBox.Text.ToString())){openPDFbutton.Enabled=true;
generatePDFbutton.Enabled=false;}else{generatePDFbutton.Enabled=true;}
GO_PART_BoxSelectedIndexChanged();
		}
		void Button5Click(object sender, EventArgs e)
		{
			if (EEcounter == 3){EEcounter++;}
	ViewFileFolder(CAD_DIR_Location);
		}
		void Button8Click(object sender, EventArgs e)
		{
						if (EEcounter == 4){EEcounter++;}
	ViewFileFolder(CAD_DIR_Location + "\\" + PdfFolder);
		}
		void Button10Click(object sender, EventArgs e)
		{
						if (EEcounter == 5){EEcounter++;}
			ViewFileFolder(CAD_DIR_Location + "\\" + StepFolder);
		}
		void OpenPDFbuttonClick(object sender, EventArgs e)
		{
			string filetoopen= CAD_DIR_Location  + "\\" + PdfFolder + "\\" + SelectedToOpenPdf;
	if (File.Exists (filetoopen) ) 
{ViewFileFolder(filetoopen );
	} else
	{
//		MessageBox("The file doesn't exist. Downloading");
		DialogResult result1 = MessageBox.Show("The file doesn't exist. Download?", "File Missing", MessageBoxButtons.YesNo);
		if (result1==DialogResult.Yes)
		{
		StringBuilder sbError = new StringBuilder();
StringBuilder sbOutput = new StringBuilder();
//string InstallPathSVN = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\TortoiseSVN" , "ProcPath", null);
if (InstallPathSVN != null)
{
string commandtolaunch = "\"" + InstallPathSVN + "\"";
    System.Diagnostics.Process.Start(commandtolaunch, "/command:update " + " /path:" + "\"" +  filetoopen + "\"");
   	if (File.Exists (filetoopen) ) 
{
		ViewFileFolder(filetoopen );
}
}   
		}
		
	}
	}
		void OpenSTEPbuttonClick(object sender, EventArgs e)
		{
	string filetoopen= CAD_DIR_Location  + "\\" + StepFolder + "\\" + SelectedToOpenStep;
	if (File.Exists (filetoopen) ) 
{ViewFileFolder(filetoopen );
	} else
	{
//		MessageBox("The file doesn't exist. Downloading");
		DialogResult result1 = MessageBox.Show("The file doesn't exist. Download?", "File Missing", MessageBoxButtons.YesNo);
		if (result1==DialogResult.Yes)
		{
		StringBuilder sbError = new StringBuilder();
StringBuilder sbOutput = new StringBuilder();
//string InstallPathSVN = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\TortoiseSVN" , "ProcPath", null);
if (InstallPathSVN != null)
{
string commandtolaunch = "\"" + InstallPathSVN + "\"";
    System.Diagnostics.Process.Start(commandtolaunch, "/command:update " + " /path:" + "\"" +  filetoopen + "\"");
   	if (File.Exists (filetoopen) ) 
{
		ViewFileFolder(filetoopen );
}
}   
		}
		
	}
		}
		void Open2DbuttonClick(object sender, EventArgs e)
		{
string filetoopen= CAD_DIR_Location  + "\\" + SelectedToOpen2D;
	if (File.Exists (filetoopen) ) 
{ViewFileFolder(filetoopen );
	} else
	{
//		MessageBox("The file doesn't exist. Downloading");
		DialogResult result1 = MessageBox.Show("The file doesn't exist. Download?", "File Missing", MessageBoxButtons.YesNo);
		if (result1==DialogResult.Yes)
		{
		StringBuilder sbError = new StringBuilder();
StringBuilder sbOutput = new StringBuilder();
//string InstallPathSVN = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\TortoiseSVN" , "ProcPath", null);
if (InstallPathSVN != null)
{
string commandtolaunch = "\"" + InstallPathSVN + "\"";
    System.Diagnostics.Process.Start(commandtolaunch, "/command:update " + " /path:" + "\"" +  filetoopen + "\"");
   	if (File.Exists (filetoopen) ) 
{
		ViewFileFolder(filetoopen );
}
}   
		}
		
	}	
		}
		void OpenCADbuttonClick(object sender, EventArgs e)
		{
	string filetoopen= CAD_DIR_Location  + "\\" + SelectedToOpen3D;
	if (File.Exists (filetoopen) ) 
{ViewFileFolder(filetoopen );
	} else
	{
//		MessageBox("The file doesn't exist. Downloading");
		DialogResult result1 = MessageBox.Show("The file doesn't exist. Download?", "File Missing", MessageBoxButtons.YesNo);
		if (result1==DialogResult.Yes)
		{
		StringBuilder sbError = new StringBuilder();
StringBuilder sbOutput = new StringBuilder();
//string InstallPathSVN = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\TortoiseSVN" , "ProcPath", null);
if (InstallPathSVN != null)
{
string commandtolaunch = "\"" + InstallPathSVN + "\"";
    System.Diagnostics.Process.Start(commandtolaunch, "/command:update " + " /path:" + "\"" +  filetoopen + "\"");
   	if (File.Exists (filetoopen) ) 
{
		ViewFileFolder(filetoopen );
}
}   
		}
		
	}
		}
		void Button18Click(object sender, EventArgs e) // Downlaod PROD
		{
		
				
//		CAD_DIR_Location = ("WouldBePDMData");
//		StepFolder="OUT";
//		PdfFolder="OUT";
//				
			
			
			string prtcode ="";
			string prtthreed ="";
			string prtstep ="";
			string prttwod ="";
			string prtpdf ="", jpgimagefile="";
//			string PRT_selected ="";
//			string prtcode ="";
			string drawingfilename=drawingfilenameBox.Text.ToString();
//				drawingfilenameBox.AppendText(dr["Product2DFilename"].ToString()); //product2dfilename);
			
			filetocheckout=CAD_DIR_Location + "\\" + PdfFolder + "\\" + drawingfilename;
			
			
			
			
			
			 XmlDocument xmlDoc2 = new XmlDocument();
			xmlDoc2.Load(WouldBeXML);  
//            textBox1.AppendText(PRT_selected  + "\r\n");
			XmlNodeList nodeList = xmlDoc2.DocumentElement.SelectNodes("/WouldBePDM/PartList/Component");
            foreach (XmlNode nodepart in nodeList) //            foreach (XmlNode nodepart in nodeList)
            {
//              PartList>
		//<Component
                prtcode = nodepart.SelectSingleNode("PartCode").InnerText;
            	prtthreed= nodepart.SelectSingleNode("PartTHREE_D").InnerText ;
                prtstep= nodepart.SelectSingleNode("PartStep").InnerText ;
                prttwod= nodepart.SelectSingleNode("PartTWO_D").InnerText ;
                prtpdf= nodepart.SelectSingleNode("PartPdf").InnerText ;
                jpgimagefile=nodepart.SelectSingleNode("PartImage").InnerText ;
                			
			foreach (string CODE in PART_Box.Items )
			{
//				textBox1.AppendText("- " + CODE);
				
				if (  CODE ==prtcode)
                				{
					if (prtthreed!="NULL"){
					if (prtthreed!="")
					{ 
						if (filetocheckout=="") {
							filetocheckout= CAD_DIR_Location + "\\" + prtthreed;	}
						else{filetocheckout= filetocheckout + "*" + CAD_DIR_Location + "\\" + prtthreed;}
					}
					}
					
					if (prttwod!="NULL"){
					if (prttwod!="")
					{
						if (filetocheckout=="") {
							filetocheckout=  CAD_DIR_Location + "\\" + prttwod;	}
						else{filetocheckout= filetocheckout + "*" + CAD_DIR_Location + "\\" + prttwod;}
					}
					}

					if (prtstep!="NULL"){ //folder?
					if (prtstep!="")
					{
						if (filetocheckout==""){
							filetocheckout= CAD_DIR_Location + "\\" + StepFolder + "\\" + prtstep;	}
						else{filetocheckout= filetocheckout +"*" + CAD_DIR_Location + "\\" + StepFolder + "\\" + prtstep;}
					}
					}

					if (prtpdf!="NULL"){ //folder?
					if (prtpdf!="")
					{
					if (filetocheckout=="")
					{
						filetocheckout= CAD_DIR_Location + "\\" + PdfFolder + "\\" +  prtpdf;	}
					else{filetocheckout= filetocheckout + "*" + CAD_DIR_Location + "\\" + PdfFolder + "\\" +  prtpdf;}
					}
					
					}
					
					
					if (jpgimagefile!="NULL"){
					if (jpgimagefile!="")
					{ 
						if (filetocheckout=="") {
							filetocheckout= CAD_DIR_Location + "\\" + ImageFolder + "\\" + jpgimagefile;	}
						else{filetocheckout= filetocheckout + "*" + CAD_DIR_Location + "\\" + ImageFolder + "\\" + jpgimagefile;}
					}
					}
					
					
					
					
					
				}
			}
			
            }
//	textBox1.AppendText("file: " + filetocheckout);
	
		StringBuilder sbError = new StringBuilder();
StringBuilder sbOutput = new StringBuilder();
//string InstallPathSVN = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\TortoiseSVN" , "ProcPath", null);
if (InstallPathSVN != null)
{
string commandtolaunch = "\"" + InstallPathSVN + "\"";
    System.Diagnostics.Process.Start(commandtolaunch, "/command:update " + " /path:" + "\"" +  filetocheckout + "\"");
   	
}   
	
	
	
	
	
	GO_PROD_BoxSelectedIndexChanged();
	
		}
		void Button4Click(object sender, EventArgs e)
		{
 string path=Environment.CurrentDirectory;
  FolderBrowserDialog fbd = new FolderBrowserDialog();
  
fbd.SelectedPath = Environment.CurrentDirectory;
  DialogResult result = fbd.ShowDialog();
 if (result.ToString()=="OK"){path = fbd.SelectedPath;    //}
	string filename = Path.GetFileName(path);
CAD_DIR_Location = filename;
           CADdirTextbox.Clear();
			CADdirTextbox.Text=(CAD_DIR_Location);
 
  }}
		void Button7Click(object sender, EventArgs e)
		{
	string path=Environment.CurrentDirectory;
  FolderBrowserDialog fbd = new FolderBrowserDialog();
  
fbd.SelectedPath = Environment.CurrentDirectory;
  DialogResult result = fbd.ShowDialog();
 if (result.ToString()=="OK"){path = fbd.SelectedPath;    //}
	string filename = Path.GetFileName(path);
PdfFolder = filename;
           PDFdirBox.Clear();
			PDFdirBox.Text=(PdfFolder);
   }
		}
		void Button9Click(object sender, EventArgs e)
		{
			string path=Environment.CurrentDirectory;
  FolderBrowserDialog fbd = new FolderBrowserDialog();
  
fbd.SelectedPath = Environment.CurrentDirectory;
  DialogResult result = fbd.ShowDialog();
 if (result.ToString()=="OK"){path = fbd.SelectedPath;    //}
	string filename = Path.GetFileName(path);
StepFolder = filename;
           StepDirBox.Clear();
			StepDirBox.Text=(StepFolder);
   }
			}
		void Button11Click(object sender, EventArgs e)
		{
					string path=Environment.CurrentDirectory;
  FolderBrowserDialog fbd = new FolderBrowserDialog();
  
fbd.SelectedPath = Environment.CurrentDirectory;
  DialogResult result = fbd.ShowDialog();
 if (result.ToString()=="OK"){path = fbd.SelectedPath;    //}
	string filename = Path.GetFileName(path);
ImageFolder = filename;
           JPGdirBox.Clear();
			JPGdirBox.Text=(ImageFolder);
   }
	//JPGdirBox
	//ImageFolder
	
	
		}
		void Button12Click(object sender, EventArgs e)
		{
	XmlTextWriter writer = new XmlTextWriter(WouldBeCFG, System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("WouldBePDM");
            writer.WriteStartElement("Config");
            writer.WriteStartElement("Directories"); //Directories
            writer.WriteStartElement("CADdatadir");
            writer.WriteString(CAD_DIR_Location);
            writer.WriteEndElement(); //CAD_DIR_Location
            writer.WriteStartElement("PDFdatadir");
            writer.WriteString(PdfFolder);
            writer.WriteEndElement(); //PdfFolder
            writer.WriteStartElement("STEPdatadir");
            writer.WriteString(StepFolder);
            writer.WriteEndElement(); //STEPdatadir
            writer.WriteStartElement("JPGdatadir");
            writer.WriteString(ImageFolder);
            writer.WriteEndElement(); //ImageFolder
            writer.WriteEndElement(); //Directories
            writer.WriteStartElement("CAD_PROP"); //CAD_PROP
            writer.WriteStartElement("CATIA_TOP_EXE");//node begin
            writer.WriteString(CATDLLPath_TOP); //node 
            writer.WriteEndElement();      //node end        
            writer.WriteStartElement("CATIA_TOP_ENV");//node begin
            writer.WriteString(ApplicationPath_TOP); //node 
            writer.WriteEndElement();      //node end        
            writer.WriteStartElement("CATIA_TOP_ENV_Dir");//node begin
            writer.WriteString(EnvironmentName_TOP); //node 
            writer.WriteEndElement();      //node end        
            writer.WriteStartElement("CATIA_LOW_EXE");//node begin
            writer.WriteString(CATDLLPath_LOW); //node 
            writer.WriteEndElement();      //node end        
            writer.WriteStartElement("CATIA_LOW_ENV");//node begin
            writer.WriteString(ApplicationPath_LOW); //node 
            writer.WriteEndElement();      //node end        
            writer.WriteStartElement("CATIA_LOW_ENV_Dir");//node begin
            writer.WriteString(EnvironmentName_LOW); //node  
            writer.WriteEndElement();      //node end        
            writer.WriteStartElement("UG_TOP_EXE");//node begin
            writer.WriteString(Ug_NX_TOP_exe); //node 
            writer.WriteEndElement();      //node end        
            writer.WriteStartElement("UG_LOW_EXE");//node begin
            writer.WriteString(Ug_NX_LOW_exe); //node 
            writer.WriteEndElement();      //node end        
            writer.WriteEndElement(); //CAD_PROP
            writer.WriteEndElement(); //Config
            writer.WriteEndElement(); //WouldBePDM
            writer.WriteEndDocument();
            writer.Close();
            MessageBox.Show("XML File created ! ");
            
            		CAD_DIR_Location = ("WouldBePDMData");

//            
            
            
            
            
            
		}
		void Button19Click(object sender, EventArgs e)
		{
			// nota sposta da altra parte
//			textBox4.Clear();
//			textBox4.AppendText(FAM_Box.SelectedItem.ToString());
           
			if (FAM_Box.SelectedItem== null){}
			else{

	if (famstatusBox.ReadOnly== true){
				famstatusBox.ReadOnly=false;
				FAM_Box.Visible=false;
//				Family_pre_update=FAM_Box.SelectedItem.ToString();
//				MessageBox.Show("value " + Family_pre_update);
				famID.ReadOnly=false;
				button35.Visible=false;
				button19.Text=("Undo");}
	else {
				famstatusBox.ReadOnly=true;
				FAM_Box.Visible=true;

				famID.ReadOnly=true;
				button19.Text=("Modify");
				button35.Visible=true;
				if (FAM_Box.Text!="Select a Family"){
					Go_ComboBox1SelectedIndexChanged();}
			}
	if (Write_status.Visible==false){Write_status.Visible=true;}
	else {Write_status.Visible=false;}
			}
		}
		void Button23Click(object sender, EventArgs e)
		{
	
 System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcesses();
{
   int count = 0;
   bool tooMany = false;
   foreach (System.Diagnostics.Process proc in processes)
   {
      if (proc.ProcessName == "CNEXT")
      {
         count++;
         if (count > 0) { tooMany = true; break; }
      }
   }

   //"ERROR Multiple CATIA";
   if (tooMany == true) { 
   	            MessageBox.Show("CATIA is already running. Please close before opening a new one ");
//   	return false; 
   }
   else
   {
	DialogResult dialogResult = MessageBox.Show("Start CATIA TOP?", "CATIA Startup", MessageBoxButtons.YesNo);
if(dialogResult == DialogResult.Yes)
{
                bool AdminMode = false;
                ProcessStartInfo psi = new ProcessStartInfo("\"" + CATDLLPath_LOW + "\\CATStart.exe" + "\"");


                if (!AdminMode)
                {
                    psi.Arguments = " -run \"CNEXT.exe\" -env " + "\"" + ApplicationPath_TOP + "\"" + " -direnv " + "\"" + EnvironmentName_TOP + "\"" + " -nowindow";
                }
                else
                {
                    psi.Arguments = " -run \"CNEXT.exe -admin\" -env " + "\"" + ApplicationPath_TOP + "\"" + " -direnv " + "\"" + EnvironmentName_TOP + "\"" + " -nowindow";
                }
//EnvironmentName_TOP
                Debug.WriteLine(psi.FileName + " " + psi.Arguments);

                IntPtr oCatiaHwnd= IntPtr.Zero;
//                bool bFound = false;

                psi.UseShellExecute = false;
                psi.RedirectStandardOutput = false;
                psi.RedirectStandardError = true;

                
                
   //Prozess starten und auf dessen Ende warten
                //using (Process process = new Process())
                Process process = new Process();
                {
                    process.EnableRaisingEvents = true;
                    process.StartInfo = psi;
                    process.Start();
                    Application.DoEvents();
                    Process[] Ps = Process.GetProcesses();
                    int L = Ps.Length;
                    int timeout = 5000;
                    process.WaitForExit(timeout);
                }
   
                }
else if (dialogResult == DialogResult.No)
{
    //do something else
}
                
                
   }
            }  
                
		}
				
		public void WriteXML()
		{
MessageBox.Show("To make definitive update, please select current XML file in next steps \n" + WouldBeXML + "\n Otherwise the modifications will be temporaries!");
			
string TmpXMLexportName="tmpexport.xml";

SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
SaveFileDialog1.InitialDirectory = ".";
DialogResult result = SaveFileDialog1.ShowDialog();
SaveFileDialog1.RestoreDirectory = true; // ?
SaveFileDialog1.Title = "Select XML to save in";
SaveFileDialog1.DefaultExt = "xml";
SaveFileDialog1.CheckFileExists = true;
SaveFileDialog1.CheckPathExists = true;
SaveFileDialog1.Filter = "Xml files (*.xml)|*.xml|All files (*.*)|*.*";
SaveFileDialog1.FilterIndex = 1;
SaveFileDialog1.RestoreDirectory = true;    
if (result.ToString()=="OK"){
	TmpXMLexportName=SaveFileDialog1.FileName; 
	string SubString = TmpXMLexportName.Substring(TmpXMLexportName.Length-3);
	if ( SubString != "xml") //(TmpXMLexportName.Lenght -3))
{TmpXMLexportName=TmpXMLexportName + ".xml";}
}
          
            XmlTextWriter writer = new XmlTextWriter(TmpXMLexportName, System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("WouldBePDM");//WouldBePDM
            writer.WriteStartElement("FamilyList");//FamilyList
                   	for (int i = 0; i <= Famlytable.Rows.Count - 1; i++)
                   	{
                   	writer.WriteStartElement("Family"); //Family
                    writer.WriteStartElement("FamilyName");
                    writer.WriteString(Famlytable.Rows[i].ItemArray[1].ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("FamilyID");
                    writer.WriteString(Famlytable.Rows[i].ItemArray[0].ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("FamilyStatus");
                    writer.WriteString(Famlytable.Rows[i].ItemArray[2].ToString());
                    writer.WriteEndElement();
                    writer.WriteEndElement(); //Family               
             		}
            writer.WriteEndElement(); //FamilyList
            writer.WriteStartElement("ProjectList");  //ProjectList
                   	for (int i = 0; i <= Prjtable.Rows.Count - 1; i++)
                   	{
                   	writer.WriteStartElement("Project"); //Project
                    writer.WriteStartElement("ProjectName");
                    writer.WriteString(Prjtable.Rows[i].ItemArray[1].ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("ProjectCode");
                    writer.WriteString(Prjtable.Rows[i].ItemArray[3].ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("ProjectID");
                    writer.WriteString(Prjtable.Rows[i].ItemArray[0].ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("FamilyID");
                    writer.WriteString(Prjtable.Rows[i].ItemArray[4].ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("CustomerName");
                    writer.WriteString(Prjtable.Rows[i].ItemArray[5].ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("CustomerCode");
                    writer.WriteString(Prjtable.Rows[i].ItemArray[6].ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("ProjectStatus");
                    writer.WriteString(Prjtable.Rows[i].ItemArray[2].ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("ProjectManager");
                    writer.WriteString(Prjtable.Rows[i].ItemArray[7].ToString());
                    writer.WriteEndElement();
                    writer.WriteEndElement(); //Project               
             		}
            writer.WriteEndElement(); //ProjectList
            writer.WriteStartElement("ProductList");  //ProductList
                   	for (int i = 0; i <= Prodtable.Rows.Count - 1; i++)
                   	{
                   	writer.WriteStartElement("Product"); //Product
                    writer.WriteStartElement("ProductName");
                    writer.WriteString(Prodtable.Rows[i].ItemArray[0].ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("ProductCar");
                    writer.WriteString(Prodtable.Rows[i].ItemArray[1].ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("ProductCode");
                    writer.WriteString(Prodtable.Rows[i].ItemArray[2].ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("ProductStatus");
                    writer.WriteString(Prodtable.Rows[i].ItemArray[3].ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("ProjectCode");
                    writer.WriteString(Prodtable.Rows[i].ItemArray[4].ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("Product2DName");
                    writer.WriteString(Prodtable.Rows[i].ItemArray[5].ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("Product2DFilename");
                    writer.WriteString(Prodtable.Rows[i].ItemArray[6].ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("Product2DREV");
                    writer.WriteString(Prodtable.Rows[i].ItemArray[7].ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("Product2DDate");
                    writer.WriteString(Prodtable.Rows[i].ItemArray[8].ToString());
                    writer.WriteEndElement();
                    writer.WriteEndElement(); //Product               
             		}
            writer.WriteEndElement(); //ProductList   
            writer.WriteStartElement("PartList");  //PartList Parttable
                   	for (int i = 0; i <= Parttable.Rows.Count - 1; i++)
                   	{
                   	writer.WriteStartElement("Component"); //Component
                    writer.WriteStartElement("PartName");
                    writer.WriteString(Parttable.Rows[i].ItemArray[1].ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("PartCode");
                    writer.WriteString(Parttable.Rows[i].ItemArray[0].ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("PartStatus");
                    writer.WriteString(Parttable.Rows[i].ItemArray[2].ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("PartRev");
                    writer.WriteString(Parttable.Rows[i].ItemArray[3].ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("PartDate");
                    writer.WriteString(Parttable.Rows[i].ItemArray[4].ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("PartDesigner");
                    writer.WriteString(Parttable.Rows[i].ItemArray[5].ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("PartTHREE_D");
                    writer.WriteString(Parttable.Rows[i].ItemArray[6].ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("PartStep");
                    writer.WriteString(Parttable.Rows[i].ItemArray[7].ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("PartTWO_D");
                    writer.WriteString(Parttable.Rows[i].ItemArray[8].ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("PartPdf");
                    writer.WriteString(Parttable.Rows[i].ItemArray[9].ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("PartWeight");
                    writer.WriteString(Parttable.Rows[i].ItemArray[10].ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("PartMaterial");
                    writer.WriteString(Parttable.Rows[i].ItemArray[11].ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("PartTThreat");
                    writer.WriteString(Parttable.Rows[i].ItemArray[12].ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("PartCoat");
                    writer.WriteString(Parttable.Rows[i].ItemArray[13].ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("PartSupplyer");
                    writer.WriteString(Parttable.Rows[i].ItemArray[14].ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("PartImage");
                    writer.WriteString(Parttable.Rows[i].ItemArray[15].ToString());
                    writer.WriteEndElement();                   
                    writer.WriteEndElement(); //Component               
             		}
            writer.WriteEndElement(); //PartList     
            writer.WriteStartElement("PartMatch");  //PartMatch
                   	for (int i = 0; i <= Matchtable.Rows.Count - 1; i++)
                   	{
                   	writer.WriteStartElement("ComponentList"); //ComponentList
                    writer.WriteStartElement("PartListed");
                    writer.WriteString(Matchtable.Rows[i].ItemArray[0].ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("ProjectListed");
                    writer.WriteString(Matchtable.Rows[i].ItemArray[1].ToString());
                    writer.WriteEndElement();
                    writer.WriteEndElement(); //ComponentList               
             		}
            writer.WriteEndElement(); //PartMatch   
            writer.WriteEndElement(); //WouldBePDM
            writer.WriteEndDocument(); // END
            writer.Close();
            MessageBox.Show("XML File created ! " + TmpXMLexportName);
            
            Readonly_All();
		}	
		public void Readonly_All()
		{
				famstatusBox.ReadOnly=true;
				famID.ReadOnly=true;
				ProjectCodeBox.ReadOnly=true;
				textBox1.ReadOnly=true;
				textBox2.ReadOnly=true;
				projectstatusBox.ReadOnly=true;
				projectManagerBox.ReadOnly=true;
				textBox3.ReadOnly=true;
				drawingBox.ReadOnly=true;
				drawingRevBox.ReadOnly=true;
				drawingdateBox.ReadOnly=true;
				drawingfilenameBox.ReadOnly=true;
				jpegfile.ReadOnly=true;
				CodeBox.ReadOnly=true;
				NameBox.ReadOnly=true;
				StatusBox.ReadOnly=true;
				RevBox.ReadOnly=true;
				DateBox.ReadOnly=true;
				DesignerBox.ReadOnly=true;
				weightBox.ReadOnly=true;
				materialBox.ReadOnly=true;
				ttreatmentBox.ReadOnly=true;
				coatingBox.ReadOnly=true;
				supplierBox.ReadOnly=true;
				ThreedBox.ReadOnly=true;
				TwodBox.ReadOnly=true;
				StepBox.ReadOnly=true;
				PdfBox.ReadOnly=true;
				
		}
		void Write_statusClick(object sender, EventArgs e)
		{
			if(Addfamiliystatus==1){
			Familyrow = Famlytable.NewRow();
			Familyrow["ID"] = famID.Text.ToString(); 
//            Familyrow["Name"] = FAM_Box.SelectedItem.ToString() ;
			Familyrow["Name"] = textBox4.Text.ToString() ;
            Familyrow["Status"] = famstatusBox.Text.ToString() ;
            Famlytable.Rows.Add(Familyrow);
			}else{
			 foreach(DataRow dr in Famlytable.Rows) // search whole table
 	{
			 	if(dr["Name"].ToString() == Family_pre_update) //FAM_Box.SelectedItem.ToString()) // if id==2  FAM_Box.SelectedItem.ToString()
//			 	if (Familyrow["Name"] == Family_pre_update)
    	{
//    	familyselectedID= dr["ID"].ToString();//familyid;
//    	familyid=familyselectedID;
		dr["ID"]=famID.Text.ToString();
		dr["Status"]= famstatusBox.Text.ToString();// .Text();
//		Familyrow["Name"] = textBox4.Text.ToString() ;
		dr["Name"] = textBox4.Text.ToString() ;
		Family_pre_update="";
//		familyname=dr["Name"].ToString();
//		famstatusBox.AppendText(dr["Status"].ToString());
        //dr["Product_name"] = "cde"; //change the name
    	}
			 }}
 	WriteXML();
 	Addfamiliystatus=0;
	famstatusBox.ReadOnly=true;
	famID.ReadOnly=true;
	Write_status.Visible=false;
	button19.Text=("Modify");
	FAM_Box.Visible=true;
	FAM_Box.Items.Clear();
	foreach(DataRow dr in Famlytable.Rows){
		FAM_Box.Items.Add(dr["Name"].ToString());
	}
		}
		void Button25Click(object sender, EventArgs e) // modify prj
		{
	// PRJ_Box
//	        Addprojectstatus=0;
//        Project_pre_update="";
if (PRJ_Box.SelectedItem== null){}
			else{

			if (ProjectCodeBox.ReadOnly== true){
		PRJ_Box.Visible=false;
				ProjectCodeBox.ReadOnly=false;
				textBox1.ReadOnly=false;
				textBox2.ReadOnly=false;
				prjID.ReadOnly=false;
				prjID.Enabled=true;
//				projectstatusBox.Enabled=true;
				projectstatusBox.ReadOnly=false;
				projectManagerBox.ReadOnly=false;
				button36.Visible=false;
				button25.Text=("Undo");}
	else {
				ProjectCodeBox.ReadOnly=true;
				textBox1.ReadOnly=true;
				textBox2.ReadOnly=true;
				prjID.ReadOnly=true;
				projectManagerBox.ReadOnly=true;
				button25.Text=("Modify");
				PRJ_Box.Visible=true;
				Addprojectstatus=0;
				button36.Visible=true;
				GO_PRJ_BoxSelectedIndexChanged(); 
				projectstatusBox.ReadOnly=true;				//to search
			}
	if (button24.Visible==false){button24.Visible=true;}
	else {button24.Visible=false;}

			
		} // modify prj
		}
		void Button24Click(object sender, EventArgs e) //write prj
		{
			
			if(Addprojectstatus==1)
			{
			Prjrow = Prjtable.NewRow();
			Prjrow["ID"]= prjID.Text.ToString();// .Text();
			Prjrow["Status"]=projectstatusBox.Text.ToString();
			Prjrow["prjcode"]=ProjectCodeBox.Text.ToString();
			Prjrow["Name"]=textBox5.Text;
			Prjrow["Customer"]=textBox2.Text.ToString();
			Prjrow["CusCode"]=textBox1.Text.ToString();
			Prjrow["PM"]=projectManagerBox.Text.ToString();
			Prjrow["IDprjFam"] =famID.Text;
			Prjtable.Rows.Add(Prjrow);
			Addprojectstatus=0;
						}
			else{
			
	 foreach(DataRow dr in Prjtable.Rows) // search whole table
 	{ 
	 	if(dr["Name"].ToString() ==Project_pre_update)
    	{
	dr["ID"]= prjID.Text.ToString();// .Text();
	dr["Status"]=projectstatusBox.Text.ToString();
	dr["prjcode"]=ProjectCodeBox.Text.ToString();
	dr["Name"]=textBox5.Text;
	dr["Customer"]=textBox2.Text.ToString();
	dr["CusCode"]=textBox1.Text.ToString();
	dr["PM"]=projectManagerBox.Text.ToString();
    	}
	}
			}
			
			 	WriteXML();
			 	PRJ_Box.Items.Clear();
			 	foreach(DataRow dr in Prjtable.Rows) // search whole table
 	{
			 		if(dr["IDprjFam"].ToString() == famID.Text) // if id==2  FAM_Box.SelectedItem.ToString()
   	{PRJ_Box.Items.Add(dr["Name"].ToString()); }
	}
	button24.Visible=false;
	button25.Text=("Modify");
	PRJ_Box.Visible=true;
	
		}//write prj
		void Button27Click(object sender, EventArgs e) // modify prod
		{
			if(PROD_Box.SelectedItem==null){}
			else{
			if (textBox3.ReadOnly== true){
				textBox3.ReadOnly=false;
				drawingBox.ReadOnly=false;
				drawingRevBox.ReadOnly=false;
				drawingdateBox.ReadOnly=false;
				drawingfilenameBox.ReadOnly=false;
				carBOX.ReadOnly=false;
				button26.Visible=true;
				PROD_Box.Visible=false;
				prodID.Enabled=true;
				prodID.ReadOnly=false;
				button18.Enabled=false;
				button6.Enabled=false;
				button27.Text=("Undo");}
	else {
				textBox3.ReadOnly=true;
				drawingBox.ReadOnly=true;
				drawingRevBox.ReadOnly=true;
				drawingdateBox.ReadOnly=true;	
				drawingfilenameBox.ReadOnly=true;
				carBOX.ReadOnly=true;
				button27.Text=("Modify");
				button26.Visible=false;
				PROD_Box.Visible=true;
				button18.Enabled=true;
				button6.Enabled=true;
//				prodID.Enabled=false;
				prodID.ReadOnly=true;
				GO_PROD_BoxSelectedIndexChanged();  //to search
			}	
		}
		} // modify prod 
		void Button26Click(object sender, EventArgs e) //write prod
		{
			string projectselectedID ="";
			
			if(Addproductstatus==1){
				Prodrow = Prodtable.NewRow();
		Prodrow["ProductName"]= textBox6.Text.ToString();
      Prodrow["ProductCar"]=carBOX.Text.ToString();
      Prodrow["ProductCode"]=prodID.Text.ToString();
      Prodrow["ProductStatus"]=textBox3.Text.ToString();
      Prodrow["ProjectCode"]=prjID.Text.ToString();
      Prodrow["Product2DName"]=drawingBox.Text.ToString();
      Prodrow["Product2DFilename"]=drawingfilenameBox.Text.ToString();
      Prodrow["Product2DREV"]=drawingRevBox.Text.ToString();
      Prodrow["Product2DDate"]=drawingdateBox.Text.ToString(); 	
      Prodtable.Rows.Add(Prodrow);
      Addproductstatus=0;
			}
			else{
		 foreach(DataRow dr in Prodtable.Rows) // search whole table
 	{
 		if(dr["ProductName"].ToString() == PROD_Box.SelectedItem.ToString()) // if id==2  FAM_Box.SelectedItem.ToString()
    	{
	dr["ProductName"]= textBox6.Text.ToString();
      dr["ProductCar"]=carBOX.Text.ToString();
      dr["ProductCode"]=prodID.Text.ToString();
      dr["ProductStatus"]=textBox3.Text.ToString();
      dr["ProjectCode"]=prjID.Text.ToString();
      dr["Product2DName"]=drawingBox.Text.ToString();
      dr["Product2DFilename"]=drawingfilenameBox.Text.ToString();
      dr["Product2DREV"]=drawingRevBox.Text.ToString();
      dr["Product2DDate"]=drawingdateBox.Text.ToString(); 				
    	}
	}
			}
			
			 	WriteXML();
	button26.Visible=false;
	button27.Text=("Modify");
		PROD_Box.Visible=true;
		
		
		PROD_Box.Items.Clear();
		
		foreach(DataRow dr in Prjtable.Rows) // search whole table
 	{
 		if(dr["Name"].ToString() == PRJ_Box.SelectedItem.ToString()) // if id==2  FAM_Box.SelectedItem.ToString()
    	{
        	projectselectedID= dr["ID"].ToString();
//        	projectstatusBox.AppendText(dr["Status"].ToString());//---projectstatus);
//			ProjectCodeBox.AppendText(dr["prjcode"].ToString());//---projectcode);
//			textBox1.AppendText(dr["CusCode"].ToString());
//			textBox2.AppendText(dr["Customer"].ToString());
//			projectManagerBox.AppendText(dr["PM"].ToString());//---projectmanager);
//			prjID.AppendText(projectselectedID);
     	}
	}

		foreach(DataRow dr in Prodtable.Rows) // search whole table
 	{
 	if(dr["ProjectCode"].ToString() == projectselectedID) // if id==2  FAM_Box.SelectedItem.ToString()
   	{PROD_Box.Items.Add(dr["ProductName"].ToString()); }
	}
			prodID.ReadOnly=true;
			carBOX.ReadOnly=true;
		GO_PRJ_BoxSelectedIndexChanged();	
				button37.Text=("Add");
				button27.Visible=true;
				button26.Visible=false;
		
		}//write prod	
		void Button28Click(object sender, EventArgs e) //modify prt 

		{
				if (CodeBox.ReadOnly== true){
				CodeBox.ReadOnly=false;
				NameBox.ReadOnly=false;
				StatusBox.ReadOnly=false;
				RevBox.ReadOnly=false;
				DateBox.ReadOnly=false;
				DesignerBox.ReadOnly=false;
				ThreedBox.ReadOnly=false;
				StepBox.ReadOnly=false;
				TwodBox.ReadOnly=false;
				PdfBox.ReadOnly=false;
				weightBox.ReadOnly=false;
				materialBox.ReadOnly=false;
				ttreatmentBox.ReadOnly=false;
				coatingBox.ReadOnly=false;
				supplierBox.ReadOnly=false;
				button30.Visible=true;
				jpegfile.ReadOnly=false;
				jpegfile.Visible=true;
				button29.Visible=true;
				WhereUsed.Enabled=false;
				OpenCADbutton.Enabled=false;
				Checkout_3D.Enabled=false;
				whereUSEDbutton.Enabled=false;
				open2Dbutton.Enabled=false;
				Checkout_2D.Enabled=false;
				where2Dbutton.Enabled=false;
				OpenSTEPbutton.Enabled=false;
				CheckOut_Step.Enabled=false;
				button38.Visible=false;
//				generateSTEPbuttron.Enabled=false;
				openPDFbutton.Enabled=false;
				CheckOut_pdf.Enabled=false;
//				generatePDFbutton.Enabled=false;				
				button28.Text=("Undo");}
	else {
				CodeBox.ReadOnly=true;
				NameBox.ReadOnly=true;
				StatusBox.ReadOnly=true;
				RevBox.ReadOnly=true;
				DateBox.ReadOnly=true;
				DesignerBox.ReadOnly=true;
				ThreedBox.ReadOnly=true;
				StepBox.ReadOnly=true;
				TwodBox.ReadOnly=true;
				PdfBox.ReadOnly=true;
				weightBox.ReadOnly=true;
				materialBox.ReadOnly=true;
				ttreatmentBox.ReadOnly=true;
				coatingBox.ReadOnly=true;
				supplierBox.ReadOnly=true;
				button30.Visible=false;
				jpegfile.ReadOnly=true;
				jpegfile.Visible=false;
				button38.Visible=true;
//				pictureBox1.ReadOnly=false; //check
				button28.Text=("Modify");
				WhereUsed.Enabled=true;
				OpenCADbutton.Enabled=true;
				Checkout_3D.Enabled=true;
				whereUSEDbutton.Enabled=true;
				open2Dbutton.Enabled=true;
				Checkout_2D.Enabled=true;
				where2Dbutton.Enabled=true;
				OpenSTEPbutton.Enabled=true;
				CheckOut_Step.Enabled=true;
//				generateSTEPbuttron.Enabled=false;
				openPDFbutton.Enabled=true;
				generatePDFbutton.Enabled=true;
				CheckOut_pdf.Enabled=true;
//				generatePDFbutton.Enabled=false;	
				button29.Visible=false;
				GO_PART_BoxSelectedIndexChanged();  //to search
			}	

		} //modify prt
		void Button29Click(object sender, EventArgs e) //write prt
		{
			
			if (CodeBox.Text!=""){
	
			if(Addpartstatus==0){
			
		 foreach(DataRow dr in Parttable.Rows) // search whole table
 	{
 		if(dr["PartCode"].ToString() == PART_Box.SelectedItem.ToString()) // if id==2  FAM_Box.SelectedItem.ToString()
    	{
//	dr["PartCode"]= CodeBox.Text.ToString();
 			if (NameBox.Text.ToString()!="")
 			{ dr["PartName"]= NameBox.Text.ToString();}
 			else {dr["PartName"]="NULL";}
 			if (StatusBox.Text.ToString()!="")
 			{ 	dr["PartStatus"]= StatusBox.Text.ToString();}
 			else {dr["PartStatus"]="NULL";}
 			if (RevBox.Text.ToString()!="")
 			{ 	dr["PartRev"]= RevBox.Text.ToString();}
 			else {dr["PartRev"]="NULL";}
 			if (DateBox.Text.ToString()!="")
 			{ dr["PartDate"]= DateBox.Text.ToString();}
 			else {dr["PartDate"]="NULL";}
 			if (DesignerBox.Text.ToString()!="")
 			{ dr["PartDesigner"]= DesignerBox.Text.ToString();}
 			else {dr["PartDesigner"]="NULL";}
 			if (ThreedBox.Text.ToString()!="")
 			{ dr["PartTHREE_D"]= ThreedBox.Text.ToString();}
 			else {dr["PartTHREE_D"]="NULL";}
 			if (StepBox.Text.ToString()!="")
 			{ dr["PartStep"]= StepBox.Text.ToString();}
 			else {dr["PartStep"]="NULL";}
 			if (TwodBox.Text.ToString()!="")
 			{ dr["PartTWO_D"]= TwodBox.Text.ToString();}
 			else {dr["PartTWO_D"]="NULL";}
 			if (PdfBox.Text.ToString()!="")
 			{ dr["PartPdf"]= PdfBox.Text.ToString();}
 			else {dr["PartPdf"]="NULL";}
 			if (weightBox.Text.ToString()!="")
 			{ dr["PartWeight"]= weightBox.Text.ToString();}
 			else {dr["PartWeight"]="NULL";}
 			if (materialBox.Text.ToString()!="")
 			{ dr["PartMaterial"]= materialBox.Text.ToString();}
 			else {dr["PartMaterial"]="NULL";}
 			if (ttreatmentBox.Text.ToString()!="")
 			{ dr["PartTThreat"]= ttreatmentBox.Text.ToString();}
 			else {dr["PartTThreat"]="NULL";}
 			if (coatingBox.Text.ToString()!="")
 			{ dr["PartCoat"]= coatingBox.Text.ToString();}
 			else {dr["PartCoat"]="NULL";}
 			if (supplierBox.Text.ToString()!="")
 			{ dr["PartSupplyer"]= supplierBox.Text.ToString();}
 			else {dr["PartSupplyer"]="NULL";}
 			if (jpegfile.Text.ToString()!="")
 			{ dr["PartImage"]= jpegfile.Text.ToString();}
 			else {dr["PartImage"]="NULL";}

    	}
	}
			}
			else{
			  {			
						
//if (CodeBox.Text!=""){}else{MessageBox.Show("Please enter a part code");}
						Partrow=Parttable.NewRow();
					
if (CodeBox.Text!=""){Partrow["PartCode"]=CodeBox.Text.ToString();}else{Partrow["PartCode"]="NULL";}
if (NameBox.Text!=""){Partrow["PartName"]=NameBox.Text.ToString();}else{Partrow["PartName"]="NULL";}
if (StatusBox.Text!=""){Partrow["PartStatus"]=StatusBox.Text.ToString();}else{Partrow["PartStatus"]="NULL";}
if (RevBox.Text!=""){Partrow["PartRev"]=RevBox.Text.ToString();}else{Partrow["PartRev"]="NULL";}
if (DateBox.Text!=""){Partrow["PartDate"]=DateBox.Text.ToString();}else{Partrow["PartDate"]="NULL";}
if (DesignerBox.Text!=""){Partrow["PartDesigner"]=DesignerBox.Text.ToString();}else{Partrow["PartDesigner"]="NULL";}
if (ThreedBox.Text!=""){Partrow["PartTHREE_D"]=ThreedBox.Text.ToString();}else{Partrow["PartTHREE_D"]="NULL";}
if (StepBox.Text!=""){Partrow["PartStep"]=StepBox.Text.ToString();}else{Partrow["PartStep"]="NULL";}
if (TwodBox.Text!=""){Partrow["PartTWO_D"]=TwodBox.Text.ToString();}else{Partrow["PartTWO_D"]="NULL";}
if (PdfBox.Text!=""){Partrow["PartPdf"]=PdfBox.Text.ToString();}else{Partrow["PartPdf"]="NULL";}
if (weightBox.Text!=""){Partrow["PartWeight"]=weightBox.Text.ToString();}else{Partrow["PartWeight"]="NULL";}
if (materialBox.Text!=""){Partrow["PartMaterial"]=materialBox.Text.ToString();}else{Partrow["PartMaterial"]="NULL";}
if (ttreatmentBox.Text!=""){Partrow["PartTThreat"]=ttreatmentBox.Text.ToString();}else{Partrow["PartTThreat"]="NULL";}
if (coatingBox.Text!=""){Partrow["PartCoat"]=coatingBox.Text.ToString();}else{Partrow["PartCoat"]="NULL";}
if (supplierBox.Text!=""){Partrow["PartSupplyer"]=supplierBox.Text.ToString();}else{Partrow["PartSupplyer"]="NULL";}
if(jpegfile.Text!=""){Partrow["PartImage"]=jpegfile.Text.ToString();}else{Partrow["PartImage"]="NULL";}
Parttable.Rows.Add(Partrow);
//					}else{MessageBox.Show("Please enter a part code");}


			Matchrow=Matchtable.NewRow();
			Matchrow["PartListed"]= CodeBox.Text.ToString();
            Matchrow["ProjectListed"]= prodID.Text.ToString();
			Matchtable.Rows.Add(Matchrow);



}
               }	
		
		//}
		 WriteXML();
//	famstatusBox.ReadOnly=true;
	button29.Visible=false;
	button28.Text=("Modify");
	button38.Text=("Add");	
	button38.Visible=true;
	button30.Visible=false;
//	jpegfile.ReadOnly=true;
	jpegfile.Visible=false;		
	
	}else{MessageBox.Show("Please enter a part code");}
		} //write prt
		void Button30Click(object sender, EventArgs e)
		{
			string imagefile="";
			OpenFileDialog 	fbd = new OpenFileDialog();
			
fbd.InitialDirectory=(CAD_DIR_Location + "\\" + ImageFolder);
 DialogResult result = fbd.ShowDialog();
 if (result.ToString()=="OK"){imagefile = fbd.FileName;    //}
	string filename = Path.GetFileName(imagefile);
jpegfile.Text=(filename);
			
		}  
		}
		void WhereUsedClick(object sender, EventArgs e)
		{
			string Code_full_check = CodeBox.Text;
			string Code_no_rev_check="";
			string Code_no_index_check="";
			
			if (Code_full_check!="")
			{WouldBe_PDM_sharpdev.Where_used Whereused = new WouldBe_PDM_sharpdev.Where_used();
				if (Code_full_check.Length>=8) {Code_no_rev_check = Code_full_check.Substring(0,8);
				Whereused.label3.Text=(Code_no_rev_check);}
				if (Code_full_check.Length>=5) {Code_no_index_check = Code_full_check.Substring(0,5);
				Whereused.label5.Text=(Code_no_index_check);}

			Whereused.Show();
		    WouldBe_PDM_sharpdev.Where_used.ActiveForm.Activate();
		    Whereused.Activate();
			Whereused.label2.Text=(Code_full_check);
			
			
			
	foreach(DataRow dr in Matchtable.Rows) // search whole table
 	{string chatchme = dr["PartListed"].ToString();
 	if(chatchme==Code_full_check)
//			dr["PartListed"].ToString() == Code_full_check) // if id==2  FAM_Box.SelectedItem.ToString()
   	{
 		foreach(DataRow dr2 in Prodtable.Rows) // search whole table
 	{
 		if(dr2["ProductCode"].ToString() == dr["ProjectListed"].ToString()) // if id==2  FAM_Box.SelectedItem.ToString()
 		{if(!Whereused.textBox1.Text.Contains(dr2["ProductName"].ToString())){
 			Whereused.textBox1.AppendText(dr2["ProductName"].ToString()+"\n");}
 			foreach(DataRow dr3 in Prjtable.Rows) // search whole table
 				{if(dr3["ID"].ToString() == dr2["ProjectCode"].ToString()) // if id==2  FAM_Box.SelectedItem.ToString()
 				{ if(!Whereused.textBox6.Text.Contains(dr3["Name"].ToString())){
					Whereused.textBox6.AppendText(dr3["Name"].ToString()+"\n");}
 					    	}
				}
     	}
	}
 	}
 	if(chatchme.Length>=8){
 	if(chatchme.Substring(0,8) == Code_no_rev_check) // if id==2  FAM_Box.SelectedItem.ToString()
   	{
 		foreach(DataRow dr2 in Prodtable.Rows) // search whole table
 	{
 		if(dr2["ProductCode"].ToString() == dr["ProjectListed"].ToString()) // if id==2  FAM_Box.SelectedItem.ToString()
 		{if(!Whereused.textBox2.Text.Contains(dr2["ProductName"].ToString())){
 			Whereused.textBox2.AppendText(dr2["ProductName"].ToString()+"\n");}
 			foreach(DataRow dr3 in Prjtable.Rows) // search whole table
 				{if(dr3["ID"].ToString() == dr2["ProjectCode"].ToString()) // if id==2  FAM_Box.SelectedItem.ToString()
 				{ if(!Whereused.textBox5.Text.Contains(dr3["Name"].ToString())){
					Whereused.textBox5.AppendText(dr3["Name"].ToString()+"\n");}
 					    	}
				}
     	}
	}
 	}
 	}	
 	if(chatchme.Length>=5){
 	if(chatchme.Substring(0,5) == Code_no_index_check) // if id==2  FAM_Box.SelectedItem.ToString()
   	{
 		foreach(DataRow dr2 in Prodtable.Rows) // search whole table
 	{
 		if(dr2["ProductCode"].ToString() == dr["ProjectListed"].ToString()) // if id==2  FAM_Box.SelectedItem.ToString()
 		{if(!Whereused.textBox3.Text.Contains(dr2["ProductName"].ToString())){
 			Whereused.textBox3.AppendText(dr2["ProductName"].ToString()+"\n");}
 			foreach(DataRow dr3 in Prjtable.Rows) // search whole table
 				{if(dr3["ID"].ToString() == dr2["ProjectCode"].ToString()) // if id==2  FAM_Box.SelectedItem.ToString()
 				{ if(!Whereused.textBox4.Text.Contains(dr3["Name"].ToString())){
					Whereused.textBox4.AppendText(dr3["Name"].ToString()+"\n");}
 					    	}
				}
     	}
	}
 	}
 	}
	}
	
	
	
	
			}
			else {MessageBox.Show("Pleaase select a valid CODE");}
		}
		void Button6Click(object sender, EventArgs e)
		{
	 string drawing_full_file= CAD_DIR_Location + "\\" + PdfFolder + "\\" + drawingfilenameBox.Text.ToString();
//  if (File.Exists(drawing_full_file)){button6.Enabled=true;} else{button6.Enabled=false;}
	if (File.Exists (drawing_full_file) ) 
		{ViewFileFolder(drawing_full_file );} 
		}
		void Button31Click(object sender, EventArgs e)
		{
	
	DialogResult dialogResult = MessageBox.Show("Start UG NX TOP?", "UG NX Startup", MessageBoxButtons.YesNo);
if(dialogResult == DialogResult.Yes)
{
                ProcessStartInfo psi = new ProcessStartInfo("\"" + Ug_NX_TOP_exe + "\"" );

                Debug.WriteLine(psi.FileName + " " + " -nx");

//                IntPtr oCatiaHwnd= IntPtr.Zero;
//                bool bFound = false;

                psi.UseShellExecute = false;
                psi.RedirectStandardOutput = false;
                psi.RedirectStandardError = true;

                
                
   //Prozess starten und auf dessen Ende warten
                //using (Process process = new Process())
                Process process = new Process();
                {
                    process.EnableRaisingEvents = true;
                    process.StartInfo = psi;
                    process.Start();
                    Application.DoEvents();
                    Process[] Ps = Process.GetProcesses();
                    int L = Ps.Length;
                    int timeout = 5000;
                    process.WaitForExit(timeout);
                }
   
                }
else if (dialogResult == DialogResult.No)
{
    //do something else
}			
			
			
		}
		void Button32Click(object sender, EventArgs e)
		{
	
	
	DialogResult dialogResult = MessageBox.Show("Start UG NX LOW?", "UG NX Startup", MessageBoxButtons.YesNo);
if(dialogResult == DialogResult.Yes)
{
                ProcessStartInfo psi = new ProcessStartInfo("\"" + Ug_NX_LOW_exe + "\"" );

                Debug.WriteLine(psi.FileName + " " + " -nx");

//                IntPtr oCatiaHwnd= IntPtr.Zero;
//                bool bFound = false;

                psi.UseShellExecute = false;
                psi.RedirectStandardOutput = false;
                psi.RedirectStandardError = true;

                
                
   //Prozess starten und auf dessen Ende warten
                //using (Process process = new Process())
                Process process = new Process();
                {
                    process.EnableRaisingEvents = true;
                    process.StartInfo = psi;
                    process.Start();
                    Application.DoEvents();
                    Process[] Ps = Process.GetProcesses();
                    int L = Ps.Length;
                    int timeout = 5000;
                    process.WaitForExit(timeout);
                }
   
                }
else if (dialogResult == DialogResult.No)
{
    //do something else
}			
		
			
			
		}
		void Button33Click(object sender, EventArgs e)
		{
	System.Diagnostics.Process.Start("https://github.com/robertobartola/WouldBePDM");
		}
		void Button1Click(object sender, EventArgs e)
		{
	
		WouldBe_PDM_sharpdev.ManyThanx ManyThanks = new WouldBe_PDM_sharpdev.ManyThanx();
		    	ManyThanks.Show();
		    	WouldBe_PDM_sharpdev.ManyThanx.ActiveForm.Activate();
		    	ManyThanks.Activate();			
		}
		void CheckBoxPRJCheckedChanged(object sender, EventArgs e)
		{
			 MainFormLoad(null, null);
				checkBoxPROD.Checked=false;
				checkBox2.Checked=false;
				PROD_Box.Enabled=false;
				checkBoxPRT.Checked=false;
				checkBox3.Checked=false;
				PART_Box.Enabled=false;
			if (checkBox1.Checked==false){
					checkBox1.Checked=true;
					groupBox7.Enabled=true;
					PRJ_Box.Enabled=true;


				foreach(DataRow dr in Prjtable.Rows)  	{					
					
						PRJ_Box.Items.Add(dr["Name"].ToString());
				}
			}
				else{
		    	checkBox1.Checked=false;
		    	PRJ_Box.Enabled=false;
						}
		}
		void CheckBoxPRODCheckedChanged(object sender, EventArgs e)
		{
				MainFormLoad(null, null);
				checkBoxPRJ.Checked=false;
				checkBox1.Checked=false;
				PRJ_Box.Enabled=false;
				checkBoxPRT.Checked=false;
				checkBox3.Checked=false;
				PART_Box.Enabled=false;
			if (checkBox2.Checked==false){
					checkBox2.Checked=true;
					groupBox8.Enabled=true;
					PROD_Box.Enabled=true;
					foreach(DataRow dr in Prodtable.Rows) // search whole table
 	{
   	{PROD_Box.Items.Add(dr["ProductName"].ToString()); }
	}
			}
				else{
		    	checkBox2.Checked=false;
		    	PROD_Box.Enabled=false;
						}
		}
		void CheckBoxPRTCheckedChanged(object sender, EventArgs e)
		{
				MainFormLoad(null, null);
				checkBoxPRJ.Checked=false;
				checkBox1.Checked=false;
				PRJ_Box.Enabled=false;
				checkBoxPROD.Checked=false;
				checkBox2.Checked=false;
				PROD_Box.Enabled=false;
			if (checkBox3.Checked==false){
					checkBox3.Checked=true;
					groupBox5.Enabled=true;
					PART_Box.Enabled=true;
					
	 foreach(DataRow dr in Matchtable.Rows) // search whole table
 	{
   	{PART_Box.Items.Add(dr["PartListed"].ToString());  }
	}	
			}
				else{
		    	checkBox3.Checked=false;
		    	PART_Box.Enabled=false;
		    	groupBox5.Enabled=false;
				}
			
//				if (groupBox5.Enabled==false) {groupBox5.Enabled=true;
//				PART_Box.Enabled=true;
//				
//	 foreach(DataRow dr in Matchtable.Rows) // search whole table
// 	{
//// 	if(dr["ProjectListed"].ToString() == projectselectedID) // if id==2  FAM_Box.SelectedItem.ToString()
//   	{PART_Box.Items.Add(dr["PartListed"].ToString());  }
//	}		
//			
//			
//			}
//			else{groupBox5.Enabled=false;
//			PART_Box.Enabled=false;
//			PART_Box.Items.Clear();}
//			
//			
//			if (checkBoxPRJ.Checked==true){
//		    	checkBoxPRJ.Checked=false;
//		    	groupBox7.Enabled=false;
//		    }
//		    if (checkBoxPROD.Checked==true){
//		    	checkBoxPROD.Checked=false;
//		    	groupBox8.Enabled=true;
//		    }
//		    
//			
//			
//			
		}
		
		void clearalldata()
		{

			FAM_Box.Items.Clear();
		    FAM_Box.Text=("Select a Family");
			PRJ_Box.Items.Clear();
		    PRJ_Box.Text=("Select a Project");
			PROD_Box.Items.Clear();
		    PROD_Box.Text=("Select a Product");
		    PART_Box.Items.Clear();
		    PART_Box.Text=("Select a Component");
   
		    	groupBox7.Enabled=false;								
				groupBox5.Enabled=false;				
//				checkBoxPROD.Checked=false;
//				PRJ_Box.Enabled=false;
//				PART_Box.Enabled=false;  

			famstatusBox.Text=("");
			FAM_Box.Items.Clear();
			famID.Text=("");
			
				ProjectCodeBox.Text=("");
				projectstatusBox.Text=("");
				projectManagerBox.Text=("");
				textBox1.Text=("");
				textBox2.Text=("");
				textBox3.Text=("");
				drawingBox.Text=("");
				drawingRevBox.Text=("");
				drawingdateBox.Text=("");
				drawingfilenameBox.Text=("");
					
					CodeBox.Text=("");
					NameBox.Text=("");
			
              		
CodeBox.Text=("");
NameBox.Text=("");
StatusBox.Text=("");
RevBox.Text=("");
DateBox.Text=("");
DesignerBox.Text=("");
ThreedBox.Text=("");
StepBox.Text=("");
TwodBox.Text=("");
PdfBox.Text=("");
weightBox.Text=("");
materialBox.Text=("");
ttreatmentBox.Text=("");
coatingBox.Text=("");
supplierBox.Text=("");
pictureBox1.Image = null;
		
		}
		void Button17Click(object sender, EventArgs e)
		{
 string path=Environment.CurrentDirectory;
  FolderBrowserDialog fbd = new FolderBrowserDialog();
  if (CATIA_TOP_EXE.Text.ToString()!=""){fbd.SelectedPath = CATIA_TOP_EXE.Text.ToString();}
  else{fbd.SelectedPath = Environment.CurrentDirectory;}
  DialogResult result = fbd.ShowDialog();
 if (result.ToString()=="OK"){path = fbd.SelectedPath; 
  	CATDLLPath_TOP = path; // filename;
           CATIA_TOP_EXE.Clear();
			CATIA_TOP_EXE.Text=(CATDLLPath_TOP);
  }
		}
		void Button20Click(object sender, EventArgs e)
		{
	 string path=Environment.CurrentDirectory;
OpenFileDialog openFileDialog1 = new OpenFileDialog();
   if (CATIA_TOP_ENV.Text.ToString()!=""){openFileDialog1.InitialDirectory = CATIA_TOP_ENV.Text.ToString();}
   else{openFileDialog1.InitialDirectory = Environment.CurrentDirectory;}
    openFileDialog1.Title = "Select ENV File";
    openFileDialog1.CheckFileExists = true;
    openFileDialog1.CheckPathExists = true;
    //openFileDialog1.DefaultExt = "txt";
    //openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
    openFileDialog1.FilterIndex = 2;
    openFileDialog1.RestoreDirectory = true;
    openFileDialog1.ReadOnlyChecked = true;
    openFileDialog1.ShowReadOnly = true;
    if (openFileDialog1.ShowDialog() == DialogResult.OK)
    {
        path = openFileDialog1.FileName;
        string filename = Path.GetFileName(path);
ApplicationPath_TOP = filename;
           CATIA_TOP_ENV_Dir.Clear();
			CATIA_TOP_ENV_Dir.Text=(ApplicationPath_TOP);
    } 
		}
		void Button21Click(object sender, EventArgs e)
		{
	 string path=Environment.CurrentDirectory;
  FolderBrowserDialog fbd = new FolderBrowserDialog();
  if (CATIA_TOP_ENV.Text.ToString()!=""){fbd.SelectedPath = CATIA_TOP_ENV.Text.ToString();}
  else{fbd.SelectedPath = Environment.CurrentDirectory;}
  DialogResult result = fbd.ShowDialog();
 if (result.ToString()=="OK"){path = fbd.SelectedPath;    //}
  	ApplicationPath_TOP = path; // filename;
           CATIA_TOP_ENV.Clear();
			CATIA_TOP_ENV.Text=(ApplicationPath_TOP);
  }
		}
		void Button14Click(object sender, EventArgs e)
		{
string path=Environment.CurrentDirectory;
  FolderBrowserDialog fbd = new FolderBrowserDialog();
  if (CATIA_LOW_EXE.Text.ToString()!=""){fbd.SelectedPath = CATIA_LOW_EXE.Text.ToString();}
  else{fbd.SelectedPath = Environment.CurrentDirectory;}
  DialogResult result = fbd.ShowDialog();
 if (result.ToString()=="OK"){path = fbd.SelectedPath; 
  	CATDLLPath_LOW = path; // filename;
           CATIA_LOW_EXE.Clear();
			CATIA_LOW_EXE.Text=(CATDLLPath_LOW);
  }	
		}
		void Button22Click(object sender, EventArgs e)
		{
	 string path=Environment.CurrentDirectory;
OpenFileDialog openFileDialog1 = new OpenFileDialog();
   if (CATIA_LOW_ENV.Text.ToString()!=""){openFileDialog1.InitialDirectory = CATIA_LOW_ENV.Text.ToString();}
   else{openFileDialog1.InitialDirectory = Environment.CurrentDirectory;}
    openFileDialog1.Title = "Select ENV File";
    openFileDialog1.CheckFileExists = true;
    openFileDialog1.CheckPathExists = true;
    //openFileDialog1.DefaultExt = "txt";
    //openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
    openFileDialog1.FilterIndex = 2;
    openFileDialog1.RestoreDirectory = true;
    openFileDialog1.ReadOnlyChecked = true;
    openFileDialog1.ShowReadOnly = true;
    if (openFileDialog1.ShowDialog() == DialogResult.OK)
    {
        path = openFileDialog1.FileName;
        string filename = Path.GetFileName(path);
ApplicationPath_LOW = filename;
           CATIA_LOW_ENV_Dir.Clear();
			CATIA_LOW_ENV_Dir.Text=(ApplicationPath_LOW);
    } 	
		}
		void Button15Click(object sender, EventArgs e)
		{
	 string path=Environment.CurrentDirectory;
  FolderBrowserDialog fbd = new FolderBrowserDialog();
  if (CATIA_LOW_ENV.Text.ToString()!=""){fbd.SelectedPath = CATIA_LOW_ENV.Text.ToString();}
  else{fbd.SelectedPath = Environment.CurrentDirectory;}
  DialogResult result = fbd.ShowDialog();
 if (result.ToString()=="OK"){path = fbd.SelectedPath;    //}
  	ApplicationPath_LOW = path; // filename;
           CATIA_LOW_ENV.Clear();
			CATIA_LOW_ENV.Text=(ApplicationPath_LOW);
  }
			
		}
		void Button34Click(object sender, EventArgs e)
		{
	ViewFileFolder(Environment.CurrentDirectory);
		}
		void Button35Click(object sender, EventArgs e)
		{
//					if (FAM_Box.Text!="Select a Family"){
			
//			if (FAM_Box.SelectedItem== null){}
//			else{
			
			
			
	if (famstatusBox.ReadOnly== true){
				Addfamiliystatus=1;
				famstatusBox.ReadOnly=false;
				famID.ReadOnly=false;
				button35.Text=("Undo");
				button19.Visible=false;
//				FAM_Box.Items.Add("Replace with family");
//				FAM_Box.SelectedIndex = FAM_Box.FindStringExact("Replace with family");
				famstatusBox.Text=("Insert status");
				famID.Text=("Insert ID");
				FAM_Box.Visible=false;
				textBox4.Text=("Replace with family");
//				FAM_Box.SelectedIndex = FAM_Box.FindStringExact("Replace with family");
				if(FAM_Box.SelectedText!=null){
					famstatusBox.Enabled=true;
					famstatusBoxPRE=0;
					famID.Enabled=true;
				}else{famstatusBoxPRE=1;}
				}
	else {
//				if (FAM_Box.Text!="Select a Family"){
//					Go_ComboBox1SelectedIndexChanged();
				famstatusBox.ReadOnly=true;
				button19.Visible=true;
				famID.ReadOnly=true;
				button35.Text=("Add");
				Addfamiliystatus=0;
				FAM_Box.Visible=true;
				if(famstatusBoxPRE==0){
					famstatusBox.Enabled=false;
					famID.Enabled=false;
				}
				
				
				
				}
//			}
	if (Write_status.Visible==false){Write_status.Visible=true;}
	else {Write_status.Visible=false;}		
			
//			}
			
//			}
		}
		void Button36Click(object sender, EventArgs e)
		{
						
			if (projectstatusBox.ReadOnly== true){
				Addprojectstatus=1;
				
				ProjectCodeBox.ReadOnly=false;
				textBox1.ReadOnly=false;
				textBox2.ReadOnly=false;
				prjID.ReadOnly=false;
				prjID.Enabled=true;
//				projectstatusBox.Enabled=true;
				projectstatusBox.ReadOnly=false;
				projectManagerBox.ReadOnly=false;
				button36.Text=("Undo");
				button25.Visible=false;
				projectstatusBox.Text=("Insert status");
				prjID.Text=("Insert ID");
				PRJ_Box.Visible=false;
				textBox5.Text=("Replace with project");
				textBox2.Text=("Replace with name");
				//Replace with 
				textBox1.Text=("Replace with code");
				ProjectCodeBox.Text=("Replace with project");
				projectManagerBox.Text=("Replace with Project Manager");
				
//				FAM_Box.SelectedIndex = FAM_Box.FindStringExact("Replace with family");
				if(PRJ_Box.SelectedText!=null){
					projectstatusBox.Enabled=true;
					prjID.Enabled=true;
					prjstatusBoxPRE=0;
				}else{prjstatusBoxPRE=1;}
				}
	else {
				ProjectCodeBox.ReadOnly=true;
				textBox1.ReadOnly=true;
				textBox2.ReadOnly=true;
				button25.Visible=true;
				prjID.ReadOnly=true;
//				projectstatusBox.ReadOnly=true;
				projectManagerBox.ReadOnly=true;
				projectManagerBox.ReadOnly=true;
				PRJ_Box.Visible=true;
				Addprojectstatus=0;
				if (PRJ_Box.SelectedItem!= null){GO_PRJ_BoxSelectedIndexChanged();}  //to search
				else{Go_ComboBox1SelectedIndexChanged();}
				projectstatusBox.ReadOnly=true;
				button36.Text=("Add");
				Addprojectstatus=0;
				if(prjstatusBoxPRE==0){
//					projectstatusBox.Enabled=false;
					prjID.Enabled=false;
				}
				
				
				
				}
//			}
	if (button24.Visible==false){button24.Visible=true;}
	else {button24.Visible=false;}	
			
			
			
			
	
		}
		void Button37Click(object sender, EventArgs e)
		{
//			string projectselectedID;
	//to migrate from prj to prod
							
			if (textBox3.ReadOnly==true){  //prod
				Addproductstatus=1; //prod
				textBox6.Text=("Replace with Name");
				textBox3.ReadOnly=false;
				textBox3.Text=("Replace with status");
				drawingBox.ReadOnly=false;
				drawingBox.Text=("Replace with drawing");
				drawingRevBox.ReadOnly=false;
				drawingRevBox.Text=("Replace with REV");
				drawingdateBox.ReadOnly=false;
				drawingdateBox.Text=("Replace with date");
				drawingfilenameBox.ReadOnly=false;
				drawingfilenameBox.Text=("Replace with filename");
				carBOX.ReadOnly=false;
				carBOX.Text=("Replace with car");
				button26.Visible=true;
				PROD_Box.Visible=false;
				prodID.Enabled=true;
				prodID.ReadOnly=false;
				prodID.Text=("Replace with ID");
				button27.Visible=false;
				button37.Text=("Undo");
				button18.Enabled=false;
				button6.Enabled=false;
					}
	else {
				textBox3.ReadOnly=true;
				drawingBox.ReadOnly=true;
				drawingRevBox.ReadOnly=true;
				drawingdateBox.ReadOnly=true;	
				drawingfilenameBox.ReadOnly=true;
				carBOX.ReadOnly=true;
				button37.Text=("Add");
				button18.Enabled=true;
				button6.Enabled=true;
				button27.Visible=true;
				Addproductstatus=0; //prod
				button26.Visible=false;
				PROD_Box.Visible=true;
//				prodID.Enabled=false;
				prodID.ReadOnly=true;
				if (PROD_Box.SelectedItem!=null){
					GO_PROD_BoxSelectedIndexChanged();
					textBox3.Enabled=true;
					prodID.Enabled=true;
					prodstatusBoxPRE=0;
				}else{prodstatusBoxPRE=1;
				GO_PRJ_BoxSelectedIndexChanged();}
			}	
				if(prodstatusBoxPRE==0){
//					projectstatusBox.Enabled=false;
//					prodID.Enabled=false;
				}
		}
		void Button38Click(object sender, EventArgs e)
		{
	
			if (CodeBox.ReadOnly== true){
				CodeBox.ReadOnly=false;
				NameBox.ReadOnly=false;
				StatusBox.ReadOnly=false;
				RevBox.ReadOnly=false;
				DateBox.ReadOnly=false;
				DesignerBox.ReadOnly=false;
				ThreedBox.ReadOnly=false;
				StepBox.ReadOnly=false;
				TwodBox.ReadOnly=false;
				PdfBox.ReadOnly=false;
				weightBox.ReadOnly=false;
				materialBox.ReadOnly=false;
				ttreatmentBox.ReadOnly=false;
				coatingBox.ReadOnly=false;
				supplierBox.ReadOnly=false;
				button30.Visible=true;
				jpegfile.ReadOnly=false;
					
				CodeBox.Text="Insert value";
				NameBox.Text="Insert value";
				StatusBox.Text="Insert value";
				RevBox.Text="Insert value";
				DateBox.Text="Insert value";
				DesignerBox.Text="Insert value";
				ThreedBox.Text="Insert value";
				StepBox.Text="Insert value";
				TwodBox.Text="Insert value";
				PdfBox.Text="Insert value";
				weightBox.Text="Insert value";
				materialBox.Text="Insert value";
				ttreatmentBox.Text="Insert value";
				coatingBox.Text="Insert value";
				supplierBox.Text="Insert value";
				jpegfile.Text="Insert value";
//pictureBox1.Image.Dispose();
            	pictureBox1.Image = null;
            
				jpegfile.Visible=true;
				button29.Visible=true;
				WhereUsed.Enabled=false;
				OpenCADbutton.Enabled=false;
				Checkout_3D.Enabled=false;
				whereUSEDbutton.Enabled=false;
				open2Dbutton.Enabled=false;
				Checkout_2D.Enabled=false;
				where2Dbutton.Enabled=false;
				OpenSTEPbutton.Enabled=false;
				CheckOut_Step.Enabled=false;
				button28.Visible=false;
//				generateSTEPbuttron.Enabled=false;
				openPDFbutton.Enabled=false;
				generatePDFbutton.Enabled=false;
				CheckOut_pdf.Enabled=false;
				if(groupBox5.Enabled==false){partwasinvisible=1;}
				groupBox5.Enabled=true;
				generatePDFbutton.Enabled=false;				
				button38.Text=("Undo");
				Addpartstatus=1;
			// add a part
			}
						
	else {
				CodeBox.ReadOnly=true;
				NameBox.ReadOnly=true;
				StatusBox.ReadOnly=true;
				RevBox.ReadOnly=true;
				DateBox.ReadOnly=true;
				DesignerBox.ReadOnly=true;
				ThreedBox.ReadOnly=true;
				StepBox.ReadOnly=true;
				TwodBox.ReadOnly=true;
				PdfBox.ReadOnly=true;
				weightBox.ReadOnly=true;
				materialBox.ReadOnly=true;
				ttreatmentBox.ReadOnly=true;
				coatingBox.ReadOnly=true;
				supplierBox.ReadOnly=true;
				button30.Visible=false;
				jpegfile.ReadOnly=true;
				jpegfile.Visible=false;
				button28.Visible=true;
				button28.Enabled=false;
				
				CodeBox.Text="";
				NameBox.Text="";
				StatusBox.Text="";
				RevBox.Text="";
				DateBox.Text="";
				DesignerBox.Text="";
				ThreedBox.Text="";
				StepBox.Text="";
				TwodBox.Text="";
				PdfBox.Text="";
				weightBox.Text="";
				materialBox.Text="";
				ttreatmentBox.Text="";
				coatingBox.Text="";
				supplierBox.Text="";
				jpegfile.Text="";

//				pictureBox1.ReadOnly=false; //check
				button38.Text=("Add");
				WhereUsed.Enabled=true;
				button29.Visible=false;
				if(partwasinvisible==1){groupBox5.Enabled=true;
					partwasinvisible=0;}
				if(PART_Box.SelectedItem!=null){
					OpenCADbutton.Enabled=true;
				Checkout_3D.Enabled=true;
				whereUSEDbutton.Enabled=true;
				open2Dbutton.Enabled=true;
				Checkout_2D.Enabled=true;
				where2Dbutton.Enabled=true;
				OpenSTEPbutton.Enabled=true;
				CheckOut_Step.Enabled=true;
//				generateSTEPbuttron.Enabled=false;
				openPDFbutton.Enabled=true;
				generatePDFbutton.Enabled=true;
				CheckOut_pdf.Enabled=true;
				generatePDFbutton.Enabled=false;	
				Addpartstatus=0;
					GO_PART_BoxSelectedIndexChanged();}  //to search
			}	
			
			}
		void CheckBOMClick(object sender, EventArgs e)
		{
//			string product_to_bom="";
//		if (prodID.Text!=""){
//			MessageBox.Show(PRJ_Box.SelectedItem.ToString());
			foreach(DataRow dr in Filtertable.Rows) // search whole table
 	{
 		if(dr["Project_Filter"].ToString() == prjID.Text.ToString()) // if id==2  FAM_Box.SelectedItem.ToString()
    	{
 			Search1_textfilter=dr["FilterText1"].ToString();
 			Search2_textfilter=dr["FilterText2"].ToString();
 			Search3_textfilter=dr["FilterText3"].ToString();
 			Search4_textfilter=dr["FilterText4"].ToString();
 			Search_codefilter1=dr["FilterCode1"].ToString();
 			Search_codefilter2=dr["FilterCode2"].ToString();
 			Search_codefilter3=dr["FilterCode3"].ToString();
 			Search_codefilter4=dr["FilterCode4"].ToString();
 			Search_codefilter5=dr["FilterCode5"].ToString();
 			Search_codefilter6=dr["FilterCode6"].ToString();
 			
// 			MessageBox.Show("testi " + Search1_textfilter + Search2_textfilter + Search3_textfilter +Search4_textfilter);
 		
 		}
	}
			

			WouldBe_PDM_sharpdev.BomView BomView = new WouldBe_PDM_sharpdev.BomView();
			BomView.Show();
		    BomView.textBox3.Text=(prodID.Text.ToString());
		    BomView.textBox1.Text=(PROD_Box.SelectedItem.ToString());
		    
		    BomView.Search1_textfilter_2.Text=Search1_textfilter;
		    BomView.Search2_textfilter_2.Text=Search2_textfilter;
		    BomView.Search3_textfilter_2.Text=Search3_textfilter;
		    BomView.Search4_textfilter_2.Text=Search4_textfilter;
		    
		    BomView.Search_codefilter1.Text=Search_codefilter1;
		    BomView.Search_codefilter2.Text=Search_codefilter2;
		    BomView.Search_codefilter3.Text=Search_codefilter3;
		    BomView.Search_codefilter4.Text=Search_codefilter4;
		    BomView.Search_codefilter5.Text=Search_codefilter5;
		    BomView.Search_codefilter6.Text=Search_codefilter6;
	

		    foreach(string product_to_bom in PART_Box.Items)
		    
//		    foreach(DataRow dr2 in Matchtable.Rows) // search whole table
 	{
//		    	if(dr2["ProjectListed"].ToString() == PROD_Box.SelectedItem.ToString()) // if id==2  FAM_Box.SelectedItem.ToString()
		    	
   	{
//		    		PART_Box.Items.Add(dr["PartListed"].ToString());  
//		    		product_to_bom=dr2["PartListed"].ToString();
		    	
//		    	}
//	}		
		    
    
	foreach(DataRow dr in Parttable.Rows) // search whole table
 			{
 		if(dr["PartCode"].ToString()==product_to_bom) //  if (  PRT_selected ==prtcode)
              {
 			if(Search1_textfilter!=""){
 			if (dr["PartName"].ToString().Contains(Search1_textfilter))
{	
// 				BomView.Search1_text.Text=dr["PartName"].ToString();
BomView.Search1_text.AppendText(dr["PartName"].ToString());
BomView.Search1_text.AppendText("\n");
if (dr["PartCode"].ToString()!="NULL")
{BomView.Search1_code.AppendText((dr["PartCode"].ToString()));
	BomView.Search1_code.AppendText("\n");
//	BomView.Search1_code.Text=(dr["PartCode"].ToString());
 				}
 			}}

 			if(Search2_textfilter!=""){
 if (dr["PartName"].ToString().Contains(Search2_textfilter))
{	
 				BomView.Search2_text.AppendText(dr["PartName"].ToString());
BomView.Search2_text.AppendText("\n");
// 				BomView.Search2_text.Text=dr["PartName"].ToString();
if (dr["PartCode"].ToString()!="NULL"){
	BomView.Search2_code.AppendText((dr["PartCode"].ToString()));
	BomView.Search2_code.AppendText("\n");
//	BomView.Search2_code.Text=(dr["PartCode"].ToString());
}}}

 			if(Search3_textfilter!=""){
	if (dr["PartName"].ToString().Contains(Search3_textfilter))
{	
		BomView.Search3_text.AppendText(dr["PartName"].ToString());
BomView.Search3_text.AppendText("\n");
//		BomView.Search3_text.Text=dr["PartName"].ToString();
if (dr["PartCode"].ToString()!="NULL"){
	BomView.Search3_code.AppendText((dr["PartCode"].ToString()));
	BomView.Search3_code.AppendText("\n");
//	BomView.Search3_code.Text=(dr["PartCode"].ToString());
}}}

if(Search4_textfilter!=""){
	if (dr["PartName"].ToString().Contains(Search4_textfilter))
{	
		BomView.Search4_text.AppendText(dr["PartName"].ToString());
BomView.Search4_text.AppendText("\n");
//		BomView.Search4_text.Text=dr["PartName"].ToString();
if (dr["PartCode"].ToString()!="NULL"){
			BomView.Search4_code.AppendText((dr["PartCode"].ToString()));
	BomView.Search4_code.AppendText("\n");
//			BomView.Search4_code.Text=(dr["PartCode"].ToString());
}}}
 			
if(Search_codefilter1!=""){
	if (dr["PartCode"].ToString().Contains(Search_codefilter1)) //
{	
		BomView.Text_Codefilter1.Text=(dr["PartName"].ToString());
//BomView.Search4_text.AppendText("\n");
//		BomView.Search4_text.Text=dr["PartName"].ToString();
if (dr["PartCode"].ToString()!="NULL"){
//			BomView.Search4_code.AppendText((dr["PartCode"].ToString()));
			BomView.checkBox1.Checked=true;
//	BomView.Search4_code.AppendText("\n");
//			BomView.Search4_code.Text=(dr["PartCode"].ToString());
}}} 			
 
if(Search_codefilter2!=""){
	if (dr["PartCode"].ToString().Contains(Search_codefilter2)) //
{	
		BomView.Text_Codefilter2.Text=(dr["PartName"].ToString());
//BomView.Search4_text.AppendText("\n");
//		BomView.Search4_text.Text=dr["PartName"].ToString();
if (dr["PartCode"].ToString()!="NULL"){
//			BomView.Search4_code.AppendText((dr["PartCode"].ToString()));
			BomView.checkBox2.Checked=true;
//	BomView.Search4_code.AppendText("\n");
//			BomView.Search4_code.Text=(dr["PartCode"].ToString());
}}}


if(Search_codefilter3!=""){
	if (dr["PartCode"].ToString().Contains(Search_codefilter3)) //
{	
		BomView.Text_Codefilter3.Text=(dr["PartName"].ToString());
//BomView.Search4_text.AppendText("\n");
//		BomView.Search4_text.Text=dr["PartName"].ToString();
if (dr["PartCode"].ToString()!="NULL"){
//			BomView.Search4_code.AppendText((dr["PartCode"].ToString()));
			BomView.checkBox3.Checked=true;
//	BomView.Search4_code.AppendText("\n");
//			BomView.Search4_code.Text=(dr["PartCode"].ToString());
}}}
 			
 			
 			if(Search_codefilter4!=""){
	if (dr["PartCode"].ToString().Contains(Search_codefilter4)) //
{	
		BomView.Text_Codefilter4.Text=(dr["PartName"].ToString());
//BomView.Search4_text.AppendText("\n");
//		BomView.Search4_text.Text=dr["PartName"].ToString();
if (dr["PartCode"].ToString()!="NULL"){
//			BomView.Search4_code.AppendText((dr["PartCode"].ToString()));
			BomView.checkBox4.Checked=true;
//	BomView.Search4_code.AppendText("\n");
//			BomView.Search4_code.Text=(dr["PartCode"].ToString());
}}}
 			
 			if(Search_codefilter5!=""){
	if (dr["PartCode"].ToString().Contains(Search_codefilter5)) //
{	
		BomView.Text_Codefilter5.Text=(dr["PartName"].ToString());
//BomView.Search4_text.AppendText("\n");
//		BomView.Search4_text.Text=dr["PartName"].ToString();
if (dr["PartCode"].ToString()!="NULL"){
//			BomView.Search4_code.AppendText((dr["PartCode"].ToString()));
			BomView.checkBox5.Checked=true;
//	BomView.Search4_code.AppendText("\n");
//			BomView.Search4_code.Text=(dr["PartCode"].ToString());
}}}

 			if(Search_codefilter6!=""){
	if (dr["PartCode"].ToString().Contains(Search_codefilter6)) //
{	
		BomView.Text_Codefilter6.Text=(dr["PartName"].ToString());
//BomView.Search4_text.AppendText("\n");
//		BomView.Search4_text.Text=dr["PartName"].ToString();
if (dr["PartCode"].ToString()!="NULL"){
//			BomView.Search4_code.AppendText((dr["PartCode"].ToString()));
			BomView.checkBox6.Checked=true;
//	BomView.Search4_code.AppendText("\n");
//			BomView.Search4_code.Text=(dr["PartCode"].ToString());
}}}
 				    	}
	}		

             }	    
	}
	
		}
		
		void initialize_bomview()
		{

		
		}
		void Modify_BomClick(object sender, EventArgs e)
		{
			WouldBe_PDM_sharpdev.BomView BomView = new WouldBe_PDM_sharpdev.BomView();
			BomView.Show();
			BomView.comboBox1.Items.Clear();
			RereadFilter();
			
				foreach(DataRow dr in Filtertable.Rows) // search whole table
 	{
					BomView.comboBox1.Items.Add(dr["Project_Filter"].ToString());
	}
			BomView.AddButton.Visible=true;
				BomView.comboBox1.Visible=true;
			BomView.Search1_textfilter_2.Enabled=true;
			BomView.Search1_textfilter_2.ReadOnly=false;
			BomView.Search2_textfilter_2.Enabled=true;
			BomView.Search2_textfilter_2.ReadOnly=false;
			BomView.Search3_textfilter_2.Enabled=true;
			BomView.Search3_textfilter_2.ReadOnly=false;
			BomView.Search4_textfilter_2.Enabled=true;
			BomView.Search4_textfilter_2.ReadOnly=false;
			BomView.Search_codefilter1.Enabled=true;
			BomView.Search_codefilter1.ReadOnly=false;
			BomView.Search_codefilter2.Enabled=true;
			BomView.Search_codefilter2.ReadOnly=false;
			BomView.Search_codefilter3.Enabled=true;
			BomView.Search_codefilter3.ReadOnly=false;
			BomView.Search_codefilter4.Enabled=true;
			BomView.Search_codefilter4.ReadOnly=false;
			BomView.Search_codefilter5.Enabled=true;
			BomView.Search_codefilter5.ReadOnly=false;
			BomView.Search_codefilter6.Enabled=true;
			BomView.Search_codefilter6.ReadOnly=false;
//			BomView.Write_filterBOM.Enabled=true;
			BomView.Write_filterBOM.Visible=true;


			
		foreach(DataRow dr in Prjtable.Rows) // search whole table
 	{int Present=0;
			foreach(DataRow dr2 in Filtertable.Rows){
 	if(dr2["Project_Filter"].ToString()==dr["ID"].ToString()) // if id==2  FAM_Box.SelectedItem.ToString()
 	{Present=1;}
 		}
			if (Present==0){int wroteline=0;
				foreach(object comboline in BomView.comboBox2.Items){
					if(dr["IDprjFam"].ToString()==comboline.ToString()){wroteline=1;}
						}
				if(wroteline==0){BomView.comboBox2.Items.Add(dr["ID"].ToString());}
			}
		
//			BomView.comboBox1.Visible=false;
			BomView.Write_filterBOM.Visible=true;
			
		}
		}
		public void RereadFilter()
		{
			Filtertable.Clear();
				if (File.Exists(WouldBeFILTER)){             
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(WouldBeFILTER);
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/WouldBeFILTER/FilterList/Filters");
            foreach (XmlNode filetr_node in nodeList)
            {
//			FAM_Box.Items.Add(filetr_node.SelectSingleNode("FamilyName").InnerText);   //to improve
			Filterrow = Filtertable.NewRow();
			if (filetr_node.SelectSingleNode("Project_Filter").InnerText!="NULL"){Filterrow["Project_Filter"]=filetr_node.SelectSingleNode("Project_Filter").InnerText;}else{Filterrow["Project_Filter"]="";}
			if (filetr_node.SelectSingleNode("FilterText1").InnerText!="NULL"){ Filterrow["FilterText1"] = filetr_node.SelectSingleNode("FilterText1").InnerText ;}else{Filterrow["FilterText1"] ="";}
			if (filetr_node.SelectSingleNode("FilterText2").InnerText!="NULL"){Filterrow["FilterText2"] = filetr_node.SelectSingleNode("FilterText2").InnerText ;}else{Filterrow["FilterText2"] ="";}
			if (filetr_node.SelectSingleNode("FilterText3").InnerText!="NULL"){Filterrow["FilterText3"] = filetr_node.SelectSingleNode("FilterText3").InnerText ;}else{Filterrow["FilterText3"] ="";}
			if (filetr_node.SelectSingleNode("FilterText4").InnerText!="NULL"){Filterrow["FilterText4"] = filetr_node.SelectSingleNode("FilterText4").InnerText ;}else{Filterrow["FilterText4"] ="";}
			if (filetr_node.SelectSingleNode("FilterCode1").InnerText!="NULL"){Filterrow["FilterCode1"] = filetr_node.SelectSingleNode("FilterCode1").InnerText ;}else{Filterrow["FilterCode1"] ="";}
			if (filetr_node.SelectSingleNode("FilterCode2").InnerText!="NULL"){Filterrow["FilterCode2"] = filetr_node.SelectSingleNode("FilterCode2").InnerText ;}else{Filterrow["FilterCode2"] ="";}
			if (filetr_node.SelectSingleNode("FilterCode3").InnerText!="NULL"){Filterrow["FilterCode3"] = filetr_node.SelectSingleNode("FilterCode3").InnerText ;}else{Filterrow["FilterCode3"] ="";}
			if (filetr_node.SelectSingleNode("FilterCode4").InnerText!="NULL"){Filterrow["FilterCode4"] = filetr_node.SelectSingleNode("FilterCode4").InnerText ;}else{Filterrow["FilterCode4"] ="";}
			if (filetr_node.SelectSingleNode("FilterCode5").InnerText!="NULL"){Filterrow["FilterCode5"] = filetr_node.SelectSingleNode("FilterCode5").InnerText ;}else{Filterrow["FilterCode5"] ="";}
			if (filetr_node.SelectSingleNode("FilterCode6").InnerText!="NULL"){Filterrow["FilterCode6"] = filetr_node.SelectSingleNode("FilterCode6").InnerText ;}else{Filterrow["FilterCode6"] ="";}
		
			
			
			//            Filterrow["FilterText3"] = filetr_node.SelectSingleNode("FilterText3").InnerText ;
//            Filterrow["FilterText4"] = filetr_node.SelectSingleNode("FilterText4").InnerText ;
            Filtertable.Rows.Add(Filterrow);
            }   
		
			}

		}
		void GeneratePDFbuttonClick(object sender, EventArgs e)
		{
//			string macrodir= ExeDirFull + "Macros\\Catia" ;
			string macrodir= ExeDirFull + CatiaMacroDir;
			string filetoopen= CAD_DIR_Location  + "\\" + SelectedToOpen2D;
			string macrotolaunch= macrodir + "\\" + macroexportPDF ;
			string fulltemporarylistforpdf="\"" + macrodir + "\\" + temporarylistforpdf + "\" ";
			string fullfiletoopen= "\"" + ExeDirFull + filetoopen + "\" ";
			File.WriteAllText(macrodir + "\\" + temporarylistforpdf, ExeDirFull + filetoopen);
			GeneratePDF_GO();
		}
		public void GeneratePDF_GO()
		{
			string macrodir= ExeDirFull + CatiaMacroDir;
			string macrotolaunch= macrodir + "\\" + macroexportPDF ;
		System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcesses();
{
                bool AdminMode = false;
                ProcessStartInfo psi = new ProcessStartInfo("\"" + CATDLLPath_LOW + "\\CATStart.exe" + "\"");
                if (!AdminMode)
                {
                    psi.Arguments = " -run \"CNEXT.exe\" -env " + "\"" + EnvironmentName_Export + "\"" + " -direnv " + "\"" + EnvironmentDir_Export + "\"" + " -nowindow ";
                    psi.Arguments = psi.Arguments + " -object " + "\"" + " -batch -macro " + macrotolaunch + "\""; 
                }
                else
                {
                    psi.Arguments = " -run \"CNEXT.exe -admin\" -env " + "\"" + EnvironmentName_Export + "\"" + " -direnv " + "\"" + EnvironmentDir_Export  + "\"" + " -nowindow ";
                    psi.Arguments = psi.Arguments + " -object " + "\"" + "-batch -macro " + macrotolaunch + "\""; 
                }
                Debug.WriteLine(psi.FileName + " " + psi.Arguments);
                IntPtr oCatiaHwnd= IntPtr.Zero;
                psi.UseShellExecute = false;
                psi.RedirectStandardOutput = false;
                psi.RedirectStandardError = true;        
                Process process = new Process();
                {
                    process.EnableRaisingEvents = true;
                    process.StartInfo = psi;
                    process.Start();
                    Application.DoEvents();
                    Process[] Ps = Process.GetProcesses();
                    int L = Ps.Length;
                    int timeout = 5000;
                    process.WaitForExit(timeout);
                }
            }
		}
		void Button41Click_OLD(object sender, EventArgs e)
		{
	
	string projectselectedID="" , partselectedID="";
	string macrodir= ExeDirFull + CatiaMacroDir;
	string macrotolaunch= macrodir + "\\" + macroexportPDF ;
	string fulltemporarylistforpdf="\"" + macrodir + "\\" + temporarylistforpdf + "\" ";
	File.WriteAllText(macrodir + "\\" + temporarylistforpdf, "");
 foreach(DataRow dr in Prodtable.Rows) // search whole table
 	{
 		if(dr["ProductName"].ToString() == PROD_Box.SelectedItem.ToString()) // if id==2  FAM_Box.SelectedItem.ToString()
    	{
			projectselectedID=dr["ProductCode"].ToString(); 
    	}
	}
foreach(DataRow dr2 in Matchtable.Rows) // search whole table
 	{
 	if(dr2["ProjectListed"].ToString() == projectselectedID) // if id==2  FAM_Box.SelectedItem.ToString()
   	{
 		partselectedID=dr2["PartListed"].ToString();
 foreach(DataRow dr3 in Parttable.Rows) // search whole table
 	{
 		if(dr3["PartCode"].ToString() ==partselectedID)
  			{
 if (dr3["PartTHREE_D"].ToString()!="NULL")
{
  	
            ExportSTEProw = ExportSTEPTable.NewRow();
			ExportSTEProw["3Dfile"] =dr3["PartTHREE_D"].ToString() ;      
            ExportSTEPTable.Rows.Add(ExportSTEProw);


}

if (dr3["PartTWO_D"].ToString()!="NULL")
{
 	 		ExportPDFrow = ExportPDFTable.NewRow();
			ExportPDFrow["2Dfile"] = dr3["PartTWO_D"].ToString() ;      
            ExportPDFTable.Rows.Add(ExportPDFrow);
}
              }
	foreach(DataRow dr in ExportPDFTable.Rows) // search whole table
 	{		string filetoopen= CAD_DIR_Location  + "\\" + dr["2Dfile"].ToString();;
			string fullfiletoopen= "\"" + ExeDirFull + filetoopen + "\" ";
			File.AppendAllText(macrodir + "\\" + temporarylistforpdf, ExeDirFull + filetoopen);
			File.AppendAllText(macrodir + "\\" + temporarylistforpdf, "\r\n");
	}		

 }
 }
	}	
		}		
		void Button41Click(object sender, EventArgs e)
		{
	string macrodir= ExeDirFull + CatiaMacroDir;
	string macrotolaunch= macrodir + "\\" + macroexportPDF ;
	string fulltemporarylistforpdf="\"" + macrodir + "\\" + temporarylistforpdf + "\" ";
	File.WriteAllText(macrodir + "\\" + temporarylistforpdf, "");
	
			string prtcode ="";
			string prtthreed ="";
//			string prtstep ="";
			string prttwod ="";
			string prtpdf ="";
//			string jpgimagefile="";
			string drawingfilename=drawingfilenameBox.Text.ToString();
			filetocheckout=CAD_DIR_Location + "\\" + PdfFolder + "\\" + drawingfilename;
		
			 XmlDocument xmlDoc2 = new XmlDocument();
			xmlDoc2.Load(WouldBeXML);  
			XmlNodeList nodeList = xmlDoc2.DocumentElement.SelectNodes("/WouldBePDM/PartList/Component");
            foreach (XmlNode nodepart in nodeList) //            foreach (XmlNode nodepart in nodeList)
            {

                prtcode = nodepart.SelectSingleNode("PartCode").InnerText;
            	prtthreed= nodepart.SelectSingleNode("PartTHREE_D").InnerText ;
//                prtstep= nodepart.SelectSingleNode("PartStep").InnerText ;
                prttwod= nodepart.SelectSingleNode("PartTWO_D").InnerText ;
                prtpdf= nodepart.SelectSingleNode("PartPdf").InnerText ;
//                jpgimagefile=nodepart.SelectSingleNode("PartImage").InnerText ;
                			
			foreach (string CODE in PART_Box.Items )
			{
//				textBox1.AppendText("- " + CODE);
				
				if (  CODE ==prtcode)
                				{
//					if (prtthreed!="NULL"){
//					if (prtthreed!="")
//					{ 
//						if (filetocheckout=="") {
//							filetocheckout= CAD_DIR_Location + "\\" + prtthreed;	}
//						else{filetocheckout= filetocheckout + "*" + CAD_DIR_Location + "\\" + prtthreed;}
//					}
//					}
					
					if (prttwod!="NULL"){
					if (prttwod!="")
					{
						
						if(File.Exists(CAD_DIR_Location + "\\" + PdfFolder + "\\" +  prtpdf)){}else{
						
			string filetoopen= CAD_DIR_Location  + "\\" + prttwod;
			string fullfiletoopen= "\"" + ExeDirFull + filetoopen + "\" ";
			File.AppendAllText(macrodir + "\\" + temporarylistforpdf, ExeDirFull + filetoopen);
			File.AppendAllText(macrodir + "\\" + temporarylistforpdf, "\r\n");
						   }
					}
					}
				}
			}
			
            }
            GeneratePDF_GO();
		}
		void Button43Click(object sender, EventArgs e)
		{
//			string projectselectedID="" , partselectedID="";
//	string macrodir= ExeDirFull + "Macros\\Catia" ;
	string macrodir= ExeDirFull + CatiaMacroDir;
	string macrotolaunch= macrodir + "\\" + macroexportPDF ;
	string fulltemporarylistforpdf="\"" + macrodir + "\\" + temporarylistforpdf + "\" ";
	File.WriteAllText(macrodir + "\\" + temporarylistforpdf, "");
	
			string prtcode ="";
			string prtthreed ="";
			string prttwod ="";
			string prtpdf ="";
			string drawingfilename=drawingfilenameBox.Text.ToString();
			filetocheckout=CAD_DIR_Location + "\\" + PdfFolder + "\\" + drawingfilename;
		
			 XmlDocument xmlDoc2 = new XmlDocument();
			xmlDoc2.Load(WouldBeXML);  
			XmlNodeList nodeList = xmlDoc2.DocumentElement.SelectNodes("/WouldBePDM/PartList/Component");
            foreach (XmlNode nodepart in nodeList) 
            {

                prtcode = nodepart.SelectSingleNode("PartCode").InnerText;
            	prtthreed= nodepart.SelectSingleNode("PartTHREE_D").InnerText ;
                prttwod= nodepart.SelectSingleNode("PartTWO_D").InnerText ;
                prtpdf= nodepart.SelectSingleNode("PartPdf").InnerText ;
			foreach (string CODE in PART_Box.Items )
			{
				if (  CODE ==prtcode)
                				{
					if (prttwod!="NULL"){
					if (prttwod!="")
					{

			string filetoopen= CAD_DIR_Location  + "\\" + prttwod;
			string fullfiletoopen= "\"" + ExeDirFull + filetoopen + "\" ";
			File.AppendAllText(macrodir + "\\" + temporarylistforpdf, ExeDirFull + filetoopen);
			File.AppendAllText(macrodir + "\\" + temporarylistforpdf, "\r\n");
						   					}
					}
				}
			}			
            }
            GeneratePDF_GO();
		}
		void Button50Click(object sender, EventArgs e)
		{
	
		string macrodir= ExeDirFull + CatiaMacroDir;
	string macrotolaunch= macrodir + "\\" + macroexportJPG ;
	string fulltemporarylistforjpg="\"" + macrodir + "\\" + temporarylistforjpg + "\" ";
	File.WriteAllText(macrodir + "\\" + temporarylistforjpg, "");
	
			string prtcode ="";
			string prtthreed ="";
//			string prtstep ="";
//			string prttwod ="";
//			string prtpdf ="";
			string jpgimagefile="";
//			string drawingfilename=drawingfilenameBox.Text.ToString();
//			filetocheckout=CAD_DIR_Location + "\\" + ImageFolder + "\\" + drawingfilename;
		
			 XmlDocument xmlDoc2 = new XmlDocument();
			xmlDoc2.Load(WouldBeXML);  
			XmlNodeList nodeList = xmlDoc2.DocumentElement.SelectNodes("/WouldBePDM/PartList/Component");
            foreach (XmlNode nodepart in nodeList) //            foreach (XmlNode nodepart in nodeList)
            {

                prtcode = nodepart.SelectSingleNode("PartCode").InnerText;
            	prtthreed= nodepart.SelectSingleNode("PartTHREE_D").InnerText ;
//                prtstep= nodepart.SelectSingleNode("PartStep").InnerText ;
//                prttwod= nodepart.SelectSingleNode("PartTWO_D").InnerText ;
//                prtpdf= nodepart.SelectSingleNode("PartPdf").InnerText ;
                jpgimagefile=nodepart.SelectSingleNode("PartImage").InnerText ;
                			
			foreach (string CODE in PART_Box.Items )
			{
//				textBox1.AppendText("- " + CODE);
				
				if (  CODE ==prtcode)
                				{
//					if (prtthreed!="NULL"){
//					if (prtthreed!="")
//					{ 
//						if (filetocheckout=="") {
//							filetocheckout= CAD_DIR_Location + "\\" + prtthreed;	}
//						else{filetocheckout= filetocheckout + "*" + CAD_DIR_Location + "\\" + prtthreed;}
//					}
//					}
					
					if (prtthreed!="NULL"){
					if (prtthreed!="")
					{
						
						if(File.Exists(CAD_DIR_Location + "\\" + ImageFolder + "\\" +  jpgimagefile)){}else{
						
			string filetoopen= CAD_DIR_Location  + "\\" + prtthreed;
			string fullfiletoopen= "\"" + ExeDirFull + filetoopen + "\" ";
			File.AppendAllText(macrodir + "\\" + temporarylistforjpg, ExeDirFull + filetoopen);
			File.AppendAllText(macrodir + "\\" + temporarylistforjpg, "\r\n");
						   }
					}
					}
				}
			}
			
            }
            GenerateJPG_GO();		
		}
		void Button49Click(object sender, EventArgs e)
		{
	
	
		string macrodir= ExeDirFull + CatiaMacroDir;
	string macrotolaunch= macrodir + "\\" + macroexportJPG ;
	string fulltemporarylistforjpg="\"" + macrodir + "\\" + temporarylistforjpg + "\" ";
	File.WriteAllText(macrodir + "\\" + temporarylistforjpg, "");
	
			string prtcode ="";
			string prtthreed ="";
//			string prtstep ="";
//			string prttwod ="";
//			string prtpdf ="";
			string jpgimagefile="";
//			string drawingfilename=drawingfilenameBox.Text.ToString();
//			filetocheckout=CAD_DIR_Location + "\\" + ImageFolder + "\\" + drawingfilename;
		
			 XmlDocument xmlDoc2 = new XmlDocument();
			xmlDoc2.Load(WouldBeXML);  
			XmlNodeList nodeList = xmlDoc2.DocumentElement.SelectNodes("/WouldBePDM/PartList/Component");
            foreach (XmlNode nodepart in nodeList) //            foreach (XmlNode nodepart in nodeList)
            {

                prtcode = nodepart.SelectSingleNode("PartCode").InnerText;
            	prtthreed= nodepart.SelectSingleNode("PartTHREE_D").InnerText ;
//                prtstep= nodepart.SelectSingleNode("PartStep").InnerText ;
//                prttwod= nodepart.SelectSingleNode("PartTWO_D").InnerText ;
//                prtpdf= nodepart.SelectSingleNode("PartPdf").InnerText ;
                jpgimagefile=nodepart.SelectSingleNode("PartImage").InnerText ;
                			
			foreach (string CODE in PART_Box.Items )
			{
//				textBox1.AppendText("- " + CODE);
				
				if (  CODE ==prtcode)
                				{
//					if (prtthreed!="NULL"){
//					if (prtthreed!="")
//					{ 
//						if (filetocheckout=="") {
//							filetocheckout= CAD_DIR_Location + "\\" + prtthreed;	}
//						else{filetocheckout= filetocheckout + "*" + CAD_DIR_Location + "\\" + prtthreed;}
//					}
//					}
					
					if (prtthreed!="NULL"){
					if (prtthreed!="")
					{
			string filetoopen= CAD_DIR_Location  + "\\" + prtthreed;
			string fullfiletoopen= "\"" + ExeDirFull + filetoopen + "\" ";
			File.AppendAllText(macrodir + "\\" + temporarylistforjpg, ExeDirFull + filetoopen);
			File.AppendAllText(macrodir + "\\" + temporarylistforjpg, "\r\n");
						}
					}
				}
			}
			
            }
            GenerateJPG_GO();		
		}
 		public void GenerateJPG_GO()
		{
			string macrodir= ExeDirFull + CatiaMacroDir;
			string macrotolaunch= macrodir + "\\" + macroexportJPG ;
		System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcesses();
{
                bool AdminMode = false;
                ProcessStartInfo psi = new ProcessStartInfo("\"" + CATDLLPath_LOW + "\\CATStart.exe" + "\"");
                if (!AdminMode)
                {
                    psi.Arguments = " -run \"CNEXT.exe\" -env " + "\"" + EnvironmentName_Export + "\"" + " -direnv " + "\"" + EnvironmentDir_Export + "\"" + " -nowindow ";
                    psi.Arguments = psi.Arguments + " -object " + "\"" + " -batch -macro " + macrotolaunch + "\""; 
                }
                else
                {
                    psi.Arguments = " -run \"CNEXT.exe -admin\" -env " + "\"" + EnvironmentName_Export + "\"" + " -direnv " + "\"" + EnvironmentDir_Export  + "\"" + " -nowindow ";
                    psi.Arguments = psi.Arguments + " -object " + "\"" + "-batch -macro " + macrotolaunch + "\""; 
                }
                Debug.WriteLine(psi.FileName + " " + psi.Arguments);
                IntPtr oCatiaHwnd= IntPtr.Zero;
                psi.UseShellExecute = false;
                psi.RedirectStandardOutput = false;
                psi.RedirectStandardError = true;        
                Process process = new Process();
                {
                    process.EnableRaisingEvents = true;
                    process.StartInfo = psi;
                    process.Start();
                    Application.DoEvents();
                    Process[] Ps = Process.GetProcesses();
                    int L = Ps.Length;
                    int timeout = 5000;
                    process.WaitForExit(timeout);
                }
            }	
		}
		void Button42Click(object sender, EventArgs e)
		{
			
	
		string macrodir= ExeDirFull + CatiaMacroDir;
	string macrotolaunch= macrodir + "\\" + macroexportSTEP ;
	string fulltemporarylistforstep="\"" + macrodir + "\\" + temporarylistforstp + "\" ";
	File.WriteAllText(macrodir + "\\" + temporarylistforstp, "");
	
			string prtcode ="";
			string prtthreed ="";
//			string prtstep ="";
//			string prttwod ="";
//			string prtpdf ="";
			string stepimagefile="";
//			string drawingfilename=drawingfilenameBox.Text.ToString();
//			filetocheckout=CAD_DIR_Location + "\\" + ImageFolder + "\\" + drawingfilename;
		
			 XmlDocument xmlDoc2 = new XmlDocument();
			xmlDoc2.Load(WouldBeXML);  
			XmlNodeList nodeList = xmlDoc2.DocumentElement.SelectNodes("/WouldBePDM/PartList/Component");
            foreach (XmlNode nodepart in nodeList) //            foreach (XmlNode nodepart in nodeList)
            {

                prtcode = nodepart.SelectSingleNode("PartCode").InnerText;
            	prtthreed= nodepart.SelectSingleNode("PartTHREE_D").InnerText ;
                stepimagefile= nodepart.SelectSingleNode("PartStep").InnerText ;
//                prttwod= nodepart.SelectSingleNode("PartTWO_D").InnerText ;
//                prtpdf= nodepart.SelectSingleNode("PartPdf").InnerText ;
//                stepimagefile=nodepart.SelectSingleNode("PartImage").InnerText ;
                			
			foreach (string CODE in PART_Box.Items )
			{
//				textBox1.AppendText("- " + CODE);
				
				if (  CODE ==prtcode)
                				{
//					if (prtthreed!="NULL"){
//					if (prtthreed!="")
//					{ 
//						if (filetocheckout=="") {
//							filetocheckout= CAD_DIR_Location + "\\" + prtthreed;	}
//						else{filetocheckout= filetocheckout + "*" + CAD_DIR_Location + "\\" + prtthreed;}
//					}
//					}
					
					if (prtthreed!="NULL"){
					if (prtthreed!="")
					{
						
						if(File.Exists(CAD_DIR_Location + "\\" + StepFolder + "\\" +  stepimagefile)){}else{
						
			string filetoopen= CAD_DIR_Location  + "\\" + prtthreed;
			string fullfiletoopen= "\"" + ExeDirFull + filetoopen + "\" ";
			File.AppendAllText(macrodir + "\\" + temporarylistforstp, ExeDirFull + filetoopen);
			File.AppendAllText(macrodir + "\\" + temporarylistforstp, "\r\n");
						   }
					}
					}
				}
			}
			
            }
            GenerateSTEP_GO();	
			
			
	
		}
		
		void Button51Click(object sender, EventArgs e)
		{
	
			string macrodir= ExeDirFull + CatiaMacroDir;
	string macrotolaunch= macrodir + "\\" + macroexportSTEP ;
	string fulltemporarylistforstep="\"" + macrodir + "\\" + temporarylistforstp + "\" ";
	File.WriteAllText(macrodir + "\\" + temporarylistforstp, "");

	
			string prtcode ="";
			string prtthreed ="";
//			string prtstep ="";
//			string prttwod ="";
//			string prtpdf ="";
//			string stepimagefile="";
//			string drawingfilename=drawingfilenameBox.Text.ToString();
//			filetocheckout=CAD_DIR_Location + "\\" + ImageFolder + "\\" + drawingfilename;
		
			 XmlDocument xmlDoc2 = new XmlDocument();
			xmlDoc2.Load(WouldBeXML);  
			XmlNodeList nodeList = xmlDoc2.DocumentElement.SelectNodes("/WouldBePDM/PartList/Component");
            foreach (XmlNode nodepart in nodeList) //            foreach (XmlNode nodepart in nodeList)
            {

                prtcode = nodepart.SelectSingleNode("PartCode").InnerText;
            	prtthreed= nodepart.SelectSingleNode("PartTHREE_D").InnerText ;
//                prtstep= nodepart.SelectSingleNode("PartStep").InnerText ;
//                prttwod= nodepart.SelectSingleNode("PartTWO_D").InnerText ;
//                prtpdf= nodepart.SelectSingleNode("PartPdf").InnerText ;
//                stepimagefile=nodepart.SelectSingleNode("PartImage").InnerText ;
                			
			foreach (string CODE in PART_Box.Items )
			{
//				textBox1.AppendText("- " + CODE);
				
				if (  CODE ==prtcode)
                				{
//					if (prtthreed!="NULL"){
//					if (prtthreed!="")
//					{ 
//						if (filetocheckout=="") {
//							filetocheckout= CAD_DIR_Location + "\\" + prtthreed;	}
//						else{filetocheckout= filetocheckout + "*" + CAD_DIR_Location + "\\" + prtthreed;}
//					}
//					}
					
					if (prtthreed!="NULL"){
					if (prtthreed!="")
					{
			string filetoopen= CAD_DIR_Location  + "\\" + prtthreed;
			string fullfiletoopen= "\"" + ExeDirFull + filetoopen + "\" ";
			File.AppendAllText(macrodir + "\\" + temporarylistforstp, ExeDirFull + filetoopen);
			File.AppendAllText(macrodir + "\\" + temporarylistforstp, "\r\n");
						}
					}
				}
			}
			
            }
            GenerateSTEP_GO();	
		}
		public void GenerateSTEP_GO()
		{
			string macrodir= ExeDirFull + CatiaMacroDir;
			string macrotolaunch= macrodir + "\\" + macroexportSTEP ;
		System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcesses();
{
                bool AdminMode = false;
                ProcessStartInfo psi = new ProcessStartInfo("\"" + CATDLLPath_LOW + "\\CATStart.exe" + "\"");
                if (!AdminMode)
                {
                    psi.Arguments = " -run \"CNEXT.exe\" -env " + "\"" + EnvironmentName_Export + "\"" + " -direnv " + "\"" + EnvironmentDir_Export + "\"" + " -nowindow ";
                    psi.Arguments = psi.Arguments + " -object " + "\"" + " -batch -macro " + macrotolaunch + "\""; 
                }
                else
                {
                    psi.Arguments = " -run \"CNEXT.exe -admin\" -env " + "\"" + EnvironmentName_Export + "\"" + " -direnv " + "\"" + EnvironmentDir_Export  + "\"" + " -nowindow ";
                    psi.Arguments = psi.Arguments + " -object " + "\"" + "-batch -macro " + macrotolaunch + "\""; 
                }
                Debug.WriteLine(psi.FileName + " " + psi.Arguments);
                IntPtr oCatiaHwnd= IntPtr.Zero;
                psi.UseShellExecute = false;
                psi.RedirectStandardOutput = false;
                psi.RedirectStandardError = true;        
                Process process = new Process();
                {
                    process.EnableRaisingEvents = true;
                    process.StartInfo = psi;
                    process.Start();
                    Application.DoEvents();
                    Process[] Ps = Process.GetProcesses();
                    int L = Ps.Length;
                    int timeout = 5000;
                    process.WaitForExit(timeout);
                }
            }	
			
			
//			MessageBox.Show("WorkInProgress");
			
		}
		
		
		
		
		
	}
	}////PUBLIC - Name space

//}
