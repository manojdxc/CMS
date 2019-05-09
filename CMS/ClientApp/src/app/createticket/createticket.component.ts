import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-createticket',
  templateUrl: './createticket.component.html'
})

export class CreateTicketComponent {  

  constructor(private http: HttpClient, @Inject('BASE_URL') private _baseUrl: string) {

  };

  insertTicket(newticket: Ticket) {
    console.log('inside Insert ticket');
    this.http.post<Ticket>(this._baseUrl + 'api/CMS/InsertTicket', newticket);
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
