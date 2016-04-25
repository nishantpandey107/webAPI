using System.Collections.Generic;

namespace SportsStoreWebAPI.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(int productID);
        Product AddProduct(Product product);
        void RemoveProduct(int productID);
        bool UpdateProduct(Product product);
    }
}
