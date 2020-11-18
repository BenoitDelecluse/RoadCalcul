using Microsoft.AspNetCore.Mvc;
using RoadCalculModel.DataBase;
using RoadCalculServices.Public.Interface;
using System;
using System.Threading.Tasks;

namespace RoadCalculApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        private readonly IBusinessService Service;
        public RoutesController(IBusinessService service)
        {
            this.Service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await this.Service.Route.GetAll();
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

        [HttpPost("/Route/Add")]
        public async Task<IActionResult> Add([FromBody] CalculDistanceHistorique value)
        {
            try
            {
                var result = await this.Service.Route.Add(value);
                if (result == false)
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

        [HttpPost("/Route/Update")]
        public async Task<IActionResult> Update([FromBody] CalculDistanceHistorique value)
        {
            try
            {
                var result = await this.Service.Route.Update(value);
                if (result == false)
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
