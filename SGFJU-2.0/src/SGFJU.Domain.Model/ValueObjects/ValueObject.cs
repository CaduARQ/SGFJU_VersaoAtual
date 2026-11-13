using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.ValueObjects
{
    public class ValueObject<TValueObject> where TValueObject : class
    {
        public virtual int Code { get; set; }

        //public virtual int Codigo { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is TValueObject)
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return 7.GetHashCode();
        }
    }
}
