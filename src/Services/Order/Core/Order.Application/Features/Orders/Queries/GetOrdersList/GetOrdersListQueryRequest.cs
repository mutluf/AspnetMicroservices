using MediatR;

namespace Order.Application.Features.Orders.Queries.GetOrdersList
{
    public class GetOrdersListQueryRequest : IRequest<List<OrderVM>>
    {
        public string UserName { get; set; }

        public GetOrdersListQueryRequest(string userName)
        {
            UserName = userName;
        }
    }
}
