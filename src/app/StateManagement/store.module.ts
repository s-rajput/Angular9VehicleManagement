import { NgModule, InjectionToken } from '@angular/core';
import { NgxsModule } from '@ngxs/store';
import { NgxsReduxDevtoolsPluginModule } from '@ngxs/devtools-plugin'; 
import {   VehicleState } from './state/vehicle.state';
import { HttpClientModule } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { BASE_URL } from './tokens';
@NgModule({
  imports: [
    HttpClientModule,
    NgxsModule.forRoot([VehicleState], { developmentMode: !environment.production }),
    NgxsReduxDevtoolsPluginModule.forRoot()
  ],
  exports: [NgxsModule],
  providers: [
    {
      provide: BASE_URL,
      useValue: 'http://Localhost:3000',
    }
  ]
})
export class StoreModule {}
