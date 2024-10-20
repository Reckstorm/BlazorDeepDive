﻿using Microsoft.EntityFrameworkCore;
using ServerManagement.Models;

namespace ServerManagement.Persistence
{
    public class ServerManagementContext : DbContext
    {
        public ServerManagementContext(DbContextOptions<ServerManagementContext> options): base(options) { }

        public DbSet<Server> Servers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Server>().HasData(
                new Server { Id = 1, Name = "Server1", City = "Calgary" },
                new Server { Id = 2, Name = "Server2", City = "Halifax" },
                new Server { Id = 3, Name = "Server3", City = "Toronto" },
                new Server { Id = 4, Name = "Server4", City = "Ottawa" },
                new Server { Id = 5, Name = "Server5", City = "Montreal" },
                new Server { Id = 6, Name = "Server6", City = "Calgary" },
                new Server { Id = 7, Name = "Server7", City = "Calgary" },
                new Server { Id = 8, Name = "Server8", City = "Halifax" },
                new Server { Id = 9, Name = "Server9", City = "Halifax" },
                new Server { Id = 10, Name = "Server10", City = "Toronto" },
                new Server { Id = 11, Name = "Server11", City = "Toronto" },
                new Server { Id = 12, Name = "Server12", City = "Ottawa" },
                new Server { Id = 13, Name = "Server13", City = "Ottawa" },
                new Server { Id = 14, Name = "Server14", City = "Montreal" },
                new Server { Id = 15, Name = "Server15", City = "Montreal" }
             );
        }
    }
}
