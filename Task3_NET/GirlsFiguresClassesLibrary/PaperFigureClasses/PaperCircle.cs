using System;
using ClassLibrary.AbstractClasses;
using ClassLibrary.ExceptionClasses;

namespace ClassLibrary.PaperFigureClasses
{
    /// <summary>
    /// Class for paper circle, inherited from AbstractCircle class and implements interface IPainted
    /// </summary>
    public class PaperCircle : AbstractCircle, IPainted
    {
        private bool isFigurePainted;

        private Colors figureColor;

        /// <summary>
        /// Color of paper circle
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
        public PaperCircle()
        {
            FigureColor = Colors.White;
        }

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="radius"></param>
        public PaperCircle(double radius) : base(radius)
        {
            FigureColor = Colors.White;
        }

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="color"></param>
        public PaperCircle(double radius, Colors color) : base(radius)
        {
            FigureColor = color;
        }

        /// <summary>
        /// Constructor with parameters for creating paper circle from other figure
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="color"></param>
        /// <param name="figure"></param>
        public PaperCircle(double radius, Colors color, AbstractFigure figure) : base(radius, figure)
        {
            CreationException.ColorsHandler(color, (figure as IPainted).FigureColor);
            FigureColor = color;
        }

        /// <summary>
        /// Constructor with parameters for creating white color (default color) paper circle from other figure
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="figure"></param>
        public PaperCircle(double radius, AbstractFigure figure) : this(radius, Colors.White, figure)
        {

        }

        /// <summary>
        /// Override ToString() method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ($"'{this.GetType().Name}', radius '{base.Radius}', color '{this.figureColor}'");
        }
    }
}
