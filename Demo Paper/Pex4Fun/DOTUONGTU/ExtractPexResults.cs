using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Reflection;
using System.Globalization;

namespace DOTUONGTU
{
    public class ExtractPexResults
    {
        public static void ExtractPexTests(string topDir)
        {
            foreach (string taskDir in Directory.GetDirectories(topDir))
            {
                MethodInfo method = null;
                foreach (var studentDir in Directory.GetDirectories(taskDir))
                {
                    if (studentDir.EndsWith("secret_project"))
                    {
                        string assemblyFile = FileModifier.GetAssemblyFileOfProject(studentDir);
                        method = RunTest.GetMethodDefinition(assemblyFile, "Program", "Puzzle");
                        List<Test> tests = ExtractTestsForProject(studentDir, method);
                        if (tests != null)
                        {
                            string fileName = studentDir + @"\PexTests.xml";
                            Serializer.SerializeTests(tests, fileName);
                        }
                        break;
                    }
                }
                foreach (var studentDir in Directory.GetDirectories(taskDir))
                {
                    if (studentDir.EndsWith("secret_project"))
                    {
                        continue;
                    }
                    foreach (var projectDir in Directory.GetDirectories(studentDir))
                    {
                        List<Test> tests = ExtractTestsForProject(projectDir, method);
                        if (tests != null)
                        {
                            string fileName = projectDir + @"\PexTests.xml";
                            Serializer.SerializeTests(tests, fileName);
                        }
                    }
                }
            }
        }

        public static List<Test> ExtractTestsForProject(string projectDir, MethodInfo method)
        {
            var paras = method.GetParameters();
            List<Test> tests = new List<Test>();
            string reportsDir = projectDir + @"\bin\Debug\reports\";
            if (!Directory.Exists(reportsDir))
                return null;
            string reportDir = Directory.GetDirectories(reportsDir)[0];
            string reportFile = reportDir + "\\report.per";
            XmlDocument doc = new XmlDocument();
            doc.Load(reportFile);
            foreach (XmlNode node in doc.SelectNodes(
                "/pex/assembly/fixture/exploration/generatedTest"))
            {
                //node is the generted test
                Test test = new Test();
                string failed = null;
                if (node.Attributes["failed"] != null)
                {
                    failed = node.Attributes["failed"].Value;
                }
                else
                {
                    failed = "false";
                }
                if (failed == "true")
                {
                    test.Result = TestResult.Failed;
                }
                else
                {
                    test.Result = TestResult.Passed;
                }
                int i = 0;
                foreach (XmlNode child in node.ChildNodes)
                {
                    if (child.Name == "value" && i < paras.Length)
                    {
                        string input = child.InnerText;
                        //input.Replace("&apos;", "\'");
                        //input.Replace("&quot;", "\"");
                        
                        string paraType = paras[i++].ParameterType.Name;
                        switch (paraType)
                        {
                            case "Int32":
                                if (input.ToLower() == "int.maxvalue")
                                {
                                    test.TestInputs.Add(Int32.MaxValue);
                                }
                                else if (input.ToLower() == "int.minvalue")
                                {
                                    test.TestInputs.Add(Int32.MinValue);
                                }
                                else
                                {
                                    test.TestInputs.Add(Int32.Parse(input));
                                }
                                break;
                            case "String":
                                if (input == "null")
                                {
                                    test.TestInputs.Add(null);
                                }else if(input.StartsWith("new string("))
                                {
                                    input = input.Replace("\"", "");
                                    string[] tokens = input.Split(',');
                                    string token1=tokens[0].Trim();
                                    int start = token1.IndexOf('\'');
                                    string str = token1.Substring(start+1, token1.Length - start-2);
                                    string token2 = tokens[1].Trim();
                                    string numStr = token2.Substring(0, token2.Length - 1);
                                    int num = Int32.Parse(numStr);
                                    str = Utility.ParseString(str);
                                    StringBuilder sb = new StringBuilder();
                                    for (int j = 0; j < num; j++)
                                    {
                                        sb.Append(str);
                                    }
                                    test.TestInputs.Add(sb.ToString());
                                }
                                else
                                {
                                    //input = input.Replace("\"", "");
                                    input = input.Substring(1, input.Length - 2);
                                    input = Utility.ParseString(input);
                                    test.TestInputs.Add(input);
                                }
                                break;
                            case "Char":
                                input = input.Replace("\'", "");
                                input = Utility.ParseString(input);
                                if (input.ToLower() == "char.maxvalue")
                                {
                                    test.TestInputs.Add(Char.MaxValue);
                                }
                                else if (input.ToLower() == "char.minvalue")
                                {
                                    test.TestInputs.Add(Char.MinValue);
                                }
                                else
                                {
                                    test.TestInputs.Add(Char.Parse(input));
                                }
                                break;
                            case "Boolean":
                                if (input.StartsWith("t"))
                                {
                                    input = input.Substring(0, 4);
                                }
                                else
                                {
                                    input = input.Substring(0, 5);
                                }
                                test.TestInputs.Add(Boolean.Parse(input));
                                break;
                            case "Byte":
                                if (input.ToLower() == "byte.maxvalue")
                                {
                                    test.TestInputs.Add(Byte.MaxValue);
                                }
                                else if (input.ToLower() == "byte.minvalue")
                                {
                                    test.TestInputs.Add(Byte.MinValue);
                                }
                                else
                                {
                                    test.TestInputs.Add(Byte.Parse(input, NumberStyles.HexNumber));
                                }
                                break;
                            case "Int32[]":
                                int[] array;
                                if (input == "null")
                                {
                                    array = null;
                                }
                                else if (input == "{}")
                                {
                                    array = new int[0];
                                }
                                else if (input.Contains("Length=") && input.Contains("..."))
                                {
                                    int start = input.IndexOf("Length=") + 7;
                                    int end = input.IndexOf(";");
                                    string sizeStr = input.Substring(start, end - start);
                                    int size = Int32.Parse(sizeStr);
                                    array = new int[size];
                                }
                                else
                                {
                                    string str;
                                    if (!input.Contains("Length="))
                                    {
                                        str = input.Substring(1, input.Length - 2);
                                    }
                                    else
                                    {
                                        str = input.Substring(input.IndexOf(';') + 2);
                                        str = str.Substring(0, str.Length - 1);
                                    }
                                    string[] tokens = str.Split(',');
                                    array = new int[tokens.Length];
                                    for (int j = 0; j < tokens.Length; j++)
                                    {
                                        if (tokens[j].Trim().ToLower() == "int.maxvalue")
                                        {
                                            array[j] = Int32.MaxValue;
                                        }
                                        else if (tokens[j].Trim().ToLower() == "int.minvalue")
                                        {
                                            array[j] = Int32.MinValue;
                                        }
                                        else
                                        {
                                            array[j] = Int32.Parse(tokens[j].Trim());
                                        }
                                    }
                                }
                                test.TestInputs.Add(array);
                                break;
                            default:
                                throw new Exception("Unhandled para type: " + paraType);
                        }
                    }
                }
                tests.Add(test);
            }
            return tests;
        }
    }
}
