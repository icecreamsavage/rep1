using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
class Program
{
    static void Main()
    {
        string connectionString = "Data Source=(local);Initial Catalog=EmployeesDB;Integrated Security=True";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT * FROM Employees";

            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            var employeesList = new List<Employee>();

            while (reader.Read())
            {
                Employee employee = new Employee
                {
                    Id = (int)reader["Id"],
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Salary = (int)reader["Salary"],
                    YearsOfExperience = (int)reader["YearsOfExperience"]
                };

                employeesList.Add(employee);
            }

            reader.Close();

            var sortedEmployees = employeesList.OrderBy(employee => employee.Salary);

            Console.WriteLine("Отсортированные сотрудники по зарплатам:");

            foreach (var employee in sortedEmployees)
            {
                Console.WriteLine("{0} {1} - {2} руб.", employee.FirstName, employee.LastName, employee.Salary);
            }
        }

        Console.ReadLine();
    }
}

class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Salary { get; set; }
    public int YearsOfExperience { get; set; }
}
