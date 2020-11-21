using System.Collections.Generic;
using System.Linq;
using DevBase.CenterArea.DataAccess;
using DevBase.DataAccess.ContextArea;
using DevBase.DataAccess.Notional;
using DevBase.Entities.Tangible;

namespace DevBase.DataAccess.Tangible
{
    public class EfProductLayer : EfDevBaseEntityRepository<Product, DevBaseContext>, IProductLayer
    {
        private readonly DevBaseContext _baseContext;

        public EfProductLayer(DevBaseContext baseContext)
        {
            _baseContext = baseContext;
        }

        public List<Product> ProductSearch(string searchedProduct)
        {
            return _baseContext.Products.Where(ps => ps.ProductName.Contains(searchedProduct)).ToList();
        }

        public List<Product> HightPriceProduct()
        {
            return _baseContext.Products.OrderByDescending(p => p.ProductPrice).ToList();
        }

        public List<Product> LowestPriceProduct()
        {
            return _baseContext.Products.OrderBy(p => p.ProductPrice).ToList();
        }

        public List<Product> ByAlphabet()
        {
            return _baseContext.Products.OrderBy(p => p.ProductName).ToList();
        }
    }
}