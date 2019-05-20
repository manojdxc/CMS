import { Component, Inject, OnInit, DebugElement } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Component({
  selector:'app-ticket',
  templateUrl: './ticket.component.html'
})

export class TicketComponent implements OnInit{
  public tickets: Ticket[];
  public revstr: any;
  public stringvalue: any;
  
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
        
  };
  ngOnInit() {
    this.http.get<Ticket[]>(this.baseUrl + 'api/CMS/GetTickets').subscribe(result => {
      this.tickets = result;
    }, error => console.error(error));

  }

  submitClick() {

    //var body = {stringvalue:this.str };
    console.log(this.stringvalue);

    this.http.get<any>(this.baseUrl + 'api/CMS/ReverseString', {
      params: {
        stringvalue: this.stringvalue
      },
      responseType: 'text' as 'json'
    }).subscribe(result => {
      debugger;
      this.revstr = result;
    }, error => console.error(error));

    //this.http.post(this.baseUrl + 'api/CMS/ReverseString', this.stringvalue)
    //  .subscribe(data => {
    //    //this.revstr = data;
    //    console.log('inside subscribe');
    //  },
    //  err => {
    //    debugger;
    //      console.log('Error: ' + err.error);
    //  })      
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
