# csharp_stuff

Starting with MS [tour of C#](https://docs.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/)

We can use [dotnet new](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new) to create a new project.
```
dotnet new --list
```

for example
```
cd console_example
dotnet new console
dotnet add package Newtonsoft.Json --version 13.0.1
dotnet run
```

You can see the stats on most downloaded nuget packages [here](https://www.nuget.org/stats/packages).

dotnet tool update - Updates the specified .NET tool on your machine.
