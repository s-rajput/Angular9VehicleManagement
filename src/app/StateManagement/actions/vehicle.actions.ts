//import {Vehicle} from '../../models/vehicle.model';
import {VehicleViewModel, VehicleTypes, VehicleProps} from '../models/vehicle.model';

export class AddVehicle1 {
 static readonly type = '[VEHICLE] Add'

    constructor(public payload: VehicleViewModel) {}
}
export class PersisitAddVehicleAction {
    static readonly type = '[VEHICLE] Persisit Add'
   
       constructor(public vehicleList : VehicleViewModel[]) {}
   }
export class RemoveVehicle {
    static readonly type = '[VEHICLE] Remove'
   
       constructor(public payload: string) {}
   }

   export class PersistVehiclesLoadAction  {
    public static readonly type = '[VEHICLE] Persist Load';
    public constructor(public vehicleList: VehicleViewModel[]) { }
  }
  
  export class GetVehicleTypes {
    public static readonly type = '[VEHICLETYPE] Load';
    public constructor(public vehicletype: VehicleTypes) { }
  }
  export class GetVehicleProps {
    public static readonly type = '[VEHICLEPROPS] Load';
    public constructor(public vehicleProps: VehicleProps[]) { }
  }
  