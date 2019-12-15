using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary.AbstractClasses;
using ClassLibrary.FilmFigureClasses;
using ClassLibrary.ExceptionClasses;

namespace UnitTestProject
{
    [TestClass]
    public class AbstractTriangleTest
    {
        [TestMethod]
        [ExpectedException(typeof(CreationException))]
        public void TestMethodForAbstractTriangleConstructorWithoutParameters()
        {
            _ = new FilmTriangle();
        }

        [DataTestMethod]
        [DataRow(0, 3, 2)]
        [DataRow(4, -2, 3)]
        [ExpectedException(typeof(CreationException))]
        public void TestMethodForAbstractTriangleConstructorWithParameter(double triangleFirstSide, double triangleSecondSide, double triangleThirdSide)
        {
            _ = new FilmTriangle(triangleFirstSide, triangleSecondSide, triangleThirdSide);
        }

        [DataTestMethod]
        [DataRow(10, 14, 12, 3, 4)]
        [DataRow(15, 17, 16, 4, 5)]
        [DataRow(15, 12, 13, 7, 9)]
        [ExpectedException(typeof(CreationException))]
        public void TestMethodForAbstractTriangleConstructorCreateFilmTriangleFromOtherAbstractFigure(double triangleFirstSide, double triangleSecondSide, double triangleThirdSide, double rectangleFirstSide, double rectangleSecondSide)
        {
            AbstractFigure filmRectangle = new FilmRectangle(rectangleFirstSide, rectangleSecondSide);

            _ = new FilmTriangle(triangleFirstSide, triangleSecondSide, triangleThirdSide, filmRectangle);
        }

        [DataTestMethod]
        [DataRow(2.3, 4.5, 6.7, 13.5)]
        [DataRow(4.5, 8.7, 7.8, 21)]
        [DataRow(7.8, 15.3, 13.6, 36.7)]
        public void TestMethodForAbstractTriangleGetPerimeterMethod(double triangleFirstSide, double triangleSecondSide, double triangleThirdSide, double perimetr)
        {
            double expected = perimetr;
            AbstractTriangle filmTriangle = new FilmTriangle(triangleFirstSide, triangleSecondSide, triangleThirdSide);


            double result = filmTriangle.GetPerimeter();



            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(2.3, 4.5, 6.7, 1.8383)]
        [DataRow(4.5, 8.7, 7.8, 17.498)]
        [DataRow(7.8, 15.3, 13.6, 52.9591)]
        public void TestMethodForAbstractTriangleGetAreaMethod(double triangleFirstSide, double triangleSecondSide, double triangleThirdSide, double triangleArea)
        {
            double expected = triangleArea;
            AbstractTriangle filmTriangle = new FilmTriangle(triangleFirstSide, triangleSecondSide, triangleThirdSide);


            double result = filmTriangle.GetArea();



            Assert.AreEqual(expected, result);
        }
    }
}
