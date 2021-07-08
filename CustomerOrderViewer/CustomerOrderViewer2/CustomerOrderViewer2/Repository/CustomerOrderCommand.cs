﻿using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using Dapper;
using CustomerOrderViewer2.Models;


namespace CustomerOrderViewer2.Repository
{
    class CustomerOrderCommand
    {
        private string _connectionString;

        public CustomerOrderCommand(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<CustomerOrderDetailModel> GetList()
        {
            var items = new List<CustomerOrderDetailModel>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                items = connection.Query<CustomerOrderDetailModel>("CustomerOrderDetail_GetList").ToList();
            }

            return items;
        }

        public void Delete(int customerOrderId, string userId)
        {
            string upsertStatement = "CustomerOrderDetail_Delete";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Execute(upsertStatement, new { @CustomerOrderId = customerOrderId, @UserId = userId }, commandType: CommandType.StoredProcedure);
            }
        }

        public void Upsert(int customerOrderId, int customerId, int itemId, string userId)
        {
            string upsertStatement = "CustomerOrderDetail_Upsert";

            var dataTable = new DataTable();
            dataTable.Columns.Add("CustomerOrderId", typeof(int));
            dataTable.Columns.Add("CustomerId", typeof(int));
            dataTable.Columns.Add("ItemId", typeof(int));
            dataTable.Rows.Add(customerOrderId, customerId, itemId);

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Execute(upsertStatement, new { @CustomerOrderType = dataTable.AsTableValuedParameter("CustomerOrderType"), @UserId = userId }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
