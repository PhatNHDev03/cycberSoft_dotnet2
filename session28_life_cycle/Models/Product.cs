// {
//       "sizes": [
//         32,
//         33,
//         34,
//         35
//       ],
//       "id": 1,
//       "name": "vans black",
//       "alias": "vans-black-black",
//       "price": 200,
//       "description": "about this shoe:Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. ",
//       "size": "[32,33,34,35]",
//       "shortDescription": "about this shoe:Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
//       "quantity": 100,
//       "deleted": false,
//       "categories": "[{\"id\": \"VANS_CONVERSE\",\"category\"😕"VANS_CONVERSE\"}]",
//       "relatedProducts": "[2,3,1]",
//       "feature": true,
//       "image": "https://apistore.cybersoft.edu.vn/images/vans-black-black.png",
//       "imgLink": "https://apistore.cybersoft.edu.vn/images/vans-black-black.png"
//     }

using System.Text.Json;
using System.Text.Json.Serialization;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Alias { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string ShortDescription { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public bool Deleted { get; set; }

    public bool Feature { get; set; }

    public string Image { get; set; } = string.Empty;

    public string ImgLink { get; set; } = string.Empty;
    //size
    public List<int> Sizes { get; set; } = new List<int>();
    //chuyen doi categories tu json string sang list category
    [JsonIgnore]
    public List<Category> Categories { get; set; } = new List<Category>();
    //xử lý dữ liệu từ api --. parse json
    [JsonPropertyName("categories")]
    public string CategoryJson
    {
        set => Categories = JsonSerializer.Deserialize<List<Category>>(value);
    }

    [JsonIgnore]
    public List<int> RelatedProducts { get; set; } = new List<int>();

    [JsonPropertyName("relatedProducts")]
    public string RelatedProductsJson
    {
        set
        {
            RelatedProducts = JsonSerializer.Deserialize<List<int>>(value);
        }
    }


}
public class Category
{
    public string Id { get; set; }
    public string CategoryName { get; set; }

    //mapping key 'category tu json sang categoryName'
    [JsonPropertyName("category")]
    public string CategoryJson { set => CategoryName = value; }
}