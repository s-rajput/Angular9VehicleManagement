using Moq;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
//using Xunit;

using VehicleAdmin.DomainCore.AggregatesModel.VehicleAggregate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VehicleAdmin.Infrastructure.Repositories;
using MediatR;
using VehicleAdmin.Application.Commands.Payments;
using VehicleAdmin.Application.Queries;
using VehicleAdmin.API.Controllers;
using System.Linq;
using VehicleAdmin.DomainCore.AggregatesModel.CarAggregate;
using Newtonsoft.Json;
using VehicleAdmin.Domain.SeedWork;

namespace VehicleAdmin.Tests.Api
{
    [TestClass]
    public class InfrastructureTests 
    {

        Mock<IVehicleRepository> moqRepo; 

        public InfrastructureTests()
        { 
            moqRepo = new Mock<IVehicleRepository>(); 
        }
        public void Dispose()
        {
            moqRepo = null; 
        }
         

        [TestMethod]
        public async Task GetVehiclesTest()
        {
             
            //Act
            var result = await moqRepo.Object.GetAllVehicles();

            //Assert 
            Assert.IsInstanceOfType(result, typeof(IEnumerable<Vehicle>));
             
        }


    }
}
 
