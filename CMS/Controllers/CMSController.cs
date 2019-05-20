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
        public string ReverseString(string stringvalue)
        {
            //do reverse            
            char[] characters = stringvalue.ToCharArray();
            Array.Reverse(characters);
            string reversedstring = new string(characters);

            //save into db 
            
            //return value
            return reversedstring;
        }

        [HttpGet("[action]")]        
        public IEnumerable<Ticket> GetTickets()
        {
            return GetTicketDetails();           
        }
        [HttpPost("[action]")]
        public void InsertTicket([FromBody] Ticket ticket)
        {
            //System.IO.File.WriteAllText("C:\test.txt", ticket.Description);
            //, string status, string category, string createdby
            using (SqlConnection sqlconn = new SqlConnection(@"Data Source=INPF0Y6P5J\LOCALSQLSERVER;Initial Catalog=CMS;Integrated Security=True;"))
            {
                sqlconn.Open();

                string stmt = "INSERT INTO [dbo].[Tickets](Description,Status,Category,CreatedBy,CreatedDate) VALUES(@Description, @Status, @Category, @CreatedBy, @CreatedDate)";
                SqlCommand cmd = new SqlCommand(stmt, sqlconn);
                cmd.Parameters.Add("@Status", SqlDbType.VarChar);
                cmd.Parameters.Add("@Description", SqlDbType.VarChar, 100);
                cmd.Parameters.Add("@Category", SqlDbType.VarChar, 100);
                cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 100);
                cmd.Parameters.Add("@CreatedDate", SqlDbType.Date);

                cmd.Parameters["@Status"].Value = ticket.Status;
                cmd.Parameters["@Description"].Value = ticket.Description;
                cmd.Parameters["@Category"].Value = ticket.Category;
                cmd.Parameters["@CreatedBy"].Value = ticket.CreatedBy;
                cmd.Parameters["@CreatedDate"].Value = ticket.CreatedDate;
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