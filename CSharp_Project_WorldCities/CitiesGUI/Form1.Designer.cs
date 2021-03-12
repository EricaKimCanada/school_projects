namespace CitiesGUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.tabPanel = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cityInfoLabel = new System.Windows.Forms.Label();
            this.twoCityLabel = new System.Windows.Forms.Label();
            this.divider3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.compareCitiesBtn = new System.Windows.Forms.Button();
            this.secondCityCB = new System.Windows.Forms.ComboBox();
            this.firstCityCB = new System.Windows.Forms.ComboBox();
            this.citiesComboBox = new System.Windows.Forms.ComboBox();
            this.lngResultLabel = new System.Windows.Forms.Label();
            this.getCityInfoBtn = new System.Windows.Forms.Button();
            this.latResultLabel = new System.Windows.Forms.Label();
            this.nameHeaderLabel = new System.Windows.Forms.Label();
            this.provResultLabel = new System.Windows.Forms.Label();
            this.idHeaderLabel = new System.Windows.Forms.Label();
            this.popResultLabel = new System.Windows.Forms.Label();
            this.asciiHeaderLabel = new System.Windows.Forms.Label();
            this.asciiResultLabel = new System.Windows.Forms.Label();
            this.popHeaderLabel = new System.Windows.Forms.Label();
            this.nameResultLabel = new System.Windows.Forms.Label();
            this.provHeaderLabel = new System.Windows.Forms.Label();
            this.idResultLabel = new System.Windows.Forms.Label();
            this.latHeaderLabel = new System.Windows.Forms.Label();
            this.lgnHeaderLabel = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listByLabel = new System.Windows.Forms.Label();
            this.ByCitiesBtn = new System.Windows.Forms.Button();
            this.listProvByTB = new System.Windows.Forms.RichTextBox();
            this.byPopBtn = new System.Windows.Forms.Button();
            this.pickProvLabel = new System.Windows.Forms.Label();
            this.totPopLabel = new System.Windows.Forms.Label();
            this.listProvsLabel = new System.Windows.Forms.Label();
            this.popRichTB = new System.Windows.Forms.RichTextBox();
            this.GetPopulationBtn = new System.Windows.Forms.Button();
            this.resultsListBox = new System.Windows.Forms.ListBox();
            this.getCitiesBtn = new System.Windows.Forms.Button();
            this.provincesCB = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.smallestResultLabel = new System.Windows.Forms.Label();
            this.smallPopLabel = new System.Windows.Forms.Label();
            this.largestResultLabel = new System.Windows.Forms.Label();
            this.lgstPopLabel = new System.Windows.Forms.Label();
            this.sidePanel = new System.Windows.Forms.Panel();
            this.divider1 = new System.Windows.Forms.Panel();
            this.divider2 = new System.Windows.Forms.Panel();
            this.xmlImgBox = new System.Windows.Forms.PictureBox();
            this.jsonImgBox = new System.Windows.Forms.PictureBox();
            this.csvIconBox = new System.Windows.Forms.PictureBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.map = new GMap.NET.WindowsForms.GMapControl();
            this.loadMapBtn = new System.Windows.Forms.Button();
            this.showMapCitiesCB = new System.Windows.Forms.ComboBox();
            this.s = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.tabPanel.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.sidePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xmlImgBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jsonImgBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.csvIconBox)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.Teal;
            this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mainPanel.Controls.Add(this.tabPanel);
            this.mainPanel.Controls.Add(this.panel1);
            this.mainPanel.Controls.Add(this.sidePanel);
            this.mainPanel.Location = new System.Drawing.Point(-1, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(636, 353);
            this.mainPanel.TabIndex = 2;
            // 
            // tabPanel
            // 
            this.tabPanel.Controls.Add(this.tabPage1);
            this.tabPanel.Controls.Add(this.tabPage2);
            this.tabPanel.Controls.Add(this.tabPage3);
            this.tabPanel.Location = new System.Drawing.Point(112, 51);
            this.tabPanel.Name = "tabPanel";
            this.tabPanel.SelectedIndex = 0;
            this.tabPanel.Size = new System.Drawing.Size(524, 302);
            this.tabPanel.TabIndex = 21;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.DarkCyan;
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage1.Controls.Add(this.cityInfoLabel);
            this.tabPage1.Controls.Add(this.twoCityLabel);
            this.tabPage1.Controls.Add(this.divider3);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Controls.Add(this.compareCitiesBtn);
            this.tabPage1.Controls.Add(this.secondCityCB);
            this.tabPage1.Controls.Add(this.firstCityCB);
            this.tabPage1.Controls.Add(this.citiesComboBox);
            this.tabPage1.Controls.Add(this.lngResultLabel);
            this.tabPage1.Controls.Add(this.getCityInfoBtn);
            this.tabPage1.Controls.Add(this.latResultLabel);
            this.tabPage1.Controls.Add(this.nameHeaderLabel);
            this.tabPage1.Controls.Add(this.provResultLabel);
            this.tabPage1.Controls.Add(this.idHeaderLabel);
            this.tabPage1.Controls.Add(this.popResultLabel);
            this.tabPage1.Controls.Add(this.asciiHeaderLabel);
            this.tabPage1.Controls.Add(this.asciiResultLabel);
            this.tabPage1.Controls.Add(this.popHeaderLabel);
            this.tabPage1.Controls.Add(this.nameResultLabel);
            this.tabPage1.Controls.Add(this.provHeaderLabel);
            this.tabPage1.Controls.Add(this.idResultLabel);
            this.tabPage1.Controls.Add(this.latHeaderLabel);
            this.tabPage1.Controls.Add(this.lgnHeaderLabel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(516, 276);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "City Functions";
            // 
            // cityInfoLabel
            // 
            this.cityInfoLabel.AutoSize = true;
            this.cityInfoLabel.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cityInfoLabel.Location = new System.Drawing.Point(90, 11);
            this.cityInfoLabel.Name = "cityInfoLabel";
            this.cityInfoLabel.Size = new System.Drawing.Size(63, 18);
            this.cityInfoLabel.TabIndex = 30;
            this.cityInfoLabel.Text = "City Info";
            // 
            // twoCityLabel
            // 
            this.twoCityLabel.AutoSize = true;
            this.twoCityLabel.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.twoCityLabel.Location = new System.Drawing.Point(337, 11);
            this.twoCityLabel.Name = "twoCityLabel";
            this.twoCityLabel.Size = new System.Drawing.Size(114, 18);
            this.twoCityLabel.TabIndex = 29;
            this.twoCityLabel.Text = "Two city options";
            // 
            // divider3
            // 
            this.divider3.BackColor = System.Drawing.Color.Black;
            this.divider3.Location = new System.Drawing.Point(274, -3);
            this.divider3.Name = "divider3";
            this.divider3.Size = new System.Drawing.Size(2, 276);
            this.divider3.TabIndex = 28;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(340, 219);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 23);
            this.button1.TabIndex = 27;
            this.button1.Text = "Calculate Distance";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.CalculateCityDistance);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(307, 106);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(165, 65);
            this.richTextBox1.TabIndex = 26;
            this.richTextBox1.Text = "";
            // 
            // compareCitiesBtn
            // 
            this.compareCitiesBtn.Location = new System.Drawing.Point(340, 190);
            this.compareCitiesBtn.Name = "compareCitiesBtn";
            this.compareCitiesBtn.Size = new System.Drawing.Size(113, 23);
            this.compareCitiesBtn.TabIndex = 24;
            this.compareCitiesBtn.Text = "Compare Cities";
            this.compareCitiesBtn.UseVisualStyleBackColor = true;
            this.compareCitiesBtn.Click += new System.EventHandler(this.CompareCities);
            // 
            // secondCityCB
            // 
            this.secondCityCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.secondCityCB.FormattingEnabled = true;
            this.secondCityCB.Location = new System.Drawing.Point(307, 71);
            this.secondCityCB.Name = "secondCityCB";
            this.secondCityCB.Size = new System.Drawing.Size(165, 21);
            this.secondCityCB.TabIndex = 22;
            // 
            // firstCityCB
            // 
            this.firstCityCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.firstCityCB.FormattingEnabled = true;
            this.firstCityCB.Location = new System.Drawing.Point(307, 32);
            this.firstCityCB.Name = "firstCityCB";
            this.firstCityCB.Size = new System.Drawing.Size(165, 21);
            this.firstCityCB.TabIndex = 21;
            // 
            // citiesComboBox
            // 
            this.citiesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.citiesComboBox.FormattingEnabled = true;
            this.citiesComboBox.Location = new System.Drawing.Point(34, 32);
            this.citiesComboBox.Name = "citiesComboBox";
            this.citiesComboBox.Size = new System.Drawing.Size(165, 21);
            this.citiesComboBox.TabIndex = 4;
            // 
            // lngResultLabel
            // 
            this.lngResultLabel.AutoSize = true;
            this.lngResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lngResultLabel.Location = new System.Drawing.Point(120, 170);
            this.lngResultLabel.Name = "lngResultLabel";
            this.lngResultLabel.Size = new System.Drawing.Size(58, 15);
            this.lngResultLabel.TabIndex = 20;
            this.lngResultLabel.Text = "longitude";
            // 
            // getCityInfoBtn
            // 
            this.getCityInfoBtn.Location = new System.Drawing.Point(70, 204);
            this.getCityInfoBtn.Name = "getCityInfoBtn";
            this.getCityInfoBtn.Size = new System.Drawing.Size(75, 23);
            this.getCityInfoBtn.TabIndex = 6;
            this.getCityInfoBtn.Text = "Run";
            this.getCityInfoBtn.UseVisualStyleBackColor = true;
            this.getCityInfoBtn.Click += new System.EventHandler(this.GetCityInfo);
            // 
            // latResultLabel
            // 
            this.latResultLabel.AutoSize = true;
            this.latResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.latResultLabel.Location = new System.Drawing.Point(120, 153);
            this.latResultLabel.Name = "latResultLabel";
            this.latResultLabel.Size = new System.Drawing.Size(47, 15);
            this.latResultLabel.TabIndex = 19;
            this.latResultLabel.Text = "latitude";
            // 
            // nameHeaderLabel
            // 
            this.nameHeaderLabel.AutoSize = true;
            this.nameHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameHeaderLabel.Location = new System.Drawing.Point(61, 89);
            this.nameHeaderLabel.Name = "nameHeaderLabel";
            this.nameHeaderLabel.Size = new System.Drawing.Size(53, 16);
            this.nameHeaderLabel.TabIndex = 7;
            this.nameHeaderLabel.Text = "Name:";
            // 
            // provResultLabel
            // 
            this.provResultLabel.AutoSize = true;
            this.provResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.provResultLabel.Location = new System.Drawing.Point(120, 137);
            this.provResultLabel.Name = "provResultLabel";
            this.provResultLabel.Size = new System.Drawing.Size(53, 15);
            this.provResultLabel.TabIndex = 18;
            this.provResultLabel.Text = "province";
            // 
            // idHeaderLabel
            // 
            this.idHeaderLabel.AutoSize = true;
            this.idHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idHeaderLabel.Location = new System.Drawing.Point(89, 75);
            this.idHeaderLabel.Name = "idHeaderLabel";
            this.idHeaderLabel.Size = new System.Drawing.Size(25, 16);
            this.idHeaderLabel.TabIndex = 8;
            this.idHeaderLabel.Text = "Id:";
            // 
            // popResultLabel
            // 
            this.popResultLabel.AutoSize = true;
            this.popResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.popResultLabel.Location = new System.Drawing.Point(120, 121);
            this.popResultLabel.Name = "popResultLabel";
            this.popResultLabel.Size = new System.Drawing.Size(65, 15);
            this.popResultLabel.TabIndex = 17;
            this.popResultLabel.Text = "population";
            // 
            // asciiHeaderLabel
            // 
            this.asciiHeaderLabel.AutoSize = true;
            this.asciiHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.asciiHeaderLabel.Location = new System.Drawing.Point(67, 104);
            this.asciiHeaderLabel.Name = "asciiHeaderLabel";
            this.asciiHeaderLabel.Size = new System.Drawing.Size(46, 16);
            this.asciiHeaderLabel.TabIndex = 9;
            this.asciiHeaderLabel.Text = "Ascii:";
            // 
            // asciiResultLabel
            // 
            this.asciiResultLabel.AutoSize = true;
            this.asciiResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.asciiResultLabel.Location = new System.Drawing.Point(120, 105);
            this.asciiResultLabel.Name = "asciiResultLabel";
            this.asciiResultLabel.Size = new System.Drawing.Size(32, 15);
            this.asciiResultLabel.TabIndex = 16;
            this.asciiResultLabel.Text = "ascii";
            // 
            // popHeaderLabel
            // 
            this.popHeaderLabel.AutoSize = true;
            this.popHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.popHeaderLabel.Location = new System.Drawing.Point(29, 120);
            this.popHeaderLabel.Name = "popHeaderLabel";
            this.popHeaderLabel.Size = new System.Drawing.Size(86, 16);
            this.popHeaderLabel.TabIndex = 10;
            this.popHeaderLabel.Text = "Population:";
            // 
            // nameResultLabel
            // 
            this.nameResultLabel.AutoSize = true;
            this.nameResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameResultLabel.Location = new System.Drawing.Point(120, 90);
            this.nameResultLabel.Name = "nameResultLabel";
            this.nameResultLabel.Size = new System.Drawing.Size(39, 15);
            this.nameResultLabel.TabIndex = 15;
            this.nameResultLabel.Text = "name";
            // 
            // provHeaderLabel
            // 
            this.provHeaderLabel.AutoSize = true;
            this.provHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.provHeaderLabel.Location = new System.Drawing.Point(40, 136);
            this.provHeaderLabel.Name = "provHeaderLabel";
            this.provHeaderLabel.Size = new System.Drawing.Size(73, 16);
            this.provHeaderLabel.TabIndex = 11;
            this.provHeaderLabel.Text = "Province:";
            // 
            // idResultLabel
            // 
            this.idResultLabel.AutoSize = true;
            this.idResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idResultLabel.Location = new System.Drawing.Point(120, 76);
            this.idResultLabel.Name = "idResultLabel";
            this.idResultLabel.Size = new System.Drawing.Size(17, 15);
            this.idResultLabel.TabIndex = 14;
            this.idResultLabel.Text = "id";
            // 
            // latHeaderLabel
            // 
            this.latHeaderLabel.AutoSize = true;
            this.latHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.latHeaderLabel.Location = new System.Drawing.Point(46, 152);
            this.latHeaderLabel.Name = "latHeaderLabel";
            this.latHeaderLabel.Size = new System.Drawing.Size(67, 16);
            this.latHeaderLabel.TabIndex = 12;
            this.latHeaderLabel.Text = "Latitude:";
            // 
            // lgnHeaderLabel
            // 
            this.lgnHeaderLabel.AutoSize = true;
            this.lgnHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lgnHeaderLabel.Location = new System.Drawing.Point(34, 169);
            this.lgnHeaderLabel.Name = "lgnHeaderLabel";
            this.lgnHeaderLabel.Size = new System.Drawing.Size(80, 16);
            this.lgnHeaderLabel.TabIndex = 13;
            this.lgnHeaderLabel.Text = "Longitude:";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.DarkCyan;
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.pickProvLabel);
            this.tabPage2.Controls.Add(this.totPopLabel);
            this.tabPage2.Controls.Add(this.listProvsLabel);
            this.tabPage2.Controls.Add(this.popRichTB);
            this.tabPage2.Controls.Add(this.GetPopulationBtn);
            this.tabPage2.Controls.Add(this.resultsListBox);
            this.tabPage2.Controls.Add(this.getCitiesBtn);
            this.tabPage2.Controls.Add(this.provincesCB);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(516, 276);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Province Functions";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkCyan;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.listByLabel);
            this.panel2.Controls.Add(this.ByCitiesBtn);
            this.panel2.Controls.Add(this.listProvByTB);
            this.panel2.Controls.Add(this.byPopBtn);
            this.panel2.Location = new System.Drawing.Point(266, 107);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(248, 167);
            this.panel2.TabIndex = 14;
            // 
            // listByLabel
            // 
            this.listByLabel.AutoSize = true;
            this.listByLabel.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listByLabel.Location = new System.Drawing.Point(68, 6);
            this.listByLabel.Name = "listByLabel";
            this.listByLabel.Size = new System.Drawing.Size(117, 18);
            this.listByLabel.TabIndex = 13;
            this.listByLabel.Text = "List Provinces By";
            // 
            // ByCitiesBtn
            // 
            this.ByCitiesBtn.Location = new System.Drawing.Point(74, 133);
            this.ByCitiesBtn.Name = "ByCitiesBtn";
            this.ByCitiesBtn.Size = new System.Drawing.Size(98, 23);
            this.ByCitiesBtn.TabIndex = 12;
            this.ByCitiesBtn.Text = "By City Count";
            this.ByCitiesBtn.UseVisualStyleBackColor = true;
            this.ByCitiesBtn.Click += new System.EventHandler(this.ListByCityCount);
            // 
            // listProvByTB
            // 
            this.listProvByTB.Location = new System.Drawing.Point(22, 27);
            this.listProvByTB.Name = "listProvByTB";
            this.listProvByTB.Size = new System.Drawing.Size(204, 76);
            this.listProvByTB.TabIndex = 10;
            this.listProvByTB.Text = "";
            // 
            // byPopBtn
            // 
            this.byPopBtn.Location = new System.Drawing.Point(74, 110);
            this.byPopBtn.Name = "byPopBtn";
            this.byPopBtn.Size = new System.Drawing.Size(98, 23);
            this.byPopBtn.TabIndex = 11;
            this.byPopBtn.Text = "By Population";
            this.byPopBtn.UseVisualStyleBackColor = true;
            this.byPopBtn.Click += new System.EventHandler(this.ListByPopulation);
            // 
            // pickProvLabel
            // 
            this.pickProvLabel.AutoSize = true;
            this.pickProvLabel.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pickProvLabel.Location = new System.Drawing.Point(66, 14);
            this.pickProvLabel.Name = "pickProvLabel";
            this.pickProvLabel.Size = new System.Drawing.Size(105, 18);
            this.pickProvLabel.TabIndex = 9;
            this.pickProvLabel.Text = "Pick a province";
            // 
            // totPopLabel
            // 
            this.totPopLabel.AutoSize = true;
            this.totPopLabel.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totPopLabel.Location = new System.Drawing.Point(337, 14);
            this.totPopLabel.Name = "totPopLabel";
            this.totPopLabel.Size = new System.Drawing.Size(115, 18);
            this.totPopLabel.TabIndex = 8;
            this.totPopLabel.Text = "Total Population";
            // 
            // listProvsLabel
            // 
            this.listProvsLabel.AutoSize = true;
            this.listProvsLabel.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listProvsLabel.Location = new System.Drawing.Point(33, 90);
            this.listProvsLabel.Name = "listProvsLabel";
            this.listProvsLabel.Size = new System.Drawing.Size(168, 18);
            this.listProvsLabel.TabIndex = 7;
            this.listProvsLabel.Text = "List of cities per province";
            // 
            // popRichTB
            // 
            this.popRichTB.Location = new System.Drawing.Point(314, 38);
            this.popRichTB.Name = "popRichTB";
            this.popRichTB.Size = new System.Drawing.Size(163, 21);
            this.popRichTB.TabIndex = 6;
            this.popRichTB.Text = "";
            // 
            // GetPopulationBtn
            // 
            this.GetPopulationBtn.Location = new System.Drawing.Point(340, 67);
            this.GetPopulationBtn.Name = "GetPopulationBtn";
            this.GetPopulationBtn.Size = new System.Drawing.Size(101, 23);
            this.GetPopulationBtn.TabIndex = 4;
            this.GetPopulationBtn.Text = "Get Population";
            this.GetPopulationBtn.UseVisualStyleBackColor = true;
            this.GetPopulationBtn.Click += new System.EventHandler(this.GetProvincePopulation);
            // 
            // resultsListBox
            // 
            this.resultsListBox.FormattingEnabled = true;
            this.resultsListBox.Location = new System.Drawing.Point(36, 114);
            this.resultsListBox.Name = "resultsListBox";
            this.resultsListBox.Size = new System.Drawing.Size(163, 108);
            this.resultsListBox.TabIndex = 3;
            // 
            // getCitiesBtn
            // 
            this.getCitiesBtn.Location = new System.Drawing.Point(60, 232);
            this.getCitiesBtn.Name = "getCitiesBtn";
            this.getCitiesBtn.Size = new System.Drawing.Size(101, 23);
            this.getCitiesBtn.TabIndex = 2;
            this.getCitiesBtn.Text = "Get Cities";
            this.getCitiesBtn.UseVisualStyleBackColor = true;
            this.getCitiesBtn.Click += new System.EventHandler(this.GetCitiesPerProvince);
            // 
            // provincesCB
            // 
            this.provincesCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.provincesCB.FormattingEnabled = true;
            this.provincesCB.Location = new System.Drawing.Point(36, 35);
            this.provincesCB.Name = "provincesCB";
            this.provincesCB.Size = new System.Drawing.Size(163, 21);
            this.provincesCB.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Khaki;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.smallestResultLabel);
            this.panel1.Controls.Add(this.smallPopLabel);
            this.panel1.Controls.Add(this.largestResultLabel);
            this.panel1.Controls.Add(this.lgstPopLabel);
            this.panel1.Location = new System.Drawing.Point(112, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(524, 51);
            this.panel1.TabIndex = 5;
            // 
            // smallestResultLabel
            // 
            this.smallestResultLabel.AutoSize = true;
            this.smallestResultLabel.Font = new System.Drawing.Font("Gill Sans MT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smallestResultLabel.Location = new System.Drawing.Point(374, 25);
            this.smallestResultLabel.Name = "smallestResultLabel";
            this.smallestResultLabel.Size = new System.Drawing.Size(50, 18);
            this.smallestResultLabel.TabIndex = 3;
            this.smallestResultLabel.Text = "smallest";
            // 
            // smallPopLabel
            // 
            this.smallPopLabel.AutoSize = true;
            this.smallPopLabel.Font = new System.Drawing.Font("Gill Sans MT", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smallPopLabel.Location = new System.Drawing.Point(326, 5);
            this.smallPopLabel.Name = "smallPopLabel";
            this.smallPopLabel.Size = new System.Drawing.Size(150, 21);
            this.smallPopLabel.TabIndex = 2;
            this.smallPopLabel.Text = "Smallest Population";
            // 
            // largestResultLabel
            // 
            this.largestResultLabel.AutoSize = true;
            this.largestResultLabel.Font = new System.Drawing.Font("Gill Sans MT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.largestResultLabel.Location = new System.Drawing.Point(98, 25);
            this.largestResultLabel.Name = "largestResultLabel";
            this.largestResultLabel.Size = new System.Drawing.Size(43, 18);
            this.largestResultLabel.TabIndex = 1;
            this.largestResultLabel.Text = "largest";
            // 
            // lgstPopLabel
            // 
            this.lgstPopLabel.AutoSize = true;
            this.lgstPopLabel.Font = new System.Drawing.Font("Gill Sans MT", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lgstPopLabel.Location = new System.Drawing.Point(60, 5);
            this.lgstPopLabel.Name = "lgstPopLabel";
            this.lgstPopLabel.Size = new System.Drawing.Size(143, 21);
            this.lgstPopLabel.TabIndex = 0;
            this.lgstPopLabel.Text = "Largest Population";
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.Color.Lavender;
            this.sidePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sidePanel.Controls.Add(this.divider1);
            this.sidePanel.Controls.Add(this.divider2);
            this.sidePanel.Controls.Add(this.xmlImgBox);
            this.sidePanel.Controls.Add(this.jsonImgBox);
            this.sidePanel.Controls.Add(this.csvIconBox);
            this.sidePanel.Location = new System.Drawing.Point(0, 0);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(112, 353);
            this.sidePanel.TabIndex = 3;
            // 
            // divider1
            // 
            this.divider1.BackColor = System.Drawing.Color.Black;
            this.divider1.Location = new System.Drawing.Point(3, 115);
            this.divider1.Name = "divider1";
            this.divider1.Size = new System.Drawing.Size(114, 1);
            this.divider1.TabIndex = 21;
            // 
            // divider2
            // 
            this.divider2.BackColor = System.Drawing.Color.Black;
            this.divider2.Location = new System.Drawing.Point(3, 233);
            this.divider2.Name = "divider2";
            this.divider2.Size = new System.Drawing.Size(114, 1);
            this.divider2.TabIndex = 21;
            // 
            // xmlImgBox
            // 
            this.xmlImgBox.Image = ((System.Drawing.Image)(resources.GetObject("xmlImgBox.Image")));
            this.xmlImgBox.Location = new System.Drawing.Point(0, 115);
            this.xmlImgBox.Name = "xmlImgBox";
            this.xmlImgBox.Padding = new System.Windows.Forms.Padding(10);
            this.xmlImgBox.Size = new System.Drawing.Size(112, 118);
            this.xmlImgBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.xmlImgBox.TabIndex = 4;
            this.xmlImgBox.TabStop = false;
            this.xmlImgBox.Click += new System.EventHandler(this.ParseXmlFile);
            // 
            // jsonImgBox
            // 
            this.jsonImgBox.Image = ((System.Drawing.Image)(resources.GetObject("jsonImgBox.Image")));
            this.jsonImgBox.Location = new System.Drawing.Point(-2, -2);
            this.jsonImgBox.Name = "jsonImgBox";
            this.jsonImgBox.Padding = new System.Windows.Forms.Padding(8);
            this.jsonImgBox.Size = new System.Drawing.Size(112, 117);
            this.jsonImgBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.jsonImgBox.TabIndex = 4;
            this.jsonImgBox.TabStop = false;
            this.jsonImgBox.Click += new System.EventHandler(this.ParseJsonFile);
            // 
            // csvIconBox
            // 
            this.csvIconBox.Image = ((System.Drawing.Image)(resources.GetObject("csvIconBox.Image")));
            this.csvIconBox.Location = new System.Drawing.Point(-2, 233);
            this.csvIconBox.Name = "csvIconBox";
            this.csvIconBox.Padding = new System.Windows.Forms.Padding(10);
            this.csvIconBox.Size = new System.Drawing.Size(112, 118);
            this.csvIconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.csvIconBox.TabIndex = 2;
            this.csvIconBox.TabStop = false;
            this.csvIconBox.Click += new System.EventHandler(this.ParseCsvFile);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.DarkCyan;
            this.tabPage3.Controls.Add(this.s);
            this.tabPage3.Controls.Add(this.showMapCitiesCB);
            this.tabPage3.Controls.Add(this.loadMapBtn);
            this.tabPage3.Controls.Add(this.map);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(516, 276);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Show On Map";
            // 
            // map
            // 
            this.map.Bearing = 0F;
            this.map.CanDragMap = true;
            this.map.EmptyTileColor = System.Drawing.Color.Navy;
            this.map.GrayScaleMode = false;
            this.map.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.map.LevelsKeepInMemory = 5;
            this.map.Location = new System.Drawing.Point(2, 3);
            this.map.MarkersEnabled = true;
            this.map.MaxZoom = 2;
            this.map.MinZoom = 2;
            this.map.MouseWheelZoomEnabled = true;
            this.map.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.map.Name = "map";
            this.map.NegativeMode = false;
            this.map.PolygonsEnabled = true;
            this.map.RetryLoadTile = 0;
            this.map.RoutesEnabled = true;
            this.map.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.map.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.map.ShowTileGridLines = false;
            this.map.Size = new System.Drawing.Size(351, 270);
            this.map.TabIndex = 0;
            this.map.Zoom = 0D;
            // 
            // loadMapBtn
            // 
            this.loadMapBtn.Location = new System.Drawing.Point(375, 94);
            this.loadMapBtn.Name = "loadMapBtn";
            this.loadMapBtn.Size = new System.Drawing.Size(118, 29);
            this.loadMapBtn.TabIndex = 1;
            this.loadMapBtn.Text = "Load Map";
            this.loadMapBtn.UseVisualStyleBackColor = true;
            this.loadMapBtn.Click += new System.EventHandler(this.LoadMap);
            // 
            // showMapCitiesCB
            // 
            this.showMapCitiesCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.showMapCitiesCB.FormattingEnabled = true;
            this.showMapCitiesCB.Location = new System.Drawing.Point(359, 54);
            this.showMapCitiesCB.Name = "showMapCitiesCB";
            this.showMapCitiesCB.Size = new System.Drawing.Size(147, 21);
            this.showMapCitiesCB.TabIndex = 2;
            // 
            // s
            // 
            this.s.AutoSize = true;
            this.s.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.s.Location = new System.Drawing.Point(399, 27);
            this.s.Name = "s";
            this.s.Size = new System.Drawing.Size(75, 18);
            this.s.TabIndex = 3;
            this.s.Text = "Pick a city";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 352);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.mainPanel.ResumeLayout(false);
            this.tabPanel.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.sidePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xmlImgBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jsonImgBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.csvIconBox)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.PictureBox csvIconBox;
        private System.Windows.Forms.PictureBox xmlImgBox;
        private System.Windows.Forms.PictureBox jsonImgBox;
        private System.Windows.Forms.ComboBox citiesComboBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label largestResultLabel;
        private System.Windows.Forms.Label lgstPopLabel;
        private System.Windows.Forms.Label smallestResultLabel;
        private System.Windows.Forms.Label smallPopLabel;
        private System.Windows.Forms.Button getCityInfoBtn;
        private System.Windows.Forms.Label asciiHeaderLabel;
        private System.Windows.Forms.Label idHeaderLabel;
        private System.Windows.Forms.Label nameHeaderLabel;
        private System.Windows.Forms.Label popHeaderLabel;
        private System.Windows.Forms.Label provHeaderLabel;
        private System.Windows.Forms.Label lgnHeaderLabel;
        private System.Windows.Forms.Label latHeaderLabel;
        private System.Windows.Forms.Label lngResultLabel;
        private System.Windows.Forms.Label latResultLabel;
        private System.Windows.Forms.Label provResultLabel;
        private System.Windows.Forms.Label popResultLabel;
        private System.Windows.Forms.Label asciiResultLabel;
        private System.Windows.Forms.Label nameResultLabel;
        private System.Windows.Forms.Label idResultLabel;
        private System.Windows.Forms.Panel divider2;
        private System.Windows.Forms.Panel divider1;
        private System.Windows.Forms.TabControl tabPanel;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox secondCityCB;
        private System.Windows.Forms.ComboBox firstCityCB;
        private System.Windows.Forms.Button compareCitiesBtn;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel divider3;
        private System.Windows.Forms.ComboBox provincesCB;
        private System.Windows.Forms.Button getCitiesBtn;
        private System.Windows.Forms.ListBox resultsListBox;
        private System.Windows.Forms.Button GetPopulationBtn;
        private System.Windows.Forms.RichTextBox popRichTB;
        private System.Windows.Forms.Label totPopLabel;
        private System.Windows.Forms.Label listProvsLabel;
        private System.Windows.Forms.Label pickProvLabel;
        private System.Windows.Forms.Label cityInfoLabel;
        private System.Windows.Forms.Label twoCityLabel;
        private System.Windows.Forms.Button ByCitiesBtn;
        private System.Windows.Forms.Button byPopBtn;
        private System.Windows.Forms.RichTextBox listProvByTB;
        private System.Windows.Forms.Label listByLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button loadMapBtn;
        private GMap.NET.WindowsForms.GMapControl map;
        private System.Windows.Forms.ComboBox showMapCitiesCB;
        private System.Windows.Forms.Label s;
    }
}

