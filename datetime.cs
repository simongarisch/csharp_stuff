// csc datetime.cs && datetime && del datetime.exe
// https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-5.0
using System;
using System.Globalization; // for CultureInfo

class Program {
    public static void Main() {
        DateTime dt = new DateTime();
        Console.WriteLine(dt); // 1/01/0001 12:00:00 AM

        //assigns default value 01/01/0001 00:00:00
        DateTime dt1 = new DateTime();
        Console.WriteLine(dt1); // 1/01/0001 12:00:00 AM

        //assigns year, month, day
        DateTime dt2 = new DateTime(2015, 12, 31); 
        Console.WriteLine(dt2); // 31/12/2015 12:00:00 AM

        //assigns year, month, day, hour, min, seconds
        DateTime dt3 = new DateTime(2015, 12, 31, 5, 10, 20);
        Console.WriteLine(dt3); // 31/12/2015 5:10:20 AM

        //assigns year, month, day, hour, min, seconds, UTC timezone
        DateTime dt4 = new DateTime(2015, 12, 31, 5, 10, 20, DateTimeKind.Utc);
        Console.WriteLine(dt4); // 31/12/2015 5:10:20 AM

        // static fields
        DateTime currentDateTime = DateTime.Now;  //returns current date and time
        DateTime todaysDate = DateTime.Today; // returns today's date
        DateTime currentDateTimeUTC = DateTime.UtcNow;// returns current UTC date and time

        DateTime maxDateTimeValue = DateTime.MaxValue; // returns max value of DateTime
        DateTime minDateTimeValue = DateTime.MinValue; // returns min value of DateTime

        Console.WriteLine(currentDateTime.Year);   // 2021
        Console.WriteLine(currentDateTime.Month);  // 5
        Console.WriteLine(currentDateTime.Day);    // 22
        Console.WriteLine(currentDateTime.Hour);   // 13
        Console.WriteLine(currentDateTime.Minute); // 3
        Console.WriteLine(currentDateTime.Second); // 45
        Console.WriteLine("===========");

        // TimeSpan is a struct that is used to represent time
        // in days, hour, minutes, seconds, and milliseconds.
        TimeSpan ts = new TimeSpan(1, 0, 0, 0); // one day
        DateTime nowPlusOne = currentDateTime.Add(ts);

        TimeSpan timeDiff = nowPlusOne.Subtract(currentDateTime);
        Console.WriteLine(timeDiff.Days);    // 1
        Console.WriteLine(timeDiff.Hours);   // 0 
        Console.WriteLine(timeDiff.Minutes); // 0
        Console.WriteLine(timeDiff.Seconds); // 0

        Console.WriteLine(currentDateTime.ToString("yyyy-MM-dd")); // 2021-05-22
        Console.WriteLine(currentDateTime.ToString("dd/MM/yyyy")); // 22/05/2021
        Console.WriteLine(currentDateTime.ToString("MM/dd/yyyy h:mm tt")); // 05/22/2021 1:26 PM
        Console.WriteLine("=====");

        // parsing date strings
        string[] dates = new string[] {"22/05/2021", "10/06/2020", "abc"};
        string dateFormat = "dd/MM/yyyy";
        foreach(string dateString in dates) {
            try {
                DateTime dateTime = DateTime.ParseExact(
                    dateString,
                    dateFormat,
                    CultureInfo.InvariantCulture
                );
                Console.WriteLine(dateTime);
            } catch (FormatException) {
                Console.WriteLine("Unable to parse '{0}'", dateString);
            }
        }
        /*
        22/05/2021 12:00:00 AM
        10/06/2020 12:00:00 AM
        Unable to parse 'abc'
        */
    }
}