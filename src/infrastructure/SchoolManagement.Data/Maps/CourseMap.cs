using FluentNHibernate.Mapping;

using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Data.Maps
{
    public class CourseMap : ClassMap<Course>
    {
        public CourseMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
        }
    }
}
