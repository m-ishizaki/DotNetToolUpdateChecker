using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rksoftware.DotNetToolUpdateChecker.Services;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        // 登録
        services
            .AddSingleton<IProcessService, ProcessService>()
            .AddSingleton<IDotNetToolCommandService, DotNetToolCommandService>()
            .AddSingleton<IUpdateCheckService, UpdateCheckService>()
            .AddSingleton<IUpdateCheckConsoleService, UpdateCheckConsoleService>()
    )
    .Build();

host.Services.GetService<IUpdateCheckConsoleService>()!.CheckAndOutput();
