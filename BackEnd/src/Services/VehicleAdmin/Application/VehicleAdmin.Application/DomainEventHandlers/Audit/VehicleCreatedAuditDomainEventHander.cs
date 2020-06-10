using System;
using System.Collections.Generic;
using System.Text;
using MediatR; 
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using VehicleAdmin.DomainCore.Events;

namespace VehicleAdmin.Application.DomainEventHandlers.Audit
{ 
     public class VehicleCreatedAuditDomainEventHander : INotificationHandler<VehicleCreatedAuditDomainEvent>
    { 
        private readonly ILoggerFactory _logger; 

        public VehicleCreatedAuditDomainEventHander( 
            ILoggerFactory logger  
             )
        { 
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
           
        }

        public async Task Handle(VehicleCreatedAuditDomainEvent PaymentGeneratedDomainEvent, CancellationToken cancellationToken)
        {
            _logger.CreateLogger(nameof(VehicleCreatedAuditDomainEvent))
             .LogTrace($"vehicle has been successfully created");


            //DO THIS


            //DO THAT
            

        }
    }
}

