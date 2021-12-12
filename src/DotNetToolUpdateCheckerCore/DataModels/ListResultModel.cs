using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rksoftware.DotNetToolUpdateChecker.DataModels;

internal record ListResultModel(string PackageId, Version Version, string Command)
{
}

