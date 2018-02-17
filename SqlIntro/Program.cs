using System;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace SqlIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["AdventureWorks"].ConnectionString;
            var connection = new MySqlConnection(connectionString);

            var repo = new ProductRepository(connection);

            
            
            var quit = false;
            //ProductRepository acctions = new ProductRepository();

            while(!quit)
            {
                Console.WriteLine("ShowAll, Delete, Update, Insert, Quit");
                var Userinput = Console.ReadLine().ToLower();

                if(Userinput == "quit")
                {
                    quit = true;
                }

                if (Userinput == "showall")
                {
                    foreach (var prod in repo.GetProducts())
                    {
                        Console.WriteLine("Product Name:" + prod.Name);
                    }
                    Console.WriteLine("");
                }

                if (Userinput == "delete")
                {
                    Console.WriteLine("Enter Product ID to DELETE.");
                    var id = Convert.ToInt32(Console.ReadLine());
                    
                    repo.DeleteProduct(id);

                    Console.WriteLine($"Deleted Product with ID {id}");
                }
            
                if (Userinput == "update")
                {
                    Console.WriteLine("Enter Product ID to UPDATE.");
                    var id = Convert.ToInt32(Console.ReadLine());
                    //acctions.DeleteProduct(id);
                }

                if (Userinput == "insert")
                {
                    Console.WriteLine("Enter Product ID to DELETE.");
                    var name = Console.ReadLine();
                   // acctions.UpdateProduct(name);
                }
           }
        }


    }
}
