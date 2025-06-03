using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace apbd_12.Models;

[PrimaryKey(nameof(IdClient), nameof(IdTrip))]
[Table("Client_Trip")]
public class ClientTrip
{
    [ForeignKey(nameof(Client))]public int IdClient { get; set; }
    [ForeignKey(nameof(Trip))] public int IdTrip { get; set; }
    public DateTime RegisteredAt { get; set; }
    public DateTime? PaymentDate { get; set; }
    public Client Client { get; set; }
    public Trip Trip { get; set; }
}