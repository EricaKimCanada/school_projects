/*
 * Coders: Yeonju Jeong, Sungok Kim, Osiris Hernandez
 * Date: Sunday, Feb 17th, 2020
 * 
 * Notes: Class containing the parsing logic for JSON, XML and CSV files.
 *        contains the main parsing function call.
 */

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Project1_G17
{
    public class DataModeler
    {

        /************************
        *      PROPERTIES       *
        ************************/
        private Dictionary<string, CityInfo> CityDictionary;


        /************************
        *      CONSTRUCTORS     *
        ************************/
        public DataModeler()
        {
            CityDictionary = new Dictionary<string, CityInfo>();
        }


        /************************
        *        DELEGATE       *
        ************************/
        public delegate void ParsingHandler(string fileName);


        /************************
        *        METHODS        *
        ************************/

        // Method that can parse an XML type document containing cities info
        public void ParseXML(string fileName)
        {
            // Set path
            string xmlFile = "..\\..\\Data\\" + fileName;

            try
            {
                //Load XML file into the DOM
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlFile);
                XmlNodeList canadaCityList = doc.GetElementsByTagName("CanadaCity");

                // Create CityInfo objects
                foreach (XmlElement canadaCity in canadaCityList)
                {
                    CityInfo cityInfo = new CityInfo();
                    foreach (XmlElement canadaCityItem in canadaCity.ChildNodes)
                    {
                        switch (canadaCityItem.Name)
                        {
                            case "id":
                                cityInfo.CityId = canadaCityItem.InnerText;
                                break;
                            case "city":
                                cityInfo.CityName = canadaCityItem.InnerText;
                                break;
                            case "city_ascii":
                                cityInfo.CityAscii = canadaCityItem.InnerText;
                                break;
                            case "population":
                                cityInfo.Population = Int64.Parse(canadaCityItem.InnerText);
                                break;
                            case "admin_name":
                                cityInfo.Province = canadaCityItem.InnerText;
                                break;
                            case "lat":
                                cityInfo.Latitude = Double.Parse(canadaCityItem.InnerText);
                                break;
                            case "lng":
                                cityInfo.Longitude = Double.Parse(canadaCityItem.InnerText);
                                break;
                            default:
                                break;
                        }
                    }

                    // Load cities into dictionary
                    if (!CityDictionary.ContainsKey(cityInfo.CityName))
                    {
                        CityDictionary.Add(cityInfo.CityName, cityInfo);
                    }
                    else
                    {
                        CityDictionary.Add(cityInfo.CityName + "(" + cityInfo.Province + ")", cityInfo);
                    }
                }
            }
            catch (XmlException err)
            {
                Console.WriteLine("\nXML ERROR: " + err.Message);
            }
            catch (Exception err)
            {
                Console.WriteLine("\nERROR: " + err.Message);
            }
        } // END ParseXML()


        // Method that can parse a JSON type document containing cities info
        public void ParseJSON(string fileName)
        {
            // Set path
            string path = "..\\..\\Data\\" + fileName;

            try
            {
                using (StreamReader r = new StreamReader(path))
                {
                    string json = r.ReadToEnd();

                    List<CityInfo> citylist = new List<CityInfo>();
                    dynamic items = JsonConvert.DeserializeObject(json);

                    // Create CityInfo objects
                    foreach (var item in items)
                    {
                        if (item.population == null)
                        {
                            item.population = 0;
                        }
                        if (item.lat == null)
                        {
                            item.lat = 0;
                        }
                        if (item.lng == null)
                        {
                            item.lng = 0;
                        }

                        CityInfo info = new CityInfo();
                        info.CityId = item.id;
                        info.CityName = item.city;
                        info.CityAscii = item.city_ascii;
                        info.Population = item.population;
                        info.Province = item.admin_name;
                        info.Latitude = item.lat;
                        info.Longitude = item.lng;

                        citylist.Add(info);
                    }

                    // Load cities into dictionary
                    foreach (CityInfo item in citylist)
                    {
                        if (!CityDictionary.ContainsKey(item.CityName))
                        {
                            // IF city name is not empty(due to partial entry in JSON doc)
                            if (item.CityName != "")
                            {
                                CityDictionary.Add(item.CityName, item);
                            }
                        }
                        else
                        {
                            CityDictionary.Add(item.CityName + "(" + item.Province + ")", item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        } // END ParseJSON()


        // Method that can parse a CSV type document containing cities info
        public void ParseCSV(string fileName)
        {
            // Set path
            string path = "..\\..\\Data\\" + fileName;

            // Call method to convert .csv file to json
            string jsonData = ConvertCsvToJsonObj(path);

            // Convert to JSON obj
            dynamic jsonObjects = JsonConvert.DeserializeObject(jsonData);
            
            // Iterate over container and add to dictionary as required
            foreach (var item in jsonObjects)
            {
                CityInfo city = new CityInfo();
                city.CityId = item.id;
                city.CityName = item.city;
                city.CityAscii = item.city_ascii;
                city.Population = item.population;
                city.Province = item.admin_name;
                city.Latitude = item.lat;
                city.Longitude = item.lng;

                string cityName = item.city;

                // If does not exist, ADD.  Else, append province and ADD.
                if (!CityDictionary.ContainsKey(cityName))
                {
                    CityDictionary.Add(cityName, city);
                }
                else
                {
                    CityDictionary.Add(cityName + "(" + item.admin_name + ")", city);
                }
            }

        } // END ParseCSV()


        // Method that will use delegate to call proper method depending on
        // parameters passed in.
        public Dictionary<string, CityInfo> ParseFile(string fileName, string fileType)
        {

            if (fileType == ".csv")
            {
                ParsingHandler parserHandler = new ParsingHandler(ParseCSV);
                parserHandler.Invoke(fileName + fileType);
            }
            else if (fileType == ".json")
            {
                ParsingHandler parserHandler = new ParsingHandler(ParseJSON);
                parserHandler.Invoke(fileName + fileType);
            }
            else if (fileType == ".xml")
            {
                ParsingHandler parserHandler = new ParsingHandler(ParseXML);
                parserHandler.Invoke(fileName + fileType);
            }

            return CityDictionary;

        } // END ParseFile()




        /************************
        *     HELPER METHODS    *
        ************************/

        /*
         * Purpose: Method that converts a .csv file to json format
         */
        public string ConvertCsvToJsonObj(string path)
        {
            var csv = new List<string[]>();
            var lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                csv.Add(line.Split(','));
            }

            var props = lines[0].Split(',');
            var finalOuput = new List<Dictionary<string, string>>();

            for (int i = 1; i < lines.Length; i++)
            {
                var result = new Dictionary<string, string>();

                for (int j = 0; j < props.Length; j++)
                    result.Add(props[j], csv[i][j]);

                finalOuput.Add(result);
            }

            return JsonConvert.SerializeObject(finalOuput);

        } // END ConvertCsvFileToJsonObject



    } // END DataModeler class

} // END namespace