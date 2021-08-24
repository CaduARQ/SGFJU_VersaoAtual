using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.ValueObjects
{
    public class ValueObjectType<TValueObjectType> where TValueObjectType : class
    {
        public virtual int Code { get; set; }
        public virtual string Descricao { get; set; }

        public virtual int Codigo { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is TValueObjectType)
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
