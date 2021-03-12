/*
 * Author: Group 30 (William Armstrong / Jeffrey Belford / Youngmin Chung)
 * Date: Apr 9, 2020
 * Filename: XMLExtension.cs
 * Description: Build a class Called XMLExtension that would have the following extension methods:
                a. WriteStartDocument: This method should include xml version and encoding
                b. WriteStartRootElement: This method should add the root tag to the file
                c. WriteEndRootElement: This method should end the root tag.
                d. WriteStartElement: This method should add the element tag to the file
                e. WriteEndElement: This method should end element tag
                f. WriteAttribute: This method should add each attribute with its values.
 */

using System;
using System.Collections.Generic;
using System.IO;

namespace Project2_Group_30
{
    public static class XMLExtension
    {

        public static string path = @"../../../XML/deserialized.xml";

        public static void CSVtoXML(List<Notation> itemList)
        {
            using var Writer = new StreamWriter(path);
            Writer.WriteStartDocument();
            Writer.WriteStartRootElement();
            try
            {
                foreach (var attribute in itemList)
                {
                    Writer.WriteStartElement();
                    Writer.WriteAttribute(attribute);
                    Writer.WriteEndElement();
                }

                Writer.WriteEndRootElement();

                Console.WriteLine($"Convert the summary report to XML file located {path} successfully!!!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void WriteStartDocument(this StreamWriter stream)
        {
            stream.Write("<?xml version= \"1.0\" encoding=\"UTF-8\"?>\n");
        }

        public static void WriteStartRootElement(this StreamWriter stream)
        {
            stream.Write("<root>\n");
        }

        public static void WriteEndRootElement(this StreamWriter stream)
        {
            stream.Write("</root>\n");
        }

        public static void WriteStartElement(this StreamWriter stream)
        {
            stream.Write("\t<element>\n");
        }

        public static void WriteEndElement(this StreamWriter stream)
        {
            stream.Write("\t</element>\n");
        }

        public static void WriteAttribute(this StreamWriter stream, Notation attribute)
        {
            var sno = "\t\t<sno>" + attribute.sno + "</sno>\n";
            var infix = "\t\t<infix>" + attribute.Infix + "</infix>\n";
            var prefix = "\t\t<prefix>" + attribute.PreFix + "</prefix>\n";
            var postfix = "\t\t<postfix>" + attribute.PosFix + "</postfix>\n";
            var result = "\t\t<evaluation>" + attribute.PosFixResult + "</evaluation>\n";
            var match = "\t\t<comparision>" + attribute.MatchResult + "</comparision>\n";
            var combine = sno + infix + prefix + postfix + result + match;
            stream.Write(combine);
        }
    }
}