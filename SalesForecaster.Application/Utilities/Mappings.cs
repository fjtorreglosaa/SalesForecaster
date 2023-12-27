using AutoMapper;
using SalesForecaster.Application.Utilities.Dtos.Employee;
using SalesForecaster.Application.Utilities.Dtos.Order;
using SalesForecaster.Application.Utilities.Dtos.OrderDetail;
using SalesForecaster.Application.Utilities.Dtos.Product;
using SalesForecaster.Application.Utilities.Dtos.Shipper;
using SalesForecaster.Domain.Models;

namespace SalesForecaster.Application.Utilities
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<OrderModel, GetOrderDto>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.OrderId))
                .ForMember(dest => dest.requireddate, opt => opt.MapFrom(src => src.RequiredDate))
                .ForMember(dest => dest.shippeddate, opt => opt.MapFrom(src => src.ShippedDate))
                .ForMember(dest => dest.shipname, opt => opt.MapFrom(src => src.ShipName))
                .ForMember(dest => dest.shipaddress, opt => opt.MapFrom(src => src.ShipAddress))
                .ForMember(dest => dest.shipcity, opt => opt.MapFrom(src => src.ShipCity))
                .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails))
                .ReverseMap();

            CreateMap<OrderDetailModel, GetOrderDetailDto>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice))
                .ForMember(dest => dest.Qty, opt => opt.MapFrom(src => src.Qty))
                .ForMember(dest => dest.Discount, opt => opt.MapFrom(src => src.Discount))
                .ReverseMap();

            CreateMap<EmployeeModel, GetEmployeeDto>()
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.Empid))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.Firstname} {src.Lastname}"))
                .ReverseMap();

            CreateMap<ProductModel, GetProductDto>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
                .ReverseMap();

            CreateMap<ShipperModel, GetShipperDto>()
                .ForMember(dest => dest.ShipperId, opt => opt.MapFrom(src => src.ShipperId))
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.CompanyName))
                .ReverseMap();

            CreateMap<NextOrderModel, NextOrderDto>()
                .ForMember(dest => dest.custid, opt => opt.MapFrom(src => src.CustId))
                .ForMember(dest => dest.customername, opt => opt.MapFrom(src => src.CompanyName))
                .ForMember(dest => dest.lastorderdate, opt => opt.MapFrom(src => src.LatestOrderDate))
                .ForMember(dest => dest.nextpredictedorder, opt => opt.MapFrom(src => src.NextPredictedOrder))
                .ReverseMap();


            CreateMap<EmployeeModel, GetEmployeeDto> ()
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.Empid))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Firstname))
                .ReverseMap();
        }
    }
}
