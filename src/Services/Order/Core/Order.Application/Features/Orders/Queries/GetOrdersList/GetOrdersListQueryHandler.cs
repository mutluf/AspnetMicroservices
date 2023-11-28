using AutoMapper;
using MediatR;
using Order.Application.Contracts.Persistence;

namespace Order.Application.Features.Orders.Queries.GetOrdersList
{
    public class GetOrdersListQueryHandler : IRequestHandler<GetOrdersListQueryRequest, List<OrderVM>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrdersListQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<List<OrderVM>> Handle(GetOrdersListQueryRequest request, CancellationToken cancellationToken)
        {
            var orderList = await _orderRepository.GetOrdersByUserNameAsync(request.UserName);

            var orders = _mapper.Map<List<OrderVM>>(orderList);

            return orders;
        }
    }
}
