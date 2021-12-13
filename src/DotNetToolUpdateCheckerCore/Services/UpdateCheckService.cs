using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rksoftware.DotNetToolUpdateChecker.Services;

internal class UpdateCheckService : IUpdateCheckService
{
    IDotNetToolCommandService dotNetToolCommandService;

    public UpdateCheckService(IDotNetToolCommandService dotNetToolCommandService) => (this.dotNetToolCommandService) = (dotNetToolCommandService);


    public string Check()
    {
        var title = new[] { "Package ID\tCurrent\tLasted\tCommand"};
        var lines = dotNetToolCommandService.List().Select(package => $"{package.PackageId}\t{package.Version}\t{dotNetToolCommandService.Search(package.PackageId).LatestVersion}\t{package.Command}");
        var result = string.Join(Environment.NewLine, title.Concat(lines));
        return result;
    }
}

