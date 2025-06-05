using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apbd_12.Models;

[Table("Client")]
public class Client
{
    [Key] public int IdClient { get; set; }
    [MaxLength(120)] public string FirstName { get; set; }
    [MaxLength(120)] public string LastName { get; set; }
    [MaxLength(120)] public string Email { get; set; }
    [MaxLength(120)] public string Telephone { get; set; }
    [MaxLength(120)] public string Pesel { get; set; }
    public ICollection<ClientTrip> ClientTrips { get; set; } = new List<ClientTrip>();
}