using FluentNHibernate.Mapping;

using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Data.Maps
{
    public class SuffixMap : ClassMap<Suffix>
    {
        public SuffixMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
        }
    }
}
