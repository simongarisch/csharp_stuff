// csc database.cs && database && del database.exe
// To get connection string: https://stackoverflow.com/a/56635680/11944914
using System;
using System.Data; // for DataTable class
using System.Data.SqlClient;
using System.Collections.Generic;


interface IExample {
    void Run();
}


class MyQuery {
    public const string ConnectionString = "Data Source=MyServer;Initial Catalog=MyDB;Integrated Security=True";
    public const string Sql = @"
            SELECT OBJECT_SCHEMA_NAME(o.object_id) schema_name, o.name
            FROM sys.objects as o
            WHERE o.type = 'V';";
}


class BasicExample : IExample {
    public void Run() {
        SqlConnection connection = new SqlConnection(MyQuery.ConnectionString);
        string sql = MyQuery.Sql;

        connection.Open();
        Console.WriteLine("Connection success!");

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

        // we can also get the table details
        Console.WriteLine("==========");
        DataTable dt = dataReader.GetSchemaTable();
        foreach(DataRow row in dt.Rows) {
            Console.Write("ColumnName: " + row.Field<string>("ColumnName") + ", ");
            Console.Write("NET Type: " + row.Field<string>("DataTypeName") + ", ");
            Console.Write("Size: " + row.Field<int>("ColumnSize") + ", ");
            Console.WriteLine();
        }
        connection.Close();
    }
}


class ToDataTable : IExample {
    public void Run() {
        SqlConnection conn = new SqlConnection(MyQuery.ConnectionString);
        string sql = MyQuery.Sql;

        SqlCommand cmd = new SqlCommand(sql, conn);
        conn.Open();

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dataTable = new DataTable();
        da.Fill(dataTable);

        conn.Close();

        foreach(DataRow dr in dataTable.Rows) {
            foreach(var item in dr.ItemArray) {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        da.Dispose();
    }
}


class Program {
    public static void Main() {
        List<IExample> examples = new List<IExample>();
        examples.Add(new BasicExample());
        examples.Add(new ToDataTable());

        foreach(IExample example in examples) {
            Console.WriteLine(example.GetType().Name);
            example.Run();
            Console.WriteLine("==========");
        }
    }
}
