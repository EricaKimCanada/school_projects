/*
 * Coders: Yeonju Jeong, Sungok Kim, Osiris Hernandez
 * Date: Sunday, Feb 17th, 2020
 * 
 * Notes: Class containing all methods able to manipulate the data pulled
 *        from the DataModeler class.  Makes use of the Google Api for distance
 *        calculation and of the GMap.NET library to display a map with a marker.
 */

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GMap.NET;
using GMap.NET.MapProviders;

namespace Project1_G17
{
    public class Statistics
    {

        /************************
        *      PROPERTIES       *
        ************************/
        private Dictionary<string, CityInfo> CityCatalogue;


        /************************
        *      CONSTRUCTORS     *
        ************************/

        // Default
        public Statistics()
        {

        }


        // 2args
        public Statistics(string fileName, string fileType)
        {
            DataModeler dataModeler = new DataModeler();
            this.CityCatalogue = dataModeler.ParseFile(fileName, fileType);
        }



        /************************
        *     CITY METHODS      *
        ************************/

        // Returns the CityInfo object containing all city properties
        public CityInfo DisplayCityInformation(string cityName)
        {

            CityInfo cityinfo = new CityInfo();

            if (CityCatalogue.ContainsKey(cityName))
            {
                cityinfo = CityCatalogue[cityName];
            }

            return cityinfo;

        } // DisplayCityInformation()


        // Returns the name of the city with the largest population
        public string DisplayLargestPopulationCity()
        {

            long largestPop = 0;
            string cityName = "";

            foreach (var city in CityCatalogue)
            {
                if (largestPop < city.Value.Population)
                {
                    largestPop = city.Value.Population;
                    cityName = city.Value.CityName;
                }
            }

            return cityName;

        } // DisplayLargestPopulationCity()


        // Returns the name of the city with the smallest population
        public string DisplaySmallestPopulationCity()
        {

            long smallestPop = 0;
            string cityName = "";

            foreach (var city in CityCatalogue)
            {
                if (smallestPop == 0)
                    smallestPop = city.Value.Population;

                if (city.Value.Population < smallestPop)
                {
                    smallestPop = city.Value.Population;
                    cityName = city.Value.CityName;
                }
            }

            return cityName;

        } // DisplaySmallestPopulationCity()


        // Determines which city has the largest population and returns a detailed string with info.
        public string CompareCitiesPopluation(string firstCity, string secondCity)
        {

            long city1Pop = CityCatalogue[firstCity].GetPopulation();
            long city2Pop = CityCatalogue[secondCity].GetPopulation();

            if (city1Pop > city2Pop)
            {
                return firstCity + " has the largest population at " + city1Pop + " compared to " + city2Pop + " for " + secondCity;
            }
            else
            {
                return secondCity + " has the largest population at " + city2Pop + " compared to " + city1Pop + " for " + firstCity;
            }

        } // CompareCitiesPopluation()


        // Methods that takes a reference parameter to a GUI map control and city properties.  Displays
        // a map of requested city and applies a marker to it as per the cities coordinates.
        public void ShowCityOnMap(ref GMap.NET.WindowsForms.GMapControl map, string cityName, 
                                  string province, double lat, double lng)
        {
            // Prepare needed keyword parameter
            string cityKeyword = cityName + ", " + province;
            
            // Pick provider, set map position and define zoom properties
            map.MapProvider = GMapProviders.OpenStreetMap;
            map.SetPositionByKeywords(cityKeyword);

            map.MinZoom = 5;
            map.MaxZoom = 15;
            map.Zoom = 13;

            map.ShowCenter = false;

            // Apply market to city
            GMap.NET.WindowsForms.GMapOverlay markers = new GMap.NET.WindowsForms.GMapOverlay("markers");
            GMap.NET.WindowsForms.GMapMarker marker =
                new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                    new GMap.NET.PointLatLng(lat, lng),
                    GMap.NET.WindowsForms.Markers.GMarkerGoogleType.blue_pushpin);
            markers.Markers.Add(marker);
            map.Overlays.Add(markers);

        } // END ShowCityOnMap()


        // Returns a km value of the driving distance between 2 coordinates
        public string CalculateDistanceBetweenCities(string firstCity, string secondCity)
        {
            // 1st set of coords
            double latOne = CityCatalogue[firstCity].Latitude;
            double lngOne = CityCatalogue[firstCity].Longitude;

            // 2nd set of coords
            double latTwo = CityCatalogue[secondCity].Latitude;
            double lngTwo = CityCatalogue[secondCity].Longitude;

            // Set variables
            string distance = "";
            string url = @"https://maps.googleapis.com/maps/api/distancematrix/json?units=metric&origins=" + latOne + "," + lngOne + 
                          "&destinations=" + latTwo + "%2C" + lngTwo + "&key=";

            // Get info from Google API
            WebRequest request = WebRequest.Create(url);
            WebResponse response = (HttpWebResponse)request.GetResponse();

            // Turn to string, convert to JSON and access required value
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                if (!string.IsNullOrEmpty(result))
                {
                    dynamic json = JsonConvert.DeserializeObject(result);

                    // Check if no results found, IF so, return 'no match' message
                    string checkIfEmpty = json["rows"][0]["elements"][0]["status"];

                    if(checkIfEmpty == "ZERO_RESULTS")
                    {
                        return "At least one of those cities could not be found through Google API.";
                    }
                    // ELSE, return distance
                    else
                    {
                        distance = json["rows"][0]["elements"][0]["distance"]["text"];
                    } 
                }
            }

            // Return distance
            return distance + "s";

        } // CalculateDistanceBetweenCities()




        /************************
        *    PROVINCE METHODS   *
        ************************/

        // Gets the population value of the city in cataglogue matching city name passed in.
        public long DisplayProvincePopulation(string provinceName)
        {

            long popNum = 0;

            for (int i = 0; i < CityCatalogue.Count; i++)
            {
                KeyValuePair<string, CityInfo> entry = CityCatalogue.ElementAt(i);
                
                if (entry.Value.GetProvince() == provinceName)
                {
                    popNum += entry.Value.GetPopulation();
                }
            }

            return popNum;

        } // END DisplayProvincePopulation()


        //Accepts a province name parameter and returns a list of all cities of that province
        public SortedSet<string> DisplayProvinceCities(string provinceName)
        {
            SortedSet<string> cityList = new SortedSet<string>();

            foreach (KeyValuePair<string, CityInfo> item in CityCatalogue)
            {
                if (item.Value.Province == provinceName)
                    cityList.Add(item.Value.CityName);
            }

            return cityList;

        } // END DisplayProvinceCities()


        //Rank all provinces by population
        public string RankProvincesByPopulation()
        {
            Dictionary<string, long> popByProvDic = new Dictionary<string, long>();

            // Get province and total province population info
            foreach (KeyValuePair<string, CityInfo> city in CityCatalogue)
            {
                if (!popByProvDic.ContainsKey(city.Value.Province))
                {
                    popByProvDic.Add(city.Value.Province, city.Value.Population);
                }
                else
                {
                    long provPopulation = popByProvDic[city.Value.Province];
                    popByProvDic[city.Value.Province] = provPopulation + city.Value.Population;
                }
            }

            string sortedProvByPop = "";
            int rankNumber = 1;

            // Sort list
            foreach (KeyValuePair<string, long> popByProv in popByProvDic.OrderByDescending(key => key.Value))
            {
                // Format for cosmetic purposes
                if(rankNumber < 10)
                    sortedProvByPop += "   " + rankNumber + ". " + popByProv.Key + "\n";
                else
                    sortedProvByPop += " " + rankNumber + ". " + popByProv.Key + "\n";

                rankNumber++;
            }

            return sortedProvByPop;

        } // END RankProvincesByPopulation()


        //Rank all provinces by the number of cities
        public string RankProvincesByCities()
        {
            Dictionary<string, long> cityNumByProvDic = new Dictionary<string, long>();

            // Get province and total cities per provice info
            foreach (KeyValuePair<string, CityInfo> city in CityCatalogue)
            {
                if (!cityNumByProvDic.ContainsKey(city.Value.Province))
                {
                    cityNumByProvDic.Add(city.Value.Province, 1);
                }
                else
                {
                    long cityNumber = cityNumByProvDic[city.Value.Province];
                    cityNumByProvDic[city.Value.Province] = cityNumber + 1;
                }
            }

            string sortedProvByCity = "";
            int rankNumber = 1;

            // Sort List
            foreach (KeyValuePair<string, long> cityByProv in cityNumByProvDic.OrderByDescending(key => key.Value))
            {
                // Format for cosmetic purposes
                if (rankNumber < 10)
                    sortedProvByCity += "   " + rankNumber + ". " + cityByProv.Key + "\n";
                else
                    sortedProvByCity += " " + rankNumber + ". " + cityByProv.Key + "\n";

                rankNumber++;
            }

            return sortedProvByCity;

        } // END RankProvincesByCities()




        /************************
        *     HELPER METHODS    *
        ************************/

        // Obtains a list containing all city names
        public List<string> GetAllCities()
        {
            List<String> allCities = new List<string>();

            foreach (var city in CityCatalogue)
            {
                allCities.Add(city.Key);
            }

            return allCities;

        } // END GetAllCities()


        // Obtains a sorted list of province names
        public SortedSet<string> GetAllProvinces()
        {
            // Add to container to get unique values
            HashSet<string> allProvincesHash = new HashSet<string>();

            foreach (var city in CityCatalogue)
            {
                allProvincesHash.Add(city.Value.Province);
            }

            // Add to container to get it sorted
            SortedSet<string> allProvinces = new SortedSet<string>();

            foreach (var prov in allProvincesHash)
            {
                allProvinces.Add(prov);
            }

            return allProvinces;

        } // END GetAllProvinces()


        // Gets the length of the CityCatalogue property
        public int GetLength()
        {
            if(CityCatalogue == null)
                return 0;
            else
                return CityCatalogue.Count;

        } // END GetLength()



    } // END Statistics class

} // END namespace