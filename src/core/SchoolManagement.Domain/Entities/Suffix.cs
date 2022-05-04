using CSharpFunctionalExtensions;
using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain.Entities
{
    public class Suffix : AggregateRoot
    {
        public static readonly Suffix Jr = new Suffix(1, "Jr");
        public static readonly Suffix Sr = new Suffix(2, "Sr");

        public static readonly Suffix[] AllSuffixes = { Jr, Sr };

        public virtual string Name { get; }
        
        protected Suffix()
        {
        }

        private Suffix(long id, string name)
            : base(id)
        {
            Name = name;
        }

        public static Maybe<Suffix> FromId(long id)
        {
            return AllSuffixes.SingleOrDefault(x => x.Id == id);
        }
    }
}
