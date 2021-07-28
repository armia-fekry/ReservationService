using Microsoft.EntityFrameworkCore;
using Reservation.Models;
using Reservation.Models.DTOs;
using Reservation.Models.Models;

namespace Reservation.DataAccess
{
    public class ReservationContext:DbContext
    {

        public ReservationContext(DbContextOptions<ReservationContext> options
            ):base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<ReservationModel> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var HMACSHA = new System.Security.Cryptography.HMACSHA512();
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Email = "Armia@fekry.com",
                    PasswordSalt = HMACSHA.Key,
                    PasswordHash= HMACSHA.ComputeHash(System.Text.Encoding.UTF8.GetBytes("123456")),
                    UserID=1

                }
                ) ;
            modelBuilder.Entity<Trip>().HasData(
            new Trip()
            {
                
                TripId=1,
                CityName = "cairo",
                Content = "test",
                CreationDate = System.DateTime.UtcNow,
                ImageUrl = "test",
                Name = "cairo trip",
                Price = 23.4
            },
                new Trip()
                {
                    TripId = 2,

                    CityName = "Alex",
                    Content = "test",
                    CreationDate = System.DateTime.UtcNow.AddDays(30),
                    ImageUrl = "test",
                    Name = "alex trip",
                    Price = 233.4
                }, new Trip()
                {
                    TripId = 3,
                    CityName = "misr",
                    Content = "test",
                    CreationDate = System.DateTime.UtcNow.AddDays(15),
                    ImageUrl = "test",
                    Name = "misr trip",
                    Price = 900
                }
                );
            modelBuilder.Entity<ReservationModel>().HasData(
                new ReservationModel()
                {
                    CustomerName = "cust one",
                    CreationDate = System.DateTime.UtcNow,
                    Notes = "this is notes ",
                    ReservationDate = System.DateTime.UtcNow.AddDays(3),
                    ReservedBy=1,
                    TripId=2,
                    ResevationId=1
                },
                new ReservationModel()
                {
                    CustomerName = "cust two",
                    CreationDate = System.DateTime.UtcNow,
                    Notes = "this is notes two ",
                    ReservationDate = System.DateTime.UtcNow.AddDays(3),
                    ReservedBy = 1,
                    TripId = 2,
                    ResevationId=2
                }

                ) ;
            
        }
    }
}
