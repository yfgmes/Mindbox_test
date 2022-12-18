using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WindowsFormsApp1;


namespace UCSharpUdoUnitTestArea
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Проверка подсчёта площади круга
        /// </summary>
        [TestMethod]
        public void TestMethodRound1()
        {
            double rad = 1;
            double area = 3.14;
            double result = AreaCalculator.AreaRound(rad);
            Assert.AreEqual(area, result);
        }

        /// <summary>
        /// Проверка на ошибку при вводе отрицательного радиуса
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethodRound2()
        {
            double rad = -1;
            AreaCalculator.AreaRound(rad);
        }

        /// <summary>
        /// Проверка подсчёта площади треугольника
        /// </summary>
        [TestMethod]
        public void TestMethodTri() 
        {
            double a1 = 3;
            double a2 = 4;
            double a3 = 5;
            double area = 6;
            double result = AreaCalculator.AreaTriangle(a1, a2, a3);
            Assert.AreEqual(area, result);
        }

        /// <summary>
        /// Проверка на ошибку при вводе невозможного треугольника
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethodTri2()
        {
            double a1 = 10;
            double a2 = 4;
            double a3 = 5;
            AreaCalculator.AreaTriangle(a1, a2, a3);
        }

        /// <summary>
        /// Проверка на ошибку при вводе неаерного колличества длин сторон треугольника
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestMethodTri3()
        {
            double a1 = 12;
            double a2 = 4;
            AreaCalculator.GetArea(new double []{ a1, a2 }, "triangle") ;
        }

        /// <summary>
        /// Проверка на прямоугольный треугольник
        /// </summary>
        [TestMethod]
        public void TestMethodTri4()
        {
            double a1 = 3;
            double a2 = 4;
            double a3 = 5;
            bool squaer = true;
            bool result = AreaCalculator.CheckSquareTriangle(a1, a2, a3);
            Assert.AreEqual(squaer, result);
        }
    }
}
