﻿using System.Collections.Generic;
using System.Data;
using Dapper;

namespace SqlIntro
{
    class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _conn;

        public DapperProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Product> GetProducts()
        {
            using (var conn = _conn)
            {
                conn.Open();
                return conn.Query<Product>("SELECT Name, ProductID FROM product");
            }
        }

        public void DeleteProduct(int id)
        {
            using (var conn = _conn)
            {
                conn.Open();
                conn.Execute("DELETE FROM Product WHERE ProductId = @id", new { id });
            }
        }

        public void UpdateProduct(Product prod)
        {
            using (var conn = _conn)
            {
                conn.Open();
                conn.Execute("update product set name = @name where id = @id", new
                {
                    id = prod.ProductID,
                    name = prod.Name
                });

            }
        }

        public void InsertProduct(Product prod)
        {
            using (var conn = _conn)
            {
                conn.Open();
                conn.Execute("INSERT INTO Product (Name) values(@name)", new
                {
                    name = prod.Name
                });
            }
        }
    }
}
