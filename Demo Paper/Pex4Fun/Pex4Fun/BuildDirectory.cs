using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Pex4Fun
{
    public class BuildDirectory
    {
        //output the not projects that cannot be compiled as the list to the topDir
        public static void CheckNotBuiltProjects(string topDir)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var taskDir in Directory.GetDirectories(topDir))
            {
                foreach (var studentDir in Directory.GetDirectories(taskDir))
                {
                    if (studentDir.EndsWith("secret_project"))
                    {
                        bool succeed = false;
                        foreach (var dir in Directory.GetDirectories(studentDir))
                        {
                            if (dir.EndsWith("\\bin"))
                            {
                                string debugDir = Directory.GetDirectories(dir)[0];
                                if (Directory.GetFiles(debugDir).Length != 0)
                                    succeed = true;
                                break;
                            }
                        }
                        if (!succeed)
                        {
                            sb.AppendLine(studentDir);
                        }
                        continue;
                    }
                    foreach (var projectDir in Directory.GetDirectories(studentDir))
                    {
                        //foreach (var projectDir in Directory.GetDirectories(projectsDir))
                        //{
                            bool succeed = false;
                            foreach (var dir in Directory.GetDirectories(projectDir))
	                        {
		                        if(dir.EndsWith("\\bin"))
                                {
                                    string debugDir = Directory.GetDirectories(dir)[0];
                                    if (Directory.GetFiles(debugDir).Length != 0)
                                        succeed = true;
                                    break;
                                }
	                        }
                            if (!succeed)
                            {
                                sb.AppendLine(projectDir);
                            }
                        //}
                    }
                }
            }
            if(sb.Length!=0)
            {
                File.WriteAllText(topDir + "\\BuildFailures.txt", sb.ToString());
            }
        }

        //build the secret projects only
        public static void BuildSecretProjects(string topDir, bool rebuild)
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
                BuildSingleProject(secretDir, rebuild);
            }
        }

        public static void BuildProjects(string topDir, bool rebuild)
        {
            foreach (var taskDir in Directory.GetDirectories(topDir))
            {
                foreach (var studentDir in Directory.GetDirectories(taskDir))
                {
                    if (studentDir.EndsWith("secret_project"))
                        continue;
                    foreach (var projectDir in Directory.GetDirectories(studentDir))
                    {
                        if (!projectDir.Contains("meta_project"))
                        {
                            BuildSingleProject(projectDir, rebuild);
                        }
                    }
                }
            }
        }

        public static void BuildMetaProjects(string topDir, bool rebuild)
        {
            foreach (var taskDir in Directory.GetDirectories(topDir))
            {
                foreach (var studentDir in Directory.GetDirectories(taskDir))
                {
                    if (studentDir.EndsWith("secret_project"))
                        continue;
                    foreach (var projectDir in Directory.GetDirectories(studentDir))
                    {
                        if (projectDir.Contains("meta_project"))
                        {
                            BuildSingleProject(projectDir, rebuild);
                        }
                    }
                }
            }
        }

        //build projects and meta project except secret projects
        public static void BuildAllProjects(string topDir, bool rebuild)
        {
            foreach (var taskDir in Directory.GetDirectories(topDir))
            {
                foreach (var studentDir in Directory.GetDirectories(taskDir))
                {
                    if (studentDir.EndsWith("secret_project"))
                        continue;
                    foreach (var projectDir in Directory.GetDirectories(studentDir))
                    {
                        BuildSingleProject(projectDir, rebuild);
                    }
                }
            }
        }

        public static void BuildSingleProject(string projectDir, bool rebuild)
        {
            if (!Directory.Exists(projectDir))
            {
                throw new Exception("directory not found");
            }
            if (!rebuild)
            {
                bool hasBin = false;
                foreach (var dir in Directory.GetDirectories(projectDir))
                {
                    if (dir.EndsWith("bin"))
                    {
                        hasBin = true;
                        break;
                    }
                }
                if (hasBin)
                    return;
            }
            string projectFile=null;
            foreach (var file in Directory.GetFiles(projectDir))
            {
                if (file.EndsWith(".csproj"))
                {
                    projectFile = file;
                    break;
                }
            }
            if (projectFile == null)
            {
                throw new Exception("project file not found");
            }
            CommandExecutor.ExecuteCommand(CommandGenerator.GenerateBuildCommand(projectFile));
        }
    }
}
