using CSharpFunctionalExtensions;

using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Resources;

namespace SchoolManagement.Domain.SharedKernel
{
    public class Name : ValueObject
    {
        public virtual string First { get; }
        public virtual string Last { get; }
        public virtual Suffix Suffix { get; protected set; }

        private Name()
        {
        }

        private Name(string first, string last, Suffix suffix)
            : this()
        {
            First = first;
            Last = last;
            Suffix = suffix;
        }

        public static Result<Name> Create(string firstName, string lastName, Suffix suffix)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                return Result.Failure<Name>(Resource.FirstNameShouldNotBeEmpty);
            if (string.IsNullOrWhiteSpace(lastName))
                return Result.Failure<Name>(Resource.LastNameShouldNotBeEmpty);

            firstName = firstName.Trim();
            lastName = lastName.Trim();

            if (firstName.Length > 200)
                return Result.Failure<Name>(Resource.FirstNameIsTooLong);
            if (lastName.Length > 200)
                return Result.Failure<Name>(Resource.LastNameIsTooLong);

            return Result.Success(new Name(firstName, lastName, suffix));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return First;
            yield return Last;
            yield return Suffix;
        }
    }
}
