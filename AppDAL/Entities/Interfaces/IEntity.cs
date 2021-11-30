using System;

namespace AppEntities.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}