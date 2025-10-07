using Assignment_MVC_CURD.Models;

namespace Assignment_MVC_CURD.Repository
{
    public class ProductRepository : IProductRepository
    {
        private static List<Product> _products = new List<Product>
        {
           new Product { Id = 1, Name = "Potato", Price = 40 },
    new Product { Id = 2, Name = "Tomato", Price = 50 },
    new Product { Id = 3, Name = "Onion", Price = 60 },
    new Product { Id = 4, Name = "Cabbage", Price = 30 },
    new Product { Id = 6, Name = "Corn", Price = 35 },
    new Product { Id = 7, Name = "Carrot", Price = 70 },
        };

        public IEnumerable<Product> GetAll() => _products;

        public Product GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

        public void Add(Product product)
        {
            product.Id = _products.Max(p => p.Id) + 1;
            _products.Add(product);
        }

        public void Update(Product product)
        {
            var existing = GetById(product.Id);
            if (existing != null)
            {
                existing.Name = product.Name;
                existing.Price = product.Price;
            }
        }

        public void Patch(int id, string name, decimal? price)
        {
            var existing = GetById(id);
            if (existing != null)
            {
                if (!string.IsNullOrEmpty(name))
                    existing.Name = name;
                if (price.HasValue)
                    existing.Price = price.Value;
            }
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            if (product != null)
                _products.Remove(product);
        }

        public bool Exists(int id) => _products.Any(p => p.Id == id);
    }
}
