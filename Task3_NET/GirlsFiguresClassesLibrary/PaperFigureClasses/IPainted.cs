using System;

namespace ClassLibrary.PaperFigureClasses
{
    /// <summary>
    /// Interface for painting figures
    /// </summary>
    public interface IPainted
    {
        /// <summary>
        /// Color of figure
        /// </summary>
        Colors FigureColor { get; set; }
    }

    /// <summary>
    ///  Enum type with 16 Colors fields copied from https://docs.microsoft.com/en-us/dotnet/api/system.consolecolor
    /// </summary>
    public enum Colors
    {
        Black,          //  0   The color black
        DarkBlue,       //  1   The color dark blue
        DarkGreen,      //  2 	The color dark green
        DarkCyan,       //  3 	The color dark cyan (dark blue-green)
        DarkRed,        //  4 	The color dark red
        DarkMagenta, 	//  5 	The color dark magenta (dark purplish-red)
        DarkYellow, 	//  6 	The color dark yellow (ochre)
        Gray,           //  7 	The color gray
        DarkGray,       //  8 	The color dark gray
        Blue,           //  9 	The color blue
        Green,          // 10 	The color green
        Cyan,           // 11 	The color cyan (blue-green)
        Red,            // 12 	The color red
        Magenta,        // 13 	The color magenta (purplish-red)
        Yellow,         // 14 	The color yellow
        White           // 15 	The color white     (DEFAULT COLOR)
    }
}
