using CSharpFunctionalExtensions;

using System.Text.RegularExpressions;
using SchoolManagement.Domain.Resources;

namespace SchoolManagement.Domain.SharedKernel
{
    public sealed class Email : ValueObject
    {
        public string Value { get; }

        private Email(string value)
        {
            Value = value;
        }

        public static Result<Email> Create(Maybe<string> emailOrNothing)
        {
            return emailOrNothing.ToResult(Resource.EmailShouldNotBeEmpty)
                .Map(email => email.Trim())
                .Ensure(email => email != string.Empty, Resource.EmailShouldNotBeEmpty)
                .Ensure(email => email.Length <= 256, Resource.EmailIsInvalid)
                .Ensure(email => Regex.IsMatch(email, @"^(.+)@(.+)$"), Resource.EmailIsInvalid)
                .Map(email => new Email(email));
        }

        public static explicit operator Email(string email)
        {
            return Create(email).Value;
        }

        public static implicit operator string(Email email)
        {
            return email.Value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
