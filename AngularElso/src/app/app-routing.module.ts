import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MilesKmConverterComponent } from './miles-km-converter/miles-km-converter.component';
import { TodoManagerComponent } from './todo-manager/todo-manager.component';

const routes: Routes = [
  {path: 'miles', component: MilesKmConverterComponent},
  {path: 'todo', component:TodoManagerComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
