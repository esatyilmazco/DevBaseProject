using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DevBase.Business.Notional;
using DevBase.DataAccess.ContextArea;
using DevBase.Entities.DTOs;
using DevBase.Entities.Tangible;
using Korzh.EasyQuery.Linq;
using Microsoft.AspNetCore.Mvc;

namespace DevBase.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public HomeController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public IActionResult Index(string searchedProduct = null)
        {
            if (!string.IsNullOrEmpty(searchedProduct))
            {
                var findProducts = _productService.ProductSearch(searchedProduct);
                return View(findProducts);
            }

            var products = _productService.ListOfProduct();
            return View(products);
        }


        public IActionResult InsertProduct(Product product)
        {
            var addedProduct = _mapper.Map<ProductDto>(product);
            return View(addedProduct);
        }

        [HttpPost]
        public IActionResult InsertProduct(ProductDto productDto)
        {
            _productService.AddedProduct(_mapper.Map<Product>(productDto));
            return RedirectToAction("Index");
        }

        public IActionResult ModifiedProduct(int productId)
        {
            var modifiedProduct = _mapper.Map<ProductDto>(_productService.GetByProductId(productId));
            return View(modifiedProduct);
        }

        [HttpPost]
        public IActionResult ModifiedProduct(ProductDto productDto)
        {
            _productService.UpdatedProduct(_mapper.Map<Product>(productDto));
            return RedirectToAction("Index");
        }

        public IActionResult RemoveProduct(int productId)
        {
            _productService.DeletedProduct(productId);
            return RedirectToAction("Index");
        }

        public IActionResult HightPriceProducts()
        {
            var sortHight = _productService.HightPriceProduct();
            return View(sortHight);
        }

        public IActionResult LowestPriceProducts()
        {
            var sortLowest = _productService.LowestPriceProduct();
            return View(sortLowest);
        }

        public IActionResult SortName()
        {
            var sortNames = _productService.ByAlphabet();
            return View(sortNames);
        }
    }
}