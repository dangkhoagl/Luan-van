using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace Pex4Fun
{
    public class Metrics
    {
        public static void ComputeMetric1(string topDir)
        {
            foreach (var taskDir in Directory.GetDirectories(topDir))
            {
                foreach (var studentDir in Directory.GetDirectories(taskDir))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("projectNo\t#pass\t#notpass\t#all\tmetric1");
                    if (studentDir.EndsWith("secret_project"))
                        continue;
                    foreach (var projectDir in Directory.GetDirectories(studentDir))
                    {
                        double pass = 0;
                        double notPass = 0;
                        double metric = 0;
                        if(projectDir.Contains("meta_project"))
                        {
                            string projectNo = projectDir.Substring(projectDir.LastIndexOf("meta_project")+12);
                            List<Test> tests = Serializer.DeserializeTests(projectDir + @"\PexTests.xml");
                            MethodInfo method = Utility.GetMethodDefinition(
                                    Utility.GetAssemblyForProject(projectDir), "MetaProgram", "Check");
                            foreach (var test in tests)
                            {
                                try
                                {
                                    //MethodInfo method1 = Utility.GetMethodDefinition(
                                    //Utility.GetAssemblyForProject(@"D:\Experiment\demo\20\Benny\project0"), "Program", "Puzzle");
                                    //MethodInfo method2 = Utility.GetMethodDefinition(
                                    //Utility.GetAssemblyForProject(@"D:\Experiment\demo\20\secret_project"), "Program", "Puzzle");
                                    //object result1 = method1.Invoke(null, test.TestInputs.ToArray());
                                    //object result2 = method2.Invoke(null, test.TestInputs.ToArray());
                                    object result = method.Invoke(null, test.TestInputs.ToArray());
                                    pass++;
                                }
                                catch (Exception e)
                                {
                                    if (e.InnerException.Message.Contains("Submission failed"))
                                    {
                                        notPass++;
                                    }
                                }
                            }
                            metric = pass / (notPass + pass);
                            sb.AppendLine(projectNo + "\t" +pass +"\t"+notPass+"\t"+(pass+notPass)+"\t"+metric);
                        }
                    }
                    File.WriteAllText(studentDir + @"\Metric1.txt", sb.ToString());
                }
            }
        }

        public static void ComputeMetric2(string topDir)
        {
            foreach (var taskDir in Directory.GetDirectories(topDir))
            {
                List<Test> tests = Serializer.DeserializeTests(taskDir + @"\secret_project\PexTests.xml");
                MethodInfo secretMethod = Utility.GetMethodDefinition(
                    Utility.GetAssemblyForProject(taskDir + @"\secret_project"), "Program", "Puzzle");
                foreach (var test in tests)
                {
                    try
                    {
                        test.TestOuput = secretMethod.Invoke(null, test.TestInputs.ToArray());
                    }
                    catch (Exception e)
                    {
                        test.TestOuput = e;
                    }
                }
                foreach (var studentDir in Directory.GetDirectories(taskDir))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("projectNo\t#match\t#all\tmetric2");
                    if (studentDir.EndsWith("secret_project"))
                        continue;
                    foreach (var projectDir in Directory.GetDirectories(studentDir))
                    {
                        double match = 0;
                        double metric = 0;
                        if (!projectDir.Contains("meta_project"))
                        {
                            string projectNo = projectDir.Substring(projectDir.LastIndexOf("project") + 7);
                            MethodInfo method = Utility.GetMethodDefinition(
                                        Utility.GetAssemblyForProject(projectDir), "Program", "Puzzle");
                            foreach (var test in tests)
                            {
                                object result;
                                try
                                {
                                    result = method.Invoke(null, test.TestInputs.ToArray());
                                }
                                catch (Exception e)
                                {
                                    result = e;
                                }
                                if (result is Exception)
                                {
                                    if (test.TestOuput is Exception)
                                    {
                                        string type1 = ((Exception)result).InnerException.GetType().ToString();
                                        string type2 = ((Exception)test.TestOuput).InnerException.GetType().ToString();
                                        if (type1 == type2)
                                        {
                                            match++;
                                        }
                                    }
                                }
                                else
                                {
                                    if (test.TestOuput is Exception)
                                        continue;
                                    if (result == null)
                                    {
                                        if (test.TestOuput == null)
                                            match++;
                                    }
                                    else if (result is Int32)
                                    {
                                        if ((int)result == (int)test.TestOuput)
                                            match++;
                                    }
                                    else if (result is Double)
                                    {
                                        if ((double)result == (double)test.TestOuput)
                                            match++;
                                    }
                                    else if (result is String)
                                    {
                                        if ((string)result == (string)test.TestOuput)
                                            match++;
                                    }
                                    else if (result is Byte)
                                    {
                                        if ((byte)result == (byte)test.TestOuput)
                                            match++;
                                    }
                                    else if (result is Char)
                                    {
                                        if ((char)result == (char)test.TestOuput)
                                            match++;
                                    }
                                    else if (result is Double)
                                    {
                                        if ((double)result == (double)test.TestOuput)
                                            match++;
                                    }
                                    else if (result is Boolean)
                                    {
                                        if ((bool)result == (bool)test.TestOuput)
                                            match++;
                                    }
                                    else if (result is Int32[])
                                    {
                                        int[] array1 = (int[])result;
                                        int[] array2 = (int[])test.TestOuput;
                                        if (array1.Length == array2.Length)
                                        {
                                            bool equal = true;
                                            for (int i = 0; i < array1.Length; i++)
                                            {
                                                if (array1[i] != array2[i])
                                                {
                                                    equal = false;
                                                    break;
                                                }
                                            }
                                            if (equal)
                                                match++;
                                        }
                                    }
                                    else
                                    {
                                        throw new Exception("Not handled return type at " + projectDir);
                                    }
                                }
                            }
                            metric = match / tests.Count;
                            sb.AppendLine(projectNo + "\t" + match + "\t" + tests.Count + "\t" + metric);
                        }
                    }
                    File.WriteAllText(studentDir + @"\Metric2.txt", sb.ToString());
                }
            }
        }

        public static void ComputeMetric3(string topDir)
        {
            foreach (var taskDir in Directory.GetDirectories(topDir))
            {
                //Console.WriteLine(taskDir);
                List<Test> tests = Serializer.DeserializeTests(taskDir + @"\secret_project\RandomTests.xml");
                MethodInfo secretMethod = Utility.GetMethodDefinition(
                    Utility.GetAssemblyForProject(taskDir + @"\secret_project"), "Program", "Puzzle");
                foreach (var test in tests)
                {
                    try
                    {
                        test.TestOuput = secretMethod.Invoke(null, test.TestInputs.ToArray());
                    }
                    catch (Exception e)
                    {
                        test.TestOuput = e;
                    }
                }
                foreach (var studentDir in Directory.GetDirectories(taskDir))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("projectNo\t#match\t#all\tmetric3");
                    if (studentDir.EndsWith("secret_project"))
                        continue;
                    foreach (var projectDir in Directory.GetDirectories(studentDir))
                    {
                        double match = 0;
                        double metric = 0;
                        if (!projectDir.Contains("meta_project"))
                        {
                            string projectNo = projectDir.Substring(projectDir.LastIndexOf("project") + 7);
                            MethodInfo method = Utility.GetMethodDefinition(
                                        Utility.GetAssemblyForProject(projectDir), "Program", "Puzzle");
                            foreach (var test in tests)
                            {
                                object result;
                                try
                                {
                                    result = method.Invoke(null, test.TestInputs.ToArray());
                                }
                                catch (Exception e)
                                {
                                    result = e;
                                }
                                if (result is Exception)
                                {
                                    if (test.TestOuput is Exception)
                                    {
                                        string type1 = ((Exception)result).InnerException.GetType().ToString();
                                        string type2 = ((Exception)test.TestOuput).InnerException.GetType().ToString();
                                        if (type1 == type2)
                                        {
                                            match++;
                                        }
                                    }
                                }
                                else
                                {
                                    if (test.TestOuput is Exception)
                                        continue;
                                    if (result == null)
                                    {
                                        if (test.TestOuput == null)
                                            match++;
                                    }
                                    else if (result is Int32)
                                    {
                                        if ((int)result == (int)test.TestOuput)
                                            match++;
                                    }
                                    else if (result is Double)
                                    {
                                        if ((double)result == (double)test.TestOuput)
                                            match++;
                                    }
                                    else if (result is String)
                                    {
                                        if ((string)result == (string)test.TestOuput)
                                            match++;
                                    }
                                    else if (result is Byte)
                                    {
                                        if ((byte)result == (byte)test.TestOuput)
                                            match++;
                                    }
                                    else if (result is Char)
                                    {
                                        if ((char)result == (char)test.TestOuput)
                                            match++;
                                    }
                                    else if (result is Double)
                                    {
                                        if ((double)result == (double)test.TestOuput)
                                            match++;
                                    }
                                    else if (result is Boolean)
                                    {
                                        if ((bool)result == (bool)test.TestOuput)
                                            match++;
                                    }
                                    else if (result is Int32[])
                                    {
                                        int[] array1 = (int[])result;
                                        int[] array2 = (int[])test.TestOuput;
                                        if (array1.Length == array2.Length)
                                        {
                                            bool equal = true;
                                            for (int i = 0; i < array1.Length; i++)
                                            {
                                                if (array1[i] != array2[i])
                                                {
                                                    equal = false;
                                                    break;
                                                }
                                            }
                                            if (equal)
                                                match++;
                                        }
                                    }
                                    else
                                    {
                                        throw new Exception("Not handled return type at " + projectDir);
                                    }
                                }
                            }
                            metric = match / tests.Count;
                            sb.AppendLine(projectNo + "\t" + match + "\t" + tests.Count + "\t" + metric);
                        }
                    }
                    File.WriteAllText(studentDir + @"\Metric3.txt", sb.ToString());
                }
            }
        }
    }
}
