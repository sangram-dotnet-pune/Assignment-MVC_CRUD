using Microsoft.AspNetCore.Mvc;
using Assignment_MVC_CURD.Models;
using Assignment_MVC_CURD.Repository;

namespace Assignment_MVC_CURD.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
           
            return View();
        }

        public IActionResult DisplayAllProducts()
        {
            return View(_productRepository.GetAll());
        }

        public IActionResult DisplayProductById(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
                return NotFound();
            return View(product);
        }

        [HttpGet]
        public IActionResult AddNewProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepository.Add(product);
                return RedirectToAction("DisplayAllProducts");
            }
            return View(product);
        }
        [HttpGet]
        public IActionResult UpdateProductPrice(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
                return NotFound();
            return View(product);
        }

        [HttpPost]
        public IActionResult UpdateProductPrice(Product updatedProduct)
        {
            var product = _productRepository.GetById(updatedProduct.Id);
            if (product != null)
            {
                product.Price = updatedProduct.Price;
                return RedirectToAction("DisplayAllProducts");
            }
            return NotFound();
        }

      

        public IActionResult DeleteProduct(int id)
        {
            _productRepository.Delete(id);
            return RedirectToAction("DisplayAllProducts");
        }
    }
}
