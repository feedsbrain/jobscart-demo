using AutoMapper;
using JobsCart.DTOs;
using JobsCart.Models;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Customer, CustomerDto>();
        CreateMap<CustomerDto, Customer>();
        CreateMap<Order, CheckoutDto>();
        CreateMap<CheckoutDto, Order>();
        CreateMap<OrderDetail, CheckoutDetailDto>();
        CreateMap<CheckoutDetailDto, OrderDetail>();
    }
}