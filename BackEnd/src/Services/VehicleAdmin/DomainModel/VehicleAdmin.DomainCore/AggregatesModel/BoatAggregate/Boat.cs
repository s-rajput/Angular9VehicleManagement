using System;
using System.Collections.Generic;
using System.Text;
using VehicleAdmin.Domain.SeedWork;
using VehicleAdmin.DomainCore.AggregatesModel.VehicleAggregate.Enumerations;

namespace VehicleAdmin.DomainCore.AggregatesModel.BoatAggregate
{
    public class Boat : Vehicle
    { 
        public string HullType { get; set; }
         
        public string Segment { get; set; }
         
        public override string VehicleType => "Boat";


    }
}
