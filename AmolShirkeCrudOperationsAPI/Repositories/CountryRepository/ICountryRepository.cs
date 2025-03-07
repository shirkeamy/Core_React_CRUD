using AmolShirkeCrudOperationsAPI.Models;

namespace AmolShirkeCrudOperationsAPI.Repositories.CountryRepository
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetAllCountriesAsync();

        Task<Country> GetCountryByIdAsync(int countryId);

        Task AddCountryAsync(Country country);

        Task DeleteCountryAsync(int countryId);

        Task UpdateCountryAsync(Country country);
    }
}
