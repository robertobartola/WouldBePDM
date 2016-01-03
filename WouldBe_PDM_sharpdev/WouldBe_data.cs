/*
 * Created by SharpDevelop.
 * User: RoBartol
 * Date: 23/12/2015
 * Time: 23:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
//using System.Data.SqlClient;
using System.Windows.Forms;
//using System.Xml;


namespace WouldBe_PDM_sharpdev
{
	/// <summary>
	/// Description of WouldBe_data.
	/// </summary>
	public partial class WouldBe_data : Form
	{
		public WouldBe_data()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//

		}
		void Button1Click(object sender, EventArgs e)
		{
//			DataTable dt1 = new DataTable(); 
//dt1.Clear();
//dt1.Columns.Add("Name");
//dt1.Columns.Add("Marks");
//DataRow _ravi = dt1.NewRow();
//_ravi["Name"] = "ravi";
//_ravi["Marks"] = "500";
//dt1.Rows.Add(_ravi);
////dt.WriteXMLSchema("dtSchemaOrStructure.xml");
//dt.WriteXML("dtDataxml");


 DataSet ds = new DataSet();
            DataTable dt ;
            DataRow dr ;
            DataColumn idCoulumn ;
            DataColumn nameCoulumn ;
            int i = 0;

            dt = new DataTable();
            idCoulumn = new DataColumn("ID", Type.GetType("System.Int32"));
            nameCoulumn = new DataColumn("Name", Type.GetType("System.String"));

            dt.Columns.Add(idCoulumn);
            dt.Columns.Add(nameCoulumn);

            dr = dt.NewRow();
            dr["ID"] = 1;
            dr["Name"] = "Name1";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["ID"] = 2;
            dr["Name"] = "Name2";
            dt.Rows.Add(dr);
            
            
           dr = dt.NewRow();
            dr["ID"] = 3;
            dr["Name"] = "Name3";
            dt.Rows.Add(dr);
            textBox1.Text=("Name");


            ds.Tables.Add(dt);
  

            for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                MessageBox.Show(ds.Tables[0].Rows[i].ItemArray[0] + " -- " + ds.Tables[0].Rows[i].ItemArray[1]);    
                }   
		}
		
		
	}
}

