using System;
using System.Collections.Generic;
using ClassLibrary.AbstractClasses;
using ClassLibrary.ExceptionClasses;
using ClassLibrary.PaperFigureClasses;
using ClassLibrary.InputOutputClasses;

namespace ClassLibrary
{
    /// <summary>
    /// Class for storing a list of abstract figures and performing operations with them
    /// </summary>
    public class GirlsBoxWithFigures
    {
        /// <summary>
        /// List of abstract figures
        /// </summary>
        public List<AbstractFigure> Figures { get; private set; }

        /// <summary>
        /// Constructor with parameter
        /// </summary>
        /// <param name="figures"></param>
        public GirlsBoxWithFigures(List<AbstractFigure> figures)
        {
            Figures = figures;
        }

        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public GirlsBoxWithFigures() : this(new List<AbstractFigure>())
        {

        }

        /// <summary>
        /// Method for adding figures to box
        /// </summary>
        /// <param name="figure"></param>
        public void AddFigure(AbstractFigure figure)
        {
            if (Figures.Contains(figure))
                throw new GirlsBoxWithFiguresException("Figure of this type are already in the box");

            if (Figures.Count == 20)
                throw new GirlsBoxWithFiguresException("There is no free space in the box");

            Figures.Add(figure);
        }

        /// <summary>
        /// Method for viewing figures by it's number
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public AbstractFigure ViewByNumber(int number)
        {
            if (Figures[number] != null && number >= 0 && number < Figures.Count)
                return Figures[number];
            else
                throw new GirlsBoxWithFiguresException("Figure with such number does not exist");
        }

        /// <summary>
        /// Method for extracting figures from box by it's number
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public AbstractFigure ExtractByNumber(int number)
        {
            AbstractFigure figure = ViewByNumber(number);

            Figures.RemoveAt(number);

            return figure;
        }

        /// <summary>
        /// Method for replacing figure by it's number on another figure
        /// </summary>
        /// <param name="number"></param>
        /// <param name="figure"></param>
        public void ReplaceByNumberOnFigure(int number, AbstractFigure figure)
        {
            if (figure == null)
                throw new GirlsBoxWithFiguresException("The figure does not exist");

            if (Figures[number] != null && number >= 0 && number < Figures.Count)
            {
                Figures.RemoveAt(number);
                Figures.Insert(number, figure);
            }
            else
                throw new GirlsBoxWithFiguresException("Figure with such number does not exist");
        }

        /// <summary>
        /// Method for finding equivalent figure in the box
        /// </summary>
        /// <param name="figure"></param>
        /// <returns></returns>
        public AbstractFigure FindEquivalentFigure(AbstractFigure figure)
        {
            foreach (AbstractFigure item in Figures)
            {
                if (item.Equals(figure))
                {
                    return item;
                }
            }

            return null;
        }

        /// <summary>
        /// Method for find out figures count
        /// </summary>
        /// <returns></returns>
        public int FiguresCount()
        {
            return Figures.Count;
        }

        /// <summary>
        /// Method for summation perimeters of all figures in the box
        /// </summary>
        /// <returns></returns>
        public double SumAllFiguresPerimeters()
        {
            double sum = 0;
            foreach (AbstractFigure item in Figures)
            {
                sum += item.GetPerimeter();
            }

            return sum;
        }

        /// <summary>
        /// Method for summation areas of all figures in the box
        /// </summary>
        /// <returns></returns>
        public double SumAllFiguresAreas()
        {
            double sum = 0;
            foreach (AbstractFigure item in Figures)
            {
                sum += item.GetArea();
            }

            return sum;
        }

        /// <summary>
        /// Method for getting all circles from box to list
        /// </summary>
        /// <returns></returns>
        public List<AbstractCircle> GetAllCircles()
        {
            List<AbstractCircle> abstractCircles = new List<AbstractCircle>();
            foreach (AbstractCircle item in Figures)
            {
                abstractCircles.Add(item);
            }

            return abstractCircles;
        }

        /// <summary>
        /// Method for getting all paper figures from box to list
        /// </summary>
        /// <returns></returns>
        public List<AbstractFigure> GetAllPaperFigures()
        {
            List<AbstractFigure> abstractFigures = new List<AbstractFigure>();
            foreach (AbstractFigure item in Figures)
            {
                if (item is IPainted)
                {
                    abstractFigures.Add(item);
                }
            }

            return abstractFigures;
        }

        /// <summary>
        /// Method for getting all film figures from box to list
        /// </summary>
        /// <returns></returns>
        public List<AbstractFigure> GetAllFilmFigures()
        {
            List<AbstractFigure> abstractFigures = new List<AbstractFigure>();
            foreach (AbstractFigure item in Figures)
            {
                if (!(item is IPainted))
                {
                    abstractFigures.Add(item);
                }
            }

            return abstractFigures;
        }


        /// <summary>
        /// Method for serialization all figures from the box to XML-file using StreamWriter class
        /// </summary>
        /// <param name="xmlFilePath"></param>
        public void WriteAllFiguresToXmlFileFromBoxByStream(string xmlFilePath)
        {
            StreamsInputOutput.WriteToXmlFileFromBox(this, xmlFilePath);
        }

        /// <summary>
        /// Method for serialization all paper figures from the box to XML-file using StreamWriter class
        /// </summary>
        /// <param name="xmlFilePath"></param>
        public void WriteAllPaperFiguresToXmlFileFromBoxByStream(string xmlFilePath)
        {
            StreamsInputOutput.WriteToXmlFileFromBox(new GirlsBoxWithFigures(GetAllPaperFigures()), xmlFilePath);
        }

        /// <summary>
        /// Method for serialization all film figures from the box to XML-file using StreamWriter class
        /// </summary>
        /// <param name="xmlFilePath"></param>
        public void WriteAllFilmFiguresToXmlFileFromBoxByStream(string xmlFilePath)
        {
            StreamsInputOutput.WriteToXmlFileFromBox(new GirlsBoxWithFigures(GetAllFilmFigures()), xmlFilePath);
        }



        /// <summary>
        /// Method for serialization all figures from the box to XML-file using XmlWriter class
        /// </summary>
        /// <param name="xmlFilePath"></param>
        public void WriteAllFiguresToXmlFileFromBoxByXml(string xmlFilePath)
        {
            XmlInputOutput.WriteToXmlFileFromBox(this, xmlFilePath);
        }

        /// <summary>
        /// Method for serialization all paper figures from the box to XML-file using XmlWriter class
        /// </summary>
        /// <param name="xmlFilePath"></param>
        public void WriteAllPaperFiguresToXmlFileFromBoxByXml(string xmlFilePath)
        {
            XmlInputOutput.WriteToXmlFileFromBox(new GirlsBoxWithFigures(GetAllPaperFigures()), xmlFilePath);
        }

        /// <summary>
        /// Method for serialization all film figures from the box to XML-file using XmlWriter class
        /// </summary>
        /// <param name="xmlFilePath"></param>
        public void WriteAllFilmFiguresToXmlFileFromBoxByXml(string xmlFilePath)
        {
            XmlInputOutput.WriteToXmlFileFromBox(new GirlsBoxWithFigures(GetAllFilmFigures()), xmlFilePath);
        }



        /// <summary>
        /// Method for deserialization list of abstract figures from XML-file using StreamReader class
        /// </summary>
        /// <param name="xmlFilePath"></param>
        public void ReadAllFiguresFromXmlFileToBoxByStream(string xmlFilePath)
        {
            Figures = StreamsInputOutput.ReadFromXmlFileToList(xmlFilePath);
        }

        /// <summary>
        /// Method for deserialization list of abstract figures from XML-file using XmlReader class
        /// </summary>
        /// <param name="xmlFilePath"></param>
        public void ReadAllFiguresFromXmlFileToBoxByXml(string xmlFilePath)
        {
            Figures = XmlInputOutput.ReadFromXmlFileToList(xmlFilePath);
        }
    }
}
