using System.Collections.Generic;

namespace SqlIntro
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProductsWithReview();
        IEnumerable<Product> GetProductsAndReviews();
        void DeleteProduct(int id);
        void UpdateProduct(Product prod);
        void InsertProduct(Product prod);
    }
}