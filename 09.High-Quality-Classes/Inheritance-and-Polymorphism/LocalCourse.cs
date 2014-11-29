namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LocalCourse : Course
    {
        private string lab;

        public LocalCourse(string name)
            : base(name)
        {
        }

        public LocalCourse(string courseName, string teacherName)
            : base(courseName, teacherName)
        {
        }

        public LocalCourse(string courseName, string teacherName, IList<string> students)
            : base(courseName, teacherName, students)
        {
        }

        public LocalCourse(string courseName, string teacherName, IList<string> students, string lab)
            : base(courseName, teacherName, students)
        {
            this.Lab = lab;
        }

        public string Lab 
        {
            get
            {
                return this.lab;
            }
            set
            {
                // Ensure that we don't have null values
                if (value == null)
                {
                    throw new ArgumentNullException("Lab can't be null!");
                }

                this.lab = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("LocalCourse");
            result.Append(base.ToString());

            result.Append("; Lab = ");
            result.Append(this.Lab);

            result.Append(" }");
            return result.ToString();
        }
    }
}
