using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EPM.API.Models
{
    public class Users
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        [NotMapped]
        public string Token { get; set; }
            //[Key]
            //public int ID { get; set; }
            //[Required]
            //public string Username { get; set; }
            //[Required]
            //[RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$", ErrorMessage = "Invalid Email Address.")]
            //public string Email { get; set; }
            //[Required]
            //public string Password { get; set; }
            //[Required]
            //public string Role { get; set; }
            //[NotMapped] // property exluded from db mapping
            //public string Token { get; set; }
        }
}
