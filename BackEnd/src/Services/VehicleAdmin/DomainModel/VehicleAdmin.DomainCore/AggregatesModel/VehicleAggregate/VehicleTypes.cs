using System;
using System.Collections.Generic;
using System.Linq;
using VehicleAdmin.Domain.SeedWork;
using VehicleAdmin.DomainCore.Exceptions;

namespace VehicleAdmin.DomainCore.AggregatesModel.VehicleAggregate.Enumerations
{

    public class VehicleTypes
        : Enumeration
    {
        public static VehicleTypes Car = new VehicleTypes(1, nameof(Car).ToLowerInvariant());
        public static VehicleTypes Boat = new VehicleTypes(2, nameof(Boat).ToLowerInvariant());
        public static VehicleTypes Truck = new VehicleTypes(3, nameof(Truck).ToLowerInvariant());
      
        public VehicleTypes(int id, string name)
            : base(id, name)
        {
        }

        public static IEnumerable<VehicleTypes> List() =>
            new[] { Car, Boat, Truck };

        public static VehicleTypes FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new VehicleAdminDomainExceptions($"Possible values for VehicleTypes: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        public static VehicleTypes From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new VehicleAdminDomainExceptions($"Possible values for VehicleTypes: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }
    }
}
