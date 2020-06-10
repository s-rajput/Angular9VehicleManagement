using System;
using System.Collections.Generic;
using System.Linq;
using VehicleAdmin.Domain.SeedWork;
using VehicleAdmin.DomainCore.Exceptions;

namespace VehicleAdmin.DomainCore.AggregatesModel.VehicleAggregate.Enumerations
{

    public class EngineFuelTypes
        : Enumeration
    {
        public static EngineFuelTypes Petrol = new EngineFuelTypes(1, nameof(Petrol).ToLowerInvariant());
        public static EngineFuelTypes Diesel = new EngineFuelTypes(2, nameof(Diesel).ToLowerInvariant());
        public static EngineFuelTypes PremiumUnleaded = new EngineFuelTypes(3, nameof(PremiumUnleaded).ToLowerInvariant());
      
        public EngineFuelTypes(int id, string name)
            : base(id, name)
        {
        }

        public static IEnumerable<EngineFuelTypes> List() =>
            new[] { Petrol, Diesel, PremiumUnleaded };

        public static EngineFuelTypes FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new VehicleAdminDomainExceptions($"Possible values for EngineFuelTypes: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        public static EngineFuelTypes From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new VehicleAdminDomainExceptions($"Possible values for EngineFuelTypes: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }
    }
}
