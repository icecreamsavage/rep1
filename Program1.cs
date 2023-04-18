using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

class Program
{
    static void Main()
    {
        string connectionString = "Data Source=(local);Initial Catalog=StudentsDB;Integrated Security=True";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT * FROM Students";

            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            var studentsList = new List<Student>();

            while (reader.Read())
            {
                Student student = new Student
                {
                    Id = (int)reader["Id"],
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Grade = (int)reader["Grade"]
                };

                studentsList.Add(student);
            }

            reader.Close();

            var filteredStudents = studentsList.Where(student => student.Grade >= 90);

            
            Console.WriteLine("Отфильтрованные студенты:");

            foreach (var student in filteredStudents)
            {
                Console.WriteLine("{0} {1} - {2}", student.FirstName, student.LastName, student.Grade);
            }
        }

        Console.ReadLine();
    }
}

class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Grade { get; set; }
}
