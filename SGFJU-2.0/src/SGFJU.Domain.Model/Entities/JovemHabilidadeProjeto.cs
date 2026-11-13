using SGFJU.Domain.Model.ValueObjects;

namespace SGFJU.Domain.Model.Entities
{
    public class JovemHabilidadeProjeto
    {
        public virtual Jovem Jovem { get; set; }
        public virtual HabilidadeProjeto Habilidade { get; set; }
        public virtual Nivel Nivel { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            var i = obj as JovemHabilidadeProjeto;

            return ((i.Jovem.Id == this.Jovem.Id)
                 && (i.Habilidade.Code == this.Habilidade.Code));
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return 9999;
        }
    }
}