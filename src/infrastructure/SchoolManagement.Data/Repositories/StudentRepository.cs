using CSharpFunctionalExtensions;

using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Repositories;

namespace SchoolManagement.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly UnitOfWork _unitOfWork;

        public StudentRepository(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Maybe<Student>> GetByIdAsync(long id)
        {
            return await _unitOfWork.GetAsync<Student>(id);
        }

        public async Task SaveAsync(Student student)
        {
            await _unitOfWork.SaveOrUpdateAsync(student);
        }
    }
}
