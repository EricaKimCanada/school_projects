/*
 * Author: Group 30 (William Armstrong / Jeffrey Belford / Youngmin Chung)
 * Date: Apr 9, 2020
 * Filename: CompareExpressions.cs
 * Description: Create a class called “CompareExpressions” that would inherit the IComparaer interface.
 *              Within this class, override the Compare method to compare the results out of the conversion processes.
 */

using System;
using System.Collections.Generic;

namespace Project2_Group_30
{
    public class CompareExpressions : IComparer<string>
    {
        public int Compare(string Post, string Pre)
        {
            return Convert.ToInt32(Post.Equals(Pre));
        }
    }
}