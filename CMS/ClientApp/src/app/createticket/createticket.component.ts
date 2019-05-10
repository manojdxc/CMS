import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from "@angular/router";

@Component({
  selector: 'app-createticket',
  templateUrl: './createticket.component.html'
})

export class CreateTicketComponent {  
    
  Description: string="";
  Status: string = "";
  Category: string = "";
  CreatedBy: string = "Usr01";
  CreatedDate: Date = new Date();
  constructor(private http: HttpClient, @Inject('BASE_URL') private _baseUrl: string, private router: Router) {

  };
  
  saveticket() {       

    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');

    var body = {
      description: this.Description,
      status: this.Status,
      category: this.Category,
      createdby: this.CreatedBy,
      createddate: this.CreatedDate
    };
       
    this.http.post(this._baseUrl + 'api/CMS/InsertTicket', body)
      .subscribe(data => {
        console.log('inside subscribe');
      },
        err => {
          console.log('Error: ' + err.error);
      });
    this.router.navigate(['/ticket']);
  }
}
