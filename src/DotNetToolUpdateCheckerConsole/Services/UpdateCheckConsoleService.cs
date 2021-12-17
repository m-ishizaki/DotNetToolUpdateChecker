using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rksoftware.DotNetToolUpdateChecker.Services;

internal class UpdateCheckConsoleService : IUpdateCheckConsoleService
{
    IUpdateCheckService updateCheckService;

    public UpdateCheckConsoleService(IUpdateCheckService updateCheckService) => (this.updateCheckService) = (updateCheckService);

    public void CheckAndOutput()
    {
        foreach (var result in updateCheckService.Check())
        {
            var values = result?.Split('\t') ?? new string[0];
            Console.ForegroundColor = values.Skip(1).FirstOrDefault() == values.Skip(2).FirstOrDefault() ? ConsoleColor.White : ConsoleColor.Red;
            Console.WriteLine(result);
        }
    }
}

