import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { EditRaceItemComponent } from './Specific/edit-race-item/edit-race-item.component';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { RaceListComponent } from './race-list.component';
import { CreateRaceItemComponent } from './Specific/create-race-item/create-race-item.component';


@NgModule({

  declarations: [
    EditRaceItemComponent,
    CreateRaceItemComponent
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
  exports:[
    ReactiveFormsModule
  ]
  

})
export class RaceModule { }
