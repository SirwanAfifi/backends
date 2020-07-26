namespace polymorphic_join.Models
{
    public class Order
    {
        public int Id { get; set; }
        public OrderType TargetType { get; set; }
        public int? TargetId { get; set; }
    }

    public enum OrderType
    {
        User,
        Company
    }
}