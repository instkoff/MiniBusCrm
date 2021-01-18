using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MiniBusCrm.DataAccess.Contracts.Entities;
using MiniBusCrm.DataAccess.Contracts.Settings;

namespace MiniBusCrm.DataAccess.Implementations
{
    public class DataContext : DbContext
    {
        //static LoggerFactory object
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        });

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        /// <summary>
        ///     Контекст БД
        /// </summary>
        public DbSet<BusEntity> Buses { get; set; }
        public DbSet<BusDriverEntity> BusDrivers { get; set; }
        public DbSet<PlaneEntity> Planes { get; set; }
        public DbSet<PassengerEntity> Passengers { get; set; }
        public DbSet<RouteEntity> Routes { get; set; }
        public DbSet<TicketEntity> Tickets { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasIndex(u => u.Username).IsUnique();
            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                CreateDate = DateTime.Now,
                Id = Guid.NewGuid(),
                Username = "admin",
                Password = "10.ioFD9w0SjwRA4DkHX0tHqg==.yLUtO8z+E0XrpTcC51+G8mfZm3dTR37dbtNYPGCt3e8=",
                IsActive = true,
                FirstName = "Admin",
                LastName = "Admin",
                Role = UserRoles.Admin
            }, new UserEntity
            {
                CreateDate = DateTime.Now,
                Id = Guid.NewGuid(),
                Username = "oper",
                Password = "10.CklkfSFyQ8TnMgaToPThNQ==.Qbg+8BgQz1odxkIgq0IDsxyTgkr/2OsYJhDtMIU6WyQ=",
                IsActive = true,
                FirstName = "Operator",
                LastName = "Operator",
                Role = UserRoles.Operator
            });
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}