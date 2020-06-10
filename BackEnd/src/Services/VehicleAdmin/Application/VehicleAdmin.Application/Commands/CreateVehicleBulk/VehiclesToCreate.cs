using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using VehicleAdmin.DomainCore.AggregatesModel.VehicleAggregate.Enumerations;

namespace VehicleAdmin.Application.Commands.CreateVehicle
{
     
    public class VehiclesToCreate
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [DataMember]
        public VehicleTypes VehicleType { get; set; }

        /// <summary>
        ///Collection of vehicles in a json string obj
        /// </summary>  
        [DataMember]
        public string VehicleJsonStrObj { get; set; }

    }
}
