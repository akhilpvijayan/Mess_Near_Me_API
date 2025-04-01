using System.Diagnostics.Metrics;
using static MessNearMe.Services.CountryService;

namespace MessNearMe.Services
{
    public interface ICountryService
    {
        Task<List<Country>> GetCountryAsync();
    }
        public class CountryService: ICountryService
    {
        #region properties
        private readonly ILogger<CountryService> _logger;
        private readonly SupabaseDbContext _context;
        private readonly Supabase.Client _supabase;

        #endregion

        #region constructor
        public CountryService(ILogger<CountryService> logger, SupabaseDbContext context, Supabase.Client supabase)
        {
            this._logger = logger;
            this._context = context;
            _supabase = supabase;
        }
        #endregion
        #region public functions
        public async Task<List<Country>> GetCountryAsync()
        {
            var countries = await _supabase.From<Country>().Select("*").Get();
            return countries.Models;
        }
        #endregion
    }
}
