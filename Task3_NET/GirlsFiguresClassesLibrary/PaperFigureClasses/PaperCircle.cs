using System;
using ClassLibrary.AbstractClasses;
using ClassLibrary.ExceptionClasses;

namespace ClassLibrary.PaperFigureClasses
{
    public class PaperCircle : AbstractCircle, IPainted
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

        public PaperCircle()
        {
            FigureColor = Colors.White;
        }

        public PaperCircle(double radius) : base(radius)
        {
            FigureColor = Colors.White;
        }

        public PaperCircle(double radius, Colors color) : base(radius)
        {
            FigureColor = color;
        }

        public PaperCircle(double radius, Colors color, AbstractFigure figure) : base(radius, figure)
        {
            CreationException.ColorsHandler(color, (figure as IPainted).FigureColor);
            FigureColor = color;
        }

        public PaperCircle(double radius, AbstractFigure figure) : this(radius, Colors.White, figure)
        {

        }

        public override string ToString()
        {
            return ($"'{this.GetType().Name}', radius '{base.Radius}', color '{this.figureColor}'");
        }
    }
}
