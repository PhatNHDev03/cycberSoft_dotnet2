// {
//                 "Name": "Cosy Room in Marais",
//                 "ImageUrl": "images/1.webp",
//                 "Link": "https://www.airbnb.com/rooms/30728079",
//                 "Rating": 4,
//                 "Description": "One spacious room in a modern apartment in the center of Paris, near Georges Pompidou Center."
//             }

public class HotelModel
{
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Link { get; set; }
    public int Rating { get; set; }
    public string Description { get; set; }

}

// define class để chứa dữ liệu từ file json
// key: tên quốc gia
// value: danh sách các khách sạn
public class HotelsData
{
    public Dictionary<string, List<HotelModel>> HotelsByCity { get; set; }
}