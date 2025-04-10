using Microsoft.EntityFrameworkCore;
using ProductManager.Model;
using ProductManager.Model.Entity;
using ProductManager.Repository.Interface;

namespace ProductManager.Repository
{
    public class ProductRepository : IProductRepository
    {

        #region DataBaseConection
        private readonly ProductManagerDBContext _context;
        #endregion

        public ProductRepository(ProductManagerDBContext context)
        {
            _context = context;
        }

        public Product AddProduct(Product product)
        {
            _context.Product.Add(product);
            _context.SaveChanges();
            return product;
        }

        public void DeleteProduct(int id)
        {
            var product = _context.Product.FirstOrDefault(e => e.Id == id);
            if (product != null)
            {
                _context.Product.Remove(product);
                _context.SaveChanges();
            }
        }

        public List<Product> GetAllProducts()
        {
            return _context.Product.FromSqlRaw("Get_All_Products").ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Product.FirstOrDefault(e => e.Id == id);
        }

        public Product UpdateProduct(Product product)
        {
            _context.Product.Update(product);
            _context.SaveChanges();
            return product;
        }
    }
}
