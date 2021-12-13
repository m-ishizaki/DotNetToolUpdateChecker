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
        var result = updateCheckService.Check();
        Console.WriteLine(result);
    }
}

