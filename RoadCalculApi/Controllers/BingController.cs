﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoadCalculModel;
using RoadCalculServices.Interface;
using RoadCalculServiceTest;

namespace RoadCalculApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BingController : ControllerBase
    {
        private readonly IBingService BingService;
        public BingController(IBingService bingService)
        {
            this.BingService = bingService;
        }

        [HttpGet("/GetCoordonate/{querryAdress}")]
        public async Task<IActionResult> GetCoordonate(string querryAdress)
        {
            try
            {
                var result = await BingService.GetLocationAsync(querryAdress);
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
                var result = await BingService.DistanceMatrixAsync(value);
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
