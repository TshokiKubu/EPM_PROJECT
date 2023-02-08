using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace EPM.API.Models
{
    public class Client
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string ClientName { get; set; }        
        [Required]
        public string Location { get; set; }
        [Required]
        [Range(1, 10)]
        public int NumberOfUsers { get; set; }        
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
