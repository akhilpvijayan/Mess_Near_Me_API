using MessNearMe.Models;
using System.Diagnostics.Metrics;
using static MessNearMe.Services.CountryService;

namespace MessNearMe.Services
{
    public interface ICountryService
    {
        Task<List<Country>> GetCountryAsync();
        Task<List<State>> GetStateAsync(long countryId);
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

        public async Task<List<State>> GetStateAsync(long countryId)
        {
            try
            {
                var states = await _supabase
                                    .From<State>()
                                    .Select("*")
                                    .Filter("country_id", Postgrest.Constants.Operator.Equals, (int)countryId)
                                    .Get();
                return states.Models;
            }
            catch(Exception ex)
            {
                throw new Exception();
            }
        }
        #endregion
    }
}
