using System;
using System.Xml;
using System.Collections.Generic;
using ClassLibrary.AbstractClasses;
using ClassLibrary.ExceptionClasses;

namespace ClassLibrary.InputOutputClasses
{
    public static class XmlInputOutput
    {
        public static void WriteToXmlFileFromBox(BoxWithFigures box, string xmlFilePath)
        {
            if (!xmlFilePath.EndsWith(".xml"))
                throw new InputOutputException("Wrong output file path. File name must have an extension \".xml\"");

            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings()
            {
                Indent = true,
                IndentChars = "\t"
            };

            using (XmlWriter xmlWriter = XmlWriter.Create(xmlFilePath, xmlWriterSettings))
            {
                xmlWriter.WriteStartDocument();

                xmlWriter.WriteStartElement(box.GetType().Name);

                foreach (AbstractFigure figure in box.Figures)
                {
                    xmlWriter.WriteStartElement(figure.GetType().Name);

                    xmlWriter.WriteStartElement("NameWithParameters");
                    xmlWriter.WriteString(figure.ToString());
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("Perimeter");
                    xmlWriter.WriteValue(figure.GetPerimeter());
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("Area");
                    xmlWriter.WriteValue(figure.GetArea());
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteEndElement();
                }

                xmlWriter.WriteEndElement();

                xmlWriter.WriteEndDocument();

                xmlWriter.Close();
            }
        }

        public static List<AbstractFigure> ReadFromXmlFileToList(string xmlFilePath)
        {
            if (!xmlFilePath.EndsWith(".xml"))
                throw new InputOutputException("Wrong input file path. File name must have an extension \".xml\"");

            List<AbstractFigure> figures = new List<AbstractFigure>();

            using (XmlReader xmlReader = XmlReader.Create(xmlFilePath))
            {
                while (xmlReader.Read())
                {
                    if (xmlReader.Name == "NameWithParameters")
                        figures.Add(StringsParser.FigureFromString(xmlReader.ReadElementContentAsString()));
                }

                xmlReader.Close();
            }

            return figures;
        }
    }
}
