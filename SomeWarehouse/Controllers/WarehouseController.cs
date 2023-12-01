using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SomeWarehouse.Models;
using SomeWarehouse.WarehouseDB;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace SomeWarehouse.Controllers
{
    [Route("api/warehouse")]
    public class WarehouseController : ControllerBase
    {
        private readonly WarehoudeDbContext _dbContext;
        private readonly IMapper _mapper;

        public WarehouseController(WarehoudeDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            
        }
        [HttpPost]
        public ActionResult CreateWarehouse([FromBody] CreateWarehouseDto dto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var warehouse = _mapper.Map<Warehouse>(dto);
            _dbContext.Warehouses.Add(warehouse);
            _dbContext.SaveChanges();

            return Created($"/api/warehouse/{warehouse.Id}",null);

        }

        [HttpGet("generate")]
        public ActionResult<IEnumerable<WarehouseFeeder>> Feed()
        {
            
            return Ok();
        }

        [HttpGet("getwarehouse")]
        public ActionResult<IEnumerable<WarehouseDto>> GetAll()
        {
            var warehausone = _dbContext
                
                .Warehouses
                .ToList();

            var warehouseDto = _mapper.Map<WarehouseDto>(warehausone);


            return Ok(warehausone);
        }

        [HttpGet("{id}")]

        public ActionResult<WarehouseDto> Get([FromRoute] int id)
        {
            var warehouse = _dbContext
                
                
                .Warehouses
                .FirstOrDefault(w => w.Id == id);
            if(warehouse == null)
            {
                return NotFound("NIe ma zodnygo detabesa");
            }
            var warehouseDto = _mapper.Map<WarehouseDto>(warehouse);
            return Ok(warehouse);
        }
    }
}
