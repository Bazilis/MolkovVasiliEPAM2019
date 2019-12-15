using System;
using ClassLibrary.AbstractClasses;
using ClassLibrary.ExceptionClasses;

namespace ClassLibrary.PaperFigureClasses
{
    public class PaperIsoscelesTriangle : AbstractIsoscelesTriangle, IPainted
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

        public PaperIsoscelesTriangle()
        {
            FigureColor = Colors.White;
        }

        public PaperIsoscelesTriangle(double firstAndSecondSides, double thirdSide) : base(firstAndSecondSides, thirdSide)
        {
            FigureColor = Colors.White;
        }

        public PaperIsoscelesTriangle(double firstAndSecondSides, double thirdSide, Colors color) : base(firstAndSecondSides, thirdSide)
        {
            FigureColor = color;
        }

        public PaperIsoscelesTriangle(double firstAndSecondSides, double thirdSide, Colors color, AbstractFigure figure) : base(firstAndSecondSides, thirdSide, figure)
        {
            CreationException.ColorsHandler(color, (figure as IPainted).FigureColor);
            FigureColor = color;
        }

        public PaperIsoscelesTriangle(double firstAndSecondSides, double thirdSide, AbstractFigure figure) : this(firstAndSecondSides, thirdSide, Colors.White, figure)
        {

        }

        public override string ToString()
        {
            return ($"'{this.GetType().Name}', sides '{base.FirstAndSecondSides}', '{base.FirstAndSecondSides}' and '{base.ThirdSide}', color '{this.figureColor}'");
        }
    }
}
