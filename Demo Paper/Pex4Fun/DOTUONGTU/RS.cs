using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DOTUONGTU
{
    public partial class RS : Form
    {
        public RS()
        {
            InitializeComponent();
        }

        private void RS_Load(object sender, EventArgs e)
        {
            string topDir = @"C:\Users\admin\Dropbox\Thac si\Luan van\Projects\Demo Paper\Pex4Fun\DOTUONGTU\bin\Debug\Data\secret_project\Students\Metric1.txt";
            System.IO.StreamReader file = new System.IO.StreamReader(topDir);
            string[] columnnames = file.ReadLine().Split('\t');
            DataTable dt = new DataTable();
            foreach (string c in columnnames)
            {
                dt.Columns.Add(c);
            }
            dt.Columns.Add("Inputs");//thêm cột inputs

            string newline;
            while ((newline = file.ReadLine()) != null)
            {
                DataRow dr = dt.NewRow();
                string[] values = newline.Split('\t');
                for (int i = 0; i < values.Length; i++)
                {
                    dr[i] = values[i];
                }
                string path = @"C:\Users\admin\Dropbox\Thac si\Luan van\Projects\Demo Paper\Pex4Fun\DOTUONGTU\bin\Debug\Data\secret_project\Students\meta_project" + values[0] + @"\PexTests.xml";
                dr[values.Length] = show_input(path); //đọc file xml Inputs của student
                dt.Rows.Add(dr);
            }
            file.Close();
            dataGridView1.DataSource = dt;

            
        }

        public static string show_input(string pathXML)
        {
            string inputs = "";
            string topDir = pathXML;
            XmlTextReader reader = new XmlTextReader(topDir);
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    
                    case XmlNodeType.Text: //Display the text in each element.
                        inputs += (reader.Value) + "  ";
                        break;
                   
                }
            }

            return inputs;
        }
    }
}
