using System.Collections.Generic;

namespace querying.Models
{
    public class EntityA
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<EntityB> EntityBs { get; set; }
    }
    
    public class EntityB
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public virtual EntityA EntityA { get; set; }
        public int EntityAId { get; set; }

        public virtual ICollection<EntityC> EntityCs { get; set; }
    }
    
    public class EntityC
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public virtual EntityB EntityB { get; set; }
        public int EntityBId { get; set; }
    }
}