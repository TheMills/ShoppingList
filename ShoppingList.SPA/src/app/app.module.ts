import { HttpModule } from '@angular/http';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';


import { AppComponent } from './app.component';
import { ListComponent } from './list/list.component';
import { ListDetailComponent } from './list-detail/list-detail.component';


@NgModule({
  declarations: [
    AppComponent,
    ListComponent,
    ListDetailComponent
],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule // needed to fetch data from API
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
