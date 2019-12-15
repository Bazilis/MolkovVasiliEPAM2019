using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary.AbstractClasses;
using ClassLibrary.FilmFigureClasses;
using ClassLibrary.ExceptionClasses;

namespace UnitTestProject
{
    /// <summary>
    /// Test class for AbstractEquilateralTriangle class
    /// </summary>
    [TestClass]
    public class AbstractEquilateralTriangleTest
    {
        /// <summary>
        /// Test method for AbstractEquilateralTriangle class constructor without parameters, catch CreationException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CreationException))]
        public void TestMethodForAbstractEquilateralTriangleConstructorWithoutParameters()
        {
            _ = new FilmEquilateralTriangle();
        }

        /// <summary>
        /// Test method for AbstractEquilateralTriangle class constructor with parameters, catch CreationException
        /// </summary>
        /// <param name="equilateralTriangleSide"></param>
        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-2)]
        [ExpectedException(typeof(CreationException))]
        public void TestMethodForAbstractEquilateralTriangleConstructorWithParameter(double equilateralTriangleSide)
        {
            _ = new FilmEquilateralTriangle(equilateralTriangleSide);
        }

        /// <summary>
        /// Test method for AbstractEquilateralTriangle class constructor with parameters for creating equilateral triangle from other figure, catch CreationException
        /// </summary>
        /// <param name="equilateralTriangleSide"></param>
        /// <param name="rectangleFirstSide"></param>
        /// <param name="rectangleSecondSide"></param>
        [DataTestMethod]
        [DataRow(10, 2, 3)]
        [DataRow(15, 3, 4)]
        [DataRow(15, 0, 4)]
        [ExpectedException(typeof(CreationException))]
        public void TestMethodForAbstractEquilateralTriangleConstructorCreateFilmEquilateralTriangleFromOtherAbstractFigure(double equilateralTriangleSide, double rectangleFirstSide, double rectangleSecondSide)
        {
            AbstractFigure filmRectangle = new FilmRectangle(rectangleFirstSide, rectangleSecondSide);

            _ = new FilmEquilateralTriangle(equilateralTriangleSide, filmRectangle);
        }

        /// <summary>
        /// Test method for AbstractEquilateralTriangle class GetPerimeter() method
        /// </summary>
        /// <param name="equilateralTriangleSide"></param>
        /// <param name="equilateralTrianglePerimetr"></param>
        [DataTestMethod]
        [DataRow(2.3, 6.9)]
        [DataRow(4.5, 13.5)]
        [DataRow(7.8, 23.4)]
        public void TestMethodForAbstractEquilateralTriangleGetPerimeterMethod(double equilateralTriangleSide, double equilateralTrianglePerimetr)
        {
            double expected = equilateralTrianglePerimetr;
            AbstractEquilateralTriangle filmEquilateralTriangle = new FilmEquilateralTriangle(equilateralTriangleSide);


            double result = filmEquilateralTriangle.GetPerimeter();



            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Test method for AbstractEquilateralTriangle class GetArea() method
        /// </summary>
        /// <param name="equilateralTriangleSide"></param>
        /// <param name="equilateralTriangleArea"></param>
        [DataTestMethod]
        [DataRow(2.3, 2.2906)]
        [DataRow(4.5, 8.7685)]
        [DataRow(7.8, 26.3445)]
        public void TestMethodForAbstractEquilateralTriangleGetAreaMethod(double equilateralTriangleSide, double equilateralTriangleArea)
        {
            double expected = equilateralTriangleArea;
            AbstractEquilateralTriangle filmEquilateralTriangle = new FilmEquilateralTriangle(equilateralTriangleSide);


            double result = filmEquilateralTriangle.GetArea();



            Assert.AreEqual(expected, result);
        }
    }
}
