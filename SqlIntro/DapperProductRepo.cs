using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;

namespace SqlIntro
{
    public class DapperProductRepo : IProductRepository
    {
        private readonly string _connectionString;

        public DapperProductRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Product> GetProducts()
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                return conn.Query<Product>("SELECT ProductId as Id, Name FROM product");
            }
        }

        public void DeleteProduct(int id)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                conn.Execute("DELETE FROM product WHERE ProductID = @id", new { id });
            }
        }

        public void InsertProduct(Product prod)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                conn.Execute("INSERT INTO product (name) VALUES(@name)", new { prod.Name });
            }
        }

        public void UpdateProduct(Product prod)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                conn.Execute("UPDATE product SET name = @name WHERE ProductID = @id", new { prod.Name, prod.Id });
            }
        }

        public IEnumerable<Product> GetProductsWithReview()
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                const string str = "SELECT p.ProductID, p.Name, pr.Comments FROM product as p INNER JOIN productreview as pr ON p.ProductID = pr.ProductID; ";
                return conn.Query<Product>(str);
            }
        }

        public IEnumerable<Product> GetProductsAndReviews()
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                const string str = "SELECT p.ProductID, p.Name, pr.Comments FROMproduct as p LEFT JOIN productreview as pr ON p.ProductID = pr.ProductID; ";
                return conn.Query<Product>(str);
            }
        }
    }
}