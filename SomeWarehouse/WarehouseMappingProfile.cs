using AutoMapper;
using SomeWarehouse.Models;
using SomeWarehouse.WarehouseDB;

namespace SomeWarehouse
{
    public class WarehouseMappingProfile : Profile
    {
        public WarehouseMappingProfile()
        {
            CreateMap<Warehouse, WarehouseDto>()
                

                .ForMember(m => m.numberOfShelf, c => c.MapFrom(s => s.Shelf.numberOfShelf));

            CreateMap<Alloy, AlloyDto>();

            CreateMap<CreateWarehouseDto, Warehouse>()
                .ForMember(r => r.Shelf, c=> c.MapFrom(dto => new Shelf() { numberOfShelf = dto.numberOfShelf}));
            
        }
    }
}
