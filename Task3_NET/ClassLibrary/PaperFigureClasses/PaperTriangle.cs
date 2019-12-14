using System;
using ClassLibrary.AbstractClasses;
using ClassLibrary.ExceptionClasses;

namespace ClassLibrary.PaperFigureClasses
{
    public class PaperTriangle : AbstractTriangle, IPainted
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

        public PaperTriangle()
        {
            FigureColor = Colors.White;
        }

        public PaperTriangle(double firstSide, double secondSide, double thirdSide) : base(firstSide, secondSide, thirdSide)
        {
            FigureColor = Colors.White;
        }

        public PaperTriangle(double firstSide, double secondSide, double thirdSide, Colors color) : base(firstSide, secondSide, thirdSide)
        {
            FigureColor = color;
        }

        public PaperTriangle(double firstSide, double secondSide, double thirdSide, Colors color, AbstractFigure figure) : base(firstSide, secondSide, thirdSide, figure)
        {
            CreationException.ColorsHandler(color, (figure as IPainted).FigureColor);
            FigureColor = color;
        }

        public PaperTriangle(double firstSide, double secondSide, double thirdSide, AbstractFigure figure) : this(firstSide, secondSide, thirdSide, Colors.White, figure)
        {

        }

        public override string ToString()
        {
            return ($"'{this.GetType().Name}', sides '{base.FirstSide}', '{base.SecondSide}' and '{base.ThirdSide}', color '{this.figureColor}'");
        }
    }
}