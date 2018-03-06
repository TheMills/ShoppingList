import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { List } from '../list';
import { Item } from '../item';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  selectedList;
  lists: List[];

  constructor(private http: Http) { }

  ngOnInit() {
    this.getLists();
  }

  getLists() {
    // this.http.get('http://localhost:5000/api/lists').subscribe(response => {
    //   console.log(response);
    //   this.lists = response.json();
    // });
    this.http.get('http://localhost:5000/api/lists').subscribe(response => {
      console.log(response);
      this.lists = response.json() as List[];
//      console.log(this.lists);
      });

    // this.parseData(this.lists);

    // if (this.lists.length > 0) {
    //   for (let i = 0; i < this.lists.length; i++) {
    //     this.list = this.lists[i];
    //     this.retrievedLists.push(new List(
    //       this.list.id,
    //       this.list.name,
    //       this.list.timeCreated,
    //       this.list.timeModified
    //     ));

    //     console.log(this.retrievedLists[i]);
    //   }
    // }

  }

  // parseData(jsonData: string) {
  //   // considering you get your data in json arrays
  //   for (let i = 0; i < jsonData[1].length; i++) {
  //         console.log(jsonData[i]);
  //        const data = new List(jsonData[1][i], jsonData[2][i], jsonData[3][i], jsonData[4][i]);
  //        this.retrievedLists.push(data);
  //   }
  // }

  onSelect(list): void {
    // this.selectedList = list;
    if (this.lists != null) {
    }

    const foundList = this.lists.find(i => i.id === list.id);
    if (foundList.listItems == null) {
      foundList.listItems = this.getListItems(foundList.id);
    }
    this.selectedList = foundList;
  }

  getListItems(id: number): Item[] {
    let list: List;
    this.http.get('http://localhost:5000/api/lists/' + id).subscribe(resp => {
      list = resp.json() as List;
     // console.log(resp.json() as List);
    });
    console.log(list.name + list.listItems);
    return list.listItems;
  }
}
