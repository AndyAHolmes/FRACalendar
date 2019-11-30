import { Component, Inject, Input } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { Race } from '../Common/race-service-contract';

@Component({
  selector: 'create-race-item',
  templateUrl: './create-race-item.component.html'
})
export class CreateRaceItemComponent {
  
  public RaceItem: Race;
  constructor (private route: ActivatedRoute, private router: Router, private http: HttpClient, @Inject('BASE_URL') private  baseUrl: string){

  }
  
  ngOnInit () {
    this.RaceItem = {id:0, name: '', price: 0, raceDate: new Date("1/1/2009")}
     this.BindControls();
  }
  raceForm: FormGroup;

  BindControls()
  {
    this.raceForm  = new FormGroup( {
      id: new FormControl(this.RaceItem.id),
      name: new FormControl(this.RaceItem.name),
      price: new FormControl(this.RaceItem.price),
      racedate: new FormControl(this.RaceItem.raceDate)

  });
}
close()
{
  this.router.navigate(["/race-item-index"]);
}

onSubmit()
{
var options = { name: this.raceForm.controls["name"].value, 
                price: +this.raceForm.controls["price"].value, 
                raceDate: this.raceForm.controls["racedate"].value};
  
  this.http.post(this.baseUrl + 'api/race', options).subscribe(result => {
    //redirect, back to index.
    this.router.navigate(["/race-item-index"]);
  }, error => console.log(error));
}
}
