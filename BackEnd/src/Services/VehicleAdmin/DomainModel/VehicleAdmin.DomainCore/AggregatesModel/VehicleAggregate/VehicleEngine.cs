using System;
using System.Collections.Generic;
using System.Text;
using VehicleAdmin.Domain.SeedWork;
using VehicleAdmin.DomainCore.AggregatesModel.VehicleAggregate.Enumerations;

namespace VehicleAdmin.DomainCore.AggregatesModel.VehicleAggregate.Entities
{
    public class VehicleEngine : Entity
    {
       
        public EngineFuelTypes FuelType { get; private set; }
        public EngineCylinderTypes CylinderType { get; private set; }
        public int MinPower { get; private set; }
        public int MaxPower { get; private set; }

        public VehicleEngine(EngineFuelTypes fuelType,
            EngineCylinderTypes cylinderType, int minPower, int maxPower)
        { 
            FuelType = fuelType;
            CylinderType = cylinderType;
            MinPower = minPower;
            MaxPower = maxPower;
        }
    }
}
