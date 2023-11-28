using Discount.Grpc.Protos;

namespace Basket.API.GrpcServices
{
    public class DiscountGrpcService
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _grpcClient;

        public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient grpcClient)
        {
            _grpcClient = grpcClient;
        }

        public async Task<CouponModel> GetDiscountAsync(string productName)
        {
            GetDiscountRequest discountRequest = new() { ProductName = productName };

            return await _grpcClient.GetDiscountAsync(discountRequest);
        }
    }
}
