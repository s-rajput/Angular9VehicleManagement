using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleAdmin.Domain.SeedWork;
using VehicleAdmin.DomainCore.AggregatesModel.BoatAggregate;
using VehicleAdmin.DomainCore.AggregatesModel.CarAggregate;
using VehicleAdmin.DomainCore.AggregatesModel.VehicleAggregate; 
using VehicleAdmin.DomainCore.AggregatesModel.VehicleAggregate.Enumerations;

namespace VehicleAdmin.Infrastructure.Repositories
{ 
   public class VehicleContext : DbContext
    {
        private readonly IMediator _mediator;
        public VehicleContext(DbContextOptions<VehicleContext> options) : base(options) { }
        //public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Boat> Boats { get; set; } 

        public VehicleContext(DbContextOptions<VehicleContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


            System.Diagnostics.Debug.WriteLine("VehicleContext::ctor ->" + this.GetHashCode());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {      

        }
    }
}
