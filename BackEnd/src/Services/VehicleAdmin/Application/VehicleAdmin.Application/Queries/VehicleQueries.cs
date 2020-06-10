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
using VehicleAdmin.DomainCore.AggregatesModel.VehicleAggregate.Enumerations;
using VehicleAdmin.Infrastructure.Repositories;

namespace VehicleAdmin.Application.Queries
{
    public class VehicleQueries : IVehicleQueries
    {
        VehicleContext _context;
        Dictionary<VehicleTypes, Vehicle> vehicleDictionary;

        public VehicleQueries(VehicleContext context)
        {
            _context = context;
        }

       public async Task<IEnumerable<VehicleTypes>> GetVehicleTypes()
        {
            return VehicleTypes.List();
        }

        public async Task<IEnumerable<VehicleViewModel>> GetAllVehicles()
        {
            var vehicles = new List<Vehicle>();
            var lvehicle = new List<VehicleViewModel>();
            var cvehicle = new VehicleViewModel();

            vehicles.AddRange(await Task.Run(() => _context.Cars));
            vehicles.AddRange(await Task.Run(() => _context.Boats)); 

            foreach(var v in vehicles)
            {
                cvehicle = new VehicleViewModel
                {
                    Category = v.Category,
                    Make = v.Make,
                    Model = v.Model,
                    VehicleType = v.VehicleType,
                    Year = v.Year,
                    VehicleProperty = v.VehicleType.ToLower() == "car" ?
                                        "<table><tr><td><b>Car Doors: " + ((Car)v).NoOfDoors.ToString() + "</td>" +
                                        "<td><b>Car VIN: " + ((Car)v).VIN + "</b></td></tr></table>"  :
                                        "<table><tr><td><b>Boat Segment: " + ((Boat)v).Segment.ToString() + "</td>" +
                                        "<td><b>Boat HullType: " + ((Boat)v).HullType + "</b></td></tr></table>"
                };
                lvehicle.Add(cvehicle);
            }
            
            return lvehicle; 

        }

      
    }
}
