using MediatR;

using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Repositories;
using SchoolManagement.Domain.SharedKernel;

namespace SchoolManagement.Application.Student
{
    public class RegisterStudentCommand : IRequest<long>
    {
        public string FirstName { get; }
        public string LastName { get; }
        public long NameSuffixId { get; }
        public string Email { get; }
        public long FavoriteCourseId { get; }
        public Grade FavoriteCourseGrade { get; }

        public RegisterStudentCommand(string firstName, string lastName, long nameSuffixId, string email, long favoriteCourseId, Grade favoriteCourseGrade)
        {
            FirstName = firstName;
            LastName = lastName;
            NameSuffixId = nameSuffixId;
            Email = email;
            FavoriteCourseId = favoriteCourseId;
            FavoriteCourseGrade = favoriteCourseGrade;
        }
    }

    public class RegisterStudentCommandHandler : IRequestHandler<RegisterStudentCommand, long>
    {
        private readonly IStudentRepository _studentRepository;

        public RegisterStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<long> Handle(RegisterStudentCommand request, CancellationToken cancellationToken)
        {
            var suffix = Suffix.FromId(request.NameSuffixId);
            var name = Name.Create(request.FirstName, request.LastName,suffix.Value);
            var email = Email.Create(request.Email);
            var favoriteCourse = Course.FromId(request.FavoriteCourseId);

            var student = new Domain.Entities.Student(name.Value,email.Value, favoriteCourse.Value, request.FavoriteCourseGrade);
            
            await _studentRepository.SaveAsync(student);

            return student.Id;
        }
    }
}
