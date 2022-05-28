using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace Controllers;

public class CitiesController : BaseController
{
    private readonly ILogger<CitiesController> _logger;
    private readonly CitiesQueries _cities;

    public CitiesController(
        ILogger<CitiesController> logger,
        CitiesQueries cities)
    {
        _logger = logger;
        _cities = cities;
    }

    [HttpGet]
    public async Task<IActionResult> GetCities()
    {
        var result = await _cities.GetCitiesList();
        _logger.LogInformation("Returning cities");
        return Ok(result);
    }
}