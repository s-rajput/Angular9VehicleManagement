using System;
using System.Collections.Generic;
using System.Linq;
using VehicleAdmin.Domain.SeedWork;
using VehicleAdmin.DomainCore.Exceptions;

namespace VehicleAdmin.DomainCore.AggregatesModel.VehicleAggregate.Enumerations
{

    public class VehicleCategories
        : Enumeration
    {
        public static VehicleCategories Family = new VehicleCategories(1, nameof(Family).ToLowerInvariant());
        public static VehicleCategories Sports = new VehicleCategories(2, nameof(Sports).ToLowerInvariant());
        public static VehicleCategories Racing = new VehicleCategories(3, nameof(Racing).ToLowerInvariant());
        public static VehicleCategories Cruising = new VehicleCategories(4, nameof(Cruising).ToLowerInvariant());


        public VehicleCategories(int id, string name)
            : base(id, name)
        {
        }

        public static IEnumerable<VehicleCategories> List() =>
            new[] { Family, Sports, Racing, Cruising };

        public static VehicleCategories FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new VehicleAdminDomainExceptions($"Possible values for VehicleCategories: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        public static VehicleCategories From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new VehicleAdminDomainExceptions($"Possible values for VehicleCategories: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }
    }
}
