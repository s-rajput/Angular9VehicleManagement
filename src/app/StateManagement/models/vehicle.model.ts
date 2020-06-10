
export  abstract  class Vehicle {
    Id: number;
    Model: VehicleModels;
    Category:  VehicleCategories;
    Color: VehicleColors;
    Year: number; 
    abstract VehicleType: VehicleTypes;
  }
  export class VehicleViewModel{

    VehicleType: string;
    Make: string;
    Model : string;
    Category: string;
    Year : string;
    VehicleProperty: string;
  }

  export class VehiclePost{

    VehicleType: VehicleTypes;
    vehicleJsonStrObj: string;
  }

  export  class VehicleModels {
    Id: number;
    Make: VehicleMakes;
    ModelName: string; 
  }
  export enum VehicleCategories {
    Family,
    Sports,
    Racing,
    Crusising
  }
  export enum VehicleMakes  {
    Ford,
    Toyota,
    BMW,
    Honda,
    Mercedes
  }
  
  export  enum VehicleColors {
   White,
   Black,
   Grey
  }
  export enum CarDoors {
       
      Four,
      Six,
      Eight 
  }

  export class Car extends Vehicle {
    NoOfDoors : CarDoors
    VIN: string; 
    VehicleType: VehicleTypes = VehicleTypes.CAR;
 
    constructor(public _Id: number, public _Model: VehicleModels, public _Category: VehicleCategories, public _Color: VehicleColors,
      public _Year: number, public _NoOfDoors: CarDoors,public _VIN : string ) { super();

       this.Id = _Id;
       this.Model= _Model;
       this.Category=_Category;
       this.Color=_Color;
       this.Year=_Year; 
       this.NoOfDoors=_NoOfDoors;
       this.VIN=_VIN;
      }
  }
  
  export class Boat extends Vehicle {
    HullType: BoatHullTypes;
    Segment: BoatSegments;
    VehicleType: VehicleTypes = VehicleTypes.BOAT;
  
  
  }
  export enum BoatHullTypes {
       
    Mono,
    Multi,
    Pantoon  
  }
    export enum BoatSegments {
        
        Power,
        Sail
    }
  
  export class CurrentVehicle {
    Id: number;
    VehicleType: VehicleTypes;
    constructor(public _id: number, public _vehicleType: VehicleTypes) {
      this.Id = _id;
      this.VehicleType = _vehicleType;
    }
  }

  export enum VehicleTypes {
    CAR,
    BOAT,
    TRUCK
  }

  export   class VehicleProps {
    Name: string;
    Datatype: string;
    Order: number;
    Regex: string;
    Required: boolean;
    Value: any;
  
    constructor(public _Name: string, public _Datatype: string,
      public _Order: number, public _Regex: string, public _Required: boolean,public _Value: any) {
      this.Name = _Name;
      this.Datatype = _Datatype;
      this.Order = _Order;
      this.Regex = _Regex;
      this.Required = _Required;
      this.Value = _Value;
    }
  }
  