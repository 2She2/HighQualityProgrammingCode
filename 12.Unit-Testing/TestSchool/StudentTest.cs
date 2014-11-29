namespace TestSchool
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using School;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void TestConstructorInitializeName()
        {
            Student student = new Student("Pesho", 50000);

            Assert.AreEqual("Pesho", student.Name);
        }

        [TestMethod]
        public void TestConstructorAssignNumber()
        {
            Student student = new Student("Pesho", 50000);

            Assert.AreEqual(50000, student.Number);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNameNullValue()
        {
            string name = null;
            Student student = new Student(name, 50000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNameEmptyString()
        {
            string name = string.Empty;
            Student student = new Student(name, 50000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestUniqueNumberBelowStartValue()
        {
            int uniqueNumber = 9999;
            Student student = new Student("Pesho", uniqueNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestUniqueNumberAboveEndValue()
        {
            int uniqueNumber = 100000;
            Student student = new Student("Pesho", uniqueNumber);
        }

        [TestMethod]
        public void TestToString()
        {
            Student pesho = new Student("Pesho", 50000);

            Assert.AreEqual("name: Pesho, number: 50000", pesho.ToString());
        }
    }
}
