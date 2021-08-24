using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class ComparadorObreiroDTO : IEqualityComparer<ObreiroDTO>
    {
        public bool Equals(ObreiroDTO x, ObreiroDTO y) {
            return x.IdObreiro == y.IdObreiro;
        }

        public int GetHashCode(ObreiroDTO obj) {
            return obj.IdObreiro;
        }
    }
}
