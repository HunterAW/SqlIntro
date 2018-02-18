using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SqlIntro
{
    public class ProductRepository
    {
        private readonly IDbConnection _conn;

        public ProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        /// <summary>
        /// Reads all the products from the products table
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetProducts()
        {
            using (var conn = _conn)
            {
                var cmd = conn.CreateCommand();
                conn.Open();
                cmd.CommandText = "SELECT Name, ProductID FROM product";

                var dr = cmd.ExecuteReader();
                var products = new List<Product>();

                while (dr.Read())
                {
                    products.Add(new Product { Name = dr["Name"].ToString() }); // TODO Can compress this into one line with yield
                }
                return products;
            }
        }
        /// <summary>
        /// Deletes a Product from the database
        /// </summary>
        /// <param name="id"></param>
        public void DeleteProduct(int id)
        {
            using (var conn = _conn)
            {
                var cmd = conn.CreateCommand();
                conn.Open();
                cmd.CommandText = "DELETE FROM Product WHERE productid = @id";
                cmd.AddParamWithValue("@id", id); // AddParamWithValue?
                cmd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Updates the Product in the database
        /// </summary>
        /// <param name="prod"></param>
        public void UpdateProduct(Product prod)
        {
            //This is annoying and unnecessarily tedious for large objects.
            //More on this in the future...  Nothing to do here..
            using (var conn = _conn)
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "update product set name = @name where id = @id";
                cmd.AddParamWithValue("@name", prod.Name);
                cmd.AddParamWithValue("@id", prod.Id);
                cmd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Inserts a new Product into the database
        /// </summary>
        /// <param name="prod"></param>
        public void InsertProduct(Product prod)
        {
            using (var conn = _conn)
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT into product (name) values(@name)";
                cmd.AddParamWithValue("@name", prod.Name);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
