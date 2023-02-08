using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EPM.API.Models;

namespace EPM.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Client> clients { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Client>().HasData(new Client
            {
               ID = 1, ClientName = "AdaptIT_JHB",
                Location = "Gauteng",
                NumberOfUsers = 8,
                CreatedOn = DateTime.Now 
            });
            modelBuilder.Entity<Client>().HasData(new Client
            {
                ID = 2,
                ClientName = "AdaptIT_CA",
                Location = "Eastern Cape",
                NumberOfUsers = 1,
                CreatedOn = DateTime.Now
            });
            modelBuilder.Entity<Client>().HasData(new Client
            {
                ID = 3,
                ClientName = "AdaptIT_KZN",
                Location = "Durban",
                NumberOfUsers = 4,
                CreatedOn = DateTime.Now
            });
            modelBuilder.Entity<Client>().HasData(new Client
            {
                ID = 4,
                ClientName = "TG-Tech",
                Location = "Gauteng",
                NumberOfUsers = 9,
                CreatedOn = DateTime.Now
            });



            modelBuilder.Entity<Users>().HasData(
               new Users { ID = 1, Username = "Tshoki", Email = "Biologicaltk@gmail.com", Password = "Pass1", Role = "Admin" },
               new Users { ID = 2, Username = "Gao", Email = "gao@gmail.com", Password = "Pass2", Role = "Admin" },
               new Users { ID = 3, Username = "Titi", Email = "titik@yahoo.com", Password = "Pass3", Role = "User" }
         );
        }
    }
}
