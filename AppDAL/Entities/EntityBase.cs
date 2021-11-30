using System;

namespace AppEntities.Entities
{
    public class EntityBase: IEntity
    {
        public Guid Id { get; set; }

        //public DateTime DateCreated { get; set; } = new DateTime();
        //public DateTime DateUpdated { get; set; } = new DateTime();
    }
}