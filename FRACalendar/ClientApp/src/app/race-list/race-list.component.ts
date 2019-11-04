import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'race-list',
  templateUrl: './race-list.component.html'
})
export class RaceListComponent {
  public races: Race[];
 
  httpOptions = {
    headers: new HttpHeaders({ 
      'Access-Control-Allow-Origin':'*'
    })
  };
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    debugger;
    http.get<Race[]>(baseUrl + 'api/race/list', this.httpOptions).subscribe(result => {
      debugger;
      this.races = result;
    }, error => console.log(error));
  }
}

interface Race {
  id: number;
  name: string;
}
