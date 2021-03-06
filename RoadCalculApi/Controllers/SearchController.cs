﻿using Microsoft.AspNetCore.Mvc;
using RoadCalculModel.DataBase;
using RoadCalculServices.Public.Interface;
using System;
using System.Threading.Tasks;


namespace RoadCalculApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IBusinessService Service;
        public SearchController(IBusinessService service)
        {
            this.Service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await this.Service.Search.GetAllSearch();
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

        [HttpPost("/Search/Add")]
        public async Task<IActionResult> Add([FromBody] SearchHistorique value)
        {
            try
            {
                var result = await this.Service.Search.Add(value);
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

        [HttpPost("Search/Update")]
        public async Task<IActionResult> Update([FromBody] SearchHistorique value)
        {
            try
            {
                var result = await this.Service.Search.Update(value);
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
