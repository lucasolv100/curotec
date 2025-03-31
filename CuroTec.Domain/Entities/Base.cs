using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuroTec.Domain.Entities
{
    public abstract class Base
    {
        public int Id { get; protected set; }
        public DateTime CreatedDate { get; protected set; } = DateTime.Now;
        public DateTime LastModifiedDate { get; protected set; } = DateTime.Now;
        public DateTime? DeletedDate { get; protected set; }
    }
}