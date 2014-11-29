namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class School
    {
        IList<Course> courses;

        public School()
        {
            this.Courses = new List<Course>();
        }

        public School(IList<Course> courses)
        {
            this.Courses = courses;
        }

        public IList<Course> Courses
        {
            get
            {
                return new List<Course>(this.courses);
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("courses", "Courses must be initialized!");
                }

                this.courses = value;
            }
        }

        public void AddCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("course", "Course must be initialized!");
            }

            if (this.courses.Contains(course))
            {
                throw new ArgumentException("It is not allowed to add " + course.Name + " course twice!");
            }

            this.courses.Add(course);
        }

        public void RemoveCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("course", "Course must be initialized!");
            }

            if (!this.Courses.Contains(course))
            {
                throw new ArgumentException("There is no course: " + course.Name);
            }

            this.courses.Remove(course);
        }
    }
}