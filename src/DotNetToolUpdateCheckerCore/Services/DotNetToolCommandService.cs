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
        public IReadOnlyList<ListResultModel> List()
        {
            var gResults = ToModels(processService.Start("dotnet tool list -g"));
            var lResults = ToModels(processService.Start("dotnet tool list --local"));
            return Enumerable.Concat(gResults, lResults).ToArray();

            static ListResultModel[] ToModels(string result)
            {
                var results = result?.Split(Environment.NewLine).Skip(2).Where(line => !string.IsNullOrWhiteSpace(line)).Select(ToModel).ToArray();
                return results ?? Array.Empty<ListResultModel>();
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
            throw new NotImplementedException();
        }
    }
}
