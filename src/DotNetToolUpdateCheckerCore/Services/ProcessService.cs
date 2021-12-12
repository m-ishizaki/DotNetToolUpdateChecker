using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rksoftware.DotNetToolUpdateChecker.Services;

internal class ProcessService : IProcessService
{
    public string Start(string command)
    {
        var filename = command.Split(" ").FirstOrDefault("");
        System.Diagnostics.ProcessStartInfo info = new()
        {
            FileName = filename,
            Arguments = command.Substring(filename.Length),
            UseShellExecute = false,
            RedirectStandardOutput = true,
        };
        using var process = System.Diagnostics.Process.Start(info);
        using var stream = process.StandardOutput;
        var output = stream.ReadToEnd();
        return output;
    }
}

