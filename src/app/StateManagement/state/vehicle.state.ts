import {State, Action, StateContext, Selector} from '@ngxs/store';
import {Vehicle, VehicleViewModel,VehicleProps, VehicleTypes} from '../models/vehicle.model';
import {PersisitAddVehicleAction, RemoveVehicle, PersistVehiclesLoadAction, GetVehicleProps, GetVehicleTypes} from '.././actions/vehicle.actions';

export class VehicleStateModel{
    vehicleProps: VehicleProps[];
    vehicles: VehicleViewModel[];
    vehicleType: VehicleTypes;
}
 
@State<VehicleStateModel>({
    name: 'vehicles',
    defaults: {
       vehicleProps: [],
       vehicles : [],
       vehicleType: null
    }
  })

export class VehicleState {


  @Selector()
    static geVehicleProps(state : VehicleStateModel){
        return state.vehicleProps;
    }
    
  @Selector()
  static geVehicleType(state : VehicleStateModel){
      return state.vehicleType;
  }

  @Selector()
  static geVehicles(state : VehicleStateModel){
      return state.vehicles;
  }

    @Action(GetVehicleTypes)
    private persistVehicleType({getState,patchState}:StateContext<VehicleStateModel>,{vehicletype }: GetVehicleTypes){
    const state = getState();
    patchState({
      vehicleType : vehicletype
      })
    }

    @Action(GetVehicleProps)
    private persistLoadProps({getState, patchState}: StateContext<VehicleStateModel>, { vehicleProps }: GetVehicleProps) {
       
        const state = getState();
        patchState({
          vehicleProps: vehicleProps
      }) 
      console.log(getState());
    }

    @Action(PersistVehiclesLoadAction)
    private persistVehicleLoad({getState, patchState}: StateContext<VehicleStateModel>, { vehicleList }: PersistVehiclesLoadAction) {
        
        const state = getState();
        
        patchState({
          vehicles: vehicleList
          
      }) 
    }

    
    @Action(PersisitAddVehicleAction)
    private PersistAddVehicle({getState, patchState}: StateContext<VehicleStateModel>, { vehicleList }: PersisitAddVehicleAction) {
   
      const state = getState();
      
      patchState({
        vehicles: vehicleList
        
    }) 
    }
 
}