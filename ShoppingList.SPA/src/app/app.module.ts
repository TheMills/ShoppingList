import { HttpModule } from '@angular/http';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';


import { AppComponent } from './app.component';
import { ListComponent } from './list/list.component';


@NgModule({
  declarations: [
    AppComponent,
    ListComponent
],
  imports: [
    BrowserModule,
    HttpModule // needed to fetch data from API
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
