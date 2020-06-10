using System;
using System.Collections.Generic;
using System.Linq;
using VehicleAdmin.Domain.SeedWork;
using VehicleAdmin.DomainCore.Exceptions;

namespace VehicleAdmin.DomainCore.AggregatesModel.VehicleAggregate.Enumerations
{

    public class VehicleMakes
        : Enumeration
    {
        public static VehicleMakes Ford = new VehicleMakes(1, nameof(Ford).ToLowerInvariant());
        public static VehicleMakes Toyota = new VehicleMakes(2, nameof(Toyota).ToLowerInvariant());
        public static VehicleMakes Honda = new VehicleMakes(3, nameof(Honda).ToLowerInvariant());
        public static VehicleMakes BMW = new VehicleMakes(3, nameof(BMW).ToLowerInvariant());
        public static VehicleMakes Mercedes = new VehicleMakes(3, nameof(Mercedes).ToLowerInvariant());

        public VehicleMakes(int id, string name)
            : base(id, name)
        {
        }

        public static IEnumerable<VehicleMakes> List() =>
            new[] { Ford, Toyota, Honda,BMW,Mercedes };

        public static VehicleMakes FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new VehicleAdminDomainExceptions($"Possible values for VehicleMakes: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        public static VehicleMakes From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new VehicleAdminDomainExceptions($"Possible values for VehicleMakes: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }
    }
}
