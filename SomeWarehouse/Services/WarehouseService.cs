using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SomeWarehouse.Models;
using SomeWarehouse.WarehouseDB;


namespace SomeWarehouse.Services
{
    public interface IWarehouseService
    {
        int Create(CreateWarehouseDto createDto);
        IEnumerable<WarehouseDto> GetAll(); 
        WarehouseDto GetById(int id);
        bool Delete(int id);
    }

    public class WarehouseService : IWarehouseService
    {
        private readonly WarehoudeDbContext _dbContext;
        private readonly IMapper _mapper;

        public WarehouseService(WarehoudeDbContext dbcontext, IMapper mapper)
        {
            _dbContext = dbcontext;
            _mapper = mapper;
        }

        public bool Delete(int id)
        {
            var warehouse = _dbContext
                .Warehouses
                .FirstOrDefault(w => w.Id == id);

            if (warehouse is null) return false;

            _dbContext.Warehouses .Remove(warehouse);
            _dbContext.SaveChanges();
            return true;
                

        }
        public WarehouseDto GetById(int id)
        {
            var warehouse = _dbContext
                .Warehouses
                .FirstOrDefault(w => w.Id == id);

            if (warehouse == null) return null;

            var result = _mapper.Map<WarehouseDto>(warehouse);
            return result;
            

        }
        public IEnumerable<WarehouseDto> GetAll()
        {
            var warehouse = _dbContext
                .Warehouses
                .ToList();
            var warethousesDtos = _mapper.Map<List<WarehouseDto>>(warehouse);
            return warethousesDtos;
        }

        public int Create(CreateWarehouseDto createDto)
        {
            var warehouse = _mapper.Map<Warehouse>(createDto);
            _dbContext.Warehouses.Add(warehouse);
            _dbContext.SaveChanges();

            return warehouse.Id;
        }

    }
}
