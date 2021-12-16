using Rksoftware.DotNetToolUpdateChecker.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rksoftware.DotNetToolUpdateChecker.Services;

internal interface IDotNetToolCommandService
{
    IEnumerable<ListResultModel> List();
    SearchResultModel Search(string packageId);
}

