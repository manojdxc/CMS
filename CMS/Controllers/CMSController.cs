using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
            return GetTicketDetails();
            //return Enumerable.Range(1, 1).Select(index => new Ticket
            //{
            //    Id="T000001",
            //    Description = "Laptop not working",
            //    Category ="Laptop",
            //    Status="Pending",
            //    CreatedBy="User01",
            //    CreatedDate = DateTime.Now,                     
            //});
        }
        //[HttpPost("[action]")]
        //public void InsertTicket(string id, string description)
        //{

        //    //, string status, string category, string createdby
        //}
        [HttpPost("[action]")]
        public void InsertTicket([FromBody] Ticket ticket)
        {
            System.IO.File.WriteAllText("C:\test.txt", ticket.Description);
            //, string status, string category, string createdby
            using (SqlConnection sqlconn = new SqlConnection(@"Data Source=INPF0Y6P5J\LOCALSQLSERVER;Initial Catalog=CMS;Integrated Security=True;"))
            {
                sqlconn.Open();

                string stmt = "INSERT INTO [dbo].[Tickets](Id, Description) VALUES(@ID, @Description)";
                SqlCommand cmd = new SqlCommand(stmt, sqlconn);
                cmd.Parameters.Add("@ID", SqlDbType.VarChar);
                cmd.Parameters.Add("@Description", SqlDbType.VarChar, 100);

                cmd.Parameters["@ID"].Value = ticket.Id;
                cmd.Parameters["@Description"].Value = ticket.Description;                                    
                cmd.ExecuteNonQuery();                
            }
        }
        private List<Ticket> GetTicketDetails()
        {
            List<Ticket> tickets = new List<Ticket>();
            using (SqlConnection sqlconn = new SqlConnection(@"Data Source=INPF0Y6P5J\LOCALSQLSERVER;Initial Catalog=CMS;Integrated Security=True;"))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select * from [dbo].[Tickets]", sqlconn);
                SqlDataReader reader =  cmd.ExecuteReader();
                while(reader.Read())
                {
                    tickets.Add(new Ticket {
                        Id = reader["Id"].ToString(),
                        Description = reader["Description"].ToString(),
                        Category = reader["Category"].ToString(),
                        Status = reader["Status"].ToString(),
                        CreatedBy = reader["CreatedBy"].ToString(),
                        CreatedDate = Convert.ToDateTime(reader["CreatedDate"])
                    });
                }
            }
            return tickets;
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