using UGeekStore.Core.Models;
using UGeekStore.DAL.Entities;
using AutoMapper;
using UGeekStore.Core.Entities;

namespace UGeekStore.Core.Profiles
{
    public class MapperProfile : AutoMapper.Profile
    {
        public MapperProfile()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.ConstructServicesUsing(x => x);
            });

            CreateMap<Shipper, ShipperModel>()
                .ForMember(s => s.Mobile, d => d.MapFrom(x => x.Phone));
            CreateMap<ShipperModel, Shipper>()
                .ForMember(s => s.Orders, d => d.Ignore());

            CreateMap<SupplierModel, Supplier>()
                .ForMember(x => x.Products, x => x.Ignore());
            CreateMap<Supplier, SupplierModel>();

            CreateMap<CategoryModel, Category>()
                .ForMember(x => x.Products, x => x.Ignore());
            CreateMap<Category, CategoryModel>();

            CreateMap<MessageModel, Message>()
                .ForMember(x =>x.Sender, x => x.Ignore())
                .ForMember(x =>x.Reciver, x => x.Ignore());
            CreateMap<Message, MessageModel>();

            CreateMap<UserModel, Order>()
                .ForMember(x => x.User, x => x.Ignore())
                .ForMember(x => x.OrderDetails, x => x.Ignore())
                .ForMember(x => x.Shipper, x => x.Ignore());
            CreateMap<Order, UserModel>();

            CreateMap<OrderDetailModel, OrderDetail>()
                .ForMember(x => x.Product, x => x.Ignore())
                .ForMember(x => x.Order, x => x.Ignore());
            CreateMap<OrderDetail, OrderDetailModel>();

            CreateMap<ProductModel, Product>()
                .ForMember(x => x.Category, x => x.Ignore())
                .ForMember(x => x.Suplier, x => x.Ignore())
                .ForMember(x => x.OrderDetails, x => x.Ignore());
            CreateMap<Product, ProductModel>();

            CreateMap<RoleModel, Role>()
                .ForMember(x => x.Users, x => x.Ignore());
            CreateMap<Role, RoleModel>();

            CreateMap<UserModel, User>()
                .ForMember(x => x.Orders, x => x.Ignore())
                .ForMember(x => x.Role, x => x.Ignore())
                .ForMember(x => x.SendersMessages, x => x.Ignore())
                .ForMember(x => x.ReciversMessages, x => x.Ignore());
            CreateMap<User, UserModel>();
        }
    }
}
