import 'jasmine';
import { RaceListComponent } from './race-list.component';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { EditRaceItemComponent } from './Specific/edit-race-item/edit-race-item.component';
import { CreateRaceItemComponent } from './Specific/create-race-item/create-race-item.component';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { DataService } from '../services/data-service';
import { Race } from './Specific/Common/race-service-contract';
import { of } from 'rxjs';

describe('can this be found', function(){
beforeEach(()=>{
  console.log('before each test')
});

describe('first tests', ()=>{
  it('test 1', function(){
    expect(true).toBeTruthy('true is not truthy');
  });
 });
});
 describe("first tests", ()=>{
  let _dataService:DataService;
   beforeEach(async(()=>{

     _dataService = new DataService(null);

     TestBed.configureTestingModule(
     {
      declarations: [
         EditRaceItemComponent,
         CreateRaceItemComponent,
         RaceListComponent
       ],
       imports: [
         ReactiveFormsModule,
         BrowserModule,
         CommonModule,
          RouterModule.forRoot([
           { path: 'edit-race-item/:id', component: EditRaceItemComponent },
           { path: 'create-race-item', component: CreateRaceItemComponent },
           { path: 'race-item-index', component: RaceListComponent }
         ])
       
       ],
       providers:[
        { provide: 'BASE_URL', useValue: '' },
        { provide: DataService, useValue: _dataService }

       ]

     }).compileComponents();
    
   }));
  
   describe("Given the control is loaded",function(){
    let component: RaceListComponent ; 
    let fixture: ComponentFixture<RaceListComponent>;

    beforeEach(async()=>{
      let raceCollection: Race[] = [];
      let race1: Race = {id: 1, name: "Race 1", raceDate: new Date(2019,10,1), price: 10}
      let race2: Race = {id: 2, name: "Race 2", raceDate: new Date(2019,10,1), price: 10}
      raceCollection.push( race1);
      raceCollection.push( race2);
      let spy = spyOn(_dataService,'GetData').and.returnValue(of(raceCollection));
      fixture = TestBed.createComponent(RaceListComponent);
      component = fixture.componentInstance;
     fixture.detectChanges();

 
    });
    it("When the list is loaded", function(){
      component.load();
    //following the load o the data that influences the bindings, need to detect changes to see the changes in the ui.
      fixture.detectChanges();
      let renderedHTML  =fixture.nativeElement.innerHTML;

      expect(component.races).toBeTruthy();
      expect(component.races.length).toEqual(2);
      let expectedHTML = '<h1 id="tableLabel">Race List</h1><!--bindings={  "ng-reflect-ng-if": "false"}--><div class="btn-toolbar"><button class="btn btn-sm btn-secondary" routerlink="/create-race-item" tabindex="0" ng-reflect-router-link="/create-race-item">Create</button></div><!--bindings={  "ng-reflect-ng-if": "[object Object],[object Object"}--><table aria-labelledby="tableLabel" class="table table-striped"><thead><tr><th>Name</th></tr></thead><tbody><!--bindings={  "ng-reflect-ng-for-of": "[object Object],[object Object"}--><tr><td><a class="btn sm-btn" ng-reflect-router-link="/edit-race-item/1" href="/edit-race-item/1">Edit</a><button class="btn sm-btn">Delete</button></td><td>Race 1</td></tr><tr><td><a class="btn sm-btn" ng-reflect-router-link="/edit-race-item/2" href="/edit-race-item/2">Edit</a><button class="btn sm-btn">Delete</button></td><td>Race 2</td></tr></tbody></table>';
      let parsedHtml = renderedHTML.replace(/(\r\n|\n|\r)/gm, "");
      expect(parsedHtml).toEqual(expectedHTML);
    });
   });
 });;