﻿using System;
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
                Console.WriteLine("ShowAll, Delete, Update, Insert, LeftJoin, InnerJoin, Quit");
                var userInput = Console.ReadLine().ToLower();

                if (userInput == "quit") 
                {
                    quit = true;
                }

                if (userInput == "leftjoin")
                {
                    foreach (var prod in repo.GetProductsAndReviews())
                    {
                        Console.WriteLine("Product Name:" + prod.Name + " Product ID: " + prod.ProductId + "Rating: " + prod.Rating);
                    }
                    Console.WriteLine();
                }

                if (userInput == "innerjoin")
                {
                    foreach (var prod in repo.GetProductsWithReviews())
                    {
                        Console.WriteLine("Product Name:" + prod.Name + " Product ID: " + prod.ProductId + "Rating: " + prod.Rating);
                    }
                    Console.WriteLine();
                }

                if (userInput == "showall")
                {
                    foreach (var prod in repo.GetProducts())
                    {
                        Console.WriteLine("Product Name:" + prod.Name + " Product ID: " + prod.ProductId);
                    }
                    Console.WriteLine();
                }

                if (userInput == "delete")
                {
                    Console.WriteLine("Enter Product ID to DELETE.");
                    var id = Convert.ToInt32(Console.ReadLine());
                    repo.DeleteProduct(id);

                    Console.WriteLine($"Deleted Product with ID {id}");
                }

                if (userInput == "insert")
                {
                    Console.WriteLine("Enter Product Name to insert.");
                    string prodNewName = Console.ReadLine();

                    product = new Product
                    {
                        Name = prodNewName
                    };
                    repo.InsertProduct(product);
                }
                if (userInput == "update")
                {
                    Console.WriteLine("Enter the Product ID for the name you would like to change");
                    var id = Convert.ToInt32(Console.ReadLine());

                    product = new Product { ProductId = id };

                    Console.WriteLine($"Change name to what?");

                    product.Name = Console.ReadLine();

                    repo.UpdateProduct(product);
                }
            }
        }
    }
}
