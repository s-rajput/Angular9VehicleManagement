 
using MediatR;
using Newtonsoft.Json.Converters;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using VehicleAdmin.DomainCore.AggregatesModel.VehicleAggregate.Entities;
using VehicleAdmin.DomainCore.AggregatesModel.VehicleAggregate.Enumerations;

namespace VehicleAdmin.Application.Commands.Payments
{
    public class  CreateVehicleBulkCmd : IRequest<bool>
    {

        /// <summary>
        //Type of vehicles to be created - Car/Boat/All
        /// </summary>  
        [JsonConverter(typeof(StringEnumConverter))]
        [DataMember]
        public RequestType VehicleTypes { get; set; }
         
        /// <summary>
        ///Collection of vehicles in a json string obj
        /// </summary>  
        [DataMember]
        public string VehiclesJsonStrObj { get; set; }
               

    }
    public enum RequestType
    {
        Car,
        Boat,
        All
    }
   
}

