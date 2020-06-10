using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleAdmin.Application.Commands.Payments;
using VehicleAdmin.Application.Queries; 
using Swashbuckle.AspNetCore.Filters;
using VehicleAdmin.DomainCore.AggregatesModel.VehicleAggregate.Enumerations;
using Newtonsoft.Json; 
using VehicleAdmin.Domain.SeedWork;
using VehicleAdmin.DomainCore.AggregatesModel.CarAggregate;
using VehicleAdmin.DomainCore.AggregatesModel.BoatAggregate;
using VehicleAdmin.Application.Commands.CreateVehicle;
using VehicleAdmin.DomainCore.AggregatesModel.VehicleAggregate;
using Newtonsoft.Json.Linq;

namespace VehicleAdmin.API.Controllers
{

    /// <summary>
    ///Vehicles administration
    /// </summary>  
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class VehicleAdminController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IVehicleQueries _queries;

        /// <summary>
        ///Ping function
        /// </summary>  
        // GET api/values
        [Route("Ping")]
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return  new string[] { "Ping successfull " + DateTime.Now.ToString() };
        }

        /// <summary>
        ///Constructor injection
        /// </summary>  
        public VehicleAdminController(IMediator mediator, IVehicleQueries queries)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _queries = queries;
        }

        /// <summary>
        ///Create Bulk vehicles
        /// </summary>  
        [Route("addvehicles")]
        [HttpPost]
        public async Task<ActionResult<bool>> CreateVehiclesAsync([FromBody] CreateVehicleBulkCmd cmd)
        {
            return await _mediator.Send(cmd);
        }


        /// <summary>
        ///Create a new vehicles
        /// </summary>  
        [Route("addvehicle")]
        [HttpPost]
        [SwaggerRequestExample(typeof(string), typeof(VehicleExample))]
        [ProducesResponseType(typeof(List<VehicleViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<VehicleViewModel>>> CreateVehicleAsync([FromBody] JObject vehicle)
        {
            var cmd = JsonConvert.DeserializeObject<CreateVehicleCmd>(vehicle.ToString());

            var success= await _mediator.Send(cmd);

            var vehicles = await _queries.GetAllVehicles();

            return Ok(vehicles);
        }

        /// <summary>
        ///Get all the vehicles
        /// </summary>  
        [Route("getvehicles")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Vehicle>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<Vehicle>>> GetAllVehiclesAsync()
        {
            var vehicles = await _queries.GetAllVehicles();

            return Ok(vehicles);

        }

        /// <summary>
        ///Get all vehicle types
        /// </summary>  
        [Route("getvehicletypes")]
        [HttpGet]
        [ProducesResponseType(typeof(List<VehicleTypes>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<VehicleTypes>>> GetAllVehicleTypesAsync()
        {
            var vehicles = await _queries.GetAllVehicles();

            return Ok(vehicles);

        }

    }

    /// <summary>
    ///Vehicle create sample
    /// </summary>  
    public class VehicleExample : IExamplesProvider<JObject>
    {
        /// <summary>
        ///Create vehicles example
        /// </summary>  
        public JObject GetExamples()
        {
            var car = new Car(); 
            car.NoOfDoors = 5; 
            car.VIN = "12344ana";
            car.Model = "X5";
            car.Make = "BMW";
            car.Category = "Family"; 
            car.Year = 2015;
            car.Color = "Black"; 
            car.NoOfWheels = "4";  

            var cmd = new
              CreateVehicleCmd
            {
                VehicleType = "Car", 

                VehicleJsonStrObj = JsonConvert.SerializeObject(car).ToString()
            };


            return JObject.FromObject(cmd); 
        }
    }

    /// <summary>
    ///Create Bulk vehicles sample
    /// </summary>  
    public class CreateVehicleBulkCmdExample : IExamplesProvider<CreateVehicleBulkCmd>
    {

        /// <summary>
        ///Create Bulk vehicles example
        /// </summary>  
        public CreateVehicleBulkCmd GetExamples()
        {
            var car = new Car(); 
            car.NoOfDoors = 5;  
            car.VIN = "12344ana";
            car.Model = "X5";
            car.Make = "BMW";
            car.Category = "Family"; 
            car.Year = 2015;
            car.Color = "Black";  
            car.NoOfWheels = "Four"; 
            var boat = new Boat();
            boat.HullType = "Mono"; 
            boat.Segment = "Power"; 
            boat.Model = "X8J";
            boat.Make = "Honda";
            boat.Category = "Cruising"; 
            boat.Year = 2016;
            boat.Color = "White"; 
            boat.NoOfWheels = "None"; 

            var vehicles = new List<VehiclesToCreate>();
            var createvehicle = new VehiclesToCreate();
            createvehicle.VehicleType = VehicleTypes.Car;
            createvehicle.VehicleJsonStrObj = JsonConvert.SerializeObject(car).ToString();
            vehicles.Add(createvehicle);

            createvehicle = new VehiclesToCreate();
            createvehicle.VehicleType = VehicleTypes.Boat;
            createvehicle.VehicleJsonStrObj = JsonConvert.SerializeObject(boat).ToString();
            vehicles.Add(createvehicle);


            return new
                CreateVehicleBulkCmd
            {
                VehicleTypes = RequestType.All,

                VehiclesJsonStrObj = JsonConvert.SerializeObject(vehicles).ToString()
            };

        }
    }
    }


