import { Component, Inject, Input } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { Race } from '../Common/race-service-contract';

@Component({
  selector: 'edit-race-item',
  templateUrl: './edit-race-item.component.html'
})
export class EditRaceItemComponent {
  
  public RaceItem: Race;
  constructor (private route: ActivatedRoute, private router: Router, private http: HttpClient, @Inject('BASE_URL') private  baseUrl: string){

  }
  
  ngOnInit () {
    const id = +this.route.snapshot.paramMap.get('id');
    this.http.get<Race>(this.baseUrl + 'api/race/'+id).subscribe(result => {
      this.RaceItem = {
        id: result.id,
        name: result.name,
        price: result.price,
        raceDate: result.raceDate
      };
      this.BindControls();

    }, error => console.log(error));
  }
  raceForm: FormGroup;

  BindControls()
  {
    this.raceForm  = new FormGroup( {
      id: new FormControl(this.RaceItem.id),
      name: new FormControl(this.RaceItem.name),
      price: new FormControl(this.RaceItem.price),
      racedate: new FormControl(new Date(this.RaceItem.raceDate))

  });
  const currentDate = new Date(this.RaceItem.raceDate).toISOString().substring(0, 10);
 
  this.raceForm.controls["racedate"].setValue(currentDate);
}
close()
{
  this.router.navigate(["/race-item-index"]);
}
onSubmit()
{
var options = {id: this.raceForm.controls["id"].value,
                name: this.raceForm.controls["name"].value, 
                price: +this.raceForm.controls["price"].value, 
                raceDate: this.raceForm.controls["racedate"].value};
  
  this.http.put(this.baseUrl + 'api/race/'+this.raceForm.controls["id"].value, options).subscribe(result => {
    //redirect, back to index.
    this.router.navigate(["/race-item-index"]);
  }, error => console.log(error));
}
}

