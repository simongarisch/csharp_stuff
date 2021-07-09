using System;
using System.Data;
using System.Collections.Generic;
using CourseReportEmailer.Models;
using CourseReportEmailer.Repository;
using CourseReportEmailer.Workers;
using Newtonsoft.Json;

namespace CourseReportEmailer
{
    class Program
    {
        static void Main(string[] args)
        {
            // converting objects to json
            var model = new EnrollmentDetailReportModel() {
                EnrollmentId = 1,
                FirstName = "Mark",
                LastName = "Hue",
                CourseCode = "CA",
                Description = "Some description"
            };

            var json = JsonConvert.SerializeObject(model);
            Console.WriteLine(json);

            var objectFromJson = (EnrollmentDetailReportModel)JsonConvert.DeserializeObject(json, typeof(EnrollmentDetailReportModel));
            Console.WriteLine(objectFromJson);
            Console.WriteLine("------------");

            // working with DataTable
            var table = new DataTable();
            var columns = new List<DataColumn>()
            {
                new DataColumn("EnrollmentId", typeof(int)),
                new DataColumn("FirstName", typeof(string)),
                new DataColumn("LastName", typeof(string)),
                new DataColumn("CourseCode", typeof(string)),
                new DataColumn("Description", typeof(string))
            };
            foreach(var column in columns)
            {
                table.Columns.Add(column);
            }

            table.Rows.Add(1, "Mark", "Hue", "CA", "Some description");
            foreach(DataRow row in table.Rows)
            {
                foreach(DataColumn column in table.Columns)
                {
                    Console.Write(row[column] + ", "); 
                }
            }
            Console.WriteLine("------------");
            
            try
            {
                // back to the core application... get our data
                string connectionString = @"Data Source=localhost,1433;Initial Catalog=CourseReport;User ID=sa;Password=MyBigPassword1!";
                var command = new EnrollmentDetailReportCommand(connectionString);
                var models = command.GetList();

                // create the excel workbook
                string reportFileName = "EnrollmentDetailsReport.xlsx";
                var workbookCreator = new EnrollmentDetailReportSpreadsheetCreator();
                workbookCreator.Create(reportFileName, models);

                // and send it via email
                var emailer = new EnrollmentDetailReportEmailSender();
                emailer.Send(reportFileName);
                // Console.ReadKey();
            }
            
            catch (Exception ex)
            {
                Console.WriteLine("Reporting error: " + ex.Message);
            }
        }
    }
}
