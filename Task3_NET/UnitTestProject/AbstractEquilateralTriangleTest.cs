using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary.AbstractClasses;
using ClassLibrary.FilmFigureClasses;
using ClassLibrary.ExceptionClasses;

namespace UnitTestProject
{
    [TestClass]
    public class AbstractEquilateralTriangleTest
    {
        [TestMethod]
        [ExpectedException(typeof(CreationException))]
        public void TestMethodForAbstractEquilateralTriangleConstructorWithoutParameters()
        {
            _ = new FilmEquilateralTriangle();
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-2)]
        [ExpectedException(typeof(CreationException))]
        public void TestMethodForAbstractEquilateralTriangleConstructorWithParameter(double equilateralTriangleSide)
        {
            _ = new FilmEquilateralTriangle(equilateralTriangleSide);
        }

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
