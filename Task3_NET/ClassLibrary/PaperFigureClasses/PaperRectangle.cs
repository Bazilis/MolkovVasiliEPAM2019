using System;
using ClassLibrary.AbstractClasses;
using ClassLibrary.ExceptionClasses;

namespace ClassLibrary.PaperFigureClasses
{
    public class PaperRectangle : AbstractRectangle, IPainted
    {
        private bool isFigurePainted;

        private Colors figureColor;

        public Colors FigureColor
        {
            get
            {
                return figureColor;
            }
            set
            {
                if (isFigurePainted)
                {
                    throw new PaintException("The figure already painted");
                }
                else
                {
                    figureColor = value;
                    isFigurePainted = true;
                }
            }
        }

        public PaperRectangle()
        {
            FigureColor = Colors.White;
        }

        public PaperRectangle(double firstSide, double secondSide) : base(firstSide, secondSide)
        {
            FigureColor = Colors.White;
        }

        public PaperRectangle(double firstSide, double secondSide, Colors color) : base(firstSide, secondSide)
        {
            FigureColor = color;
        }

        public PaperRectangle(double firstSide, double secondSide, Colors color, AbstractFigure figure) : base(firstSide, secondSide, figure)
        {
            CreationException.ColorsHandler(color, (figure as IPainted).FigureColor);
            FigureColor = color;
        }

        public PaperRectangle(double firstSide, double secondSide, AbstractFigure figure) : this(firstSide, secondSide, Colors.White, figure)
        {

        }

        public override string ToString()
        {
            return ($"'{this.GetType().Name}', sides '{base.FirstSide}' and '{base.SecondSide}', color '{this.figureColor}'");
        }
    }
}