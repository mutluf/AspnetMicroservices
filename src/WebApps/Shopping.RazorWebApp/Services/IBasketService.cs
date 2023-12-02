using Shopping.RazorWebApp.Models;

namespace Shopping.RazorWebApp.Services
{
    public interface IBasketService
    {
        Task<BasketModel> GetBasketAsync(string userName);
        Task<BasketModel> UpdateBasketAsync(BasketModel model);
        Task CheckoutBasket(BasketCheckoutModel model);
    }
}
