namespace App.CooperShip.Domain.Base
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
            Id = Guid.NewGuid();    
        }

        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;  
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
