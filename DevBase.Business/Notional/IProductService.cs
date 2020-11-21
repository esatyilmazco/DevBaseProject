using System.Collections.Generic;
using DevBase.Entities.Tangible;

namespace DevBase.Business.Notional
{
    public interface IProductService
    {
        List<Product> ListOfProduct();
        Product GetByProductId(int productId);
        void AddedProduct(Product product);
        void UpdatedProduct(Product product);
        void DeletedProduct(int productId);
        List<Product> ProductSearch(string searchedProduct);
        List<Product> HightPriceProduct();
        List<Product> LowestPriceProduct();
        List<Product> ByAlphabet();


    }
}