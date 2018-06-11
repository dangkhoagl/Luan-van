using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pex4Fun
{
    public class Program
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

        public static void Main(string[] args)
        {
            //string topDir = @"D:\Experiment\data-cleaner\apcs";
            //string topDir = @"C:\Users\photocopy\Dropbox\Thac si\Luan van\Projects\Demo Paper\Pex4Fun\Pex4Fun\bin\Debug\Data";
            string topDir = @"C:\Users\admin\Dropbox\Thac si\Luan van\Projects\Demo Paper\Pex4Fun\Pex4Fun\bin\Debug\Data";
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

            Console.WriteLine(Utility.GetNumOfStudent(topDir));
            Console.WriteLine(Utility.GetNumOfSubmissions(topDir));
            //Console.ReadKey();
            //List<string> notInclude = Utility.GetNotIncludedTasks(@"C:\Users\admin\Dropbox\Thac si\Luan van\Projects\Demo Paper\Pex4Fun\Pex4Fun\bin\Debug\Data");
            //Utility.GenerateRandomlySampleSequence(topDir, notInclude);
            //Utility.CopySampledSequences(@"D:\Experiment\apcs_sample.txt");
        }

    }
}
