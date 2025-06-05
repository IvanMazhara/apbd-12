using apbd_12.Models;
using Microsoft.EntityFrameworkCore;

namespace apbd_12.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Trip> Trips { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<ClientTrip> ClientTrips { get; set; }
    public DbSet<CountryTrip> CountryTrips { get; set; }

    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>().ToTable("Client");
        modelBuilder.Entity<Country>().ToTable("Country");
        modelBuilder.Entity<Trip>().ToTable("Trip");
        modelBuilder.Entity<ClientTrip>().ToTable("ClientTrip");
        modelBuilder.Entity<CountryTrip>().ToTable("CountryTrip");

        modelBuilder.Entity<Client>().HasData(
            new Client
            {
                IdClient = 1001,
                FirstName = "John",
                LastName = "Doe",
                Email = "john@doe.com",
                Telephone = "0888888888",
                Pesel = "1265E789AD"
            },
            new Client
            {
                IdClient = 1002,
                FirstName = "Mary",
                LastName = "Jane",
                Email = "maryjane@yahoo.com",
                Telephone = "0715931422",
                Pesel = "TR3434PO10"
            },
            new Client
            {
                IdClient = 1003,
                FirstName = "Jade",
                LastName = "Aldemir",
                Email = "jade79@gmail.com",
                Telephone = "0553412210",
                Pesel = "EM7LP82112"
            },
            new Client
            {
                IdClient = 1004,
                FirstName = "Kyle",
                LastName = "Crane",
                Email = "kcrane@yahoo.com",
                Telephone = "0567002120",
                Pesel = "10APOL300F"
            }
        );
    }
}