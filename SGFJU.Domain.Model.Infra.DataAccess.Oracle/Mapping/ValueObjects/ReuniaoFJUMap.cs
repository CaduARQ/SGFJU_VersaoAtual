using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.ValueObjects;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.ValueObjects
{
    public class ReuniaoFJUMap : ClassMap<ReuniaoFJU>
    {
        public ReuniaoFJUMap()
        {
            this.Table("SGFJU_TBL_REUNIAOFJU");
            this.Id(t => t.Code, "ID_REUNIAOFJU").GeneratedBy.Identity();
            this.Map(T => T.NomeReuniaoFJU);
            HasManyToMany(x => x.JovensQueAssistem)
                .Cascade.None()
                .Inverse()
                .Table("SGFJU_TBL_JOVEM_REUNIAOFJU");
        }
    }
}
