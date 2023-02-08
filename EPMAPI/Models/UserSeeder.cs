using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPM.API.Models
{
    public class UserSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().HasData(
                new Users { ID = 1, Username = "Tshoki", Email = "Biologicaltk@gmail.com", Password ="Pass1" , Role = "Admin"},                
                new Users { ID = 2, Username = "Gao", Email = "gao@gmail.com", Password = "Pass2", Role = "Admin" },
                new Users { ID = 3, Username = "Titi", Email = "titik@yahoo.com", Password = "Pass3", Role = "User" }
          );
        }
    }
}