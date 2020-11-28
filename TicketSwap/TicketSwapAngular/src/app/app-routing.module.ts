import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreateComponent } from './create/create.component';
import { LoginComponent } from './login/login.component';
import { TicketComponent } from './ticket/ticket.component';

const routes: Routes = [
  { path: 'add', component: CreateComponent },
  { path: 'tickets', component: TicketComponent },
  { path: 'login', component: LoginComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
