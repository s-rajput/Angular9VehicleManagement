using FluentValidation; 
using VehicleAdmin.Application.Commands.Payments;
using System;
using System.Collections.Generic;
using System.Linq; 

namespace VehicleAdmin.API.Application.Validations
{
    public class CreateVehicleCmdValidator : AbstractValidator<CreateVehicleCmd>
    {
        public CreateVehicleCmdValidator()
        {

            RuleFor(command => command.VehicleJsonStrObj).NotEmpty();

            RuleFor(command => command.VehicleType ).NotNull();
        }

        private bool BeValidExpirationDate(DateTime dateTime)
        {
            return dateTime >= DateTime.UtcNow;
        }


    }
}
