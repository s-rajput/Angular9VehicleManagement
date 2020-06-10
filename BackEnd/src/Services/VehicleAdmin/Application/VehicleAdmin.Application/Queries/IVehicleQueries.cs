using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleAdmin.Domain.SeedWork;
using VehicleAdmin.DomainCore.AggregatesModel.VehicleAggregate;
using VehicleAdmin.DomainCore.AggregatesModel.VehicleAggregate.Enumerations;

namespace VehicleAdmin.Application.Queries
{ 
   public interface IVehicleQueries
    {
        Task<IEnumerable<VehicleViewModel>> GetAllVehicles();

        Task<IEnumerable<VehicleTypes>> GetVehicleTypes();
    }
}
