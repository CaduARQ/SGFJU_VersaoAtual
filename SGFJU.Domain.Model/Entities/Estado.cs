namespace SGFJU.Domain.Model.Entities
{
    public class Estado : Entity<Estado> {
        public virtual string NomeEstado { get; set; }
        public virtual string SiglaEstado { get; set; }
    }
}