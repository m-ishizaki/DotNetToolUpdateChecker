using NUnit.Framework;
using Rksoftware.DotNetToolUpdateChecker.Services;

namespace DotNetToolUpdateCheckerCore.Test;

public class ProcessServiceTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        IProcessService process = new ProcessService();

        var result = process.Start("dotnet tool list -g");

        Assert.Pass();
    }
}