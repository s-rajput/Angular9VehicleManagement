using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleAdmin.Domain.SeedWork;
using VehicleAdmin.DomainCore.AggregatesModel.VehicleAggregate.Enumerations;

namespace VehicleAdmin.DomainCore.AggregatesModel.CarAggregate
{
    public class Car : Vehicle
    {
        public string VIN { get;  set; }

        //[System.Text.Json.Serialization.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        //public CarDoors NoOfDoors { get;  set; }

        public int NoOfDoors { get; set; }

        //public override VehicleTypes VehicleType => VehicleTypes.Car;
        public override string VehicleType => "Car";

    }
}
