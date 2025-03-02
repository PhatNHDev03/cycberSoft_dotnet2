using System.Text.Json;

public class ProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // define function call API get list product
    public async Task<List<Product>> GetProductsAsync()
    {
        try
        {
            var response = await _httpClient.GetStringAsync("Product");
            Console.WriteLine("API Response: " + response);

            var jsonDoc = JsonDocument.Parse(response);

            // xử lý dữ liệu
            // nếu API trả về objecy có chứa field là "content"
            if (jsonDoc.RootElement.TryGetProperty("content", out JsonElement contentElement))
            {
                // PropertyNameCaseInsensitive: không phân biệt hoa thường
                // VD:
                // DATA: {"name": "Nguyễn Văn A"}
                // public class Persion {
                // public string Name {get; set;} => không cần viết đúng property name
                // }

                // Deserialize: convert JSON sang List<Product>

                // GetRawText: trả về chuỗi JSON gốc từ API trả về
                return JsonSerializer.Deserialize<List<Product>>(contentElement.GetRawText(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            else
            {
                return new List<Product>();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new List<Product>();
        }
    }
}