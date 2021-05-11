// csc config.cs && config && del config.exe
using System;
using System.Configuration;

/*
When you compile an application, its app.config is copied to the bin directory
with a name that matches your exe.
For example, if your exe was named "config.exe", there should be a "config.exe.config"
in your bin directory.
 */

class Program {
    public static void Main() {
        String title = ConfigurationManager.AppSettings["title"];  
        String language = ConfigurationManager.AppSettings["language"];  

        Console.WriteLine(string.Format("'{0}' project is created in '{1}' language ", title, language));
        // 'Configuration Example' project is created in 'CSharp' language 
    }
}
