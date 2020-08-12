namespace polymorphic_join.Models
{
    public class PolymorphicType<TType, TId>
    {
        public TType TargetType { get; set; }
        public TId TargetId { get; set; }
    }
    public enum OrderType
    {
        User,
        Company
    }
}