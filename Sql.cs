using System;
// dotnet add package Microsoft.Data.Sqlite
using Microsoft.Data.Sqlite;

namespace alpha
{
  public static class Sql
  {
    public static void Query()
    {
      using var connection = new SqliteConnection("Data Source=./data/university.db");
      connection.Open();
      var command = connection.CreateCommand();
      command.CommandText =
      @"
        SELECT *
        FROM students
      ";
      using var reader = command.ExecuteReader();
      while (reader.Read())
      {
        var id = reader.GetInt32(0);
        var name = reader.GetString(1);
        var age = reader.GetInt32(2);

        Console.WriteLine($"Row: {id} - {name} - {age}");
      }
    }
    public static void Insert()
    {
      using var connection = new SqliteConnection("Data Source=./data/university.db");
      connection.Open();
      var command = connection.CreateCommand();
      command.CommandText =
      @"
        INSERT INTO students(name, age)
        VALUES ($name, $age)
      ";
      command.Parameters.AddWithValue("$name", "Alice");
      command.Parameters.AddWithValue("$age", "19");
      using var reader = command.ExecuteReader();
      Console.WriteLine($"Has Rows: {reader.HasRows}");
    }
  }
}
