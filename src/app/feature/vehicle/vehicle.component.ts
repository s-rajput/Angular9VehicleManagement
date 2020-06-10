import { Component, Input, OnInit,AfterViewInit, ɵConsole  }  from '@angular/core';
import { FormGroup }                 from '@angular/forms';

import { QuestionBase }              from '../question/question-base';
import { QuestionControlService }    from '../question/question-control.service';

import { Store } from '@ngxs/store';
import { VehicleService   } from '../../StateManagement/services/vechicle.service';
import { VehicleStateModel } from 'src/app/StateManagement/state/vehicle.state';
import { Vehicle, VehicleViewModel,VehicleCategories, VehiclePost } from 'src/app/StateManagement/models/vehicle.model';
import {  Observable } from 'rxjs'
import {  PersistVehiclesLoadAction } from '../../StateManagement/actions/vehicle.actions'


@Component({
  selector: 'app-vehicle',
  templateUrl: './vehicle.component.html',
  providers: [ QuestionControlService ]
})
export class DynamicFormComponent implements OnInit  {

  @Input() questions: QuestionBase<string>[] = [];
  form: FormGroup;
  payLoad = '';
  vehicles$: Observable<VehicleViewModel>;
  displayElement = false; 

  constructor(private qcs: QuestionControlService,private vservice: VehicleService,private store: Store) {   
    this.displayElement = false;  
    this.displayElement = true;
    this.vservice.getAllVehicles(); 
    this.vehicles$ = this.store.select(state => state.vehicles.vehicles);
  
  }

  ngOnInit() {  
    if(this.questions){  
    this.form = this.qcs.toFormGroup(this.questions);
    }
  }

  
   

  onSubmit() {
    this.payLoad = JSON.stringify(this.form.getRawValue());
 
    var v = this.form.value as Vehicle;
    console.log(v);
    var vObj: VehiclePost = {
        vehicleJsonStrObj :  this.payLoad, 
       VehicleType : v.VehicleType
    };
   
    this.vservice.addVehicle(vObj);
  }
}
