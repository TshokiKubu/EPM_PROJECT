using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPM.WEB.Models
{
    public class Client
    {
       
        public int ID { get; set; }
        [Required(ErrorMessage = "Client Name is required")]
        public string ClientName { get; set; }
        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }
        [Required(ErrorMessage = "No of Users is required")]
        [Range(1, 10)]
        public int NumberOfUsers { get; set; }
        [Required(ErrorMessage = "Created Date is required")]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
