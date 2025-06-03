using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace apbd_12.Models;

[PrimaryKey(nameof(IdTrip), nameof(IdCountry))]
[Table("Country_Trip")]
public class CountryTrip
{
    [ForeignKey(nameof(Country))]public int IdCountry { get; set; }
    [ForeignKey(nameof(Trip))] public int IdTrip { get; set; }
    public Country Country { get; set; }
    public Trip Trip { get; set; }
}