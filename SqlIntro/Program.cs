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
            foreach (var prod in repo.GetProducts())
            {
                Console.WriteLine("Product Name:" + prod.Name);
            }

            Console.ReadLine();

            /*
            var quit = false;
            //ProductRepository acctions = new ProductRepository();

            while(!quit)
            {
                Console.WriteLine("SELECTALL, DELETE, UPDATE, INSERT, quit");
                var Userinput = Console.ReadLine().ToLower();
                if(Userinput == "quit")
                {
                    quit = true;
                }

                if (Userinput == "selectall")
                {

                }

                if (Userinput == "delete")
                {
                    Console.WriteLine("Enter Product ID to DELETE.");
                    var id = Convert.ToInt32(Console.ReadLine());
                    
                    ProductRepository.DeleteProduct(id);
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
           */
        }


    }
}
