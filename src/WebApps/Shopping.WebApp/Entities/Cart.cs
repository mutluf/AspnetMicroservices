
namespace Shopping.WebApp.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public double TotalPrice
        {
            get
            {
                double totalprice = 0;
                foreach (var item in Items)
                {
                    totalprice += item.Price * item.Quantity;
                }

                return totalprice;
            }
        }
    }
}
