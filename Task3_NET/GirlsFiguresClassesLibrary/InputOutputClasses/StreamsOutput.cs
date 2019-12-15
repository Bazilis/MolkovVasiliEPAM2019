using System;
using System.IO;
using System.Collections.Generic;
using ClassLibrary.AbstractClasses;
using ClassLibrary.ExceptionClasses;

namespace ClassLibrary.InputOutputClasses
{
    public static class StreamsOutput
    {
        public static void WriteToXmlFileFromBox(BoxWithFigures box, string filePath)
        {
            if (!filePath.EndsWith(".xml"))
                throw new OutputException("Wrong output file path. File name must have an extension \".xml\"");

            using (StreamWriter stream = new StreamWriter(filePath))
            {
                stream.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                stream.WriteLine($"<{box.GetType().Name}>");

                foreach (AbstractFigure figure in box.Figures)
                {
                    stream.WriteLine($"\t<{figure.GetType().Name}>");

                    stream.WriteLine($"\t\t<NameWithParameters>{figure.ToString()}</NameWithParameters>");
                    stream.WriteLine($"\t\t<Perimeter>{figure.GetPerimeter()}</Perimeter>");
                    stream.WriteLine($"\t\t<Square>{figure.GetArea()}</Square>");

                    stream.WriteLine($"\t</{figure.GetType().Name}>");
                }

                stream.WriteLine($"</{box.GetType().Name}>");
                stream.Close();
            }
        }
    }
}
