using System;
using ClassLibrary.AbstractClasses;
using ClassLibrary.ExceptionClasses;

namespace ClassLibrary.PaperFigureClasses
{
    /// <summary>
    /// Class for paper isosceles triangle, inherited from AbstractIsoscelesTriangle class and implements interface IPainted
    /// </summary>
    public class PaperIsoscelesTriangle : AbstractIsoscelesTriangle, IPainted
    {
        private bool isFigurePainted;

        private Colors figureColor;

        /// <summary>
        /// Color of paper isosceles triangle
        /// </summary>
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

        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public PaperIsoscelesTriangle()
        {
            FigureColor = Colors.White;
        }

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="firstAndSecondSides"></param>
        /// <param name="thirdSide"></param>
        public PaperIsoscelesTriangle(double firstAndSecondSides, double thirdSide) : base(firstAndSecondSides, thirdSide)
        {
            FigureColor = Colors.White;
        }

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="firstAndSecondSides"></param>
        /// <param name="thirdSide"></param>
        /// <param name="color"></param>
        public PaperIsoscelesTriangle(double firstAndSecondSides, double thirdSide, Colors color) : base(firstAndSecondSides, thirdSide)
        {
            FigureColor = color;
        }

        /// <summary>
        /// Constructor with parameters for creating paper isosceles triangle from other figure
        /// </summary>
        /// <param name="firstAndSecondSides"></param>
        /// <param name="thirdSide"></param>
        /// <param name="color"></param>
        /// <param name="figure"></param>
        public PaperIsoscelesTriangle(double firstAndSecondSides, double thirdSide, Colors color, AbstractFigure figure) : base(firstAndSecondSides, thirdSide, figure)
        {
            CreationException.ColorsHandler(color, (figure as IPainted).FigureColor);
            FigureColor = color;
        }

        /// <summary>
        /// Constructor with parameters for creating white color (default color) paper isosceles triangle from other figure
        /// </summary>
        /// <param name="firstAndSecondSides"></param>
        /// <param name="thirdSide"></param>
        /// <param name="figure"></param>
        public PaperIsoscelesTriangle(double firstAndSecondSides, double thirdSide, AbstractFigure figure) : this(firstAndSecondSides, thirdSide, Colors.White, figure)
        {

        }

        /// <summary>
        /// Override ToString() method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ($"'{this.GetType().Name}', sides '{base.FirstAndSecondSides}', '{base.FirstAndSecondSides}' and '{base.ThirdSide}', color '{this.figureColor}'");
        }
    }
}
