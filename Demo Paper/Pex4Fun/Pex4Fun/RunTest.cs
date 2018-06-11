using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Globalization;

namespace Pex4Fun
{
    public class RunTest
    {
        //public static void TestRun()
        //{
        //    List<Test> tests = Serializer.DeserializeTests(@"D:\demo\0\secret_project\PexTests.xml");
        //    RunTestOn(@"D:\demo\0\anchi\meta_project0\bin\Debug\meta_project0.dll", "MetaProgram", "Check", tests[0]);
        //}
                
        //public static void RunTestOn(string assemblyFile, string typeName, string methodName, Test test)
        //{
        //    MethodInfo method = Utility.GetMethodDefinition(assemblyFile, typeName, methodName);
        //    object result = method.Invoke(null, test.TestInputs.ToArray());
        //}

        public static void RunPexTestsOnSecretProjects(string topDir)
        {

        }

        public static void RunPexTestsOnProjects(string topDir)
        {

        }

        public static void RunPexTestsOnMetaProjects(string topDir)
        {

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
    }
}
