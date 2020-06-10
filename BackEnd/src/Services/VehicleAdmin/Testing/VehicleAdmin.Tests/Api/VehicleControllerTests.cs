using Moq;
using Newtonsoft.Json.Linq; 
using System.Threading.Tasks; 
using VehicleAdmin.DomainCore.AggregatesModel.VehicleAggregate;
using Microsoft.VisualStudio.TestTools.UnitTesting; 
using MediatR;
using VehicleAdmin.Application.Commands.Payments;
using VehicleAdmin.Application.Queries;
using VehicleAdmin.API.Controllers; 
using VehicleAdmin.DomainCore.AggregatesModel.CarAggregate;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace VehicleAdmin.Tests.Api
{
    [TestClass]
    public class VehicleControllerTests 
    {
         
        Mock<IVehicleRepository> moqRepo;
        Mock<IVehicleQueries> moqQueries;

        public VehicleControllerTests()
        { 
            moqRepo = new Mock<IVehicleRepository>();
            moqQueries = new Mock<IVehicleQueries>();
        }
        public void Dispose()
        {
            moqRepo = null;
            moqQueries = null;
        }
         
      
        [TestMethod]
        public async Task Mediatr_test_success()
        {
            //Assemble 
            var _mediatorMock = new Mock<IMediator>();
            var _mockCmd = new Mock<CreateVehicleCmd>();
            var ExpectedResult = true;

            //Arrange 
            var mockCmd = new CreateVehicleCmd();
            mockCmd.VehicleType = "Fake";
            mockCmd.VehicleJsonStrObj = "Invalid";

            _mediatorMock.Setup(x => x.Send(It.IsAny<CreateVehicleCmd>(), default(System.Threading.CancellationToken)))
                 .Returns(Task.FromResult(ExpectedResult));

            //Act
            var controller = new VehicleAdminController(_mediatorMock.Object, moqQueries.Object);
            var actionResult = await controller.CreateVehicleAsync(MockedObject());

            //Assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult.Result, typeof(OkObjectResult));
          
        }

        [TestMethod]
        public async Task CommandHandlerTest()
        {


            //Assemble 
            var _mediatorMock = new Mock<IMediator>();

            //Arrange
            var mockCmd = MockedCommand();
            var handler = new CreateVehicleCmdHandler(moqRepo.Object);
            var cltToken = new System.Threading.CancellationToken();

            //Act
            var result = await handler.Handle(mockCmd, cltToken);

            //Assert 
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(bool));

        }

        /// <summary>
        ///Create vehicles example
        /// </summary>  
        public JObject MockedObject()
        {             
            return JObject.FromObject(MockedCommand());
        }
        /// <summary>
        ///Mocked command
        /// </summary>  
        public CreateVehicleCmd MockedCommand()
        {
           return new
              CreateVehicleCmd
            {
                VehicleType = "Car",
                VehicleJsonStrObj = JsonConvert.SerializeObject(MockedCar()).ToString()
            }; 
        }
        /// <summary>
        ///Create vehicles example
        /// </summary>  
        public Car MockedCar()
        {
            return new Car()
            {
                NoOfDoors = 5,
                VIN = "12344ana",
                Model = "X5",
                Make = "BMW",
                Category = "Family",
                Year = 2015,
                Color = "Black",
                NoOfWheels = "4",
            };
        }

    }
}
 
