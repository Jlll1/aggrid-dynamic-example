using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace Controllers;

public class CitiesController : BaseController
{
    private readonly CitiesQueries _cities;

    public CitiesController(CitiesQueries cities)
    {
        _cities = cities;
    }

    [HttpGet]
    public async Task<IActionResult> GetCities()
    {
        var result = await _cities.GetCitiesList();

        return Ok(result);
    }
}