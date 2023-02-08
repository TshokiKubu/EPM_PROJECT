using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EPM.API.Models.Dtos
{
    public class ClientDto
    {
       
        public int ID { get; set; }        
        public string ClientName { get; set; }        
        public string Location { get; set; }       
        public int NumberOfUsers { get; set; }       
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
