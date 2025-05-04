
using Microsoft.EntityFrameworkCore;
using session40_52.Data;
using session40_52.Interfaces;
using session40_52.Models;

namespace session40_52.Repsitory
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        /*************  ✨ Windsurf Command ⭐  *************/
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        /// <param name="context">The database context used to access the products.</param>

        /*******  6a9d6701-dd22-4404-9d21-041978ac91af  *******/
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            // EF Core sẽ tự động chuyển sang SQL và connect tới database
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            // tạo data cho CreatedAt và UpdatedAt
            product.CreatedAt = DateTime.UtcNow;
            product.UpdatedAt = DateTime.UtcNow;

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateProductAsync(int id, Product product)
        {
            // lấy product từ database
            var existingProduct = await _context.Products.FindAsync(id);

            // kiểm tra nếu ko có thì trả về null
            if (existingProduct == null)
            {
                return null;
            }

            // nếu có thì update và return product Entity
            existingProduct.CategoryID = product.CategoryID;
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.UpdatedAt = DateTime.UtcNow;
            existingProduct.Description = product.Description;
            existingProduct.Discount = product.Discount;
            existingProduct.Stock = product.Stock;
            existingProduct.OriginalPrice = product.OriginalPrice;

            await _context.SaveChangesAsync();
            return existingProduct;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            // lấy product từ database
            var existingProduct = await _context.Products.FindAsync(id);
            if (existingProduct == null)
            {
                return false;
            }

            // nếu có thì xóa và return true
            _context.Products.Remove(existingProduct);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

