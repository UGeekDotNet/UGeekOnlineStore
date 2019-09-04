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

            CreateMap<Category, CategoryModel>();
            CreateMap<CategoryModel, Category>()
                .ForMember(x => x.Products, y => y.Ignore());

            CreateMap<Message, MessageModel>();
            CreateMap<MessageModel, Message>()
                .ForMember(x => x.Sender, y => y.Ignore())
                .ForMember(x => x.Reciver, y => y.Ignore());

            CreateMap<Order, OrderModel>();
            CreateMap<OrderModel, Order>()
                .ForMember(x => new { x.User, x.Shipper, x.OrderDetails }, y => y.Ignore());

            CreateMap<OrderDetail, OrderDetailModel>();
            CreateMap<OrderDetailModel, OrderDetail>()
                .ForMember(x => x.Product, y => y.Ignore())
                .ForMember(x => x.Order, y => y.Ignore());


            CreateMap<Product, ProductModel>();
            CreateMap<ProductModel, Product>()
                .ForMember(x =>x.Category , y => y.Ignore())
                .ForMember(x => x.Supplier, y => y.Ignore())
                .ForMember(x => x.OrderDetails, y => y.Ignore());



            CreateMap<Role, RoleModel>();
            CreateMap<RoleModel, Role>()
                .ForMember(x => x.Users, y => y.Ignore());

            CreateMap<Supplier, SupplierModel>();
            CreateMap<SupplierModel, Supplier>()
                .ForMember(x => x.Products, y => y.Ignore());

            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>()
                .ForMember(x =>x.SendersMessages, y => y.Ignore())
                .ForMember(x => x.ReciversMessages, y => y.Ignore());



            //??????
        }
    }
}
