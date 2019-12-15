using System;
using ClassLibrary.AbstractClasses;
using ClassLibrary.ExceptionClasses;

namespace ClassLibrary.PaperFigureClasses
{
    /// <summary>
    /// Class for paper rectangle, inherited from AbstractRectangle class and implements interface IPainted
    /// </summary>
    public class PaperRectangle : AbstractRectangle, IPainted
    {
        private bool isFigurePainted;

        private Colors figureColor;

        /// <summary>
        /// Color of paper rectangle
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
        public PaperRectangle()
        {
            FigureColor = Colors.White;
        }

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="firstSide"></param>
        /// <param name="secondSide"></param>
        public PaperRectangle(double firstSide, double secondSide) : base(firstSide, secondSide)
        {
            FigureColor = Colors.White;
        }

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="firstSide"></param>
        /// <param name="secondSide"></param>
        /// <param name="color"></param>
        public PaperRectangle(double firstSide, double secondSide, Colors color) : base(firstSide, secondSide)
        {
            FigureColor = color;
        }

        /// <summary>
        /// Constructor with parameters for creating paper rectangle from other figure
        /// </summary>
        /// <param name="firstSide"></param>
        /// <param name="secondSide"></param>
        /// <param name="color"></param>
        /// <param name="figure"></param>
        public PaperRectangle(double firstSide, double secondSide, Colors color, AbstractFigure figure) : base(firstSide, secondSide, figure)
        {
            CreationException.ColorsHandler(color, (figure as IPainted).FigureColor);
            FigureColor = color;
        }

        /// <summary>
        /// Constructor with parameters for creating white color (default color) paper rectangle from other figure
        /// </summary>
        /// <param name="firstSide"></param>
        /// <param name="secondSide"></param>
        /// <param name="figure"></param>
        public PaperRectangle(double firstSide, double secondSide, AbstractFigure figure) : this(firstSide, secondSide, Colors.White, figure)
        {

        }

        /// <summary>
        /// Override ToString() method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ($"'{this.GetType().Name}', sides '{base.FirstSide}' and '{base.SecondSide}', color '{this.figureColor}'");
        }
    }
}
