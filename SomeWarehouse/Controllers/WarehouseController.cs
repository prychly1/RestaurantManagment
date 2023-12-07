using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SomeWarehouse.Models;
using SomeWarehouse.WarehouseDB;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SomeWarehouse.Services;

namespace SomeWarehouse.Controllers
{
    [Route("api/warehouse")]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;

        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
            
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id) 
        {
            var IsDeleted = _warehouseService.Delete(id);
            
            if(IsDeleted)
            {
                return NoContent();
            }

            return NotFound();

        }

        [HttpPost("dodaj")] //nie działa, bład 500
        public ActionResult CreateWarehouse([FromBody] CreateWarehouseDto dto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var id = _warehouseService.Create(dto);

            return Created($"/api/warehouse/{id}", null);
        }

        [HttpGet("generate")]
        public ActionResult<IEnumerable<WarehouseFeeder>> Feed()
        {
            
            return Ok();
        }

        [HttpGet("getwarehouse")] //działa
        public ActionResult<IEnumerable<WarehouseDto>> GetAll()
        {
            var warehouse = _warehouseService.GetAll();


            return Ok(warehouse);
        }

        [HttpGet("{id}")]

        public ActionResult<WarehouseDto> Get([FromRoute] int id)
        {
            var warehouse = _warehouseService.GetById(id);
            if(warehouse is null)
            {
                return NotFound("NIe ma zodnygo detabesa");
            }
            
            return Ok(warehouse);
        }
    }
}
