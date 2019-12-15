using System;
using System.Xml;
using ClassLibrary.AbstractClasses;
using ClassLibrary.ExceptionClasses;

namespace ClassLibrary.InputOutputClasses
{
    public static class XmlOutput
    {
        public static void WriteToXmlFileFromBox(BoxWithFigures box, string xmlFilePath)
        {
            if (!xmlFilePath.EndsWith(".xml"))
                throw new OutputException("Wrong output file path. File name must have an extension \".xml\"");

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

                    xmlWriter.WriteStartElement("Square");
                    xmlWriter.WriteValue(figure.GetArea());
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteEndElement();
                }

                xmlWriter.WriteEndElement();

                xmlWriter.WriteEndDocument();

                xmlWriter.Close();
            }
        }
    }
}
