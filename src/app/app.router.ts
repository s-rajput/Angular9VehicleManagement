
import {Routes, RouterModule, CanActivateChild} from '@angular/router';
import { NgModule } from '@angular/core'; 

import { DynamicFormComponent  } from  './feature/vehicle/vehicle.component';

const appRoute: Routes = [ 
  {path: 'Add', component: DynamicFormComponent}
];

@NgModule ({
  imports: [
    RouterModule.forRoot(appRoute)
  ],
  exports: [RouterModule]
})

export class AppRoutingModule {

}
