using System;

namespace Domain.Base.Entity
{
    public class BaseEntity
    {
       public Guid Id { get; set; }

        public BaseEntity()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
