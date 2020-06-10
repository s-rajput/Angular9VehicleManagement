using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleAdmin.DomainCore.Exceptions
{ 
    /// <summary>
    /// Exception type for domain exceptions
    /// </summary>
    public class VehicleAdminDomainExceptions : Exception
    {
        public VehicleAdminDomainExceptions()
        { }

        public VehicleAdminDomainExceptions(string message)
            : base(message)
        { }

        public VehicleAdminDomainExceptions(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
