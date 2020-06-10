import { Injectable, Injector } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { VehicleViewModel , VehicleTypes,VehicleProps, VehiclePost} from '../models/vehicle.model';
import { BASE_URL } from '../tokens';
import { Select } from '@ngxs/store';
import {  VehicleState } from '../state/vehicle.state';  
import { Dispatch } from '@ngxs-labs/dispatch-decorator';
import {  PersisitAddVehicleAction, PersistVehiclesLoadAction,GetVehicleTypes, GetVehicleProps } from '../actions/vehicle.actions';
import { tap, map } from 'rxjs/operators';


@Injectable({ providedIn: 'root' })
export class VehicleService {

  @Select(VehicleState)
  public data$: Observable<VehicleViewModel[]>;

  private baseUrl: string;

  public constructor(
    private injector: Injector,
    private http: HttpClient
  ) {
    this.baseUrl = this.injector.get(BASE_URL);
  }

  @Dispatch()
  public getAllVehicles() {  
    return this.http
      .get<VehicleViewModel[]>(`${this.baseUrl}/api/VehicleAdmin/getvehicles`)
      .pipe(
        map((vehicles) => new PersistVehiclesLoadAction(vehicles))
      );
  }

 
  @Dispatch()
  public getVehicleType(type: string) { 
    let vtype: VehicleTypes;
    vtype = null;
    if(type == 'Car') { vtype = VehicleTypes.CAR; }
    if(type == 'Boat') {vtype = VehicleTypes.BOAT; }
    if(type == 'Car') {vtype = VehicleTypes.CAR; }

    new GetVehicleTypes(vtype);
    return vtype;
     
  }

 
  @Dispatch()
  public getVehicleProps(type : string) {  
  return this.http
    .get<VehicleProps[]>(`${this.baseUrl}/api/VehicleAdmin/getvehicleprops?type=` + type)
    .pipe(
      map((vehicleprops) => new GetVehicleProps(vehicleprops))
    );
  } 
   
 
  @Dispatch()
  public addVehicle (vehicle: VehiclePost) {
    return this.http.post<VehicleViewModel[]>(`${this.baseUrl}/api/VehicleAdmin/addvehicle`, vehicle)
    .pipe(
        map((result) => new PersisitAddVehicleAction(result))  
    );
  }
}