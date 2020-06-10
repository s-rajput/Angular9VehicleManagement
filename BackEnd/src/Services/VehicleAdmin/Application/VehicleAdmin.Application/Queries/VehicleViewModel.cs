using System;
using System.Collections.Generic;
using System.Text;
using VehicleAdmin.DomainCore.AggregatesModel.VehicleAggregate.Entities;
using VehicleAdmin.DomainCore.AggregatesModel.VehicleAggregate.Enumerations;

namespace VehicleAdmin.Application.Queries
{
    public class VehicleViewModel
    { 
        public string VehicleType { get; set; }
         
        public string Make { get; set; }
         
        public string Model { get; set; }
         
        public string Category { get; set; }
         
        public int Year { get; set; }
         
        public string VehicleProperty { get; set; }
    }
}
