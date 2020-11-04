import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MilesKmConverterComponent } from './miles-km-converter/miles-km-converter.component';
import { TodoManagerComponent } from './todo-manager/todo-manager.component';

@NgModule({
  declarations: [
    AppComponent,
    MilesKmConverterComponent,
    TodoManagerComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
