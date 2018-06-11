# https://bitbucket.org/lsh891023/behavioral-similarity
# Measuring Behavioral Similarity #

Project Summary: Measuring behavioral similarity based on input/output behaviors is important and useful in various tasks (e.g., semantic code clone, automatic grading). However, in practice, it is challenging to precisely quantify the behavioral similarity due to the huge input domain of programs. Hence, we propose three metrics that approximate the computation of behavioral similarity using dynamic analysis. We leverage random testing and dynamic symbolic execution (DSE) to generate test inputs, and run programs on these test inputs to compute metric values.

Tool features: 
1. Download students' solutions from the Pex4Fun website. 
2. Modify the downloaded solutions so that they can be compiled (e.g., add references). 
3. Build the modified solutions into C# projects in order to run Pex on them. 
4. Run Pex on the C# projects with customized configurations in a batch. 
5. Analyze the Pex reports of generated tests and compute the three metrics described in the draft.

Instructions on how to run the tool 
1. Check out the tool from the repo to a local computer. 
2. Install Pex and add Pex into the references of the project. 
3. Have the downloaded solutions in place using the ruby scripts (see README in the scripts folder for details). 
4. Run the tool from the main method in the project (comment out statements that are not necessary for your analysis).

Example: 

```
#!c#

public static void Main(string[] args) { 
  //set the top directory 
  string topDir = @"D:\Experiment\icse2011";
  //modify the downloaded files 
  FileModifier.MakeProjects(topDir); 
  FileModifier.MakeSecretProjects(topDir);
  //Build the downloaded files into C# project Build
  Directory.BuildProjects(topDir, true); 
  BuildDirectory.BuildSecretProjects(topDir, true); 
  FileModifier.MakeMetaProjects(topDir);
  BuildDirectory.BuildMetaProjects(topDir, true); 
  BuildDirectory.CheckNotBuiltProjects(topDir);
  //Run Pex on the built projects 
  RunPex.RunPexOnSecretProjects(topDir); 
  RunPex.RunPexOnMetaProjects(topDir);
  //Extract test cases from the Pex reports 
  ExtractPexResults.ExtractPexTests(topDir);
  //Compute metrics 
  Metrics.ComputeMetric1(topDir); 
  Metrics.ComputeMetric2(topDir); 
  RandomTestGenerator.GenerateRandomTests(topDir, 200); 
  Metrics.ComputeMetric3(topDir);
  //Some other useful utilities 
  Console.WriteLine(Utility.GetNumOfStudent(topDir)); 
  Console.WriteLine(Utility.GetNumOfSubmissions(topDir)); 
  Utility.GenerateRandomlySampleSequence(topDir); 
}
```