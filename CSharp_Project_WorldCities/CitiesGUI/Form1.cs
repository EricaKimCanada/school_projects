/*
 * Coders: Yeonju Jeong, Sungok Kim, Osiris Hernandez
 * Date: Sunday, Feb 17th, 2020
 * 
 * Notes: Simple GUI allowing user to interact and display with 
 *        the statistics of various Canadian cities.
 */

using Project1_G17;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;

namespace CitiesGUI
{
    public partial class Form1 : Form
    {

        /************************
        *         GLOBAL        *
        ************************/
        static Statistics stats = new Statistics();


        /************************
        *      CONSTRUCTORS     *
        ************************/
        public Form1()
        {
            InitializeComponent();
            
            TurnOffCityLabels();
            TurnOffHeaderLabels();

        } // END Form1()



        /************************
        *        METHODS        *
        ************************/

        // OnPress method to parse a JSON file
        private void ParseJsonFile(object sender, EventArgs e)
        {
            string fileName = "Canadcities-JSON";
            string fileType = ".json";

            stats = new Statistics(fileName, fileType);

            ClearCB();

            LoadCityCB();
            LoadHeaderResults();
            TurnOnHeaderLabels();
            LoadProvincesCB();

        } // END ParseJsonFile()


        // OnPress method to parse an XML file
        private void ParseXmlFile(object sender, EventArgs e)
        {
            string fileName = "Canadcities-XML";
            string fileType = ".xml";

            stats = new Statistics(fileName, fileType);

            ClearCB();

            LoadCityCB();
            LoadHeaderResults();
            TurnOnHeaderLabels();
            LoadProvincesCB();

        } // END ParseXmlFile()


        // OnPress method to parse a CSV file
        private void ParseCsvFile(object sender, EventArgs e)
        {
            string fileName = "Canadacities";
            string fileType = ".csv";

            stats = new Statistics(fileName, fileType);

            ClearCB();

            LoadCityCB();
            LoadHeaderResults();
            TurnOnHeaderLabels();
            LoadProvincesCB();

        } // END ParseCsvFile()


        // OnPress method that will display the properties of a
        // CityInfo object to screen.
        private void GetCityInfo(object sender, EventArgs e)
        {
            // Get ComboBox selection
            int selectedIndex = citiesComboBox.SelectedIndex;

            // Check that something has been selected
            if (selectedIndex == -1)
            {
                string title = "ERROR";
                string message = "You must select city first.";

                MessageBox.Show(message, title);
                return;
            }

            // Get and display info
            Object selectedItem = citiesComboBox.SelectedItem;

            CityInfo loneCity = stats.DisplayCityInformation(selectedItem.ToString());

            idResultLabel.Text = loneCity.CityId;
            nameResultLabel.Text = loneCity.CityName;
            asciiResultLabel.Text = loneCity.CityAscii;
            popResultLabel.Text = loneCity.Population.ToString();
            provResultLabel.Text = loneCity.Province;
            latResultLabel.Text = loneCity.Latitude.ToString();
            lngResultLabel.Text = loneCity.Longitude.ToString();

            TurnOnCityLabels();

        } // END GetCityInfo()


        // OnPress method to will compare some properties between two cities.
        private void CompareCities(object sender, EventArgs e)
        {
            // Get selection
            int selectedIndex = firstCityCB.SelectedIndex;
            int selectedIndex2 = secondCityCB.SelectedIndex;

            //  Validate selection
            if (selectedIndex == -1 || selectedIndex2 == -1)
            {
                string title = "ERROR";
                string message = "You must select two cities before comparing cities.";

                MessageBox.Show(message, title);
                return;
            }
            else if (selectedIndex == selectedIndex2)
            {
                string title = "ERROR";
                string message = "You must select two different cities to compare.";

                MessageBox.Show(message, title);
                return;
            }

            // Get and display requested info
            Object selectedItem1 = firstCityCB.SelectedItem;
            Object selectedItem2 = secondCityCB.SelectedItem;

            richTextBox1.Text = stats.CompareCitiesPopluation(selectedItem1.ToString(), selectedItem2.ToString());

        } // END CompareCities()


        // OnPress method that will display the driving distance
        // between two selected cities.
        private void CalculateCityDistance(object sender, EventArgs e)
        {
            // Get selection
            int selectedIndex = firstCityCB.SelectedIndex;
            int selectedIndex2 = secondCityCB.SelectedIndex;

            // Validate selection
            if (selectedIndex == -1 || selectedIndex2 == -1)
            {
                string title = "ERROR";
                string message = "You must select two cities before calculating distance.";
                
                MessageBox.Show(message, title);

                return;
            }
            else if (selectedIndex == selectedIndex2)
            {
                string title = "ERROR";
                string message = "You must select two different cities to calculate distance.";

                MessageBox.Show(message, title);
                return;
            }

            Object selectedItem1 = firstCityCB.SelectedItem;
            Object selectedItem2 = secondCityCB.SelectedItem;

            // Get distance
            string distance = stats.CalculateDistanceBetweenCities(selectedItem1.ToString(), selectedItem2.ToString());

            // IF result equals length of no match message
            if (distance.Length == 67)
            {
                richTextBox1.Text = distance;
            }
            // Update textbox with distance
            else
            {
                richTextBox1.Text = "The driving distance between " + firstCityCB.SelectedItem + " and "
                                 + secondCityCB.SelectedItem + " is " + distance + ".";
            }

        } // END CalculateCityDistance()


        // OnPress method to will display the population of a province
        private void GetProvincePopulation(object sender, EventArgs e)
        {
            // Get selection
            int selectedIndex = provincesCB.SelectedIndex;

            // Validate it
            if (selectedIndex == -1)
            {
                string title = "ERROR";
                string message = "You must select a province first.";

                MessageBox.Show(message, title);
                return;
            }

            // Display it
            string popNum = stats.DisplayProvincePopulation(provincesCB.SelectedItem.ToString()).ToString();
            popRichTB.Text = popNum;

        } // END GetProvincePopulation()


        // OnPress method to will show the cities of a specific province
        private void GetCitiesPerProvince(object sender, EventArgs e)
        {
            // Clear previnous results
            resultsListBox.Items.Clear();

            // Get selection and validate it
            int selectedIndex = provincesCB.SelectedIndex;

            if (selectedIndex == -1)
            {
                string title = "ERROR";
                string message = "You must select a province first.";

                MessageBox.Show(message, title);
                return;
            }

            // Display them to screen
            SortedSet<string> allCitiesInProv = stats.DisplayProvinceCities(provincesCB.SelectedItem.ToString());

            for (int i = 0; i < allCitiesInProv.Count; i++)
            {
                if (i < 9)
                    resultsListBox.Items.Add("  " + (i + 1) + ". " + allCitiesInProv.ElementAt(i));
                else
                    resultsListBox.Items.Add((i + 1) + ". " + allCitiesInProv.ElementAt(i));
            }

        } // END GetCitiesPerProvince()


        // OnPress method that will display a list of provinces sorted by population
        private void ListByPopulation(object sender, EventArgs e)
        {
            // Make sure cities info is available
            if (stats.GetLength() == 0)
            {
                string title = "ERROR";
                string message = "You must select a file type on the side panel.";

                MessageBox.Show(message, title);
                return;
            }

            // Display requested info
            string allProvs = stats.RankProvincesByPopulation();
            listProvByTB.Text = allProvs;

        } // ListByPopulation()


        // OnPress method will display a list of provinces sorted by amount of cities
        private void ListByCityCount(object sender, EventArgs e)
        {
            // Make sure cities info is available
            if (stats.GetLength() == 0)
            {
                string title = "ERROR";
                string message = "You must select a file type on the side panel.";

                MessageBox.Show(message, title);
                return;
            }

            // Display requested info
            string allProvs = stats.RankProvincesByCities();
            listProvByTB.Text = allProvs;

        } // END ListByCityCount()


        // OnPress method that displays a marker on map of selected city
        private void LoadMap(object sender, EventArgs e)
        {
            // Get ComboBox selection
            int selectedIndex = showMapCitiesCB.SelectedIndex;

            // Check that something has been selected
            if (selectedIndex == -1)
            {
                string title = "ERROR";
                string message = "You must select city first.";

                MessageBox.Show(message, title);
                return;
            }

            // Get and display info
            Object selectedItem = showMapCitiesCB.SelectedItem;

            CityInfo loneCity = stats.DisplayCityInformation(selectedItem.ToString());

            stats.ShowCityOnMap(ref map, loneCity.CityName, loneCity.Province, loneCity.Latitude, loneCity.Longitude);

        } // END LoadMap()




        /************************
        *     HELPER METHODS    *
        ************************/

        // Loads header info
        private void LoadHeaderResults()
        {
            largestResultLabel.Text = stats.DisplayLargestPopulationCity();
            smallestResultLabel.Text = stats.DisplaySmallestPopulationCity();

        } // END LoadHeaderResults()


        // Loads the cities ComboBoxes
        private void LoadCityCB()
        {
            List<string> allCities = stats.GetAllCities();

            foreach (var item in allCities)
            {
                citiesComboBox.Items.Add(item);
                firstCityCB.Items.Add(item);
                secondCityCB.Items.Add(item);
                showMapCitiesCB.Items.Add(item);
            }

        } // END LoadCityCBs()


        // Loads the provinces ComboBoxes
        private void LoadProvincesCB()
        {
            SortedSet<string> allCities = stats.GetAllProvinces();

            foreach (var prov in allCities)
            {
                provincesCB.Items.Add(prov);
            }

        } // END LoadCityCBs()


        // Clears all ComboBoxes
        private void ClearCB()
        {
            citiesComboBox.Items.Clear();
            firstCityCB.Items.Clear();
            secondCityCB.Items.Clear();
            provincesCB.Items.Clear();
            showMapCitiesCB.Items.Clear();

        } // END ClearCB()


        // Makes labels not visible
        private void TurnOffCityLabels()
        {
            idResultLabel.Visible = false;
            nameResultLabel.Visible = false;
            asciiResultLabel.Visible = false;
            popResultLabel.Visible = false;
            provResultLabel.Visible = false;
            latResultLabel.Visible = false;
            lngResultLabel.Visible = false;

        } // END TurnOffCityLabels


        // Makes labels visible
        private void TurnOnCityLabels()
        {
            idResultLabel.Visible = true;
            nameResultLabel.Visible = true;
            asciiResultLabel.Visible = true;
            popResultLabel.Visible = true;
            provResultLabel.Visible = true;
            latResultLabel.Visible = true;
            lngResultLabel.Visible = true;

        } // END TurnOnCityLabels


        // Makes header labels not visible
        private void TurnOffHeaderLabels()
        {
            largestResultLabel.Visible = false;
            smallestResultLabel.Visible = false;

        } // END TurnOffHeaderLabels()


        // Makes header labels visible
        private void TurnOnHeaderLabels()
        {
            largestResultLabel.Visible = true;
            smallestResultLabel.Visible = true;

        } // END TurnOnHeaderLabels



    } // END Form1 class

} // END namespace