import { BrowserModule }                from '@angular/platform-browser';
import { ReactiveFormsModule }          from '@angular/forms';
import { NgModule }                     from '@angular/core';

import { AppComponent }                 from './app.component';
import { DynamicFormComponent }         from  './feature/vehicle/vehicle.component';
import { DynamicFormQuestionComponent } from './feature/question/question.component';

import { NgxsModule } from '@ngxs/store';
import { VehicleState} from './StateManagement/state/vehicle.state';
import { NgxsReduxDevtoolsPluginModule  } from '@ngxs/devtools-plugin'   //redux dev tools
import { NgxsLoggerPluginModule } from '@ngxs/logger-plugin';    //logger

import { HttpClientModule } from '@angular/common/http';
import { StoreModule} from './StateManagement/store.module';
import {NgxsDispatchPluginModule } from '@ngxs-labs/dispatch-decorator';
import { AppRoutingModule } from './app.router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap'; 

@NgModule({
  imports: [ BrowserModule, ReactiveFormsModule ,AppRoutingModule,
    HttpClientModule,
    StoreModule,
    NgxsDispatchPluginModule,
    NgxsModule.forRoot([
      VehicleState
    ]),
    NgxsReduxDevtoolsPluginModule.forRoot(),
    NgxsLoggerPluginModule.forRoot(),
    NgbModule
  ],
  declarations: [ AppComponent, DynamicFormComponent, DynamicFormQuestionComponent ],
  bootstrap: [ AppComponent ]
})
export class AppModule {
  constructor() {
  }
}
