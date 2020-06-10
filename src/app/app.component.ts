import { Component }       from '@angular/core';

import { QuestionService } from './feature/question/question.service';
import { QuestionBase }    from './feature/question/question-base';
import { Observable }      from 'rxjs';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { VehicleTypes } from './StateManagement/models/vehicle.model';
  

@Component({
  selector: 'app-root',
  template: `
  <style>
   .container {
      margin-top: 30px;
    }

    input.ng-invalid.ng-touched {
      border: 1px solid red
    }
    .control-label.required:after {
      color: #d00;
      content: "*";
      position: absolute;
      margin-left: 5px;
    }

    </style>
    <div>
 

      <h1>Vehicle Management System</h1>
      <div> 
      <div class="form-group"> 
        <select class="form-control" (change)="selectVehicle($event)">
          <option>Select Vehicle Type to create</option>
          <option *ngFor="let web of vehicleList">{{web}}</option>
        </select>           
      </div>  
      </div>
 

      <div *ngIf='displayElement'>
      <app-vehicle [questions]="questions$ | async"></app-vehicle>
      </div>
       
    </div>
  `,
  providers:  [QuestionService]
})
export class AppComponent {
  questions$: Observable<QuestionBase<any>[]>;
  form = new FormGroup({
    vehicle: new FormControl('', Validators.required)
  });
  vehicleType: VehicleTypes;
  service :QuestionService;
  vehicleList: any = ['Car', 'Boat', 'Truck'];
  displayElement = false; 
  

  constructor(private _service: QuestionService) {  
  }

  get f(){
    return this.form.controls;
  }

  selectVehicle(e){  this.displayElement=false;  this.questions$ = null; this.form = null;
 
console.log(e.target.value);
    if(e.target.value == 'Select Vehicle Type to create'){  
        this.displayElement=false;      
      return;}
  
    this.vehicleType = e.target.value; 
    this.questions$ = this._service.getQuestions(e.target.value);
    this.displayElement=true;    
 
  }
}
