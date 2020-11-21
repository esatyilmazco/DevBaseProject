using System.Collections.Generic;
using System.Linq;
using DevBase.Business.Notional;
using DevBase.DataAccess.Notional;
using DevBase.Entities.Tangible;

namespace DevBase.Business.Tangible
{
    public class ProductManager : IProductService
    {
        private readonly IProductLayer _productLayer;

        public ProductManager(IProductLayer productLayer)
        {
            _productLayer = productLayer;
        }

        public List<Product> ListOfProduct()
        {
            return _productLayer.GetAll().OrderByDescending(p => p.ProductId).ToList();
        }

        public Product GetByProductId(int productId)
        {
            return _productLayer.Get(p => p.ProductId == productId);
        }

        public void AddedProduct(Product product)
        {
            _productLayer.Add(product);
        }

        public void UpdatedProduct(Product product)
        {
            _productLayer.Update(product);
        }

        public void DeletedProduct(int productId)
        {
            _productLayer.Delete(new Product {ProductId = productId});
        }

        public List<Product> ProductSearch(string searchedProduct)
        {
            return _productLayer.ProductSearch(searchedProduct);
        }

        public List<Product> HightPriceProduct()
        {
            return _productLayer.HightPriceProduct();
        }

        public List<Product> LowestPriceProduct()
        {
            return _productLayer.LowestPriceProduct();
        }

        public List<Product> ByAlphabet()
        {
            return _productLayer.ByAlphabet();
        }
    }
}