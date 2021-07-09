using System;
using System.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;
using Dapper;
using CourseReportEmailer.Models;

namespace CourseReportEmailer.Repository
{
    class EnrollmentDetailReportCommand
    {
        private string _connectionString;

        public EnrollmentDetailReportCommand(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<EnrollmentDetailReportModel> GetList()
        {
            var enrollments = new List<EnrollmentDetailReportModel>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                enrollments = connection.Query<EnrollmentDetailReportModel>("EnrollmentReport_GetList").ToList();
            }

            return enrollments;
        }
    }
}
