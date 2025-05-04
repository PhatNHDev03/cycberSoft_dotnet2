using session40_50.Models.DTOs;


namespace session40_52.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseDTO>> GetAllProductsAsync();
        Task<ProductResponseDTO> GetProductByIdAsync(int id);

        Task<ProductResponseDTO> CreateProductAsync(ProductRequestDTO productRequestDTO);

        Task<ProductResponseDTO?> UpdateProductAsync(int id, ProductRequestDTO productRequestDTO);

        Task<bool> DeleteProductAsync(int id);
    }
}