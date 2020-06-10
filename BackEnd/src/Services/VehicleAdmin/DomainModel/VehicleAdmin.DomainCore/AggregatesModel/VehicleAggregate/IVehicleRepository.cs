using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleAdmin.Domain.SeedWork;
using VehicleAdmin.DomainCore.AggregatesModel.VehicleAggregate.Enumerations;
using VehicleAdmin.DomainCore.SeedWork;

namespace VehicleAdmin.DomainCore.AggregatesModel.VehicleAggregate
{ 
    public interface IVehicleRepository // : IRepository<Vehicle>
    {
        Task<bool> AddVehicles(List<Vehicle> buyer);
        Task<bool> AddVehicle(Vehicle buyer); 
        Task<Vehicle> FindVehicle(int id);
        Task<IEnumerable<Vehicle>> GetAllVehicles();
        Task<IEnumerable<Vehicle>> GetAllVehicles(VehicleTypes Type); 

    }
}
