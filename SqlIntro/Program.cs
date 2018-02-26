using System;
using System.Configuration;
using MySql.Data.MySqlClient;
using Dapper;

namespace SqlIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["AdventureWorks"].ConnectionString;
            var connection = new MySqlConnection(connectionString);

            var repo = new DapperProductRepository(connection);

            Product product = null;

            var quit = false;

            while (!quit)
            {
                Console.WriteLine("ShowAll, Delete, Update, Insert, Quit");
                var Userinput = Console.ReadLine().ToLower();

                if (Userinput == "quit") 
                {
                    quit = true;
                }

                if (Userinput == "showall")
                {
                    foreach (var prod in repo.GetProducts())
                    {
                        Console.WriteLine("Product Name:" + prod.Name + " Product ID: " + prod.ProductID);
                    }
                    Console.WriteLine();
                }

                if (Userinput == "delete")
                {
                    Console.WriteLine("Enter Product ID to DELETE.");
                    var id = Convert.ToInt32(Console.ReadLine());
                    repo.DeleteProduct(id);

                    Console.WriteLine($"Deleted Product with ID {id}");
                }

                if (Userinput == "insert")
                {
                    Console.WriteLine("Enter Product ID to insert.");
                    var prodNewId = Console.ReadLine();

                    Console.WriteLine("Enter Product Name to insert.");
                    string prodNewName = Console.ReadLine();

                    product = new Product
                    {
                        ProductID = Convert.ToInt32(Console.ReadLine()),
                        Name = prodNewName
                    };
                    repo.InsertProduct(product);
                }
                /*
                if (Userinput == "update")
                {
                    Console.WriteLine("Enter new name for product .");
                    product = Console.ReadLine();
                    repo.UpdateProduct(product);
                }
                */
            }
        }
    }
}
