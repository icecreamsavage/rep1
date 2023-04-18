using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Data Source=(local);Initial Catalog=ProductsDB;Integrated Security=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT * FROM Products";

            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            var productsList = new List<Product>();

            while (reader.Read())
            {
                Product product = new Product
                {
                    Id = (int)reader["Id"],
                    Name = (string)reader["Name"],
                    Category = (string)reader["Category"],
                    Price = (decimal)reader["Price"]
                };

                productsList.Add(product);
            }

            reader.Close();

            var groupedProducts = productsList.GroupBy(product => product.Category);

            foreach (var group in groupedProducts)
            {
                Console.WriteLine("Категория: {0}", group.Key);

                foreach (var product in group)
                {
                    Console.WriteLine("\t{0} - {1}", product.Name, product.Price);
                }
            }
        }

        Console.ReadLine();
    }
}

class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
}
