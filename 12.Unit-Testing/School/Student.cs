namespace School
{
    using System;
    using System.Collections.Generic;

    public class Student
    {
        const int MinNumber = 10000;
        const int MaxNumber = 99999;
        private string name;
        private int uniqueNumber;

        public Student(string name, int number)
        {
            this.Name = name;
            this.Number = number;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name can't be null or empty.");
                }

                this.name = value;
            }
        }

        public int Number
        {
            get { return this.uniqueNumber; }
            set
            {
                if (value < MinNumber || value > MaxNumber)
                {
                    throw new ArgumentOutOfRangeException("number", "Student " + this.Name + " number must be greater than 10000 and less than 99999");
                }

                this.uniqueNumber = value;
            }
        }

        public override string ToString()
        {
            return String.Format("name: {0}, number: {1}", this.Name, this.Number);
        }
    }
}