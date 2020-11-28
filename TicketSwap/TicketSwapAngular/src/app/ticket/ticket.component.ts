import { HttpClient, ɵangular_packages_common_http_http_a } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
// import { Signalr } from '../signalr';
import { Ticket } from '../ticket';
import * as SignalR from '@microsoft/signalr';

@Component({
  selector: 'app-ticket',
  templateUrl: './ticket.component.html',
  styleUrls: ['./ticket.component.css']
})
export class TicketComponent implements OnInit {
  public _tickets: Array<Ticket>;
  private _router: Router;
  private _token: string | null;
  private _http: HttpClient;
  private _signalr!: SignalR.HubConnection;

  constructor(router: Router, http: HttpClient) {
    this._router = router;
    this._token = sessionStorage.getItem('token');
    this._tickets = new Array<Ticket>();
    this._http = http;
    if (this._token == null || this._token.length <= 3) {
      this._router.navigate(['/login']);
    }
    else {
      this._signalr = new SignalR.HubConnectionBuilder().withUrl('https://localhost:44398/api/ticketHub').build();
      this._signalr.on("TicketUpdate", () => this.getTickets());
      this._signalr.start();
      this.getTickets();
    }
  }

  getTickets() {
    if (this._token == null || this._token.length <= 3) {
      this._router.navigate(['/login']);
    }
    else {
      const headers = {
        'Content-Type': 'application/json',
        Authorization: 'Bearer ' + this._token
      };
      this._http.get<Ticket[]>('https://localhost:44398/api/ticket', { headers }).subscribe(response => {
        this._tickets = response;
        console.log(this._tickets);
      });
    }
  }


  ngOnInit(): void {
  }

}
