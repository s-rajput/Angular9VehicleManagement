

namespace VehicleAdmin.API.Infrastructure.ActionResults
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    ///internal server error status codes
    /// </summary>  
    public class InternalServerErrorObjectResult : ObjectResult
    {
        /// <summary>
        ///custom status codes
        /// </summary>  
        public InternalServerErrorObjectResult(object error)
            : base(error)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}