import { Component, Inject } from '@angular/core';
import { DataService } from '../services/data-service';

@Component({
  selector: 'race-list',
  templateUrl: './race-list.component.html'
})
export class RaceListComponent {
  public races: Race[];
 private _dataService: DataService;
  private _baseUrl: string;
  constructor(dataService: DataService,@Inject('BASE_URL')baseUrl: string) {
    this._dataService = dataService;
    this._baseUrl = baseUrl;
  }

  ngInit()
  {
    this.load();
  
  }
  load(){
    this._dataService.GetData(this._baseUrl + 'api/race/list').subscribe(result => {
      this.races = result as Race[];
    }, error => console.log(error));
  }

  public deleteItem(id)
  {
    this._dataService.Delete(this._baseUrl + 'api/race/'+id).subscribe(r=>{this.load()},error=>console.log(error));
  }
}

interface Race {
  id: number;
  name: string;
}
