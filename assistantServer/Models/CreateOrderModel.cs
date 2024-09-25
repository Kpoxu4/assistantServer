namespace assistantServer.Models
{
    public class CreateOrderModel
    {
        public string FirstLastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public int AdvancePayment { get; set; }
        public int ProductionTime { get; set; }
    }
}
