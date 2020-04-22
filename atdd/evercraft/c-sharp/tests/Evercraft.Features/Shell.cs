using System;
using System.Diagnostics;
using System.Runtime.Loader;

namespace Evercraft.Features
{
    public static class Shell
    {
        private static Process Execute(string command)
        {
            var escapedArgs = command.Replace("\"", "\\\"");

            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "/bin/bash",
                    Arguments = $"-c \"{escapedArgs}\"",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            process.EnableRaisingEvents = true;
            process.OutputDataReceived += (sender, args) => Console.Out.WriteLine(args?.Data);
            process.ErrorDataReceived += (sender, args) => Console.Error.WriteLine(args?.Data);
            process.Start();
            
            return process;
        }

        public static int ExecuteAndWait(string command)
        {
            var process = Execute(command);
            process.WaitForExit();
            return process.ExitCode;
        }
    }
}