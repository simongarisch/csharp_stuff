// https://jakubwajs.wordpress.com/2019/11/28/logging-with-log4net-in-net-core-3-0-console-app/
// https://www.scalyr.com/blog/get-started-quickly-csharp-logging/
// you'll see the log fine in bin/debug/netcoreapp3.1
using System;
using System.IO;
using System.Reflection;
using log4net;
using log4net.Config;


class Program {
    private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

    public static void Main(string[] args) {
        var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
        XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

        var displayMessage = "Hello, user!";

        log.Info(displayMessage);
        Console.WriteLine(displayMessage);
    }
}
