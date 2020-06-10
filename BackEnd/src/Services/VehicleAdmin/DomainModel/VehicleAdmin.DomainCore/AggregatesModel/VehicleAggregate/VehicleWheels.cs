using System;
using System.Collections.Generic;
using System.Text;
using VehicleAdmin.Domain.SeedWork;

namespace VehicleAdmin.DomainCore.AggregatesModel.VehicleAggregate.Enumerations
{
    public class VehicleWheels
     : Enumeration
    {
        public static VehicleWheels None = new VehicleWheels(0, nameof(None).ToLowerInvariant());
        public static VehicleWheels Two = new VehicleWheels(2, nameof(Two).ToLowerInvariant());
        public static VehicleWheels Three = new VehicleWheels(3, nameof(Three).ToLowerInvariant());
        public static VehicleWheels Four = new VehicleWheels(4, nameof(Four).ToLowerInvariant());
        public static VehicleWheels Six = new VehicleWheels(6, nameof(Six).ToLowerInvariant());
        public static VehicleWheels Eight = new VehicleWheels(8, nameof(Eight).ToLowerInvariant());
          
        public VehicleWheels(int id, string name)
            : base(id, name)
        {
        }

        public static IEnumerable<VehicleWheels> List() =>
            new[] { None,Two, Three, Four, Six, Eight };

    }
}