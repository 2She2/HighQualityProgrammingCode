namespace Methods
{
    using System;

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherInfo { get; set; }
        public DateTime dateOfBirth { get; set; }

        public bool IsOlderThan(Student student)
        {
            DateTime firstDate = this.dateOfBirth;
            DateTime secondDate = student.dateOfBirth;

            bool isOlder = false;

            if (firstDate.CompareTo(secondDate) < 0)
            {
                isOlder = true;   
            }

            return isOlder;
        }
    }
}
