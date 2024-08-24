namespace JangaPetStore.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string ShippingAddress { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
