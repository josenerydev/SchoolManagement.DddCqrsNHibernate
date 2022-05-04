using CSharpFunctionalExtensions;

using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Domain.Repositories
{
    public interface IStudentRepository
    {
        Task<Maybe<Student>> GetByIdAsync(long id);
        Task SaveAsync(Student student);
    }
}
