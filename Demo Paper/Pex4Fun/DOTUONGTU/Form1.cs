using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraEditors;
namespace DOTUONGTU
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        /*
         * INITIALIZATION
         * Create the projects for each submission, secret implemetation, and meta projects
         *      FileModifier.MakeProjects(topDir), 
         *      FileModifier.MakeSecretProjects(topDir), FileModifier.MakeMetaProejcts(topDir)
         * Build all the created projects
         *      BuildDirectory.BuildAllProjects(topDir, true), BuildDirectory.BuildAllSecreteProejcts(topDir, true);
         * Check the project that cannot be compiled, the list will be ouput at the topDir. 
         * Manually process the list of projects before continuing.
         *      BuildDirectory.CheckNotBuiltProjects(topDir)
         * Run Pex on all kind of the projects
         *      RunPex.RunPexOnSubmissionProjects(topDir), RunPex.RunPexOnSecretProjects(topDir), 
         *      RunPex.RunPexOnMetaProjects(topDir)
         * Extract tests from all kinds of the projects and write them to the xml file.
         *      ExtractPexResults
         *      
         * METRIC 1 (Combined Path Counting)
         * Run the tests of meta project on each meta projects, and get the test results that are failed
         * M1 = |P_pass| / |P_all|
         *      Metric1.Compute()
         *
         * METRIC 2 (Separate Path Counting)
         * Run the tests of secret project on both secret and submission projects, and compare the outputs that match (N)
         * M2 = N / |P_secret|
         *      Metric2.Compute()
         * 
         * METRIC 3 (Sample Inputs Counting)
         * Randomly sample inputs (M) for each arguments, run these inputs on both secret and submission proejcts
         * Compare the outputs that match (N)
         * M3 = N / M
         *      Metric3.Compute()
         *
         */

        public Form1()
        {
            InitializeComponent();
        }
        string topDir = @"C:\Users\admin\Dropbox\Thac si\Luan van\Projects\Demo Paper\Pex4Fun\DOTUONGTU\bin\Debug\Data";
        private void button1_Click(object sender, EventArgs e)
        {
            try {
                string topDir = @"C:\Users\admin\Dropbox\Thac si\Luan van\Projects\Demo Paper\Pex4Fun\DOTUONGTU\bin\Debug\Data";
                FileModifier.MakeProjects(topDir);
                FileModifier.MakeSecretProjects(topDir);

                BuildDirectory.BuildProjects(topDir, true);
                BuildDirectory.BuildSecretProjects(topDir, true);

                FileModifier.MakeMetaProjects(topDir);
                BuildDirectory.BuildMetaProjects(topDir, true);
                BuildDirectory.CheckNotBuiltProjects(topDir);

                RunPex.RunPexOnSecretProjects(topDir);
                RunPex.RunPexOnMetaProjects(topDir);

                ExtractPexResults.ExtractPexTests(topDir);

                Metrics.ComputeMetric1(topDir);
                Metrics.ComputeMetric2(topDir);

                RandomTestGenerator.GenerateRandomTests(topDir, 200);
                Metrics.ComputeMetric3(topDir);

                //Console.WriteLine(Utility.GetNumOfStudent(topDir));
                //Console.WriteLine(Utility.GetNumOfSubmissions(topDir);)

                lb_thongbao.Text = "Đã hoàn thành.";
            }
            catch
            {

                lb_thongbao.Text = "Code upload bị lỗi, kiểm tra lại...";
            }           
            
            //bt_rs.Enabled = true;
            //bt_sse.Enabled = true;
            //bt_pse.Enabled = true;
        }

        private void bt_upload_solution_Click(object sender, EventArgs e)
        {
            OpenFileDialog op1 = new OpenFileDialog();

            op1.Multiselect = true;

            op1.ShowDialog();

            op1.Filter = "allfiles|*.xls";

            

            int count = 0;

            string[] FName;

            foreach (string s in op1.FileNames)

            {

                FName = s.Split('\\');

                File.Copy(s, topDir + "\\secret_project\\" + FName[FName.Length - 1],true);

                count++;

                textBox1.Text = FName[FName.Length - 1];

            }

            MessageBox.Show(Convert.ToString(count) + " File(s) copied");
        }

        private void bt_upload_users_Click(object sender, EventArgs e)
        {
            OpenFileDialog op1 = new OpenFileDialog();

            op1.Multiselect = true;

            op1.ShowDialog();

            op1.Filter = "allfiles|*.xls";           

            int count = 0;

            string[] FName;

            DirectoryInfo di = new DirectoryInfo(topDir + @"\secret_project\Students\");

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }

            tb_submittions.Text = "";
            foreach (string s in op1.FileNames)

            {

                FName = s.Split('\\');

                File.Copy(s, topDir + "\\secret_project\\Students\\" + FName[FName.Length - 1], true);

                count++;

                tb_submittions.Text += FName[FName.Length - 1] + " ";

            }

            MessageBox.Show(Convert.ToString(count) + " File(s) copied");
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //bt_rs.Enabled = false;
            //bt_sse.Enabled = false;
            //bt_pse.Enabled = false;
            lb_thongbao.Text = "...";
        }

        private void bt_rs_Click(object sender, EventArgs e)
        {
            RS form_rs = new RS();
            form_rs.Show();
        }

        private void bt_sse_Click(object sender, EventArgs e)
        {
            SSE fr = new SSE();
            fr.Show();
        }

        private void bt_pse_Click(object sender, EventArgs e)
        {
            PSE fr = new PSE();
            fr.Show();
        }
    }
}
