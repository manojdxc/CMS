import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Component({
  selector:'app-ticket',
  templateUrl: './ticket.component.html'
})

export class TicketComponent implements OnInit{
  public tickets: Ticket[];
  
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
        
  };
  ngOnInit() {
    this.http.get<Ticket[]>(this.baseUrl + 'api/CMS/GetTickets').subscribe(result => {
      this.tickets = result;
    }, error => console.error(error));
  }
  
}

interface Ticket { 
  id: string;
  description: string;
  status: string;
  category: string;
  createdDate: Date;  
  createdBy: string
}
