﻿using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MiniBusCrm.DataAccess.Entities;

namespace MiniBusCrm.DataAccess.Implementations
{
    public class DataContext : DbContext
    {
        //static LoggerFactory object
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        });
        /// <summary>
        /// Контекст БД
        /// </summary>
        public DbSet<BusEntity> Buses { get; set; }
        public DbSet<DriverEntity> Drivers { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<PassangerEntity> Passangers { get; set; }
        public DbSet<RouteEntity> Routes { get; set; }
        public DbSet<TicketEntity> Tickets { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

    }
}

