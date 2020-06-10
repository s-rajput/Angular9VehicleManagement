using VehicleAdmin.Domain.SeedWork; 
using System;
using System.Collections.Generic;
using System.Text; 
using VehicleAdmin.DomainCore.AggregatesModel.VehicleAggregate.Enumerations;
using VehicleAdmin.DomainCore.AggregatesModel.VehicleAggregate.Entities;

namespace VehicleAdmin.Domain.SeedWork
{
    public abstract class Vehicle : Entity
    { 

        public virtual string VehicleType { get; set; }
        public string Make { get; set; }

        public string Model { get; set; } 
        public string Category { get; set; }         

        public string Color { get; set; }


        public int Year { get;  set; }

        public string NoOfWheels { get; set; }

    }
}
