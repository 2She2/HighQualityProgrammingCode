namespace Matrix.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestConstructorForSizeLessThanMin()
        {
            Matrix matrix = new Matrix(Matrix.MatrixMinSize - 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestConstructorForSizeGratherThanMax()
        {
            Matrix matrix = new Matrix(Matrix.MatrixMaxSize + 1);
        }

        [TestMethod]
        public void TestCorrectDisplayMatrixOfSize1()
        {
            Matrix matrix = new Matrix(1);
            matrix.FillMatrix();
            string matrixSizeOne = "1";

            Assert.AreEqual(matrixSizeOne, matrix.ToString().Trim());
        }

        [TestMethod]
        public void TestCorrectDisplayMatrixOfSize2()
        {
            Matrix matrix = new Matrix(2);
            matrix.FillMatrix();
            string matrixSizeOne = "  1  4\r\n" + 
                                   "  3  2";

            Assert.AreEqual(matrixSizeOne, matrix.ToString());
        }

        [TestMethod]
        public void TestCorrectDisplayMatrixOfSize4()
        {
            Matrix matrix = new Matrix(4);
            matrix.FillMatrix();
            string matrixSizeOne = "  1 10 11 12\r\n" +
                                   "  9  2 15 13\r\n" +
                                   "  8 16  3 14\r\n" +
                                   "  7  6  5  4";

            Assert.AreEqual(matrixSizeOne, matrix.ToString());
        }

        [TestMethod]
        public void TestCorrectDisplayMatrixOfSize5()
        {
            Matrix matrix = new Matrix(5);
            matrix.FillMatrix();
            string matrixSizeOne = "  1 13 14 15 16\r\n" +
                                   " 12  2 21 22 17\r\n" +
                                   " 11 23  3 20 18\r\n" +
                                   " 10 25 24  4 19\r\n" + 
                                   "  9  8  7  6  5";

            Assert.AreEqual(matrixSizeOne, matrix.ToString());
        }
    }
}
