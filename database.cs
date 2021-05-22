// csc database.cs && database && del database.exe
// To get connection string: https://stackoverflow.com/a/56635680/11944914
using System;
using System.Data.SqlClient;


class Program {
    private static string connectionString = "Data Source=MyServer;Initial Catalog=MyDB;Integrated Security=True";

    public static void Main() {
        SqlConnection connection = new SqlConnection(connectionString);
        
        connection.Open();
        Console.WriteLine("Connection success!");
        
        string sql = @"
            SELECT OBJECT_SCHEMA_NAME(o.object_id) schema_name, o.name
            FROM sys.objects as o
            WHERE o.type = 'V';
        ";

        SqlCommand command = new SqlCommand(sql, connection);
        SqlDataReader dataReader = command.ExecuteReader();
        while (dataReader.Read()) {
            for(int i=0; i<dataReader.FieldCount; i++) {
                var rowName = dataReader.GetName(i);
                var rowValue = dataReader.GetString(i);
                Console.Write(rowName + ": " + rowValue + ", ");
            }
            Console.WriteLine();
        }
        connection.Close();
    }
}
