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
        modelBuilder.Entity<Country>().HasData(
        new Country
        {
            IdCountry = 1,
            Name = "Canada"
        },
        new Country
        {
            IdCountry = 2,
            Name = "Turkey"
        },
        new Country
        {
            IdCountry = 3,
            Name = "Poland"
        });
        modelBuilder.Entity<Trip>().HasData(
        new Trip
        {
            IdTrip = 1,
            Name = "Niagara Falls Excursion",
            DateFrom = new DateTime(2025, 5, 1),
            DateTo = new DateTime(2025, 5, 5),
            MaxPeople = 10,
            Description = "A quick little tour to Canada."
        }, 
        new Trip {
            IdTrip = 2,
            Name = "Harran Expedition",
            DateFrom = new DateTime(2015, 6, 23),
            DateTo = new DateTime(2015, 6, 27),
            MaxPeople = 5,
            Description = "A mission to retrieve a file capable to save humanity."
        },
        new Trip {
            IdTrip = 3,
            Name = "Zakopane Vacation",
            DateFrom = new DateTime(2015, 7, 10),
            DateTo = new DateTime(2015, 7, 24),
            MaxPeople = 8,
            Description = "A cozy vacation at breathtaking range of Carpathians mountains."
        });
        modelBuilder.Entity<ClientTrip>().HasData(
            new ClientTrip 
            { 
                IdClient = 1001, 
                IdTrip = 1, 
                RegisteredAt = new DateTime(2025, 4, 1), 
                PaymentDate = new DateTime(2025, 4, 15) 
            },
            new ClientTrip 
            { 
                IdClient = 1003, 
                IdTrip = 2, 
                RegisteredAt = new DateTime(2015, 3, 10) 
            },
            new ClientTrip 
            { 
                IdClient = 1004, 
                IdTrip = 2, 
                RegisteredAt = new DateTime(2015, 4, 20), 
                PaymentDate = new DateTime(2015, 4, 25) 
            }
        );
        modelBuilder.Entity<CountryTrip>().HasData(
            new CountryTrip 
            { 
                IdCountry = 1,
                IdTrip = 1
            },
            new CountryTrip 
            { 
                IdCountry = 2,
                IdTrip = 2 
            },
            new CountryTrip 
            { 
                IdCountry = 3,
                IdTrip = 3 
            }
        );
    }
}