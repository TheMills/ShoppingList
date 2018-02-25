import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  lists: any;

  constructor(private http: Http) { }

  ngOnInit() {
    this.getLists();
  }

  getLists() {
    this.http.get('http://localhost:5000/api/lists').subscribe(response => {
      console.log(response);
      this.lists = response.json();
    });
  }
}
