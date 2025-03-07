using AmolShirkeCrudOperationsAPI.Models;
using AmolShirkeCrudOperationsAPI.Repositories.CountryRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmolShirkeCrudOperationsAPI.Controllers
{
    [Route("api/country")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetAllCountriesAsync()
        {
            var countries = await _countryRepository.GetAllCountriesAsync();

            if (countries == null)
            {
                return NotFound("There is no students in database yet!");
            }
            return Ok(countries);
        }

        [HttpGet("{countryId}")]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountryByIdAsync(int countryId)
        {
            var countries = await _countryRepository.GetCountryByIdAsync(countryId);

            if (countries == null)
            {
                return NotFound("There is no students in database yet!");
            }
            return Ok(countries);
        }

        [HttpPost]
        public async Task<ActionResult> AddCountryAsync(Country country)
        {
            await _countryRepository.AddCountryAsync(country);

            return Ok();
        }

        [HttpPost("{countryId}")]
        public async Task<ActionResult> UpdateCountryAsync(Country country)
        {
            await _countryRepository.UpdateCountryAsync(country);

            return Ok();
        }

        [HttpDelete("{countryId}")]
        public async Task<ActionResult> DeleteCountryAsync(int countryId)
        {
            await _countryRepository.DeleteCountryAsync(countryId);

            return Ok();
        }

    }
}
