using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rksoftware.DotNetToolUpdateChecker.DataModels;

internal record SearchResultModel(Version LatestVersion, string Authors, string Tags, int Downloads, bool Verified, string Description, IReadOnlyList<Version> Versions)
{
}

