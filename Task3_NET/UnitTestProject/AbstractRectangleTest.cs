﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary.AbstractClasses;
using ClassLibrary.FilmFigureClasses;
using ClassLibrary.ExceptionClasses;

namespace UnitTestProject
{
    [TestClass]
    public class AbstractRectangleTest
    {
        [TestMethod]
        [ExpectedException(typeof(CreationException))]
        public void TestMethodForAbstractRectangleConstructorWithoutParameters()
        {
            _ = new FilmRectangle();
        }

        [DataTestMethod]
        [DataRow(0, 3)]
        [DataRow(4, -2)]
        [ExpectedException(typeof(CreationException))]
        public void TestMethodForAbstractRectangleConstructorWithParameter(double rectangleFirstSide, double rectangleSecondSide)
        {
            _ = new FilmRectangle(rectangleFirstSide, rectangleSecondSide);
        }

        [DataTestMethod]
        [DataRow(10, 14, 2, 3, 4)]
        [DataRow(15, 17, 3, 4, 5)]
        [DataRow(15, 12, 4, 7, 9)]
        [ExpectedException(typeof(CreationException))]
        public void TestMethodForAbstractRectangleConstructorCreateFilmRectangleFromOtherAbstractFigure(double rectangleFirstSide, double rectangleSecondSide, double triangleFirstSide, double triangleSecondSide, double triangleThirdSide)
        {
            AbstractFigure filmTriangle = new FilmTriangle(triangleFirstSide, triangleSecondSide, triangleThirdSide);

            _ = new FilmRectangle(rectangleFirstSide, rectangleSecondSide, filmTriangle);
        }

        [DataTestMethod]
        [DataRow(2.3, 4.5, 13.6)]
        [DataRow(4.5, 8.7, 26.4)]
        [DataRow(7.8, 15.3, 46.2)]
        public void TestMethodForAbstractRectangleGetPerimeterMethod(double rectangleFirstSide, double rectangleSecondSide, double rectanglePerimetr)
        {
            double expected = rectanglePerimetr;
            AbstractRectangle filmRectangle = new FilmRectangle(rectangleFirstSide, rectangleSecondSide);


            double result = filmRectangle.GetPerimeter();



            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(2.3, 4.5, 10.35)]
        [DataRow(4.5, 8.7, 39.15)]
        [DataRow(7.8, 15.3, 119.34)]
        public void TestMethodForAbstractRectangleGetAreaMethod(double rectangleFirstSide, double rectangleSecondSide, double rectangleArea)
        {
            double expected = rectangleArea;
            AbstractRectangle filmRectangle = new FilmRectangle(rectangleFirstSide, rectangleSecondSide);


            double result = filmRectangle.GetArea();



            Assert.AreEqual(expected, result);
        }
    }
}
