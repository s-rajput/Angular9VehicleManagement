using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAdmin.Domain.SeedWork;
using VehicleAdmin.DomainCore.AggregatesModel.BoatAggregate;
using VehicleAdmin.DomainCore.AggregatesModel.CarAggregate;
using VehicleAdmin.DomainCore.AggregatesModel.VehicleAggregate;
using VehicleAdmin.DomainCore.AggregatesModel.VehicleAggregate.Entities;
using VehicleAdmin.DomainCore.AggregatesModel.VehicleAggregate.Enumerations;

namespace VehicleAdmin.Infrastructure.Repositories
{ 
   public class VehicleRepository : IVehicleRepository
    {  
        VehicleContext  _context;        
        public VehicleRepository(VehicleContext context)
        {
            _context = context;
        }

        public async Task<bool> AddVehicle(Vehicle vehicle)
        {
            if (vehicle == null) return false;
            try
            {
                 AddVehicleTypes(vehicle);
                //save context/data store
                 await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> AddVehicles(List<Vehicle> vehicles)
        {
            if (vehicles == null || vehicles.Count == 0) return false;
            try
            {
                foreach(var v in vehicles)
                {
                    AddVehicleTypes(v);
                } 
                //save context/data store
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        private void AddVehicleTypes(Vehicle vehicle)
        {
            if(vehicle.VehicleType == "Boat") 
            { 
                _context.Add((Boat)vehicle);
            }
            else if (vehicle.VehicleType == "Car") 
            {               
                _context.Add((Car)vehicle);
            }
        }

        public async Task<Vehicle> FindVehicle(int Id)
        { 
            return  await _context.Cars. FindAsync(Id); 
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehicles()
        {

            return await Task.Run(() => _context.Cars);

        }

        public async Task<IEnumerable<Vehicle>> GetAllVehicles(VehicleTypes Type)
        {
            return await Task.Run(() => _context.Cars);
            //return await _context.Cars?.Where(x=> x.VehicleType == Type)?.ToListAsync() ?? null;
        }

       

        ////private Vehicle GetVehicleType(VehicleTypes vehicleType)
        ////{
        ////    var vehicle = vehicleDictionary[vehicleType];
        ////    return vehicle;

        ////}
    }
}
