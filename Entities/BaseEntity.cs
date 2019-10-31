using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Created { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
            Created = DateTime.UtcNow;
        }
    }
}
