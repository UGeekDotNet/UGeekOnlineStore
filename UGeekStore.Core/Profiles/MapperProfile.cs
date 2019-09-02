using UGeekStore.Core.Models;
using UGeekStore.DAL.Entities;
using AutoMapper;
namespace UGeekStore.Core.Profiles
{
    public class MapperProfile : AutoMapper.Profile
    {
        public MapperProfile()
        {

            //Mapper.(cfg =>
            //{
            //    cfg.ConstructServicesUsing(x => x);
            //});

            CreateMap<Shipper, ShipperModel>()
                .ForMember(s => s.Mobile, d => d.MapFrom(x => x.Phone));

            CreateMap<ShipperModel, Shipper>()
                .ForMember(s => s.Orders, d => d.Ignore());
        }
    }
}
