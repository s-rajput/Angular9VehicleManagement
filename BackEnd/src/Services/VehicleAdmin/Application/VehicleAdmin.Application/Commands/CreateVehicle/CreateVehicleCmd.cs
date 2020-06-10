 
using MediatR;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Runtime.Serialization;
using VehicleAdmin.Application.Queries;
using VehicleAdmin.DomainCore.AggregatesModel.VehicleAggregate.Entities;
using VehicleAdmin.DomainCore.AggregatesModel.VehicleAggregate.Enumerations;

namespace VehicleAdmin.Application.Commands.Payments
{
    public class  CreateVehicleCmd : IRequest<bool>
    {

        /// <summary>
        ///Type of vehicle - car/boat/truck
        /// </summary>   
        [DataMember]
        public string VehicleType { get; set; }

        /// <summary>
        ///Vehicle obj in a json string to be created
        /// </summary>
        [DataMember]
        public string VehicleJsonStrObj { get; set; }
         

    }
   
   
}

