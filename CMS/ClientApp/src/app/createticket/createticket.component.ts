import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-createticket',
  templateUrl: './createticket.component.html'
})

export class CreateTicketComponent {  

  ticket: Ticket = { id: '3', description: 'issue with hardware', status: 'pending', category: 'hardware', createdBy: 'usr01', createdDate: Date.now };
  ID: string="";
  Description: string="";
  Status: string="";
  constructor(private http: HttpClient, @Inject('BASE_URL') private _baseUrl: string) {

  };
  
  saveticket() {
    
    console.log('save ticket method');
    console.log(this.ID);

    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');

    var body = {
      id: this.ID,
      description: this.Description
    };

    //var result = JSON.stringify(this.ticket);

    console.log(this._baseUrl);
    console.log(body);
    this.http.post(this._baseUrl + 'api/CMS/InsertTicket', this.ticket, { headers });
    
    //let postData = new FormData();
    //postData.append('id', this.ID);
    //postData.append('description', this.Description);

    //console.log(postData);

    //this.http.post(this._baseUrl + 'api/CMS/InsertTicket', postData)
    //  .subscribe(data => {
    //    console.log('inside subscribe');
    //  },
    //    err => {
    //      console.log('Error: ' + err.error);
    //    });
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
