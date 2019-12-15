﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary.AbstractClasses;
using ClassLibrary.FilmFigureClasses;
using ClassLibrary.ExceptionClasses;

namespace UnitTestProject
{
    /// <summary>
    /// Test class for AbstractIsoscelesTriangle class
    /// </summary>
    [TestClass]
    public class AbstractIsoscelesTriangleTest
    {
        /// <summary>
        /// Test method for AbstractIsoscelesTriangle class constructor without parameters, catch CreationException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CreationException))]
        public void TestMethodForAbstractIsoscelesTriangleConstructorWithoutParameters()
        {
            _ = new FilmIsoscelesTriangle();
        }

        /// <summary>
        /// Test method for AbstractIsoscelesTriangle class constructor with parameters, catch CreationException
        /// </summary>
        /// <param name="isoscelesTriangleFirsAndSecondSides"></param>
        /// <param name="isoscelesTriangleThirdSide"></param>
        [DataTestMethod]
        [DataRow(0, 3)]
        [DataRow(4, -2)]
        [ExpectedException(typeof(CreationException))]
        public void TestMethodForAbstractIsoscelesTriangleConstructorWithParameter(double isoscelesTriangleFirsAndSecondSides, double isoscelesTriangleThirdSide)
        {
            _ = new FilmIsoscelesTriangle(isoscelesTriangleFirsAndSecondSides, isoscelesTriangleThirdSide);
        }

        /// <summary>
        /// Test method for AbstractIsoscelesTriangle class constructor with parameters for creating isosceles triangle from other figure, catch CreationException
        /// </summary>
        /// <param name="isoscelesTriangleFirsAndSecondSides"></param>
        /// <param name="isoscelesTriangleThirdSide"></param>
        /// <param name="rectangleFirstSide"></param>
        /// <param name="rectangleSecondSide"></param>
        [DataTestMethod]
        [DataRow(2.3, 4.5, 0.1, 1.1)]
        [DataRow(4.5, 8.7, 1.1, 4.1)]
        [DataRow(7.8, 15.3, 2.1, 4.1)]
        [ExpectedException(typeof(CreationException))]
        public void TestMethodForAbstractIsoscelesTriangleConstructorCreateFilmIsoscelesTriangleFromOtherAbstractFigure(double isoscelesTriangleFirsAndSecondSides, double isoscelesTriangleThirdSide, double rectangleFirstSide, double rectangleSecondSide)
        {
            AbstractFigure filmRectangle = new FilmRectangle(rectangleFirstSide, rectangleSecondSide);

            _ = new FilmIsoscelesTriangle(isoscelesTriangleFirsAndSecondSides, isoscelesTriangleThirdSide, filmRectangle);
        }

        /// <summary>
        /// Test method for AbstractIsoscelesTriangle class GetPerimeter() method
        /// </summary>
        /// <param name="isoscelesTriangleFirsAndSecondSides"></param>
        /// <param name="isoscelesTriangleThirdSide"></param>
        /// <param name="isoscelesTrianglePerimetr"></param>
        [DataTestMethod]
        [DataRow(2.3, 4.5, 6.8)]
        [DataRow(4.5, 8.7, 13.2)]
        [DataRow(7.8, 15.3, 23.1)]
        public void TestMethodForAbstractIsoscelesTriangleGetPerimeterMethod(double isoscelesTriangleFirsAndSecondSides, double isoscelesTriangleThirdSide, double isoscelesTrianglePerimetr)
        {
            double expected = isoscelesTrianglePerimetr;
            AbstractIsoscelesTriangle filmIsoscelesTriangle = new FilmIsoscelesTriangle(isoscelesTriangleFirsAndSecondSides, isoscelesTriangleThirdSide);


            double result = filmIsoscelesTriangle.GetPerimeter();



            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Test method for AbstractIsoscelesTriangle class GetArea() method
        /// </summary>
        /// <param name="isoscelesTriangleFirsAndSecondSides"></param>
        /// <param name="isoscelesTriangleThirdSide"></param>
        /// <param name="isoscelesTriangleArea"></param>
        [DataTestMethod]
        [DataRow(2.3, 4.5, 1.0732)]
        [DataRow(4.5, 8.7, 5.0119)]
        [DataRow(7.8, 15.3, 11.6459)]
        public void TestMethodForAbstractIsoscelesTriangleGetAreaMethod(double isoscelesTriangleFirsAndSecondSides, double isoscelesTriangleThirdSide, double isoscelesTriangleArea)
        {
            double expected = isoscelesTriangleArea;
            AbstractIsoscelesTriangle filmIsoscelesTriangle = new FilmIsoscelesTriangle(isoscelesTriangleFirsAndSecondSides, isoscelesTriangleThirdSide);


            double result = filmIsoscelesTriangle.GetArea();



            Assert.AreEqual(expected, result);
        }
    }
}