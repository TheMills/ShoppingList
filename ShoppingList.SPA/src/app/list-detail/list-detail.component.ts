import { Component, OnInit, Input } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';
import { Item } from '../item';
import { List } from '../list';

@Component({
  selector: 'app-list-detail',
  templateUrl: './list-detail.component.html',
  styleUrls: ['./list-detail.component.css']
})
export class ListDetailComponent implements OnInit {
  @Input() list: List;
  listDetails: any;
  apiUrl = 'http://localhost:5000/api/';
  items: any;

  constructor(private http: Http) { }

  ngOnInit() {
    // this.getListDetails();
    if (this.list) {
      this.items = this.list.listItems;
     }
  }

  private requestOptions() {
    const headers = new Headers({'Content-type': 'application/json'});
    return new RequestOptions({headers: headers});
}

  // getListDetails() {
  //   this.http.get('http://localhost:5000/api/lists/' + this.list.id).subscribe(response => {
  //     console.log(response);
  //     this.listDetails = response.json();
  //   });
  // }

  ItemAdd(newItemName: string) {
    this.http.post(this.apiUrl + 'lists/' + this.list.id, JSON.stringify(newItemName), this.requestOptions()).subscribe(resp => {
      this.list.listItems.push(resp.json() as Item);
      if (this.list.listItems != null) {
        this.list.listItems.push(resp.json() as Item);
      } else {
        this.list.listItems[0] = resp.json() as Item;
      }

//      console.log(JSON.stringify(newItemName));
//      const item: Item = resp.json() as Item;
//      this.list.listItems.push(item);
//      console.log(item);
      }, error => {
      console.log(error);
    });
  }

  ItemDelete(listId: number, item: Item) {
    this.http.delete(this.apiUrl + 'lists/' + listId + '/' + item.id, this.requestOptions()).subscribe(resp => {
      this.list.listItems.splice(this.list.listItems.indexOf(item, 0), 1);
    });
  }

  ItemUpdate(listId: number, item: Item) {

  }
}
