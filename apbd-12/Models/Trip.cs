using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apbd_12.Models;

[Table("Trip")]
public class Trip
{
    [Key] public int IdTrip { get; set; }
    [MaxLength(120)] public string Name { get; set; }
    [MaxLength(120)] public string Description { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public int MaxPeople { get; set; }
}