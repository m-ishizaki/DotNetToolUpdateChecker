# DotNetToolUpdateChecker


This tool checks the installed dotnettool for updates.  

# Install

```
> dotnet tool update -g rksoftware.dotnettoolupdatecheckerconsole
```

# Usage

```
> dotnettoolupdatecheck
```

# Result


The console displays a list of currently installed dotnet tools.  
The currently installed version and the latest version are displayed as items in the list. If there is a difference here, there is an update.

```
Package ID                                      Current         Latest          Command
------------------------------------------------------------
redth.net.maui.check                            0.10.0          0.10.0          maui-check
rksoftware.dotnettoolupdatecheckerconsole       0.1.3           0.1.3           DotNetToolUpdateCheck
```


