

using FindIt.Domain.Common;

namespace FindIt.Domain
{
    public class Order : BaseEntity
    {
        public string BuyerEmail { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public string Status { get; set; } = null!;
        public Decimal SubTotal { get; set; }
        public string PaymentIntentId { get; set; } = null!;
        public long OrderDeliveryMethodId { get; set; }
       // public required OrderDeliveryMethods OrderDeliveryMethods { get; set; }

        //public virtual ICollection<OrderItem> OrderItems { get; set; } = null!;
        public ShippingAddress ShippingAddress { get; set; }


    }
}
