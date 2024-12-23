using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

[Route("api/[controller]")]
[ApiController]
public class HotelsController : ControllerBase
{
    private readonly string _filePath = @"C:\Users\Vinicius_Silva\AspNetApp\Assets\seeds\hotels.json";


    [HttpGet]
    public ActionResult<List<HotelModel>> GetHotels()
    {
        var hotels = LoadHotels();
        return Ok(hotels);
    }

    [HttpGet("{id}")]
    public ActionResult<HotelModel> GetHotel(int id)
    {
        var hotels = LoadHotels();
        var hotel = hotels.FirstOrDefault(h => h.Id == id);

        if (hotel == null)
        {
            return NotFound(new { Message = "Hotel not found" });
        }

        return Ok(hotel);
    }

    private List<HotelModel> LoadHotels()
    {
        if (!System.IO.File.Exists(_filePath))
        {
            Debug.WriteLine("TESTE: " + _filePath);
            throw new FileNotFoundException($"Data source not found at {_filePath}.");
        }
        var jsonData = System.IO.File.ReadAllText(_filePath);
        Debug.WriteLine("JSON: " + jsonData);
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        return JsonSerializer.Deserialize<List<HotelModel>>(jsonData, options);
    }
}