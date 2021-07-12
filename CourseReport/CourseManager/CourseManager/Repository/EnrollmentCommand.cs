using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using CourseManager.Models;

namespace CourseManager.Repository
{
    class EnrollmentCommand
    {
        private string _connectionString;

        public EnrollmentCommand(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<EnrollmentModel> GetList()
        {
            var enrollments = new List<EnrollmentModel>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                enrollments = connection.Query<EnrollmentModel>("Enrollments_GetList").ToList();
            }

            foreach(var enrollment in enrollments)
            {
                enrollment.IsCommitted = true;
            }
            return enrollments;
        }

        public void Upsert(EnrollmentModel enrollmentModel)
        {
            var userId = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString();

            var table = new DataTable();
            table.Columns.Add("EnrollmentId", typeof(int));
            table.Columns.Add("StudentId", typeof(int));
            table.Columns.Add("CourseId", typeof(int));
            table.Rows.Add(enrollmentModel.EnrollmentId, enrollmentModel.StudentId, enrollmentModel.CourseId);

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Execute("Enrollments_Upsert", new { @EnrollmentType = table.AsTableValuedParameter("EnrollmentType"), @UserId = userId }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
