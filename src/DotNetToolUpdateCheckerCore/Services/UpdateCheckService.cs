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
        const string titlePackageID = "Package ID";
        const string titleCurrent = "Current       ";
        const string titleLatest = "Latest        ";
        const string titleCommand = "Command";

        yield return "";
        var list = dotNetToolCommandService.List().ToArray();
        var packageIdLength = Math.Max(titlePackageID.Length, list.Max(m => m.PackageId.Length));

        yield return $"{titlePackageID?.PadRight(packageIdLength)}\t{titleCurrent}\t{titleLatest}\t{titleCommand}\t";
        yield return "".PadRight(60, '-');

        foreach (var package in list)
        {
            var detail = dotNetToolCommandService.Search(package.PackageId ?? "");
            yield return $"{(package.PackageId ?? "").PadRight(packageIdLength)}\t{(package.Version?.ToString() ?? "").PadRight(titleCurrent.Length)}\t{(detail.LatestVersion?.ToString() ?? "").PadRight(titleLatest.Length)}\t{package.Command}";
        }
        yield return Environment.NewLine;
    }
}

