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
            Console.WriteLine(result);
    }
}

