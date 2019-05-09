using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    [Route("api/[controller]")]
    public class CMSController : Controller
    {
        [HttpGet("[action]")]        
        public IEnumerable<Ticket> GetTickets()
        {
            return Enumerable.Range(1, 1).Select(index => new Ticket
            {
                Id="T000001",
                Description = "Laptop not working",
                Category ="Laptop",
                Status="Pending",
                CreatedBy="User01",
                CreatedDate = DateTime.Now,                     
            });
        }
        [HttpPost("[action]")]
        public void InsertTicket(Ticket ticket)
        {

        }
        
        public class Ticket
        {
            public string Id { get; set; }
            public string Description { get; set; }
            public string Status { get; set; }
            public string Category { get; set; }
            public DateTime CreatedDate { get; set; }            
            public string CreatedBy { get; set; }            
        }
    }
}