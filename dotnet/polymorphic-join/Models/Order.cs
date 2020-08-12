namespace polymorphic_join.Models
{
    public class Order : PolymorphicType<OrderType, int>
    {
        public int Id { get; set; }
    }
}