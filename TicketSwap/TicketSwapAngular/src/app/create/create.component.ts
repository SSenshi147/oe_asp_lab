import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Ticket } from '../ticket';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

  private _http: HttpClient;
  private _token: string | null;
  private _router: Router;

  constructor(http: HttpClient, router: Router) {
    this._http = http;
    this._token = sessionStorage.getItem('token');
    this._router = router;
    if (this._token == null || this._token.length <= 3) {
      this._router.navigate(['/login']);
    }
  }

  sell(eventname: HTMLInputElement, eventdate: HTMLInputElement, eventprice: HTMLInputElement) {
    const newTicket = new Ticket();
    newTicket.eventName = eventname.value;
    newTicket.eventDate = eventdate.value;
    newTicket.eventPrice = parseInt(eventprice.value, 10);
    if (this._token == null || this._token.length <= 3) {
      this._router.navigate(['/login']);
    }
    else {
      const headers = {
        'Content-Type': 'application/json',
        Authorization: 'Bearer ' + this._token
      };
      this._http.post('https://localhost:44398/api/ticket', newTicket, { headers }).subscribe(response => {
      }, error => {
        console.log(error);
      });
      this._router.navigate(['/tickets']);
    }
  }

  ngOnInit(): void {
  }

}
