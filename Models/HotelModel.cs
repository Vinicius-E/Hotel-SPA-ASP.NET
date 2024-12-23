public class HotelModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public float Rating { get; set; }
    public string ImageUrl { get; set; }
    public List<string> DatesOfTravel { get; set; }
    public string BoardBasis { get; set; }
    public List<Room> Rooms { get; set; }
}