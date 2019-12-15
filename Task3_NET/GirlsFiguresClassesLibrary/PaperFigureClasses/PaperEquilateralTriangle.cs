using System;
using ClassLibrary.AbstractClasses;
using ClassLibrary.ExceptionClasses;

namespace ClassLibrary.PaperFigureClasses
{
    /// <summary>
    /// Class for paper equilateral triangle, inherited from AbstractEquilateralTriangle class and implements interface IPainted
    /// </summary>
    public class PaperEquilateralTriangle : AbstractEquilateralTriangle, IPainted
    {
        private bool isFigurePainted;

        private Colors figureColor;

        /// <summary>
        /// Color of paper equilateral triangle
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
        public PaperEquilateralTriangle()
        {
            FigureColor = Colors.White;
        }

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="side"></param>
        public PaperEquilateralTriangle(double side) : base(side)
        {
            FigureColor = Colors.White;
        }

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="side"></param>
        /// <param name="color"></param>
        public PaperEquilateralTriangle(double side, Colors color) : base(side)
        {
            FigureColor = color;
        }

        /// <summary>
        /// Constructor with parameters for creating paper equilateral triangle from other figure
        /// </summary>
        /// <param name="side"></param>
        /// <param name="color"></param>
        /// <param name="figure"></param>
        public PaperEquilateralTriangle(double side, Colors color, AbstractFigure figure) : base(side, figure)
        {
            CreationException.ColorsHandler(color, (figure as IPainted).FigureColor);
            FigureColor = color;
        }

        /// <summary>
        /// Constructor with parameters for creating white color (default color) paper equilateral triangle from other figure
        /// </summary>
        /// <param name="side"></param>
        /// <param name="figure"></param>
        public PaperEquilateralTriangle(double side, AbstractFigure figure) : this(side, Colors.White, figure)
        {

        }

        /// <summary>
        /// Override ToString() method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ($"'{this.GetType().Name}', sides '{base.Side}', '{base.Side}' and '{base.Side}', color '{this.figureColor}'");
        }
    }
}
