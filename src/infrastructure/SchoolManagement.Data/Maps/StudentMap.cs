using FluentNHibernate.Mapping;

using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Data.Maps
{
    public class StudentMap : ClassMap<Student>
    {
        public StudentMap()
        {
            Id(x => x.Id);
            Map(x => x.Email).CustomType<string>().Access.CamelCaseField(Prefix.Underscore);

            Component(x => x.Name, y =>
            {
                y.Map(x => x.First, "FirstName").CustomType<string>();
                y.Map(x => x.Last, "LastName").CustomType<string>();
                y.References(x => x.Suffix, "NameSuffixID").Nullable();
            });

            References(x => x.FavoriteCourse);
            HasMany(x => x.Enrollments).Access.CamelCaseField(Prefix.Underscore)
                .Cascade.SaveUpdate()
                .Not.LazyLoad()
                .Inverse();
        }
    }
}
