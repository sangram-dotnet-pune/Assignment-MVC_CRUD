using Assignment_MVC_CURD.Models;

namespace Assignment_MVC_CURD.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Patch(int id, string name, decimal? price);
        void Delete(int id);
        bool Exists(int id);
    }
}
