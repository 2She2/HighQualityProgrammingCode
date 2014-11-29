namespace TestSchool
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using School;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        public void TestConstructorWithOneParameterName()
        {
            Course course = new Course("Math");

            Assert.AreEqual("Math", course.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestConstructorWithNameNullValue()
        {
            Course course = new Course(null);
        }

        [TestMethod]
        public void TestConstructorWithOneParameterForInitializeStudentsList()
        {
            Course course = new Course("Math");

            Assert.AreEqual(0, course.Students.Count);
        }

        [TestMethod]
        public void TestConstructorForAssigningStudentList()
        {

            List<Student> students = CreateStudents(5);
            Course course = new Course("Math", students);

            Assert.AreEqual(5, course.Students.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructorForAssigningMoreThanAllowedStudents()
        {
            List<Student> students = CreateStudents(30);
            Course course = new Course("Math", students);
        }

        [TestMethod]
        public void TestAddingStudent()
        {
            Course course = new Course("Math");
            Student pesho = new Student("Pesho", 50000);
            course.AddStudent(pesho);

            Assert.AreEqual(pesho, course.Students[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddingNullStudent()
        {
            Course course = new Course("Math");
            Student pesho = null;
            course.AddStudent(pesho);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddingSameStudentTwice()
        {
            Course course = new Course("Math");
            Student pesho = new Student("Pesho", 50000);
            course.AddStudent(pesho);
            course.AddStudent(pesho);
        }

        [TestMethod]
        public void TestRemoveStudent()
        {
            Course course = new Course("Math");
            Student pesho = new Student("Pesho", 50000);

            course.AddStudent(pesho);
            course.RemoveStudent(pesho);

            Assert.AreEqual(0, course.Students.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestRemoveNullStudent()
        {
            Course course = new Course("Math");
            Student pesho = null;
            course.RemoveStudent(pesho);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRemoveNonAddedStudent()
        {
            Course course = new Course("Math");
            Student pesho = new Student("Pesho", 50000);
            course.RemoveStudent(pesho);
        }


        private List<Student> CreateStudents(int studentsCount)
        {
            List<Student> students = new List<Student>();

            for (int i = 1; i < studentsCount + 1; i++)
            {
                Student currentStudent = new Student(i.ToString(), i + 10000);

                students.Add(currentStudent);
            }

            return students;
        }

        [TestMethod]
        public void TestToStringForEmptyStudentsList()
        {
            Course math = new Course("Math");

            Assert.AreEqual("Course: Math, students:\n", math.ToString());
        }

        [TestMethod]
        public void TestToStringFor()
        {
            Course math = new Course("Math");
            Student pesho = new Student("Pesho", 50000);

            math.AddStudent(pesho);

            Assert.AreEqual("Course: Math, students:\nPesho", math.ToString());
        }
    }
}
