using System;
using System.Configuration;

namespace SqlIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=localhost;Database=adventureworksw;Uid=root;Pwd=password;"; //get connectionString format from connectionstrings.com and change to match your database
            var repo = new ProductRepository(connectionString);
            foreach (var prod in repo.GetProducts())
            {
                Console.WriteLine("Product Name:" + prod.Name);
            }


            Console.ReadLine();
        }


    }
}
