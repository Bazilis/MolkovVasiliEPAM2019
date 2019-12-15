using System;
using ClassLibrary.AbstractClasses;
using ClassLibrary.ExceptionClasses;
using ClassLibrary.FilmFigureClasses;
using ClassLibrary.PaperFigureClasses;

namespace ClassLibrary.InputOutputClasses
{
    /// <summary>
    /// Static class for deserialization figures and colors instances from strings
    /// </summary>
    public static class StringsParser
    {
        /// <summary>
        /// Static method convert String type name of color to enum Colors type
        /// </summary>
        /// <param name="figureColor"></param>
        /// <returns></returns>
        static Colors GetColorFromString(string figureColor)
        {
            return (Colors)Enum.Parse(typeof(Colors), figureColor);
        }

        /// <summary>
        /// Static method convert String type of abstract figure to AbstractFigure type
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static AbstractFigure GetFigureFromString(string inputString)
        {
            AbstractFigure figure;
            string[] subStrings = inputString.Split('\u0027');

            switch (subStrings[1])
            {
                case "FilmCircle":
                    figure = new FilmCircle(Double.Parse(subStrings[3]));
                    break;

                case "FilmEquilateralTriangle":
                    figure = new FilmEquilateralTriangle(Double.Parse(subStrings[3]));
                    break;

                case "FilmIsoscelesTriangle":
                    figure = new FilmIsoscelesTriangle(Double.Parse(subStrings[3]), Double.Parse(subStrings[7]));
                    break;

                case "FilmRectangle":
                    figure = new FilmRectangle(Double.Parse(subStrings[3]), Double.Parse(subStrings[5]));
                    break;

                case "FilmTriangle":
                    figure = new FilmTriangle(Double.Parse(subStrings[3]), Double.Parse(subStrings[5]), Double.Parse(subStrings[7]));
                    break;

                case "PaperCircle":
                    figure = new PaperCircle(Double.Parse(subStrings[3]), GetColorFromString(subStrings[5]));
                    break;

                case "PaperEquilateralTriangle":
                    figure = new PaperEquilateralTriangle(Double.Parse(subStrings[3]), GetColorFromString(subStrings[9]));
                    break;

                case "PaperIsoscelesTriangle":
                    figure = new PaperIsoscelesTriangle(Double.Parse(subStrings[3]), Double.Parse(subStrings[7]), GetColorFromString(subStrings[9]));
                    break;

                case "PaperRectangle":
                    figure = new PaperRectangle(Double.Parse(subStrings[3]), Double.Parse(subStrings[5]), GetColorFromString(subStrings[7]));
                    break;

                case "PaperTriangle":
                    figure = new PaperTriangle(Double.Parse(subStrings[3]), Double.Parse(subStrings[5]), Double.Parse(subStrings[7]), GetColorFromString(subStrings[9]));
                    break;

                default:
                    throw new ParserException("Figure does not exist");
            }

            return figure;
        }
    }
}
