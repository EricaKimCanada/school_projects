/*
 * Coders: Yeonju Jeong, Sungok Kim, Osiris Hernandez
 * Date: Sunday, Feb 17th, 2020
 * 
 * Notes: Object representation of a city. Contains various properties
 *        holding different information aspects of a city.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_G17
{
    public class CityInfo
    {

        /************************
        *      PROPERTIES       *
        ************************/
        public string CityId { get; set; }
        public string CityName { get; set; }
        public string CityAscii { get; set; }
        public long Population { get; set; }
        public string Province { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }



        /************************
        *        METHODS        *
        ************************/
        public string GetProvince()
        {
            return Province;

        } // END GetProvince()


        public long GetPopulation()
        {
            return Population;

        } // END GetPopulation()


        public string GetLocation()
        {
            return "Lat: " + Latitude + " / Lon: " + Longitude;

        } // END GetLocation()


        public override string ToString()
        {
            return CityId + "\n" + CityName;

        } // END ToString()


    } // END CityInfo class

} // END namespace