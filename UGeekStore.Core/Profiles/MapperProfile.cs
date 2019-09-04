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

            //Mapper.(cfg =>
            //{
            //    cfg.ConstructServicesUsing(x => x);
            //});

            CreateMap<Shipper, ShipperModel>()
                .ForMember(s => s.Mobile, d => d.MapFrom(x => x.Phone));
            CreateMap<ShipperModel, Shipper>()
                .ForMember(s => s.Orders, d => d.Ignore());

            CreateMap<CategoryModel, Category>()
                .ForMember(s => s.Products, d => d.Ignore());
            CreateMap<Category, CategoryModel>();

            CreateMap<MessageModel, Message>()
                .ForMember(s => s.Sender, d => d.Ignore())
                .ForMember(s => s.Reciver, d => d.Ignore());
            CreateMap<Message, MessageModel>();

            CreateMap<OrderModel, Order>()
               .ForMember(s => s.User, d => d.Ignore())
               .ForMember(s => s.OrderDetails, d => d.Ignore())
               .ForMember(s => s.Shipper, d => d.Ignore());
            CreateMap<Order, OrderModel>();

            CreateMap<OrderDetailModel, OrderDetail>()
               .ForMember(s => s.Product, d => d.Ignore())
               .ForMember(s => s.Order, d => d.Ignore());
            CreateMap<OrderDetail, OrderDetailModel>();

            CreateMap<ProductModel, Product>()
               .ForMember(s => s.Category, d => d.Ignore())
               .ForMember(s => s.Supplier, d => d.Ignore())
               .ForMember(s => s.OrderDetails, d => d.Ignore());
            CreateMap<Product, ProductModel>();

            CreateMap<RoleModel, Role>()
               .ForMember(s => s.Users, d => d.Ignore());
            CreateMap<Role, RoleModel >();

            CreateMap<ShipperModel, Shipper>()
               .ForMember(s => s.Orders, d => d.Ignore());
            CreateMap<Shipper, ShipperModel>();

            CreateMap<SupplierModel, Supplier>()
              .ForMember(s => s.Products, d => d.Ignore());
            CreateMap<Supplier, SupplierModel>();

            CreateMap<UserModel, User>()
              .ForMember(s => s.Orders, d => d.Ignore())
              .ForMember(s => s.Role, d => d.Ignore())
              .ForMember(s => s.ReciversMessages, d => d.Ignore())
              .ForMember(s => s.SendersMessages, d => d.Ignore());
            CreateMap<User, UserModel>();


        }
    }
}
