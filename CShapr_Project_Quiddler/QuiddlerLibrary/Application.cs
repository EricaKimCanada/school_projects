/*
 * Program:         QuiddlerLibrary.dll
 * Module:          Application.cs
 * Author:          E. Kim & N. Uddin
 * Date:            February 10, 2020
 * Description:     Application class for checking spelling. Unmanaged resourse.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuiddlerLibrary
{
    public class Application
    {
        Microsoft.Office.Interop.Word.Application application;
        public Application()
        {
            application = new Microsoft.Office.Interop.Word.Application();
        }        

        //Check Spelling of word
        public bool CheckSpelling(string word)
        {
            try
            {    
                return application.CheckSpelling(word.ToLower()); ;
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Exception occurred:" + Ex.Message);
            }
            return false;
        }

        public void Quit()
        {
            application.Quit();
        }
    }
}