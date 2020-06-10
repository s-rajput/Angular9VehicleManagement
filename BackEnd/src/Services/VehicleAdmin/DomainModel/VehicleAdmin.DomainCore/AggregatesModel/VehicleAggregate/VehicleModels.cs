using System;
using System.Collections.Generic;
using System.Text;
using VehicleAdmin.Domain.SeedWork;
using VehicleAdmin.DomainCore.AggregatesModel.VehicleAggregate.Enumerations;

namespace VehicleAdmin.DomainCore.AggregatesModel.VehicleAggregate.Entities
{
    public class VehicleModels :Entity
    {
        public VehicleMakes Make { get; private set; }
        public string ModelName { get; private set; }

        public VehicleModels(VehicleMakes make, string modelName)
        {
            Make = make;
            ModelName = modelName;
        }
    }
}
