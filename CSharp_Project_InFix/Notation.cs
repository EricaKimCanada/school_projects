/*
 * Author: Group 30 (William Armstrong / Jeffrey Belford / Youngmin Chung)
 * Date: Apr 9, 2020
 * Filename: Notation.cs
 * Description: Notation class for the summary report and creating XML file
 */
using System.Text;

namespace Project2_Group_30
{
    public class Notation
    {
        public string sno { get; set; }
        public string Infix { get; set; }
        public string PosFix { get; set; }
        public string PreFix { get; set; }
        public string PreFixResult { get; set; }
        public string PosFixResult { get; set; }
        public bool MatchResult { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat($"|{sno,5}|{Infix,20}|{PosFix,20}|{PreFix,20}|{PosFixResult,12}|{PreFixResult,12}|{MatchResult,7}|\n");
            return sb.ToString();
        }

        
    }
}