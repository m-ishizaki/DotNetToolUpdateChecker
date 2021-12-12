using NUnit.Framework;
using Rksoftware.DotNetToolUpdateChecker.Services;

namespace DotNetToolUpdateCheckerCore.Test;

public class DotNetToolCommandServiceProcessServiceTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        IProcessService process = new ProcessService();
        IDotNetToolCommandService dotNetToolCommandService = new DotNetToolCommandService(process);
        var result = dotNetToolCommandService.List();

        Assert.Pass();
    }
}