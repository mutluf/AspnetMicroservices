using Basket.API.Entities;
using Basket.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Basket.API.Controllers
{
    [Route("api/v1/basket")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;
        private readonly ILogger<BasketController> _logger;
        public BasketController(IBasketRepository basketRepository, ILogger<BasketController> logger)
        {
            _basketRepository = basketRepository;
            _logger = logger;
        }

        [HttpGet("{username}")]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> Get(string username)
        {
            var basket = await _basketRepository.GetBasketAsync(username);
            return Ok(basket ?? new ShoppingCart(username));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> Update([FromBody] ShoppingCart basket)
        {
            basket = await _basketRepository.UpdateBasketAsync(basket);
            return Ok(basket);
        }

        [HttpDelete("{username}")]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> Delete(string username)
        {
            await _basketRepository.DeleteBasketAsync(username);
            return Ok();
        }
    }
}
