using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace DOTUONGTU
{
    public class RandomTestGenerator
    {
        public static void GenerateRandomTests(string topDir, int numOfTests)
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
                        List<Test> tests = GenerateTestsForProject(method, numOfTests);
                        string fileName = studentDir + @"\RandomTests.xml";
                        Serializer.SerializeTests(tests, fileName);
                        break;
                    }
                }
            }
        }

        public static List<Test> GenerateTestsForProject(MethodInfo method, int NumOfTests)
        {
            int strBound = 10;
            int arrBound = 10;
            List<Test> tests = new List<Test>();
            var paras = method.GetParameters();
            Random rd = new Random();
            RandomStringGenerator rsg = new RandomStringGenerator();
            while (tests.Count < NumOfTests)
            {
                Test test = new Test();
                foreach (var para in paras)
                {
                    string paraType = para.ParameterType.Name;
                    switch (paraType)
                    {
                        case "Int32":
                            test.TestInputs.Add(rd.Next(Int32.MinValue, Int32.MaxValue));
                            break;
                        case "String":
                            int length = rd.Next(0, strBound + 1);
                            if (length == 0)
                            {
                                test.TestInputs.Add("");
                            }
                            else
                            {
                                //test.TestInputs.Add(rsg.Generate(length));
                                StringBuilder sb = new StringBuilder();
                                for (int i = 0; i < length; i++)
                                {
                                    int n = rd.Next(0, 256);
                                    char c = Convert.ToChar(n);
                                    sb.Append(c);
                                }
                                test.TestInputs.Add(sb.ToString());
                            }
                            break;
                        case "Char":
                            test.TestInputs.Add(Char.Parse(rsg.Generate(1)));
                            break;
                        case "Boolean":
                            if(rd.NextDouble() >= 0.5){
                                test.TestInputs.Add(true);
                            }else
                            {
                                test.TestInputs.Add(false);
                            }
                            break;
                        case "Byte":
                            test.TestInputs.Add((Byte) rd.Next(Byte.MinValue, Byte.MaxValue+1));
                            break;
                        case "Int32[]":
                            int size = rd.Next(0, arrBound);
                            int[] array = new int[size+1];
                            for (int i = 0; i < array.Length; i++)
                            {
                                array[i] = rd.Next(Int32.MinValue, Int32.MaxValue);
                            }
                            test.TestInputs.Add(array);
                            break;
                        default:
                            throw new Exception("Unhandled para type: " + paraType);
                    }
                }
                tests.Add(test);
            }
            return tests;
        }
    }
}
