using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Dapper;
using CustomerOrderViewer2.Models;


namespace CustomerOrderViewer2.Repository
{
    class CustomerCommand
    {
        private string _connectionString;

        public CustomerCommand(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<CustomerModel> GetList()
        {
            var items = new List<CustomerModel>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                items = connection.Query<CustomerModel>("Customer_GetList").ToList();
            }

            return items;
        }
    }
}
