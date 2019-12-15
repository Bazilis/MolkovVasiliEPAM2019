using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary.AbstractClasses;
using ClassLibrary.FilmFigureClasses;
using ClassLibrary.ExceptionClasses;

namespace UnitTestProject
{
    [TestClass]
    public class AbstractCircleTest
    {
        [TestMethod]
        [ExpectedException(typeof(CreationException))]
        public void TestMethodForAbstractCircleConstructorWithoutParameters()
        {
            _ = new FilmCircle();
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-2)]
        [ExpectedException(typeof(CreationException))]
        public void TestMethodForAbstractCircleConstructorWithParameter(double circleRadius)
        {
            _ = new FilmCircle(circleRadius);
        }

        [DataTestMethod]
        [DataRow(10, 2, 3)]
        [DataRow(15, 3, 4)]
        [DataRow(15, 0, 4)]
        [ExpectedException(typeof(CreationException))]
        public void TestMethodForAbstractCircleConstructorCreateFilmCircleFromOtherAbstractFigure(double circleRadius, double rectangleFirstSide, double rectangleSecondSide)
        {
            AbstractFigure filmRectangle = new FilmRectangle(rectangleFirstSide, rectangleSecondSide);

            _ = new FilmCircle(circleRadius, filmRectangle);
        }

        [DataTestMethod]
        [DataRow(2.3, 14.4513)]
        [DataRow(4.5, 28.2743)]
        [DataRow(7.8, 49.0088)]
        public void TestMethodForAbstractCircleGetPerimeterMethod(double circleRadius, double circlePerimetr)
        {
            double expected = circlePerimetr;
            AbstractCircle filmCircle = new FilmCircle(circleRadius);


            double result = filmCircle.GetPerimeter();



            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(2.3, 16.619)]
        [DataRow(4.5, 63.6173)]
        [DataRow(7.8, 191.1345)]
        public void TestMethodForAbstractCircleGetAreaMethod(double circleRadius, double circleArea)
        {
            double expected = circleArea;
            AbstractCircle filmCircle = new FilmCircle(circleRadius);


            double result = filmCircle.GetArea();



            Assert.AreEqual(expected, result);
        }
    }
}
