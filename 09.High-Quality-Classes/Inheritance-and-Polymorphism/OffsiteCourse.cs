namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class OffsiteCourse : Course
    {
        private string town;

        public OffsiteCourse(string name)
            : base(name)
        {
        }

        public OffsiteCourse(string courseName, string teacherName)
            : base(courseName, teacherName)
        {
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students)
            : base(courseName, teacherName, students)
        {
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students, string town)
            : base(courseName, teacherName, students)
        {
            this.Town = town;
        }

        public string Town 
        {
            get
            {
                return this.town;
            }
            set
            {
                // Ensure that we don't have null values
                if (value == null)
                {
                    throw new ArgumentNullException("Town can't be null");
                }

                this.town = value;
            } 
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("OffsiteCourse");
            result.Append(base.ToString());

            result.Append("; Town = ");
            result.Append(this.Town);

            result.Append(" }");
            return result.ToString();
        }
    }
}
