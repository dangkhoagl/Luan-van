using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace DOTUONGTU
{
    public class RunPex
    {
        public static void RunPexOnSubmissionProjects(string topDir)
        {
            foreach (var taskDir in Directory.GetDirectories(topDir))
            {
                foreach (var studentDir in Directory.GetDirectories(taskDir))
                {
                    if (studentDir.EndsWith("\\secret_project"))
                        continue;
                    foreach (var projectDir in Directory.GetDirectories(studentDir))
                    {
                        if (!projectDir.Contains("meta_project"))
                        {
                            string reportDir = projectDir + @"\bin\Debug\reports";
                            if (Directory.Exists(reportDir))
                                DeleteDirectory(reportDir);
                            string assemblyName = projectDir.Substring(projectDir.LastIndexOf('\\') + 1);
                            string assemblyFile = projectDir + @"\bin\Debug\" + assemblyName + ".dll";
                            if (!File.Exists(assemblyFile))
                            {
                                throw new Exception("assembly file not found");
                            }
                            string[] methods = { "Puzzle" };
                            string typeUnderTest = null;
                            Assembly assembly = Assembly.LoadFile(assemblyFile);
                            foreach (var type in assembly.GetTypes())
                            {
                                foreach (var method in type.GetMethods())
                                {
                                    if (method.Name == "Puzzle")
                                    {
                                        typeUnderTest = type.Name;
                                        break;
                                    }
                                }
                                if (typeUnderTest!=null)
                                    break;
                            }
                            CommandExecutor.ExecuteCommand(
                                CommandGenerator.GenerateRunPexCommand(assemblyFile, "Submission", typeUnderTest, methods));
                        }
                    }
                }
            }
        }

        public static void RunPexOnSecretProjects(string topDir)
        {
            foreach (string taskDir in Directory.GetDirectories(topDir))
            {
                string secretDir = null;
                foreach (var dir in Directory.GetDirectories(taskDir))
                {
                    if (dir.EndsWith("secret_project"))
                    {
                        secretDir = dir;
                        break;
                    }
                }
                if (secretDir == null)
                    throw new Exception("secret project not found");
                string reportDir = secretDir + @"\bin\Debug\reports";
                if (Directory.Exists(reportDir))
                    DeleteDirectory(reportDir);
                string assemblyFile = secretDir + @"\bin\Debug\secret_project.dll";
                if (!File.Exists(assemblyFile))
                {
                    throw new Exception("assembly file not found");
                }
                string[] methods = { "Puzzle" };
                string typeUnderTest = null;
                Assembly assembly = Assembly.LoadFile(assemblyFile);
                foreach (var type in assembly.GetTypes())
                {
                    foreach (var method in type.GetMethods())
                    {
                        if (method.Name == "Puzzle")
                        {
                            typeUnderTest = type.Name;
                            break;
                        }
                    }
                    if (typeUnderTest != null)
                        break;
                }
                CommandExecutor.ExecuteCommand(
                    CommandGenerator.GenerateRunPexCommand(assemblyFile, "Solution", typeUnderTest, methods));
            }
        }

        public static void DeleteDirectory(string target_dir)
        {
            string[] files = Directory.GetFiles(target_dir);
            string[] dirs = Directory.GetDirectories(target_dir);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                DeleteDirectory(dir);
            }

            Directory.Delete(target_dir, false);
        }

        public static void RunPexOnMetaProjects(string topDir)
        {
            foreach (var taskDir in Directory.GetDirectories(topDir))
            {
                foreach (var studentDir in Directory.GetDirectories(taskDir))
                {
                    if (studentDir.EndsWith("\\secret_project"))
                        continue;
                    foreach (var metaDir in Directory.GetDirectories(studentDir))
                    {
                        if (metaDir.Contains("meta_project"))
                        {
                            string reportDir = metaDir + @"\bin\Debug\reports";
                            if (Directory.Exists(reportDir))
                            {
                                DeleteDirectory(reportDir);
                            }
                            string assemblyName = metaDir.Substring(metaDir.LastIndexOf('\\') + 1);
                            string assemblyFile = metaDir + @"\bin\Debug\"+assemblyName+".dll";
                            if (!File.Exists(assemblyFile))
                            {
                                //throw new Exception("assembly file not found");
                                continue;
                            }
                            string[] methods = { "Check" };
                            CommandExecutor.ExecuteCommand(
                                CommandGenerator.GenerateRunPexCommand(assemblyFile, "MetaProject", "MetaProgram", methods));
                        }
                    }
                }
            }
        }

        public static void DumpAllArgTypes(string topDir)
        {
            List<string> types = new List<string>();
            foreach (string taskDir in Directory.GetDirectories(topDir))
            {
                string[] files = Directory.GetFiles(taskDir);
                string secretFile = null;
                foreach (var file in files)
                {
                    if (file.EndsWith("solution.cs"))
                    {
                        secretFile = file;
                        break;
                    }
                }
                if (secretFile == null)
                {
                    throw new Exception("secret implementation not found");
                }
                foreach (var type in GetArgTypes(secretFile))
                {
                    if (!types.Contains(type))
                        types.Add(type);
                }
            }
            StringBuilder sb = new StringBuilder();
            foreach (var type in types)
            {
                sb.AppendLine(type);
            }
            File.WriteAllText(topDir + "\\ArgTypes.txt", sb.ToString());
        }

        public static List<string> GetArgTypes(string file)
        {
            StringBuilder sb = new StringBuilder();
            string[] lines = File.ReadAllLines(file);
            List<string> argTypeList = new List<string>();
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Trim();
                string[] tokens = line.Split();
                if (tokens[0] == "public" && line.Contains("Puzzle"))
                {
                    int start = line.IndexOf('(');
                    int end = line.IndexOf(')');
                    string argList = line.Substring(start + 1, end - start - 1);
                    string[] args = argList.Split(',');
                    for (int j = 0; j < args.Length; j++)
                    {
                        string arg = args[j].Trim();
                        string[] temp = arg.Split();
                        if(!argTypeList.Contains(temp[0]))
                            argTypeList.Add(temp[0]);
                    }
                    break;
                }
            }
            return argTypeList;
        }
    }
}
