using AutoMapper;
using Order.Application.Features.Orders.Commands.CheckoutOrder;
using Order.Application.Features.Orders.Commands.UpdateOrder;
using Order.Application.Features.Orders.Queries.GetOrdersList;

namespace Order.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderVM, Domain.Entities.Order>().ReverseMap();
            CreateMap<CheckoutOrderCommandRequest, Domain.Entities.Order>().ReverseMap();
            CreateMap<UpdateOrderCommandRequest, Domain.Entities.Order>().ReverseMap();
        }
    }
}
