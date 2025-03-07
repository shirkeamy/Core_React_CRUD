using AmolShirkeCrudOperationsAPI.Context;
using AmolShirkeCrudOperationsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace AmolShirkeCrudOperationsAPI.Repositories.CountryRepository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public CountryRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        async Task<IEnumerable<Country>> ICountryRepository.GetAllCountriesAsync()
        {
            return await _applicationDbContext.Countries.ToListAsync();
        }

        async Task<Country> ICountryRepository.GetCountryByIdAsync(int countryId)
        {
            return await _applicationDbContext.Countries.FindAsync(countryId);
        }

        async Task ICountryRepository.AddCountryAsync(Country country)
        {
            await _applicationDbContext.Countries.AddAsync(country);
            await _applicationDbContext.SaveChangesAsync();
        }

        async Task ICountryRepository.UpdateCountryAsync(Country country)
        {
            _applicationDbContext.Countries.Update(country);
            await _applicationDbContext.SaveChangesAsync();
        }

        async Task ICountryRepository.DeleteCountryAsync(int countryId)
        {
            var country = _applicationDbContext.Countries.FindAsync(countryId);
            if (country == null)
            {
                _applicationDbContext.Remove(country);
                await _applicationDbContext.SaveChangesAsync();
            }
        }
    }
}
