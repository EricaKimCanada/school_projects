/*
 * Author: Group 30 (William Armstrong / Jeffrey Belford / Youngmin Chung)
 * Date: Apr 9, 2020
 * Filename: Program.cs
 * Description: Using a CSV file contained infix expression to coverts Postfix/Prefix with evaluation results and match up to the summary report.
 *              And create a XML file with combined expressions. 
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Project2_Group_30
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Deserialization
            List<string> deserializedData = CSVFile.CSVDeserialize();
            List<string> InfixData = new List<string>();
            for (int i = 1; i < deserializedData.Count; i += 2)
            {
                InfixData.Add(deserializedData[i]);
            }

            // create new list
            List<Notation> notations = new List<Notation>();

            // create new classes
            Conversion cv = new Conversion();
            ExpressionEvaluation ee = new ExpressionEvaluation();
            CompareExpressions ce = new CompareExpressions();

            // contain converting values to notation class 
            for (int i = 0; i < InfixData.Count(); i++)
            {
                Notation note = new Notation();
                note.sno = i.ToString();
                note.Infix = InfixData[i];
                note.PosFix = cv.PostConvert(InfixData[i]);
                note.PosFixResult = ee.PostCalculate(note.PosFix);
                note.PreFix = cv.PreConvert(InfixData[i]);
                note.PreFixResult = ee.PreCalculate(note.PreFix);
                //checks for equivalency by seeing if a 1 is returned
                note.MatchResult = ce.Compare(note.PreFixResult, note.PosFixResult) == 1;
                notations.Add(note);
            }

            // console summary report
            string str = "";
            char pad = '=';
            Console.WriteLine(str.PadRight(104, pad));
            Console.WriteLine($"{"*",1}{"Summary",48} {"Report",1}{"*",48}");
            Console.WriteLine(str.PadRight(104, pad) + "\n");
            Console.WriteLine(
                $"|{"Sno",5}|{"Infix",20}|{"PosFix",20}|{"PreFix",20}|{"Prefix Res",12}|{"PosFix Res",12}|{"Match",7}|");
            Console.WriteLine(str.PadRight(104, pad));

            // Also, it must provide a summary report, including all conversion outputs, similar to the provided sample one.
            foreach (var notation in notations)
            {
                Console.Write(notation.ToString());
            }
            Console.WriteLine("\n" + str.PadRight(104, pad));

            // After demonstrating the summary report in the console,
            // the application must prompt the user that the required XML file is ready and bring it up on any web browser.
            XMLExtension.CSVtoXML(notations);

            string path = Environment.ExpandEnvironmentVariables(
                @"%PROGRAMFILES%\Internet Explorer\iexplore.exe");

            System.Diagnostics.Process.Start(path, Path.GetFullPath(XMLExtension.path));

            Console.ReadKey();

        }
    }
}