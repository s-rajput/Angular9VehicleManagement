using System.Linq;
using System.Reflection;
using Autofac; 
using FluentValidation;
using MediatR;
using VehicleAdmin.API.Application.Validations;
using VehicleAdmin.Application.Behaviors;
using VehicleAdmin.Application.Commands.Payments;
using VehicleAdmin.Application.DomainEventHandlers.Audit; 
using VehicleAdmin.Infrastructure.Repositories;
using VehicleAdmin.DomainCore.AggregatesModel.VehicleAggregate;

namespace VehicleAdmin.API.Infrastructure.AutofacModules
{
    /// <summary>
    ///Registering all mediatr commands
    /// </summary>  
    public class MediatorModule : Autofac.Module
    {
        /// <summary>
        ///registering dependencies
        /// </summary>  
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();
                       
             

            // Register all the Command classes (they implement IRequestHandler) in assembly holding the Commands
            builder.RegisterAssemblyTypes(typeof(CreateVehicleCmd).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            // Register all the Command classes (they implement IRequestHandler) in assembly holding the Commands
            builder.RegisterAssemblyTypes(typeof(CreateVehicleBulkCmd).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            // Register the DomainEventHandler classes (they implement INotificationHandler<>) in assembly holding the Domain Events
            builder.RegisterAssemblyTypes(typeof(VehicleCreatedAuditDomainEventHander).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(INotificationHandler<>));

            // Register the Command's Validators (Validators based on FluentValidation library)
            builder
                .RegisterAssemblyTypes(typeof(CreateVehicleCmdValidator).GetTypeInfo().Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
                .AsImplementedInterfaces();


            builder.Register<ServiceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();
                return t => { object o; return componentContext.TryResolve(t, out o) ? o : null; };
            });

            //services.AddScoped(typeof(IUniversityRepository), typeof(UniversitySqlServerRepository));

            //register behaviors
            builder.RegisterGeneric(typeof(LoggingBehavior<,>)).As(typeof(IPipelineBehavior<,>));  //logging
            builder.RegisterGeneric(typeof(ValidatorBehavior<,>)).As(typeof(IPipelineBehavior<,>));  //validator


            //APPLICATION MODULES
             

            builder.RegisterType<VehicleRepository>()
                  .As<IVehicleRepository>()
                  .InstancePerLifetimeScope();
             

        }


    }
}


