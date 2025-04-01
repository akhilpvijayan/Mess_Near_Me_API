using Postgrest.Attributes;
using Postgrest.Models;
using System.Text.Json.Serialization;

[Table("Country")]
public class Country : BaseModel
{
    [PrimaryKey("id", true)]
    [JsonIgnore]
    public long CountryId { get; set; }

    [Column("country_name")]
    public string CountryName { get; set; }

    [Column("country_currency")]
    public string CountryCurrency { get; set; }
}
