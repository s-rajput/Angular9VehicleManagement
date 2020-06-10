
using MediatR;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
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

    
    public class CreateVehicleCmdHandler : IRequestHandler<CreateVehicleCmd, bool>
    {
        private readonly IVehicleRepository  _Repository;

        public CreateVehicleCmdHandler(IVehicleRepository Repository)
        {
            _Repository = Repository;
        }

        /// <summary>
        /// Handler which processes the command when
        /// customer executes cancel order from app
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
       public Task<bool> Handle(CreateVehicleCmd command, CancellationToken cancellationToken) 
        {
            try
            {
                return _Repository.AddVehicle(GetVehicle(command));
            }
           catch(Exception e)
            {
                var error = e.Message;               
            }
            return Task.FromResult(false);
        }

        private Vehicle GetVehicle(CreateVehicleCmd command)
        {
            if (command.VehicleType == "Car") 
            {
                return JsonConvert.DeserializeObject<Car>(command.VehicleJsonStrObj.ToString());
            }
            else if (command.VehicleType == "Boat") 
            {
                return JsonConvert.DeserializeObject<Boat>(command.VehicleJsonStrObj.ToString());
            }

            return null;
        }
       
    }

   

}

