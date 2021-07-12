using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using CourseManager.Models;

namespace CourseManager.Repository
{
    class StudentCommand
    {
        private string _connectionString;

        public StudentCommand(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<StudentModel> GetList()
        {
            var students = new List<StudentModel>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                students = connection.Query<StudentModel>("Student_GetList").ToList();
            }
            return students;
        }
    }
}
