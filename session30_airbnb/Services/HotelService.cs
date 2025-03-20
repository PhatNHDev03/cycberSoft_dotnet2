using System.Net.Http.Json;

public class HotelService
{
    private readonly HttpClient _httpClient;
    public HotelService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    //call API
    // call API lấy dữ liệu từ file json (giả lập)
    public async Task<List<HotelModel>> GetHotelByCityAsync(string city)
    {
        // đọc dữ liệu từ file json
        // file hotels.json phải để ở folder wwwroot
        var response = await _httpClient.GetFromJsonAsync<HotelsData>("/hotels.json");

        return response?.HotelsByCity.ContainsKey(city) == true
                                    ? response.HotelsByCity[city] : new List<HotelModel>();
    }
}