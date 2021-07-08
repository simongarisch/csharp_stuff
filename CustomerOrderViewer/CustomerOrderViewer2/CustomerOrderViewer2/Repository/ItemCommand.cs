using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Dapper;
using CustomerOrderViewer2.Models;


namespace CustomerOrderViewer2.Repository
{
    class ItemCommand
    {
        private string _connectionString;

        public ItemCommand(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<ItemModel> GetList()
        {
            var items = new List<ItemModel>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                items = connection.Query<ItemModel>("Item_GetList").ToList();
            }

            return items;
        }
    }
}
