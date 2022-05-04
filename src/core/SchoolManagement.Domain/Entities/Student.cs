using SchoolManagement.Domain.Common;
using SchoolManagement.Domain.SharedKernel;

namespace SchoolManagement.Domain.Entities
{
    public class Student : AggregateRoot
    {
        private readonly string _email;
        public virtual Email Email => (Email)_email;
        public virtual Name Name { get; protected set; }
        public virtual Course FavoriteCourse { get; protected set; }
        private readonly IList<Enrollment> _enrollments = new List<Enrollment>();
        public virtual IReadOnlyList<Enrollment> Enrollments => _enrollments.ToList();

        protected Student()
        {
        }

        public Student(
            Name name, Email email, Course favoriteCourse, Grade favoriteCourseGrade)
            : this()
        {
            Name = name;
            _email = email;
            FavoriteCourse = favoriteCourse;

            EnrollIn(favoriteCourse, favoriteCourseGrade);
        }

        public virtual string EnrollIn(Course course, Grade grade)
        {
            if (_enrollments.Any(x => x.Course == course))
                return $"Already enrolled in course '{course.Name}'";

            var enrollment = new Enrollment(course, this, grade);
            _enrollments.Add(enrollment);

            return "OK";
        }
    }
}
