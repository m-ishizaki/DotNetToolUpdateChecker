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


    public IEnumerable<string> Check()
    {
        yield return "Current\tLatest\tCommand\t\tPackage ID";
        yield return "----------------------------------------------------------------------";
        foreach (var package in dotNetToolCommandService.List())
            yield return $"{package.Version}\t{dotNetToolCommandService.Search(package.PackageId).LatestVersion}\t{package.Command}\t{package.PackageId}";
        yield return Environment.NewLine;
    }
}

