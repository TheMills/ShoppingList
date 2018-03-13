import { Component, OnInit, } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';
import { List } from '../list';
import { Item } from '../item';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  apiUrl = 'http://localhost:5000/api/';
  lists: List[];
  selectedList;

  // newList: List;

  constructor(private http: Http) { }

  ngOnInit() {
    this.getSimpleListsFromAPI();

//    this.getLists();
  }

  getSimpleListsFromAPI() {
    this.http.get(this.apiUrl + 'lists').subscribe(response => {
      this.lists = response.json() as List[];
    });
  }

  onSelect(list): void {
    // const foundList = this.lists.find(i => i.id === list.id); // No need to search for the list, when it has been selected from list
    if (list.listItems === null) {
      this.fillListItems(list);
    }
    this.selectedList = list;
  }

  fillListItems(selList: List): void {
    let list: List;
    const res = this.http.get(this.apiUrl + 'lists/' + selList.id).subscribe(resp => {
      list = resp.json() as List;
      selList.listItems = list.listItems;
    });
  }

  ListUpdate(list): void {
    list.name = list.name + '-o-';
    const headers = new Headers();
    headers.append('Content-Type', 'application/json');

  //  this.http.put(this.apiUrl + 'lists/' + list.id, JSON.stringify(list), {headers: headers}).subscribe(res => res.json());
    this.http.put(this.apiUrl + 'lists/' + list.id, JSON.stringify(list), {headers: headers}).subscribe(resp => {
      console.log(JSON.stringify(list));
    });
  }

  ListDelete(list): void {
    const headers = new Headers();
    headers.append('Content-Type', 'application/json');
    this.http.delete(this.apiUrl + 'lists/' + list.id, this.requestOptions()).subscribe(resp => {
      this.lists.splice(this.lists.indexOf(list, 0), 1);
    });
  }

  ListAdd(newListName: string) {
    // console.log(newListName);
    // console.log(JSON.stringify(newListName));
    this.http.post(this.apiUrl + 'lists', JSON.stringify(newListName), this.requestOptions()).subscribe(resp => {
      // console.log('List created: {0}', resp.json());
      const list: List = resp.json() as List;
      this.lists.push(list);
      this.selectedList = list;
      // console.log(list);
      // this.lists.push(list);
      }, error => {
      console.log(error);
    });
  }

  private requestOptions() {
    const headers = new Headers({'Content-type': 'application/json'});
    return new RequestOptions({headers: headers});
}



//   // Update existing Hero
// private put(hero: Hero) {
//   let headers = new Headers();
//   headers.append('Content-Type', 'application/json');

//   let url = `${this.heroesUrl}/${hero.id}`;

//   return this.http
//              .put(url, JSON.stringify(hero))
//              .map(res => res.json());
// }


//   getLists() {
//     // this.http.get('http://localhost:5000/api/lists').subscribe(response => {
//     //   console.log(response);
//     //   this.lists = response.json();
//     // });
//     this.http.get('http://localhost:5000/api/lists').subscribe(response => {
//       console.log(response);
//       this.lists = response.json() as List[];
// //      console.log(this.lists);
//       });

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

  // }

  // parseData(jsonData: string) {
  //   // considering you get your data in json arrays
  //   for (let i = 0; i < jsonData[1].length; i++) {
  //         console.log(jsonData[i]);
  //        const data = new List(jsonData[1][i], jsonData[2][i], jsonData[3][i], jsonData[4][i]);
  //        this.retrievedLists.push(data);
  //   }
  // }
}
