using System;
using ClassLibrary.AbstractClasses;
using ClassLibrary.ExceptionClasses;

namespace ClassLibrary.PaperFigureClasses
{
    /// <summary>
    /// Class for paper triangle, inherited from AbstractTriangle class and implements interface IPainted
    /// </summary>
    public class PaperTriangle : AbstractTriangle, IPainted
    {
        private bool isFigurePainted;

        private Colors figureColor;

        /// <summary>
        /// Color of paper triangle
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
        public PaperTriangle()
        {
            FigureColor = Colors.White;
        }

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="firstSide"></param>
        /// <param name="secondSide"></param>
        /// <param name="thirdSide"></param>
        public PaperTriangle(double firstSide, double secondSide, double thirdSide) : base(firstSide, secondSide, thirdSide)
        {
            FigureColor = Colors.White;
        }

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="firstSide"></param>
        /// <param name="secondSide"></param>
        /// <param name="thirdSide"></param>
        /// <param name="color"></param>
        public PaperTriangle(double firstSide, double secondSide, double thirdSide, Colors color) : base(firstSide, secondSide, thirdSide)
        {
            FigureColor = color;
        }

        /// <summary>
        /// Constructor with parameters for creating paper triangle from other figure
        /// </summary>
        /// <param name="firstSide"></param>
        /// <param name="secondSide"></param>
        /// <param name="thirdSide"></param>
        /// <param name="color"></param>
        /// <param name="figure"></param>
        public PaperTriangle(double firstSide, double secondSide, double thirdSide, Colors color, AbstractFigure figure) : base(firstSide, secondSide, thirdSide, figure)
        {
            CreationException.ColorsHandler(color, (figure as IPainted).FigureColor);
            FigureColor = color;
        }

        /// <summary>
        /// Constructor with parameters for creating white color (default color) paper triangle from other figure
        /// </summary>
        /// <param name="firstSide"></param>
        /// <param name="secondSide"></param>
        /// <param name="thirdSide"></param>
        /// <param name="figure"></param>
        public PaperTriangle(double firstSide, double secondSide, double thirdSide, AbstractFigure figure) : this(firstSide, secondSide, thirdSide, Colors.White, figure)
        {

        }

        /// <summary>
        /// Override ToString() method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ($"'{this.GetType().Name}', sides '{base.FirstSide}', '{base.SecondSide}' and '{base.ThirdSide}', color '{this.figureColor}'");
        }
    }
}
