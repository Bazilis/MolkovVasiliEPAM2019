using System;
using System.Collections.Generic;
using ClassLibrary.AbstractClasses;
using ClassLibrary.ExceptionClasses;
using ClassLibrary.PaperFigureClasses;

namespace ClassLibrary
{
    public class BoxWithFigures
    {
        public List<AbstractFigure> Figures { get; private set; }

        public BoxWithFigures(List<AbstractFigure> figures)
        {
            Figures = figures;
        }

        public BoxWithFigures() : this(new List<AbstractFigure>())
        {

        }

        public void AddFigure(AbstractFigure figure)
        {
            if (Figures.Contains(figure))
                throw new BoxWithFiguresException("Figure of this type are already in the box");

            if (Figures.Count == 20)
                throw new BoxWithFiguresException("There is no free space in the box");

            Figures.Add(figure);
        }

        public AbstractFigure ViewByNumber(int number)
        {
            if (Figures[number] != null && number >= 0 && number < Figures.Count)
                return Figures[number];
            else
                throw new BoxWithFiguresException("Figure with such number does not exist");
        }

        public AbstractFigure ExtractByNumber(int number)
        {
            AbstractFigure figure = ViewByNumber(number);

            Figures.RemoveAt(number);

            return figure;
        }

        public void ReplaceByNumberOnFigure(int number, AbstractFigure figure)
        {
            if (figure == null)
                throw new BoxWithFiguresException("The figure does not exist");

            if (Figures[number] != null && number >= 0 && number < Figures.Count)
            {
                Figures.RemoveAt(number);
                Figures.Insert(number, figure);
            }
            else
                throw new BoxWithFiguresException("Figure with such number does not exist");
        }

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

        public int FiguresCount()
        {
            return Figures.Count;
        }

        public double SumAllFiguresPerimeters()
        {
            double sum = 0;
            foreach (AbstractFigure item in Figures)
            {
                sum += item.GetPerimeter();
            }

            return sum;
        }

        public double SumAllFiguresAreas()
        {
            double sum = 0;
            foreach (AbstractFigure item in Figures)
            {
                sum += item.GetArea();
            }

            return sum;
        }

        public List<AbstractCircle> GetAllCircles()
        {
            List<AbstractCircle> abstractCircles = new List<AbstractCircle>();
            foreach (AbstractCircle item in Figures)
            {
                abstractCircles.Add(item);
            }

            return abstractCircles;
        }

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
    }
}
