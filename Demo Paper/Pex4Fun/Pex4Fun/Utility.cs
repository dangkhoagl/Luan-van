using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace Pex4Fun
{
    public class Utility
    {
        public static string ParseString(string txt)
        {
            var provider = new Microsoft.CSharp.CSharpCodeProvider();
            var prms = new System.CodeDom.Compiler.CompilerParameters();
            prms.GenerateExecutable = false;
            prms.GenerateInMemory = true;
            var results = provider.CompileAssemblyFromSource(prms, @"
namespace tmp
{
    public class tmpClass
    {
        public static string GetValue()
        {
             return " + "\"" + txt + "\"" + @";
        }
    }
}");
            System.Reflection.Assembly ass = results.CompiledAssembly;
            var method = ass.GetType("tmp.tmpClass").GetMethod("GetValue");
            return method.Invoke(null, null) as string;
        }

        public static MethodInfo GetMethodDefinition(string assemblyFile, string typeName, string methodName)
        {
            Assembly assembly = Assembly.LoadFile(assemblyFile);
            foreach (var type in assembly.GetTypes())
            {
                if (type.Name == typeName)
                {
                    foreach (var method in type.GetMethods())
                    {
                        if (method.Name == methodName)
                        {
                            return method;
                        }
                    }
                }
            }
            throw new Exception("Method not found");
        }

        public static int GetNumOfSubmissionSequences(string topDir)
        {
            int counter = 0;
            foreach (string taskDir in Directory.GetDirectories(topDir))
            {
                foreach (var studentDir in Directory.GetDirectories(taskDir))
                {
                    if (!studentDir.Contains("secret_project"))
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }

        public static int GetNumOfStudent(string topDir)
        {
            List<string> names = new List<string>();
            foreach (string taskDir in Directory.GetDirectories(topDir))
            {
                foreach (var studentDir in Directory.GetDirectories(taskDir))
                {
                    if (!studentDir.Contains("secret_project"))
                    {
                        string name = studentDir.Substring(studentDir.LastIndexOf('\\') + 1);
                        if (!names.Contains(name))
                        {
                            names.Add(name);
                        }
                    }
                }
            }
            return names.Count;
        }

        public static int GetNumOfSubmissions(string topDir)
        {
            int counter = 0;
            foreach (string taskDir in Directory.GetDirectories(topDir))
            {
                foreach (var studentDir in Directory.GetDirectories(taskDir))
                {
                    if (studentDir.Contains("secret_project"))
                    {
                        continue;
                    }
                    foreach (var file in Directory.GetFiles(studentDir))
                    {
                        if (file.EndsWith(".cs"))
                        {
                            counter++;
                        }
                    }
                }
            }
            return counter;
        }

        public static List<string> GetNotIncludedTasks(string topDir)
        {
            List<string> list = new List<string>();
            foreach (var taskDir in Directory.GetDirectories(topDir))
            {
                string num = taskDir.Substring(taskDir.LastIndexOf('\\') + 1);
                list.Add(num);
            }
            return list;
        }

        public static void GenerateRandomlySampleSequence(string topDir, List<string> notInclude)
        {
            List<string> list = new List<string>();
            foreach (string taskDir in Directory.GetDirectories(topDir))
            {
                string num = taskDir.Substring(taskDir.LastIndexOf('\\') + 1);
                //if (Int32.Parse(num) > 5)
                //{
                //    continue;
                //}
                foreach (var studentDir in Directory.GetDirectories(taskDir))
                {
                    if (studentDir.Contains("secret_project"))
                    {
                        continue;
                    }
                    list.Add(studentDir);
                }
            }
            Random rd = new Random();
            List<string> sampleSequence = new List<string>();
            int total = list.Count;
            while (sampleSequence.Count != total)
            {
                int i = rd.Next(0, list.Count);
                if (!sampleSequence.Contains(list[i]))
                {
                    sampleSequence.Add(list[i]);
                }
            }
            StringBuilder sb = new StringBuilder();
            foreach (var dir in sampleSequence)
            {
                int counter=0;
                foreach (var file in Directory.GetFiles(dir))
                {
                    if (file.EndsWith(".cs"))
                    {
                        counter++;
                    }
                }
                if(counter>1)
                    sb.AppendLine(dir);
            }
            File.WriteAllText(topDir + @"\SampleSequence.txt", sb.ToString());
        }

        public static string GetAssemblyForProject(string projectDir)
        {
            string name = projectDir.Substring(projectDir.LastIndexOf("\\") + 1);
            return projectDir + @"\bin\Debug\" + name + ".dll";
        }

        public static void CopySampledSequences(string sampleFile)
        {
            string[] files = File.ReadAllLines(sampleFile);
            foreach (var line in files)
            {
                string destDir = line.Replace(@"D:\Experiment\data-cleaner\apcs", @"D:\Experiment\apcs_sample");
                int end = line.LastIndexOf('\\');
                string str = line.Substring(0, end);
                string secretFile = str + @"\solution.cs";
                end = str.LastIndexOf('\\');
                str = str.Substring(end+1);
                string newSecretFile = @"D:\Experiment\apcs_sample\" + str + @"\solution.cs";
                FileModifier.CopyDirectory(line, destDir);
                File.Copy(secretFile, newSecretFile, true);
            }
        }
    }
}
