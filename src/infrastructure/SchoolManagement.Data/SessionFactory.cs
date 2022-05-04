using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Conventions.Instances;
using FluentNHibernate.Mapping;

using NHibernate;

using System.Reflection;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace SchoolManagement.Data
{
    public class SessionFactory
    {
        private static ISessionFactory _factory;

        public SessionFactory(string connectionString)
        {
            _factory = BuidSessionFactory(connectionString);
        }

        internal static ISession OpenSession()
        {
            return _factory.OpenSession();
        }

        //public static void Init(string connectionString)
        //{
        //    _factory = BuidSessionFactory(connectionString);
        //}

        private static ISessionFactory BuidSessionFactory(string connectionString)
        {
            FluentConfiguration configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString))
                .Mappings(m => m.FluentMappings
                    .AddFromAssembly(Assembly.GetExecutingAssembly())
                    .Conventions.Add(
                        ForeignKey.EndsWith("ID"),
                        ConventionBuilder.Property.When(criteria => criteria.Expect(x => x.Nullable, Is.Not.Set),
                            x => x.Not.Nullable()))
                    .Conventions.Add<OtherConversions>()
                    .Conventions.Add<TableNameConvention>()
                    .Conventions.Add<HiLoConvention>()
                );
                //.ExposeConfiguration(BuildSchema)
                //.ExposeConfiguration(ScriptSchema);

            return configuration.BuildSessionFactory();
        }

        //private static void BuildSchema(Configuration configuration)
        //{
        //    SchemaExport schemaExport = new SchemaExport(configuration);
        //    schemaExport.Create(false, true);
        //}

        //private static void ScriptSchema(Configuration configuration)
        //{
        //    SchemaExport schemaExport = new SchemaExport(configuration);
        //    schemaExport.SetOutputFile(@"db.sql")
        //        .Execute(false, false, false);
        //}

        private class OtherConversions : IHasManyConvention, IReferenceConvention
        {
            public void Apply(IOneToManyCollectionInstance instance)
            {
                instance.LazyLoad();
                instance.AsBag();
                instance.Cascade.SaveUpdate();
                instance.Inverse();
            }

            public void Apply(IManyToOneInstance instance)
            {
                instance.LazyLoad(Laziness.Proxy);
                instance.Cascade.None();
                instance.Not.Nullable();
            }
        }

        private class TableNameConvention : IClassConvention
        {
            public void Apply(IClassInstance instance)
            {
                instance.Table(instance.EntityType.Name);
            }
        }

        private class HiLoConvention : IIdConvention
        {
            public void Apply(IIdentityInstance instance)
            {
                instance.Column(instance.EntityType.Name + "ID");
                instance.GeneratedBy.HiLo("Ids", "NextHigh", "9", "EntityName = '" + instance.EntityType.Name + "'");
            }
        }
    }
}
