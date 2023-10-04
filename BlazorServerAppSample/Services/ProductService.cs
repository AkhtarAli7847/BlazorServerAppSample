using BlazorServerAppSample.Data;
using BlazorServerAppSample.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerAppSample.Services
{
    public class ProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;

        }
        public List<ProductModel> GetProducts()
        {
            return _context.tblProduct.ToList();
        }
        public ProductModel GetProduct(int prodId)
        {
            return _context.tblProduct.FirstOrDefault(p=>p.Id==prodId);
        }

        public void AddProducts(ProductModel prod)
        {
            _context.tblProduct.Add(prod);
            _context.SaveChanges();
        }

        public void UpdateProduct(ProductModel updatedProd)
        {
            var existingTask = _context.tblProduct.FirstOrDefault(p => p.Id == updatedProd.Id);
            if (existingTask != null)
            {
                existingTask.ProdName = updatedProd.ProdName;
                existingTask.ProdPrice = updatedProd.ProdPrice;
                _context.SaveChanges();
            }
        }

        public void DeleteProduct(int prodId)
        {
            var prodToDelete =_context.tblProduct.FirstOrDefault(p => p.Id == prodId);
            if (prodToDelete != null)
            {
               _context.tblProduct.Remove(prodToDelete);
                _context.SaveChanges();
            }
        }

    }
}
