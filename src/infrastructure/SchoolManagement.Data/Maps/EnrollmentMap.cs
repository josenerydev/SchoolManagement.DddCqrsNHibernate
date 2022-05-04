using FluentNHibernate.Mapping;

using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.SharedKernel;

namespace SchoolManagement.Data.Maps
{
    public class EnrollmentMap : ClassMap<Enrollment>
    {
        public EnrollmentMap()
        {
            Id(x => x.Id);
            Map(x => x.Grade).CustomType<Grade>();
            References(x => x.Student);
            References(x => x.Course);
        }
    }
}
