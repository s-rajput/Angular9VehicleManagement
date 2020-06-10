using System;
using System.Collections.Generic;
using System.Linq;
using VehicleAdmin.Domain.SeedWork;
using VehicleAdmin.DomainCore.Exceptions;

namespace VehicleAdmin.DomainCore.AggregatesModel.VehicleAggregate.Enumerations
{

    public class EngineCylinderTypes
        : Enumeration
    {
        public static EngineCylinderTypes Two = new EngineCylinderTypes(2, nameof(Two).ToLowerInvariant());
        public static EngineCylinderTypes Four = new EngineCylinderTypes(4, nameof(Four).ToLowerInvariant());
        public static EngineCylinderTypes Six = new EngineCylinderTypes(6, nameof(Six).ToLowerInvariant());
        public static EngineCylinderTypes Eight = new EngineCylinderTypes(8, nameof(Eight).ToLowerInvariant());
        public static EngineCylinderTypes Ten = new EngineCylinderTypes(10, nameof(Ten).ToLowerInvariant());
        
        public EngineCylinderTypes(int id, string name)
            : base(id, name)
        {
        }

        public static IEnumerable<EngineCylinderTypes> List() =>
            new[] { Two, Four, Six, Eight , Ten };

        public static EngineCylinderTypes FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new VehicleAdminDomainExceptions($"Possible values for EngineCylinderTypes: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        public static EngineCylinderTypes From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new VehicleAdminDomainExceptions($"Possible values for EngineCylinderTypes: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }
    }
}
