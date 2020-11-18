using Microsoft.AspNetCore.Mvc;
using RoadCalculModel;
using RoadCalculServices.Public.Interface;
using System;
using System.Threading.Tasks;

namespace RoadCalculApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BingController : ControllerBase
    {
        private readonly IBusinessService Service;
        public BingController(IBusinessService service)
        {
            this.Service = service;
        }

        [HttpGet("/GetCoordonate/{querryAdress}")]
        public async Task<IActionResult> GetCoordonate(string querryAdress)
        {
            try
            {
                var result = await Service.Bing.GetLocationAsync(querryAdress);
                if (result == null)
                {
                    return Ok(new { succes = false, description = "" });
                }
                else
                {
                    return Ok(new { succes = true, data = result, description = "" });
                }

            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                {
                    return Ok(new { succes = false, description = ex.Message });
                }
                else
                {
                    return Ok(new { succes = false, description = ex.InnerException });
                }
            }

        }

        [HttpPost("/CalculDistance")]
        public async Task<IActionResult> CalculDistance([FromBody] Route value)
        {
            try
            {
                var result = await Service.Bing.DistanceMatrixAsync(value);
                if (result == null)
                {
                    return Ok(new { succes = false, description = "" });
                }
                else
                {
                    return Ok(new { succes = true, data = result, description = "" });
                }

            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                {
                    return Ok(new { succes = false, description = ex.Message });
                }
                else
                {
                    return Ok(new { succes = false, description = ex.InnerException });
                }
            }
        }
    }
}
