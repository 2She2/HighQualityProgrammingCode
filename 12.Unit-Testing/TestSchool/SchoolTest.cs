namespace TestSchool
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using School;
    using System.Collections.Generic;

    [TestClass]
    public class SchoolTest
    {
        [TestMethod]
        public void TestIfEmtyConstructorInitializeCourses()
        {
            School school = new School();
            Assert.IsNotNull(school.Courses);
        }

        [TestMethod]
        public void TestConstructorWithCoursesParameterCourseInitializeCount()
        {
            Course mathCourse = new Course("Math");

            List<Course> courses = new List<Course>();
            courses.Add(mathCourse);

            School school = new School(courses);

            Assert.AreEqual(1, school.Courses.Count);
        }

        [TestMethod]
        public void TestConstructorWithCoursesParameterCourseInitializeName()
        {
            Course mathCourse = new Course("Math");

            List<Course> courses = new List<Course>();
            courses.Add(mathCourse);

            School school = new School(courses);

            Assert.AreEqual("Math", school.Courses[0].Name);
        }

        [TestMethod]
        public void TestAddCourse()
        {
            Course mathCourse = new Course("Math");
            School school = new School();

            school.AddCourse(mathCourse);

            Assert.AreEqual("Math", mathCourse.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddNullCourse()
        {
            Course mathCourse = null;
            School school = new School();

            school.AddCourse(mathCourse);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddSameCourseTwice()
        {
            Course mathCourse = new Course("Math");
            School school = new School();

            school.AddCourse(mathCourse);
            school.AddCourse(mathCourse);
        }

        [TestMethod]
        public void TestRemoveCourseRemainingCount()
        {
            Course mathCourse = new Course("Math");
            Course itCourse = new Course("IT");
            School school = new School();

            school.AddCourse(mathCourse);
            school.AddCourse(itCourse);

            school.RemoveCourse(mathCourse);

            Assert.AreEqual(1, school.Courses.Count);
        }

        [TestMethod]
        public void TestRemoveCourseRemainingCourseName()
        {
            Course mathCourse = new Course("Math");
            Course itCourse = new Course("IT");
            School school = new School();

            school.AddCourse(mathCourse);
            school.AddCourse(itCourse);

            school.RemoveCourse(mathCourse);

            Assert.AreEqual("IT", school.Courses[0].Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestRemoveNullCourse()
        {
            Course mathCourse = null;
            Course itCourse = new Course("IT");
            School school = new School();

            school.AddCourse(itCourse);

            school.RemoveCourse(mathCourse);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRemoveNoneAddedCourse()
        {
            Course mathCourse = new Course("Math");
            Course itCourse = new Course("IT");
            School school = new School();

            school.AddCourse(itCourse);

            school.RemoveCourse(mathCourse);
        }
    }
}
