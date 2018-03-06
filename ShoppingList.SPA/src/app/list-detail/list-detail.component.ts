import { Component, OnInit, Input } from '@angular/core';
import { Http } from '@angular/http';

@Component({
  selector: 'app-list-detail',
  templateUrl: './list-detail.component.html',
  styleUrls: ['./list-detail.component.css']
})
export class ListDetailComponent implements OnInit {
  @Input() list;
  listDetails: any;
  constructor(private http: Http) { }

  ngOnInit() {
    // this.getListDetails();
  }

  getListDetails() {
    this.http.get('http://localhost:5000/api/lists/' + this.list.id).subscribe(response => {
      console.log(response);
      this.listDetails = response.json();
    });
  }
}
