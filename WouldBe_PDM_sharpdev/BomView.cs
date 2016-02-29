/*
 * Created by SharpDevelop.
 * User: RoBartol
 * Date: 19/02/2016
 * Time: 13:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using System.IO;
//using System.Text;
//using System.Diagnostics;
//using System.Collections.Generic;
//
//
//using System.Text;
//using System.Collections.Generic;
//using System.Diagnostics;
//using Microsoft.Win32; //for regedit (tortoise)


namespace WouldBe_PDM_sharpdev
{
	/// <summary>
	/// Description of BomView.
	/// </summary>
	public partial class BomView : Form
	
	
	{
		public DataTable Filtertable;
		 public DataRow  Filterrow;
//		 public string WouldBeFILTER =""; //WouldBe_PDM_sharpdev.MainForm.Filter_XML_filename.Text.ToString();//("WouldBeFILTER.xml");
		const string WouldBeFILTER =("WouldBeFILTER.xml");
		int addfilterline=0;
		public BomView()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void BomViewLoad(object sender, EventArgs e)
		{
			
//			WouldBeFILTER= WouldBe_PDM_sharpdev.WouldBe_data   MainForm.Filter_XML_filename.Text.ToString();//("WouldBeFILTER.xml");
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
			

            
            
            
		}
		void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
		{
		foreach(DataRow dr in Filtertable.Rows) // search whole table
 	{
//					BomView.comboBox1.Items.Add(dr["Project_Filter"].ToString());
			if(dr["Project_Filter"].ToString() == comboBox1.SelectedItem.ToString()) // if id==2  FAM_Box.SelectedItem.ToString()
    	{
 			Search1_textfilter_2.Text=dr["FilterText1"].ToString();
 			Search2_textfilter_2.Text=dr["FilterText2"].ToString();
 			Search3_textfilter_2.Text=dr["FilterText3"].ToString();
 			Search4_textfilter_2.Text=dr["FilterText4"].ToString();
 			Search_codefilter1.Text=dr["FilterCode1"].ToString();
		    Search_codefilter2.Text=dr["FilterCode2"].ToString();
		    Search_codefilter3.Text=dr["FilterCode3"].ToString();
		    Search_codefilter4.Text=dr["FilterCode4"].ToString();
		    Search_codefilter5.Text=dr["FilterCode5"].ToString();
		    Search_codefilter6.Text=dr["FilterCode6"].ToString();
 			
 			
// 			MessageBox.Show("testi " + Search1_textfilter + Search2_textfilter + Search3_textfilter +Search4_textfilter);
 		
 		}
	}
		textBox3.Text=comboBox1.SelectedItem.ToString();
		Write_filterBOM.Enabled=true;
		}
		void Write_filterBOMClick(object sender, EventArgs e)
		{
	
			
			if(addfilterline==1){
				Filterrow = Filtertable.NewRow();
		Filterrow["Project_Filter"]= textBox3.Text.ToString();
	  Filterrow["FilterText1"]= Search1_textfilter_2.Text.ToString();
      Filterrow["FilterText2"]=Search2_textfilter_2.Text.ToString();
      Filterrow["FilterText3"]=Search3_textfilter_2.Text.ToString();
      Filterrow["FilterText4"]=Search4_textfilter_2.Text.ToString();
      Filterrow["FilterCode1"]=Search_codefilter1.Text.ToString();
      Filterrow["FilterCode2"]=Search_codefilter2.Text.ToString();
      Filterrow["FilterCode3"]=Search_codefilter3.Text.ToString();
      Filterrow["FilterCode4"]=Search_codefilter4.Text.ToString();
      Filterrow["FilterCode5"]=Search_codefilter5.Text.ToString();
      Filterrow["FilterCode6"]=Search_codefilter6.Text.ToString();
      
      
      
      
      Filtertable.Rows.Add(Filterrow);
      addfilterline=0;
			}
			else{
		 foreach(DataRow dr in Filtertable.Rows) // search whole table
 	{
 		if(dr["Project_Filter"].ToString() == comboBox1.SelectedItem.ToString()) // if id==2  FAM_Box.SelectedItem.ToString()
    	{
	dr["FilterText1"]= Search1_textfilter_2.Text.ToString();
      dr["FilterText2"]=Search2_textfilter_2.Text.ToString();
      dr["FilterText3"]=Search3_textfilter_2.Text.ToString();
      dr["FilterText4"]=Search4_textfilter_2.Text.ToString();
      dr["FilterCode1"]=Search_codefilter1.Text.ToString();
      dr["FilterCode2"]=Search_codefilter2.Text.ToString();
      dr["FilterCode3"]=Search_codefilter3.Text.ToString();
      dr["FilterCode4"]=Search_codefilter4.Text.ToString();
      dr["FilterCode5"]=Search_codefilter5.Text.ToString();
      dr["FilterCode6"]=Search_codefilter6.Text.ToString();
		
    	}
	}
			} //else
			
			 	WriteFilterXML();
			
			 	Write_filterBOM.Visible=false;	
			
		}
		
		
		public void WriteFilterXML()
		{
            XmlTextWriter writer = new XmlTextWriter(WouldBeFILTER, System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("WouldBeFILTER");//WouldBePDM
            writer.WriteStartElement("FilterList");//FamilyList
                   	for (int i = 0; i <= Filtertable.Rows.Count - 1; i++)
                   	{
                   	writer.WriteStartElement("Filters"); //Family
                    writer.WriteStartElement("Project_Filter");
                    writer.WriteString(Filtertable.Rows[i].ItemArray[0].ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("FilterText1");
                    writer.WriteString(Filtertable.Rows[i].ItemArray[1].ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("FilterText2");
                    writer.WriteString(Filtertable.Rows[i].ItemArray[2].ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("FilterText3");
                    writer.WriteString(Filtertable.Rows[i].ItemArray[3].ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("FilterText4");
                    writer.WriteString(Filtertable.Rows[i].ItemArray[4].ToString());
                    writer.WriteEndElement();                 
                    writer.WriteStartElement("FilterCode1");
                    writer.WriteString(Filtertable.Rows[i].ItemArray[5].ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("FilterCode2");
                    writer.WriteString(Filtertable.Rows[i].ItemArray[6].ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("FilterCode3");
                    writer.WriteString(Filtertable.Rows[i].ItemArray[7].ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("FilterCode4");
                    writer.WriteString(Filtertable.Rows[i].ItemArray[8].ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("FilterCode5");
                    writer.WriteString(Filtertable.Rows[i].ItemArray[9].ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("FilterCode6");
                    writer.WriteString(Filtertable.Rows[i].ItemArray[10].ToString());
                    writer.WriteEndElement();
                    writer.WriteEndElement(); //Family        FilterCode1       
             		}
            writer.WriteEndElement(); //FamilyList
     
            writer.WriteEndElement(); //WouldBePDM
            writer.WriteEndDocument(); // END
            writer.Close();
            MessageBox.Show("XML File updated ! " + WouldBeFILTER);
            
            RereadFilter();
            
		}	
		public void RereadFilter()
		{
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
//            Filterrow["FilterText3"] = filetr_node.SelectSingleNode("FilterText3").InnerText ;
//            Filterrow["FilterText4"] = filetr_node.SelectSingleNode("FilterText4").InnerText ;
            Filtertable.Rows.Add(Filterrow);
            }   
		
			}
			AddButton.Visible=false;
			comboBox2.Visible=false;
		}
		void AddButtonClick(object sender, EventArgs e)
		{
			addfilterline=1;
			comboBox2.Visible=true;
			comboBox1.Visible=false;
			
		}
		void ComboBox2SelectedIndexChanged(object sender, EventArgs e)
		{
			textBox3.Text=comboBox2.SelectedItem.ToString();
			Write_filterBOM.Visible=true;
			Write_filterBOM.Enabled=true;
//			comboBox1.Visible=false;
		}
	

	}
}
