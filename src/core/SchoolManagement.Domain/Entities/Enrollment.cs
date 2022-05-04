
using CSharpFunctionalExtensions;

using SchoolManagement.Domain.SharedKernel;

namespace SchoolManagement.Domain.Entities
{
    public class Enrollment : Entity
    {
        public virtual Grade Grade { get; protected set; }
        public virtual Course Course { get; protected set; }
        public virtual Student Student { get; protected set; }

        protected Enrollment()
        {
        }

        public Enrollment(Course course, Student student, Grade grade)
            : this()
        {
            Course = course;
            Student = student;
            Grade = grade;
        }
    }
}
