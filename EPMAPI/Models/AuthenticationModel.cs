using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPM.API.Models
{
    public class AuthenticationModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        //[Required]
        //public string Username { get; set; }
        //[Required]
        //public string Email { get; set; }

        //[Required]
        //public string Password { get; set; }
        //[Required]
        //public string Role { get; set; }
    }
}
