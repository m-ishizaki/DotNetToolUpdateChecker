using Rksoftware.DotNetToolUpdateChecker.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rksoftware.DotNetToolUpdateChecker.Services
{
    internal class DotNetToolCommandService : IDotNetToolCommandService
    {
        IProcessService processService;

        public DotNetToolCommandService(IProcessService processService) => (this.processService) = (processService);

        public IEnumerable<ListResultModel> List()
        {
            foreach(var result in ToModels(processService.Start("dotnet tool list -g"))) yield return result;
            foreach (var result in ToModels(processService.Start("dotnet tool list --local"))) yield return result;

            static IEnumerable<ListResultModel> ToModels(string result)
            {
                var results = result?.Split(Environment.NewLine).Skip(2).Where(line => !string.IsNullOrWhiteSpace(line)).Select(ToModel);
                if (results != null)
                    foreach (var line in results)
                        yield return line;
            }

            static ListResultModel ToModel(string line)
            {
                var values = line.Split(" ").Where(value => !string.IsNullOrEmpty(value)).ToArray();
                ListResultModel model = new(
                    values.FirstOrDefault(""),
                    new Version(values.Skip(1).FirstOrDefault("")),
                    values.Skip(2).FirstOrDefault("")
                    );
                return model;
            }
        }

        public SearchResultModel Search(string packageId)
        {
            var result = processService.Start($"dotnet tool search --detail {packageId}");

            var lines = result?.Split(Environment.NewLine).Skip(2).ToArray();
            SearchResultModel model = new(
                new Version(lines.FirstOrDefault("").Split(' ').LastOrDefault("")),
                lines.Skip(1).FirstOrDefault("").Split(' ').LastOrDefault(""),
                lines.Skip(2).FirstOrDefault("").Split(' ').LastOrDefault(""),
                int.TryParse(lines.Skip(3).FirstOrDefault("").Split(' ').LastOrDefault(""), out var download) ? download : default,
                bool.TryParse(lines.Skip(4).FirstOrDefault("").Split(' ').LastOrDefault(""), out var verified) ? verified : default,
                lines.Skip(5).FirstOrDefault("").Split(' ').LastOrDefault(""),
                Array.Empty<Version>()
                );
            return model;
        }
    }
}
