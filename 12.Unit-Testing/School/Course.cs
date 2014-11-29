namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Course
    {
        public const int MaxStudentsCount = 29;
        private string name;
        private IList<Student> students;

        public Course(string name)
        {
            this.Name = name;
            this.students = new List<Student>();
        }

        public Course(string name, IList<Student> students)
        {
            this.Name = name;
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
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name can't be null or empty.");
                }

                this.name = value;
            }
        }

        public IList<Student> Students
        {
            get
            {
                // Actually, here we must return a copy of the list
                return new List<Student>(this.students);
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("students", "Students must be initialized!");
                }

                if (value.Count >= 30)
                {
                    throw new ArgumentException("Students count must be less than 30!");
                }

                //We copy the given list, else we will have only a reference
                this.students = new List<Student>(value);
            }
        }

        public void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("student", "Student must be initialized!");
            }

            if (this.students.Count == MaxStudentsCount)
            {
                throw new InvalidOperationException("Students must be less than 30!");
            }

            if (this.students.Contains(student))
            {
                throw new ArgumentException("It is not allowed to add the " + student.Name + " student twice!");
            }

            this.students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("student", "Student must be initialized!");
            }
            if (!this.Students.Contains(student))
            {
                throw new ArgumentException("There is no student: " + student.Name);
            }

            this.students.Remove(student);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Course: {0}, students:\n", this.Name);

            for (int i = 0; i < this.Students.Count; i++)
            {
                sb.Append(this.Students[i].Name);

                if (i + 1 < this.Students.Count)
                {
                    sb.Append(", ");
                }
            }

            return sb.ToString();
        }
    }
}