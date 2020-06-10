import { Injectable, ɵConsole }       from '@angular/core';

import { DropdownQuestion } from './question-dropdown';
import { QuestionBase }     from './question-base';
import { TextboxQuestion }  from './question-textbox';
import { of , Observable } from 'rxjs';
import { VehicleProps } from '../../StateManagement/models/vehicle.model';
import { Store, Select } from '@ngxs/store';
import { VehicleService } from '../../StateManagement/services/vechicle.service';


@Injectable()
export class QuestionService {

   requestedvehicletype: string;
 
  
  constructor(private store: Store,private vehicleService: VehicleService) {
    }

  // TODO: get from a remote source of question metadata
  getQuestions(vehicleType: string) {
 
    
   let vehicleQustions = this.getVehicleQuestions(false); 

   if(vehicleType == 'Car'){  
      var carQuestions = this.getCarQuestions(false);
      vehicleQustions= vehicleQustions.concat(carQuestions); 
   }

   if(vehicleType == 'Boat'){ 
    let boatQuestions= this.getBoatQuestions(false);   
    vehicleQustions= vehicleQustions.concat(boatQuestions);
    //let carQuestions = this.getCarQuestions(true);
    console.log(boatQuestions);
 
  }
 
  console.log(vehicleType);
  console.log(vehicleQustions);
  console.log('VERIFY');
  return of(vehicleQustions.sort((a, b) => a.order - b.order));
 
  }

  selectVehicle(vehicleType: string){ 
    this.requestedvehicletype = 'Car';  
  }

  getVehicleQuestions(hideIt:boolean){

    
    let questions: QuestionBase<string>[] = [
 

      new DropdownQuestion(
      {
        hide: hideIt,
        key: 'Make',
        label: 'Vehicle Make',
        value: 'Ford',
        options: [
          {key: 'Ford',  value: 'Ford'},
          {key: 'Toyota',  value: 'Toyota'},
          {key: 'BMW',   value: 'BMW'},
          {key: 'Honda', value: 'Honda'}
        ],
        order: 1
      }),
      new DropdownQuestion(
        {
          hide: hideIt,
          key: 'Category',
          label: 'Vehicle Category', 
          value: 'Family',
          options: [
            {key: 'Family',  value: 'Family'},
            {key: 'Sports',  value: 'Sports'},
            {key: 'Racing',   value: 'Racing'},
            {key: 'Cruising', value: 'Cruising'}
          ],
          order: 2
        }),
      new DropdownQuestion(
      {
        hide: hideIt,
        key: 'Color',
        label: 'Color',
        value: 'White',
        options: [
          {key: 'White',  value: 'White'},
          {key: 'Black',  value: 'Black'},
          {key: 'Grey',   value: 'Grey'},
          {key: 'Green', value: 'Green'}
        ],
        order: 3
      }
      )

    ];

  return questions;
  }

  
  getCarQuestions(hideIt: boolean){

    
    let questions: QuestionBase<string>[] = [

      new DropdownQuestion(
        {
          hide: hideIt,
        key: 'NoOfDoors',
        label: 'Car Doors',
        requestedvehicletype : true,
        value: '4',
        options: [
          {key: '4',  value: '4'},
          {key: '6',  value: '6'},
          {key: '8',   value: '8'}
        ],
        order: 4
      }),     

      new TextboxQuestion({
        hide: hideIt,
        key: 'VIN',
        label: 'Car VIN No',
        value :'1234545DGHDHD', 
        order: 5
      }),
      
      new TextboxQuestion({
        hide: hideIt,
        key: 'VehicleType',
        label: 'Vehicle Type',
        value: 'Car', 
        order: 6
      })
    ];

    return questions; 
   }

  
  getBoatQuestions(hideIt : boolean){

    
    let questions: QuestionBase<string>[] = [

      new DropdownQuestion(
        {
          hide: hideIt,
        key: 'HullType',
        label: 'Boat HullType', 
        value: 'Mono',
        options: [
          {key: 'Mono',  value: 'Mono'},
          {key: 'Multi',  value: 'Multi'},
          {key: 'Pantoon',   value: 'Pantoon'}
        ],
        order: 7
      }),
      new DropdownQuestion(
      {
        hide: hideIt,
        key: 'Segment',
        label: 'Boat Segment', 
        value: 'Power',
        options: [
          {key: 'Power',  value: 'Power'},
          {key: 'Sail',  value: 'Sail'}
        ],
        order: 8
      }),     

      new TextboxQuestion({
        hide: hideIt,
        key: 'VehicleType',
        label: 'Vehicle Type',
        value: 'Boat', 
        order: 9
      })
    ];

    return questions; 
   }
 
  
}
