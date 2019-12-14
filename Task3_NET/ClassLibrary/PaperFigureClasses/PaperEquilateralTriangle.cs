using System;
using ClassLibrary.AbstractClasses;
using ClassLibrary.ExceptionClasses;

namespace ClassLibrary.PaperFigureClasses
{
    public class PaperEquilateralTriangle : AbstractEquilateralTriangle, IPainted
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

        public PaperEquilateralTriangle()
        {
            FigureColor = Colors.White;
        }

        public PaperEquilateralTriangle(double side) : base(side)
        {
            FigureColor = Colors.White;
        }

        public PaperEquilateralTriangle(double side, Colors color) : base(side)
        {
            FigureColor = color;
        }

        public PaperEquilateralTriangle(double side, Colors color, AbstractFigure figure) : base(side, figure)
        {
            CreationException.ColorsHandler(color, (figure as IPainted).FigureColor);
            FigureColor = color;
        }

        public PaperEquilateralTriangle(double side, AbstractFigure figure) : this(side, Colors.White, figure)
        {

        }

        public override string ToString()
        {
            return ($"'{this.GetType().Name}', sides '{base.Side}', '{base.Side}' and '{base.Side}', color '{this.figureColor}'");
        }
    }
}