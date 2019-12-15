using System;
using ClassLibrary.AbstractClasses;
using ClassLibrary.ExceptionClasses;
using ClassLibrary.FilmFigureClasses;
using ClassLibrary.PaperFigureClasses;

namespace ClassLibrary.InputOutputClasses
{
    public static class StringsParser
    {
        static Colors ColorFromString(string figureColor)
        {
            return (Colors)Enum.Parse(typeof(Colors), figureColor);
        }

        public static AbstractFigure FigureFromString(string inputString)
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
                    figure = new PaperCircle(Double.Parse(subStrings[3]), ColorFromString(subStrings[5]));
                    break;

                case "PaperEquilateralTriangle":
                    figure = new PaperEquilateralTriangle(Double.Parse(subStrings[3]), ColorFromString(subStrings[9]));
                    break;

                case "PaperIsoscelesTriangle":
                    figure = new PaperIsoscelesTriangle(Double.Parse(subStrings[3]), Double.Parse(subStrings[7]), ColorFromString(subStrings[9]));
                    break;

                case "PaperRectangle":
                    figure = new PaperRectangle(Double.Parse(subStrings[3]), Double.Parse(subStrings[5]), ColorFromString(subStrings[7]));
                    break;

                case "PaperTriangle":
                    figure = new PaperTriangle(Double.Parse(subStrings[3]), Double.Parse(subStrings[5]), Double.Parse(subStrings[7]), ColorFromString(subStrings[9]));
                    break;

                default:
                    throw new ParserException("Figure does not exist");
            }

            return figure;
        }
    }
}
