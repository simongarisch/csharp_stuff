using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Dapper;
using CourseManager.Models;


namespace CourseManager.Repository
{
    class CourseCommand
    {
        private string _connectionString;

        public CourseCommand(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<CourseModel> GetList()
        {
            var courses = new List<CourseModel>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                courses = connection.Query<CourseModel>("Course_GetList").ToList();
            } 
                return courses;
        }
    }
}
