import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Component({
  selector:'app-ticket',
  templateUrl: './ticket.component.html'
})

export class TicketComponent {
  public tickets: Ticket[];
  
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    
    http.get<Ticket[]>(baseUrl + 'api/CMS/GetTickets').subscribe(result => {
      this.tickets = result;      
    }, error => console.error(error));
  };
  
}

interface Ticket { 
  id: string;
  description: string;
  status: string;
  category: string;
  createdDate: Date;
  updatedDate: Date
  createdBy: string,
  updatedBy: string,  
}
