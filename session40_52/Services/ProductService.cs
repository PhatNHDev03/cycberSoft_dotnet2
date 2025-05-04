
using session40_50.Models.DTOs;
using session40_52.Interfaces;
using session40_52.Models;

namespace session40_52.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductResponseDTO>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();

            // convert từ entity sang DTO
            return products.Select(p => MapToProductResponseDTO(p));
        }

        public async Task<ProductResponseDTO> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            // convert từ entity sang DTO
            return MapToProductResponseDTO(product);
        }

        public async Task<ProductResponseDTO> CreateProductAsync(ProductRequestDTO productRequestDTO)
        {
            // tạo entity từ ProductRequestDTO
            var product = new Product
            {
                CategoryID = productRequestDTO.CategoryID,
                Name = productRequestDTO.Name,
                Description = productRequestDTO.Description,
                Price = productRequestDTO.Price,
                OriginalPrice = productRequestDTO.OriginalPrice,
                Discount = productRequestDTO.Discount,
                Stock = productRequestDTO.Stock,
                Sold = 0,
                Rating = 0,
                ReviewCount = 0
            };
            // gửi entity vào repository
            var createdProduct = await _productRepository.CreateProductAsync(product);

            // return DTO
            return MapToProductResponseDTO(createdProduct);
        }

        public async Task<ProductResponseDTO?> UpdateProductAsync(int id, ProductRequestDTO productRequestDTO)
        {
            // lưu ý: lớp mình có thể tạo UpdatedProductDTO
            var product = new Product
            {
                CategoryID = productRequestDTO.CategoryID,
                Name = productRequestDTO.Name,
                Description = productRequestDTO.Description,
                Price = productRequestDTO.Price,
                OriginalPrice = productRequestDTO.OriginalPrice,
                Discount = productRequestDTO.Discount,
                Stock = productRequestDTO.Stock
            };

            // gửi entity vào repository
            var updatedProduct = await _productRepository.UpdateProductAsync(id, product);

            // dùng toán tử ba ngôi để kiểm tra xem có phải là null hay không
            return updatedProduct != null ? MapToProductResponseDTO(updatedProduct) : null;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            return await _productRepository.DeleteProductAsync(id);
        }

        // define function MapToProductResponseDTO
        // input: Product entity
        // output: ProductResponseDTO
        private ProductResponseDTO MapToProductResponseDTO(Product product)
        {
            return new ProductResponseDTO
            {
                ProductID = product.ProductID,
                CategoryID = product.CategoryID,
                Name = product.Name,
                Price = product.Price,
                OriginalPrice = product.OriginalPrice,
                Discount = product.Discount,
                Stock = product.Stock,
                Sold = product.Sold,
                Rating = product.Rating,
                ReviewCount = product.ReviewCount
            };
        }

    }



}