using AgilleApi.Domain.Interfaces.Shared;
using System;
using System.ComponentModel.DataAnnotations;

namespace AgilleApi.Domain.Shared
{
    public class Entity : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }

        public DateTime CreatedAt { get; private set; }
        public DateTime LastUpdateAt { get; set; }
    }
}