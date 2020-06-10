
using MediatR;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VehicleAdmin.Application.Commands.CreateVehicle;
using VehicleAdmin.Domain.SeedWork;
using VehicleAdmin.DomainCore.AggregatesModel.BoatAggregate;
using VehicleAdmin.DomainCore.AggregatesModel.CarAggregate; 
using VehicleAdmin.DomainCore.AggregatesModel.VehicleAggregate;
using VehicleAdmin.DomainCore.AggregatesModel.VehicleAggregate.Entities;
using VehicleAdmin.DomainCore.AggregatesModel.VehicleAggregate.Enumerations;

namespace VehicleAdmin.Application.Commands.Payments
{

    
    public class CreateVehicleBulkCmdHandler : IRequestHandler<CreateVehicleBulkCmd, bool>
    {
        private readonly IVehicleRepository  _Repository;

        public CreateVehicleBulkCmdHandler(IVehicleRepository Repository)
        {
            _Repository = Repository;
        }

        /// <summary>
        /// Handler which processes the command when
        /// customer executes cancel order from app
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
       public Task<bool> Handle(CreateVehicleBulkCmd command, CancellationToken cancellationToken) 
        {
             
            return _Repository.AddVehicles(GetVehicles(command));  
        }

        private List<Vehicle> GetVehicles(CreateVehicleBulkCmd command)
        {
            var vehiclesToCreate = JsonConvert.DeserializeObject<List<VehiclesToCreate>>(command.VehiclesJsonStrObj.ToString());
            var vehicles = new List<Vehicle>();
            foreach (var v in vehiclesToCreate)
            {
                if (v.VehicleType.Name.ToLower().Equals("car"))
                {
                    vehicles.Add(JsonConvert.DeserializeObject<Car>(v.VehicleJsonStrObj.ToString()));
                }
                else if (v.VehicleType.Name.ToLower().Equals("boat"))
                {
                    vehicles.Add(JsonConvert.DeserializeObject<Boat>(v.VehicleJsonStrObj.ToString()));
                }
            }
            return vehicles;
        }

       
    }

   

}

