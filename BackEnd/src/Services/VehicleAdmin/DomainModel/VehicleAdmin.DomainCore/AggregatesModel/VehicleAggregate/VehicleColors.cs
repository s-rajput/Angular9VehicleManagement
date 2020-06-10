using System;
using System.Collections.Generic;
using System.Text;
using VehicleAdmin.Domain.SeedWork;

namespace VehicleAdmin.DomainCore.AggregatesModel.VehicleAggregate.Enumerations
{
    public class VehicleColors
     : Enumeration
    {
        public static VehicleColors Red = new VehicleColors(2, nameof(Red).ToLowerInvariant());
        public static VehicleColors White = new VehicleColors(4, nameof(White).ToLowerInvariant());
        public static VehicleColors Black = new VehicleColors(5, nameof(Black).ToLowerInvariant());
        public static VehicleColors Green = new VehicleColors(6, nameof(Green).ToLowerInvariant());
        public static VehicleColors Grey = new VehicleColors(8, nameof(Grey).ToLowerInvariant());
          
        public VehicleColors(int id, string name)
            : base(id, name)
        {
        }

        public static IEnumerable<VehicleColors> List() =>
            new[] { Red, White, Black, Green, Grey };

    }
}