namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    public abstract class Course
    {
        private string name;
        private string teacherName;
        private IList<string> students;

        // Other way is just to have one constructor, that require all variables. And probably it is better solution!
        public Course(string name)
        {
            this.Name = name;
            this.students = new List<string>();
        }

        public Course(string name, string teacherName)
            : this(name)
        {
            this.TeacherName = teacherName;
        }

        public Course(string name, string teacherName, IList<string> students)
            : this (name, teacherName)
        {
            this.Students = students;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                // Ensure that we don't have null values
                if (value == null)
                {
                    throw new ArgumentNullException("Name can't be null!");
                }

                this.name = value;
            }
        }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }
            set
            {
                // Ensure that we don't have null values
                if (value == null)
                {
                    throw new ArgumentNullException("Teacher name can't be null!");
                }

                this.teacherName = value;
            }
        }

        public IList<string> Students
        {
            get
            {
                // It is not a good idea to return the original collection.
                // But in this case if we don't, we have to implement method to add the students!
                return students;
            }
            set
            {
                // Ensure that we don't have null values
                if (value == null)
                {
                    throw new ArgumentNullException("Students list can't be null!");
                }

                this.students = value;
            }
        }

        protected string GetStudentsAsString()
        {
            if (this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(" { Name = ");
            result.Append(this.Name);

            result.Append("; Teacher = ");
            result.Append(this.TeacherName);

            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());

            return result.ToString();
        }
    }
}
