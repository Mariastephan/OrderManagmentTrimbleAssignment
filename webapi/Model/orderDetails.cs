using System.ComponentModel.DataAnnotations;

namespace orderManagement.webApi.Model
{
    public class OrderDetails
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public decimal OrderAmount { get; set; }
        public string Vendor { get; set; }
        public string Shop { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
