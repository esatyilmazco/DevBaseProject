using System.Collections.Generic;
using DevBase.CenterArea.DataAccess;
using DevBase.Entities.Tangible;

namespace DevBase.DataAccess.Notional
{
    public interface IProductLayer : IDevBaseEntityRepository<Product>
    {
        List<Product> ProductSearch(string searchedProduct);
        List<Product> HightPriceProduct();
        List<Product> LowestPriceProduct();
        List<Product> ByAlphabet();
    }
}