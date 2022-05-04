using CSharpFunctionalExtensions;
using SchoolManagement.Domain.Common;
using SchoolManagement.Domain.Resources;

namespace SchoolManagement.Domain.Entities
{
    public class Course : AggregateRoot
    {
        public static readonly Course Calculus = new Course(1, "Calculus");
        public static readonly Course Chemistry = new Course(2, "Chemistry");
        public static readonly Course Literature = new Course(3, "Literature");
        public static readonly Course Trigonometry = new Course(4, "Trigonometry");
        public static readonly Course Microeconomics = new Course(5, "Microeconomics");

        public static readonly Course[] AllCourses = { Calculus, Chemistry, Literature, Trigonometry, Microeconomics };

        public virtual string Name { get; protected set; }

        protected Course()
        {
        }

        private Course(long id, string name)
            : base(id)
        {
            Name = name;
        }

        public static Result<Course> FromId(long id)
        {
            var course = AllCourses.SingleOrDefault(x => x.Id == id);

            if (course is not null)
                return course;

            return Result.Failure<Course>(Resource.CourseDoesNotExist);
        }
    }
}
