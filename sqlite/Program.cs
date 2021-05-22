// dotnet add package System.Data.SQLite.Core
using System;
using System.Data.SQLite;
using System.Collections.Generic;


interface IExample {
    void Run();
}

class CheckVersion : IExample {
    public void Run() {
        string cs = "Data Source=:memory:"; // connecting to an in memory database
        string sql = "SELECT SQLITE_VERSION()";

        using var con = new SQLiteConnection(cs);
        con.Open();

        using var cmd = new SQLiteCommand(sql, con);
        string version = cmd.ExecuteScalar().ToString();
        Console.WriteLine($"SQLite Version: {version}"); // SQLite Version: 3.32.1
        con.Close();
    }
}


class CreateTable : IExample {
    public void Run() {
        string cs = @"URI=file:test.db";
        var con = new SQLiteConnection(cs);
        con.Open();

        var cmd = new SQLiteCommand(con);
        cmd.CommandText = "DROP TABLE IF EXISTS cars";
        cmd.ExecuteNonQuery();

        string[] queries = new string[] {
            "CREATE TABLE cars(id INTEGER PRIMARY KEY, name TEXT, price INT)",
            "INSERT INTO cars(name, price) VALUES('Audi',52642)",
            "INSERT INTO cars(name, price) VALUES('Mercedes',57127)",
            "INSERT INTO cars(name, price) VALUES('Skoda',9000)",
            "INSERT INTO cars(name, price) VALUES('Volvo',29000)",
            "INSERT INTO cars(name, price) VALUES('Bentley',350000)",
            "INSERT INTO cars(name, price) VALUES('Citroen',21000)",
            "INSERT INTO cars(name, price) VALUES('Hummer',41400)",
            "INSERT INTO cars(name, price) VALUES('Volkswagen',21600)"
        };

        foreach(string query in queries) {
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
        }

        con.Close();
        Console.WriteLine("Table cars created");
    }
}


class PreparedStatements : IExample {
    public void Run() {
        string connectionString = @"URI=file:test.db";
        var connection = new SQLiteConnection(connectionString);
        connection.Open();

        var cmd = new SQLiteCommand(connection);
        cmd.CommandText = "INSERT INTO cars(name,price) VALUES(@name,@price)";
        cmd.Parameters.AddWithValue("@name", "BMW");
        cmd.Parameters.AddWithValue("@price", 36600);
        cmd.Prepare();

        cmd.ExecuteNonQuery();
        Console.WriteLine("row inserted");
        connection.Close();
    }
}


class DataReader : IExample {
    public void Run() {
        string connectionString = @"URI=file:test.db";
        var connection = new SQLiteConnection(connectionString);
        connection.Open();

        string sql = "SELECT * FROM cars LIMIT 5";
        var cmd = new SQLiteCommand(sql, connection);
        SQLiteDataReader reader = cmd.ExecuteReader();
        while (reader.Read()) {
            Console.WriteLine($"{reader.GetInt32(0)} {reader.GetString(1)} {reader.GetInt32(2)}");
        }
        /*
        1 Audi 52642    
        2 Mercedes 57127
        3 Skoda 9000    
        4 Volvo 29000   
        5 Bentley 350000
        */
        connection.Close();
    }
}


class ColumnHeaders : IExample {
    public void Run() {
        string connectionString = @"URI=file:test.db";
        var connection = new SQLiteConnection(connectionString);
        connection.Open();

        string sql = "SELECT * FROM cars LIMIT 5";
        var cmd = new SQLiteCommand(sql, connection);
        SQLiteDataReader reader = cmd.ExecuteReader();

        Console.WriteLine($"{reader.GetName(0), -3} {reader.GetName(1), -8} {reader.GetName(2), 8}");
        while (reader.Read()) {
            Console.WriteLine($@"{reader.GetInt32(0), -3} {reader.GetString(1), -8} {reader.GetInt32(2), 8}");
        }

        connection.Close();
    }
}

class Program {
    static void Main(string[] args) {
        List<IExample> examples = new List<IExample>();
        examples.Add(new CheckVersion());
        examples.Add(new CreateTable());
        examples.Add(new PreparedStatements());
        examples.Add(new DataReader());
        examples.Add(new ColumnHeaders());

        foreach(IExample example in examples) {
            example.Run();
        }
    }
}
