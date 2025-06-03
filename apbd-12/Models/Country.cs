using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apbd_12.Models;

[Table("Country")]
public class Country
{
    [Key] public int IdCountry { get; set; }
    [MaxLength(120)] public string Name { get; set; }
}