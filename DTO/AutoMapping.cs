

using AutoMapper;
using Shop.DAL.Entities;

//using Shop.DAL.Entities;
using Shop.DTO.Mapper;
using System.Diagnostics.Contracts;

namespace Shop.DTO
{
    public class AutoMapping : Profile
    {
    public AutoMapping()
    {

            CreateMap<User, UserDTO>();
            CreateMap<Order, OrderDTO>();
            CreateMap<Product, ProductDTO>();
            //CreateMap<User, UserLoginDTO>();
            //CreateMap<OrdersProduct, OrdersProductDTO>();


            CreateMap<UserDTO, User>();
            CreateMap<OrderDTO, Order>();
            CreateMap<ProductDTO, Product>();
            //CreateMap<UserLoginDTO, User>();
            //CreateMap<OrdersProductDTO, OrdersProduct>();

        }

    }
}
