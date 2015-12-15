/*
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
		public string CAD_DIR_Location = ("WouldBePDMData");
		public string StepFolder="OUT";
		public string PdfFolder="OUT";
		public string ImageFolder="JPG";
		
		string FAM_selected = "";
		string PRJ_selected = "";
		string PROD_selected = "";
		string PRT_selected = "";
		public string family_node_value, family_node_name, Family_level_name;
		public string prj_proID, prj_proName ;
		public string prod_proID , prod_proName ;
		public string prt_proID , prt_proName ;
		public string SelectedToOpen3D ="", SelectedToOpen2D ="", SelectedToOpenPdf ="" , SelectedToOpenStep ="";
//		public string LocalDir =@"C:\Users\rbartola\Documents\SharpDevelop Projects\WouldBe_PDM_sharpdev\WouldBe_PDM_sharpdev\";
	
		public string filetocheckout = "";
		int famcounter = 0, prjcounter = 0, prodcounter = 0, prtcounter=0;
//		int famidcounter=0;
		
		
		
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
		
		void ComboBox1SelectedIndexChanged(object sender, EventArgs e)   //select family
		{
			
//			textBox1.Clear();
//            textBox1.Text=("ciao");
//			textBox1.AppendText(WouldBeXML + "\r\n" );

			
			string familyname = "" ;
			string familyid = "";
			string familyselectedID ="";
            string familystatus = "" ;
            
            string projectname = "" ;
//			string projectcode = "" ;
//			string projectid = "" ;
			string prjfamilyid = "" ;
//			string customername = "" ;
//			string customercode = "" ;
//			string projectstatus = "" ;
//			string projectmanager = "" ;
	
			famstatusBox.Clear();
			PRJ_Box.Items.Clear();
	    	PRJ_Box.Text=("Select a Project");
		    groupBox7.Enabled=true;
		    PROD_Box.Text=("Select a Product");
		    groupBox8.Enabled=false;
		    PART_Box.Text=("Select a Component");
		    PART_Box.Enabled=false;
		    PartIndexText.Enabled=false;
		    clearboxes();
		    clearprojectboxes();
		    clearproductboxes();
		    groupBox5.Enabled=false;
//			int FamilySelectedNumber=0;
			FAM_selected = FAM_Box.SelectedItem.ToString() ;
            XmlDocument xmlDoc = new XmlDocument();
            famstatusBox.Enabled=true;
            
            
            xmlDoc.Load(WouldBeXML);
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/WouldBePDM/FamilyList/Family");
            foreach (XmlNode family_node in nodeList)
            {
			familyname= family_node.SelectSingleNode("FamilyName").InnerText ;
			familyid= family_node.SelectSingleNode("FamilyID").InnerText ;
			familystatus= family_node.SelectSingleNode("FamilyStatus").InnerText ;
			if (familyname==FAM_selected)
			{familyselectedID= familyid;
				famstatusBox.AppendText(familystatus);
					}
            }
            
            
            XmlNodeList nodeList2 = xmlDoc.DocumentElement.SelectNodes("/WouldBePDM/ProjectList/Project");
            foreach (XmlNode projectnode in nodeList2)
            {
            projectname= projectnode.SelectSingleNode("ProjectName").InnerText ;
//			projectcode= projectnode.SelectSingleNode("ProjectCode").InnerText ;
//			projectid= projectnode.SelectSingleNode("ProjectID").InnerText ;
			prjfamilyid= projectnode.SelectSingleNode("FamilyID").InnerText ;
//			customername= projectnode.SelectSingleNode("CustomerName").InnerText ;
//			customercode= projectnode.SelectSingleNode("CustomerCode").InnerText ;
//			projectstatus= projectnode.SelectSingleNode("ProjectStatus").InnerText ;
//			projectmanager= projectnode.SelectSingleNode("ProjectManager").InnerText ;
//			familyname= prj_node.SelectSingleNode("FamilyName").InnerText ;
//			familyid= prj_node.SelectSingleNode("FamilyID").InnerText ;
//			familystatus= family_node.SelectSingleNode("FamilyStatus").InnerText ;

//			textBox1.AppendText(projectname);
			
			
			if (prjfamilyid==familyselectedID)
		         	{
//			familyselectedID= familyid;
			PRJ_Box.Items.Add(projectname);
//				textBox1.AppendText(projectname + "\r\n" );
					}
            }
 		}
		void MainFormLoad(object sender, EventArgs e)
			{
			string familyname = "" ;
            string familyid = "" ;
            string familystatus = "" ;
			textBox1.Clear();
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
			}
		else{
		CAD_DIR_Location = ("WouldBePDMData");
		StepFolder="OUT";
		PdfFolder="OUT";
		ImageFolder="JPG";
		}
            CADdirTextbox.Clear();
			CADdirTextbox.Text=(CAD_DIR_Location);
			PDFdirBox.Clear();
			PDFdirBox.Text=(PdfFolder);
			StepDirBox.Clear();
			StepDirBox.Text=(StepFolder);
			JPGdirBox.Clear();
			JPGdirBox.Text=(ImageFolder);
if (File.Exists(WouldBeXML)){             
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(WouldBeXML);
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/WouldBePDM/FamilyList/Family");
            
            foreach (XmlNode family_node in nodeList)
            {
			familyname= family_node.SelectSingleNode("FamilyName").InnerText ;
			familyid= family_node.SelectSingleNode("FamilyID").InnerText ;
			familystatus= family_node.SelectSingleNode("FamilyStatus").InnerText ;
			FAM_Box.Items.Add(familyname);
			
//			textBox1.AppendText(familyname + "\r\n" );
//			textBox1.AppendText(familystatus + "\r\n" );
            }
        }
			else{FAM_Box.Enabled=false;}
		}
		void Button1Click(object sender, EventArgs e)
		{
//			textBox1.AppendText(Xml_file_to_open + "\r\n" );
//			textBox1.AppendText(Xml_prt_list + "\r\n" );
//			textBox1.AppendText(CAD_DIR_Location + "\r\n" );

            XmlTextWriter writer = new XmlTextWriter("product.xml", System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("Table");
            createNode("1", "Product 1", "1000", writer);
            createNode("2", "Product 2", "2000", writer);
            createNode("3", "Product 3", "3000", writer);
            createNode("4", "Product 4", "4000", writer);
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
            MessageBox.Show("XML File created ! ");

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
				textBox1.Clear();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Xml_prj_list);
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("*");
            foreach (XmlNode family_level_node in nodeList) // family_level_node
            {
            	famcounter ++ ;
		 Family_level_name = family_level_node.Name;
			foreach (XmlNode family_node in family_level_node) //family_node
              {
	 family_node_value = family_node.Value;
		 family_node_name = family_node.Name;
		if (family_node.Name == "#text" ) // if text
			                             {
			
//		textBox1.AppendText(famcounter +  " " + Family_level_name + family_node_value + " typo " + family_node_name +  "\r\n" ); // famiglia
                                         }       // if text
foreach (XmlNode prj_node in family_node) // prj_node
                 {
		 prj_proID = prj_node.Value;
		 prj_proName = prj_node.Name;
		if (prj_node.Name == "#text" ) // if text
			                           {
				prjcounter++;
//			textBox1.AppendText(famcounter  + " " + prjcounter + " " + family_node_name + prj_proID + "\r\n" ); // progetto
//			textBox1.AppendText("Family " + family_node_value + " PRJ " + prj_proID + "\r\n" );
		PRJ_Box.Items.Add(prj_node.Value);
		                               }             // if text
		foreach (XmlNode prod_node in prj_node) // prj_familynode
			         {
			prod_proID = prod_node.Value;
		    prod_proName = prod_node.Name;
		    if (prod_node.Name == "#text" ) // if text
			                                   {
				prodcounter++;
//			textBox1.AppendText(famcounter  + " " + prjcounter + " " + prodcounter  + " " + prj_proName + " " + prod_proID + "\r\n" ); // prodotto
//			textBox1.AppendText("Family " + family_node_value + " PRJ " + prj_proID + "\r\n" );
		PROD_Box.Items.Add(prod_node.Value);
                                               }  // if text
		foreach (XmlNode prt_node in prod_node)   //prod_node
			           {
			prt_proID = prt_node.Value;
		    prt_proName = prt_node.Name;
		    
		    if (prt_node.Name == "#text" ) // if text
			                               {
				prtcounter++;
//			textBox1.AppendText(famcounter  + " " + prjcounter + " " + prodcounter + " " + prtcounter + " " +  prod_proName + prt_proID + " " + "\r\n" ); // prt
		PART_Box.Items.Add(prt_node.Value);
			                              } // if text
		                 }    //prod_node
			         } // prj_familynode
		          }		// prj_node
			   }	//family_node		
            }	// family_level_node		
		}//Buttonclick - to delete?
		void PRJ_BoxSelectedIndexChanged(object sender, EventArgs e)
		{
			textBox1.Clear();
            textBox1.Text=("");
            PART_Box.Items.Clear();
//			textBox1.AppendText(WouldBeXML + "\r\n" );
			clearprojectboxes();
			clearproductboxes();
			clearboxes();
			groupBox5.Enabled=false;
			button18.Enabled=false;
			button6.Enabled=false;
					    
//			string familyname = "" ;
//			string familyid = "";
			string projectselectedID ="";
//          string familystatus = "" ;
            
            string projectname = "" ;
			string projectcode = "" ;
			string projectid = "" ;
			string prjfamilyid = "" ;
			string customername = "" ;
			string customercode = "" ;
			string projectstatus = "" ;
			string projectmanager = "" ;
			
			string productname = "" ;
//			string productcar = "" ;
//			string productcode = "" ;
//			string productstatus = "" ;
			string productprojectcode = "" ; // attent
//			string product2dname = "" ;
//			string product2dfilename = "" ;
//			string product2drev = "" ;
//			string product2ddate = "" ;
//			string product2d = "" ;


			PROD_Box.Items.Clear();
		    PROD_Box.Text=("Select a Product");
		    groupBox8.Enabled=true;
		    PART_Box.Text=("Select a Component");
		    PART_Box.Enabled=false;
		    PartIndexText.Enabled=false;
		    
			PRJ_selected = PRJ_Box.SelectedItem.ToString() ;
            XmlDocument xmlDoc = new XmlDocument();
            
			xmlDoc.Load(WouldBeXML);

            XmlNodeList nodeList2 = xmlDoc.DocumentElement.SelectNodes("/WouldBePDM/ProjectList/Project");
            foreach (XmlNode projectnode in nodeList2)
            {
            projectname= projectnode.SelectSingleNode("ProjectName").InnerText ;
			projectcode= projectnode.SelectSingleNode("ProjectCode").InnerText ;
			projectid= projectnode.SelectSingleNode("ProjectID").InnerText ;
			prjfamilyid= projectnode.SelectSingleNode("FamilyID").InnerText ;
			customername= projectnode.SelectSingleNode("CustomerName").InnerText ;
			customercode= projectnode.SelectSingleNode("CustomerCode").InnerText ;
			projectstatus= projectnode.SelectSingleNode("ProjectStatus").InnerText ;
			projectmanager= projectnode.SelectSingleNode("ProjectManager").InnerText ;
			if (projectname==PRJ_selected)
		         	{
			projectselectedID= projectid;
			projectstatusBox.AppendText(projectstatus);
			ProjectCodeBox.AppendText(projectcode);
			projectManagerBox.AppendText(projectmanager);
					}
			            }
//            textBox1.AppendText(projectselectedID);
				XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/WouldBePDM/ProductList/Product");
            foreach (XmlNode product_node in nodeList)
            {
            	productname= product_node.SelectSingleNode("ProductName").InnerText ;
//            	productcar= product_node.SelectSingleNode("ProductCar").InnerText ;
//            	productcode= product_node.SelectSingleNode("ProductCode").InnerText ;
//            	productstatus= product_node.SelectSingleNode("ProductStatus").InnerText ;
            	productprojectcode= product_node.SelectSingleNode("ProjectCode").InnerText ;
//            	product2dname= product_node.SelectSingleNode("Product2DName").InnerText ;
//            	product2dfilename= product_node.SelectSingleNode("Product2DFilename").InnerText ;
//            	product2drev= product_node.SelectSingleNode("Product2DREV").InnerText ;
//            	product2ddate= product_node.SelectSingleNode("Product2DDate").InnerText ;
			if (projectselectedID==productprojectcode)
			{
				PROD_Box.Items.Add(productname);
				}
            }
		}  //select prj			
		void PROD_BoxSelectedIndexChanged(object sender, EventArgs e)
		{
//			PART_Box.Items.Clear();
//			PART_Box.Text=("Select a Component");
//		    PART_Box.Visible=true;
//		    PartIndexText.Visible=false;
		    clearboxes();
//		    clearprojectboxes();
		    clearproductboxes();
		    PART_Box.Items.Clear();
		    groupBox5.Enabled=false;
		    button18.Enabled=true;
		    button6.Enabled=true;
//		    int counter=0;
		    
		    
//            int ProdSelectedNumber=0;
			PROD_selected = PROD_Box.SelectedItem.ToString() ;
//			textBox1.Clear();
		
			textBox1.Clear();
            textBox1.Text=("");
//			textBox1.AppendText(WouldBeXML + "\r\n" );
//			textBox1.AppendText(PROD_selected + "\r\n" );
		
					    
//			string familyname = "" ;
//			string familyid = "";
			string projectselectedID ="";
//			string projectselectedID="";
//          string familystatus = "" ;
            

			
			string productname = "" ;
			string productcar = "" ;
			string productcode = "" ;
			string productstatus = "" ;
			string productprojectcode = "" ; // attent
			string product2dname = "" ;
			string product2dfilename = "" ;
			string product2drev = "" ;
			string product2ddate = "" ;
			string partcode = "" ;
			string projectselected = "" ;

//			PROD_Box.Items.Clear();
//		    PROD_Box.Text=("Select a Product");
//		    PROD_Box.Visible=true;
		    PART_Box.Text=("Select a Component");
		    PART_Box.Enabled=true;
		    PartIndexText.Enabled=false;
		    
			PROD_selected = PROD_Box.SelectedItem.ToString() ;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(WouldBeXML);
//           textBox1.AppendText(projectselectedID  + "\r\n");
				XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/WouldBePDM/ProductList/Product");
            foreach (XmlNode product_node in nodeList)
            {
            	productname= product_node.SelectSingleNode("ProductName").InnerText ;
            	productcar= product_node.SelectSingleNode("ProductCar").InnerText ;
            	productcode= product_node.SelectSingleNode("ProductCode").InnerText ;
            	productstatus= product_node.SelectSingleNode("ProductStatus").InnerText ;
            	productprojectcode = product_node.SelectSingleNode("ProjectCode").InnerText ;
            	product2dname= product_node.SelectSingleNode("Product2DName").InnerText ;
            	product2dfilename= product_node.SelectSingleNode("Product2DFilename").InnerText ;
            	product2drev= product_node.SelectSingleNode("Product2DREV").InnerText ;
            	product2ddate= product_node.SelectSingleNode("Product2DDate").InnerText ;
//            	counter ++;
//            	 textBox1.AppendText("ciao" + counter  + "\r\n");
			if (PROD_selected==productname) //PROD_selected
			{projectselectedID=productcode;
//				PROD_Box.Items.Add(productname);
				drawingBox.AppendText(product2dname);
				drawingRevBox.AppendText(product2drev);
				drawingdateBox.AppendText(product2ddate);
				textBox3.AppendText(productstatus);
				drawingfilenameBox.AppendText(product2dfilename);
				
				}
            }


 XmlNodeList nodeList2 = xmlDoc.DocumentElement.SelectNodes("/WouldBePDM/PartMatch/ComponentList");
            foreach (XmlNode partnode in nodeList2)
            {
partcode= partnode.SelectSingleNode("PartListed").InnerText ;
projectselected= partnode.SelectSingleNode("ProjectListed").InnerText ;

			if (projectselectedID==projectselected) // select componentes..............
		         	{
//							textBox3.AppendText(partcode);
							PART_Box.Items.Add(partcode);
//			projectselectedID= projectid;
//			projectstatusBox.AppendText(projectstatus);
//			ProjectCodeBox.AppendText(projectcode);
//			projectManagerBox.AppendText(projectmanager);
					}
			            }




			
			
		}
		void PART_BoxSelectedIndexChanged(object sender, EventArgs e)
		{
			
			textBox1.Clear();
            textBox1.Text=("");
//			textBox1.AppendText(WouldBeXML + "\r\n" );
			string prtcode = "", prtname = "", prtstatus="", prtrev="", prtdate="", prtdesigner="";
            string prtthreed="", prtstep="", prttwod="", prtpdf="", prtweight="", prtmaterial="";
            string prttthreat="", prtcoat="", prtsupplyer="", partimagefile="";
			
			int counter=0;
			
			PartIndexText.Enabled=true;
			PartIndexText.Clear() ;
			PRT_selected = PART_Box.SelectedItem.ToString() ;
//		textBox1.AppendText(PRT_selected + "\r\n" );
			clearboxes();
			groupBox5.Enabled=true;
			 XmlDocument xmlDoc2 = new XmlDocument();
			xmlDoc2.Load(WouldBeXML);  
//            textBox1.AppendText(PRT_selected  + "\r\n");
			XmlNodeList nodeList = xmlDoc2.DocumentElement.SelectNodes("/WouldBePDM/PartList/Component");
            foreach (XmlNode nodepart in nodeList) //            foreach (XmlNode nodepart in nodeList)
            {
//              PartList>
		//<Component
                prtcode = nodepart.SelectSingleNode("PartCode").InnerText;
//                prtname= nodepart.SelectSingleNode("Name").InnerText ;
                prtstatus= nodepart.SelectSingleNode("PartStatus").InnerText ;
                prtrev= nodepart.SelectSingleNode("PartRev").InnerText ;
                prtdate= nodepart.SelectSingleNode("PartDate").InnerText ;
                prtdesigner= nodepart.SelectSingleNode("PartDesigner").InnerText ;
                prtthreed= nodepart.SelectSingleNode("PartTHREE_D").InnerText ;
                prtstep= nodepart.SelectSingleNode("PartStep").InnerText ;
                prttwod= nodepart.SelectSingleNode("PartTWO_D").InnerText ;
                prtpdf= nodepart.SelectSingleNode("PartPdf").InnerText ;
                prtweight= nodepart.SelectSingleNode("PartWeight").InnerText ;
                prtmaterial= nodepart.SelectSingleNode("PartMaterial").InnerText ;
                prttthreat= nodepart.SelectSingleNode("PartTThreat").InnerText ;
                prtcoat= nodepart.SelectSingleNode("PartCoat").InnerText ;
                prtsupplyer= nodepart.SelectSingleNode("PartSupplyer").InnerText ;
                partimagefile=nodepart.SelectSingleNode("PartImage").InnerText ;
                counter++;
                                if (  PRT_selected ==prtcode)
              {
if (prtcode!="NULL")
{CodeBox.AppendText(prtcode);}
if (prtname!="NULL")
{NameBox.AppendText(prtname);}
if (prtstatus!="NULL")
{StatusBox.AppendText(prtstatus);}
if (prtrev!="NULL")
{RevBox.AppendText(prtrev);}
if (prtdate!="NULL")
{DateBox.AppendText(prtdate);}
if (prtdesigner!="NULL")
{DesignerBox.AppendText(prtdesigner);}
if (prtthreed!="NULL")
{ThreedBox.AppendText(prtthreed);
SelectedToOpen3D =prtthreed ;}
if (prtstep!="NULL")
{StepBox.AppendText(prtstep);
SelectedToOpenStep =prtstep;}
if (prttwod!="NULL")
{TwodBox.AppendText(prttwod);
SelectedToOpen2D =prttwod ;}
if (prtpdf!="NULL")
{PdfBox.AppendText(prtpdf);
SelectedToOpenPdf =prtpdf ;}
if (prtweight!="NULL")
{weightBox.AppendText(prtweight);}
if (prtmaterial!="NULL")
{materialBox.AppendText(prtmaterial);}
if (prttthreat!="NULL")
{ttreatmentBox.AppendText(prttthreat);}
if (prtcoat!="NULL")
{coatingBox.AppendText(prtcoat);}
if (prtsupplyer!="NULL")
{supplierBox.AppendText(prtsupplyer);}
string fullfilejpgname=CAD_DIR_Location + "\\" + ImageFolder + "\\" + partimagefile;
if (File.Exists (fullfilejpgname) ) 
{
	pictureBox1.Image=Image.FromFile(fullfilejpgname);
	textBox1.AppendText(fullfilejpgname);
}
if (SelectedToOpen3D!="")
{Checkout_3D.Enabled=true;
	OpenCADbutton.Enabled=true;
	whereUSEDbutton.Enabled=true;
	generateSTEPbuttron.Enabled=true;}
if (SelectedToOpen2D!="")
{Checkout_2D.Enabled=true;
	open2Dbutton.Enabled=true;
	where2Dbutton.Enabled=true;
generatePDFbutton.Enabled=true;}
if (SelectedToOpenPdf!="")
{
	CheckOut_pdf.Enabled=true;
	openPDFbutton.Enabled=true;
generatePDFbutton.Enabled=false;}
if(SelectedToOpenStep!="")
{
	CheckOut_Step.Enabled=true;
	OpenSTEPbutton.Enabled=true;
generateSTEPbuttron.Enabled=false;}
               }
            }
		}// select prod
		void Button3Click(object sender, EventArgs e) //dal sito - parser
		{
XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Xml_prt_list);
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("*");
            string proID = "", proName = "", price="";
            foreach (XmlNode node in nodeList)
            {
//                proID = node.SelectSingleNode("C_STATUS").InnerText;
                 proID = node.SelectSingleNode("Code").InnerText;
                proName = node.SelectSingleNode("Name").InnerText;
                price = node.SelectSingleNode("Status").InnerText;
//                MessageBox.Show(proID + " " + proName + " " + price); 
//                textBox1.AppendText(proID + " " + proName + " " + price + "\r\n");
            }





        }  // to delete
		public void clearfamilyboxes()
{
famstatusBox.Clear();
}
		public void clearprojectboxes()
{
ProjectCodeBox.Clear();
projectstatusBox.Clear();
projectManagerBox.Clear();
}
		public void clearproductboxes()
{
drawingBox.Clear();
drawingRevBox.Clear();
drawingdateBox.Clear();
drawingfilenameBox.Clear();
textBox3.Clear();
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
		void Checkout_3DClick(object sender, EventArgs e)
		{
//				textBox1.AppendText(SelectedToOpen3D + " " + SelectedToOpen2D + " " + SelectedToOpenPdf + " " + SelectedToOpenStep + "\n");
		StringBuilder sbError = new StringBuilder();
StringBuilder sbOutput = new StringBuilder();
string InstallPathSVN = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\TortoiseSVN" , "ProcPath", null);
if (InstallPathSVN != null)
{
string commandtolaunch = "\"" + InstallPathSVN + "\"";
    System.Diagnostics.Process.Start(commandtolaunch, "/command:update " + " /path:" + "\"" + CAD_DIR_Location  + "\\" + SelectedToOpen3D + "\"");
}

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
string InstallPathSVN = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\TortoiseSVN" , "ProcPath", null);
if (InstallPathSVN != null)
{
string commandtolaunch = "\"" + InstallPathSVN + "\"";
    System.Diagnostics.Process.Start(commandtolaunch, "/command:update " + " /path:" + "\"" + CAD_DIR_Location  + "\\" + SelectedToOpen2D + "\"");
}

		}
		void CheckOut_StepClick(object sender, EventArgs e)
		{
	StringBuilder sbError = new StringBuilder();
StringBuilder sbOutput = new StringBuilder();
string InstallPathSVN = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\TortoiseSVN" , "ProcPath", null);
if (InstallPathSVN != null)
{
string commandtolaunch = "\"" + InstallPathSVN + "\"";
    System.Diagnostics.Process.Start(commandtolaunch, "/command:update " + " /path:" + "\"" + CAD_DIR_Location  + "\\" + StepFolder +"\\" + SelectedToOpenStep + "\"");
}
		}
		void CheckOut_pdfClick(object sender, EventArgs e)
		{
	StringBuilder sbError = new StringBuilder();
StringBuilder sbOutput = new StringBuilder();
string InstallPathSVN = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\TortoiseSVN" , "ProcPath", null);
if (InstallPathSVN != null)
{
string commandtolaunch = "\"" + InstallPathSVN + "\"";
    System.Diagnostics.Process.Start(commandtolaunch, "/command:update " + " /path:" + "\"" + CAD_DIR_Location  + "\\" + PdfFolder +"\\" + SelectedToOpenPdf + "\"");
}
		}
		void Button5Click(object sender, EventArgs e)
		{
	ViewFileFolder(CAD_DIR_Location);
		}
		void Button8Click(object sender, EventArgs e)
		{
	ViewFileFolder(CAD_DIR_Location + "\\" + PdfFolder);
		}
		void Button10Click(object sender, EventArgs e)
		{
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
string InstallPathSVN = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\TortoiseSVN" , "ProcPath", null);
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
string InstallPathSVN = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\TortoiseSVN" , "ProcPath", null);
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
string InstallPathSVN = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\TortoiseSVN" , "ProcPath", null);
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
string InstallPathSVN = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\TortoiseSVN" , "ProcPath", null);
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
			string prtpdf ="";
//			string PRT_selected ="";
//			string prtcode ="";
			
			filetocheckout="";
			
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
				}
			}
			
            }
//	textBox1.AppendText("file: " + filetocheckout);
	
		StringBuilder sbError = new StringBuilder();
StringBuilder sbOutput = new StringBuilder();
string InstallPathSVN = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\TortoiseSVN" , "ProcPath", null);
if (InstallPathSVN != null)
{
string commandtolaunch = "\"" + InstallPathSVN + "\"";
    System.Diagnostics.Process.Start(commandtolaunch, "/command:update " + " /path:" + "\"" +  filetocheckout + "\"");
   	
}   
	
	
	
	
	
	
	
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
            writer.WriteStartElement("Directories");
            writer.WriteStartElement("CADdatadir");
            writer.WriteString(CAD_DIR_Location);
            writer.WriteEndElement();
            writer.WriteStartElement("PDFdatadir");
            writer.WriteString(PdfFolder);
            writer.WriteEndElement();
            writer.WriteStartElement("STEPdatadir");
            writer.WriteString(StepFolder);
            writer.WriteEndElement();
            writer.WriteStartElement("JPGdatadir");
            writer.WriteString(ImageFolder);
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
            MessageBox.Show("XML File created ! ");
		} //save xml
		
		
	
		
	}////PUBLIC - Name space

}
