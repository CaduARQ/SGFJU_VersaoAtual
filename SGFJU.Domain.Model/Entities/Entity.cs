using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Entities
{
    public class Entity<TEntity> where TEntity : class
    {
        public virtual int Id { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is TEntity)
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
