/*
 * Author: Group 30 (William Armstrong / Jeffrey Belford / Youngmin Chung)
 * Date: Apr 9, 2020
 * Filename: CSVFile.cs
 * Description: Create a class called CSVFile.
 *              Within this class, create a method called CSVDeserialize() to dump the content of the CSV file to a list.
 */

using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;


namespace Project2_Group_30
{
    public class CSVFile
    {
        public static List<String> CSVDeserialize()
        {
            // get path
            string upperPath = Path.GetFullPath(
                Path.Combine(
                    Directory.GetCurrentDirectory(), "..", "..", ".."
                    )
                );
            // combine upper path and file name to save the file
            string path = Path.Combine(
                upperPath, 
                "Data", 
                "Project 2_INFO_5101.csv");
            TextFieldParser parser = new TextFieldParser(path);

            List<string> CSVData = new List<string>();

            parser.SetDelimiters(new string[] { "," });

            parser.ReadLine();
            while (!parser.EndOfData)
            {
                //Process row
                string[] fields = parser.ReadFields();
                
                foreach(var field in fields)
                {
                    CSVData.Add(field);
                }
            }

            return CSVData;       
        }
    }
}
