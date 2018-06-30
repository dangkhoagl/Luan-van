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
    public partial class SSE : Form
    {
        public SSE()
        {
            InitializeComponent();
        }

        private void SSE_Load(object sender, EventArgs e)
        {
            string topDir = @"C:\Users\admin\Dropbox\Thac si\Luan van\Projects\Demo Paper\Pex4Fun\DOTUONGTU\bin\Debug\Data\secret_project\Students\Metric2.txt";
            System.IO.StreamReader file = new System.IO.StreamReader(topDir);
            string[] columnnames = file.ReadLine().Split('\t');
            DataTable dt = new DataTable();
            foreach (string c in columnnames)
            {
                dt.Columns.Add(c);
            }
            string newline;
            while ((newline = file.ReadLine()) != null)
            {
                DataRow dr = dt.NewRow();
                string[] values = newline.Split('\t');
                for (int i = 0; i < values.Length; i++)
                {
                    dr[i] = values[i];
                }
                dt.Rows.Add(dr);
            }
            file.Close();
            dataGridView1.DataSource = dt;

            tb_inputs.Text = show_input();
        }

        public static string show_input()
        {
            string inputs = "";
            string topDir = @"C:\Users\admin\Dropbox\Thac si\Luan van\Projects\Demo Paper\Pex4Fun\DOTUONGTU\bin\Debug\Data\secret_project\secret_project\PexTests.xml";
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

            return inputs.Replace("Passed", " ");
        }
    }
}
