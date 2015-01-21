namespace sudokuGUI
{
    /// <summary>
    /// In diesem class sind alle die Parameter für das GUI
    /// </summary>
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.sudtxt = new System.Windows.Forms.TextBox();
            this.startBtn = new System.Windows.Forms.Button();
            this.resultTxt = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.crroChanTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.mutChanTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.maxPopTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.maxGenTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.eliteTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.popSizTxt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.mutMethodCB = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.mutRadTxt = new System.Windows.Forms.TextBox();
            this.Radius = new System.Windows.Forms.Label();
            this.Methode = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.crossMetCB = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.turnIndTxt = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.selMethoCB = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.weiterSchrittBtn = new System.Windows.Forms.Button();
            this.weiterGehenTxt = new System.Windows.Forms.Button();
            this.shritteTxt = new System.Windows.Forms.TextBox();
            this.popFitTxt = new System.Windows.Forms.TextBox();
            this.genFitTxt = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.methodeRestCB = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.restartGeneTxt = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // sudtxt
            // 
            this.sudtxt.Font = new System.Drawing.Font("Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.sudtxt.Location = new System.Drawing.Point(306, 114);
            this.sudtxt.Multiline = true;
            this.sudtxt.Name = "sudtxt";
            this.sudtxt.Size = new System.Drawing.Size(136, 208);
            this.sudtxt.TabIndex = 0;
            this.sudtxt.Text = "080301004\r\n530674800\r\n006080700\r\n190832400\r\n003067095\r\n067000300\r\n008013040\r\n3005" +
    "06900\r\n674098031";
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(521, 28);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(73, 22);
            this.startBtn.TabIndex = 1;
            this.startBtn.Text = "Beginnen";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // resultTxt
            // 
            this.resultTxt.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultTxt.Location = new System.Drawing.Point(528, 80);
            this.resultTxt.Multiline = true;
            this.resultTxt.Name = "resultTxt";
            this.resultTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resultTxt.Size = new System.Drawing.Size(238, 290);
            this.resultTxt.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.crroChanTxt);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.mutChanTxt);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.maxPopTxt);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.maxGenTxt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.eliteTxt);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.popSizTxt);
            this.groupBox1.Location = new System.Drawing.Point(35, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(207, 229);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Allgemeine Parameters";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(186, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "%";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(186, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "%";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Crossover Chance";
            // 
            // crroChanTxt
            // 
            this.crroChanTxt.Location = new System.Drawing.Point(132, 162);
            this.crroChanTxt.Name = "crroChanTxt";
            this.crroChanTxt.Size = new System.Drawing.Size(31, 20);
            this.crroChanTxt.TabIndex = 10;
            this.crroChanTxt.Text = "50";
            this.crroChanTxt.TextChanged += new System.EventHandler(this.popSizTxt_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Mutation Chance";
            // 
            // mutChanTxt
            // 
            this.mutChanTxt.Location = new System.Drawing.Point(132, 136);
            this.mutChanTxt.Name = "mutChanTxt";
            this.mutChanTxt.Size = new System.Drawing.Size(31, 20);
            this.mutChanTxt.TabIndex = 8;
            this.mutChanTxt.Text = "5";
            this.mutChanTxt.TextChanged += new System.EventHandler(this.popSizTxt_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Max Population";
            // 
            // maxPopTxt
            // 
            this.maxPopTxt.Location = new System.Drawing.Point(132, 110);
            this.maxPopTxt.Name = "maxPopTxt";
            this.maxPopTxt.Size = new System.Drawing.Size(69, 20);
            this.maxPopTxt.TabIndex = 6;
            this.maxPopTxt.Text = "1500";
            this.maxPopTxt.TextChanged += new System.EventHandler(this.popSizTxt_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Max Generationen";
            // 
            // maxGenTxt
            // 
            this.maxGenTxt.Location = new System.Drawing.Point(132, 84);
            this.maxGenTxt.Name = "maxGenTxt";
            this.maxGenTxt.Size = new System.Drawing.Size(69, 20);
            this.maxGenTxt.TabIndex = 4;
            this.maxGenTxt.Text = "500";
            this.maxGenTxt.TextChanged += new System.EventHandler(this.popSizTxt_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Elites Restart";
            // 
            // eliteTxt
            // 
            this.eliteTxt.Location = new System.Drawing.Point(132, 58);
            this.eliteTxt.Name = "eliteTxt";
            this.eliteTxt.Size = new System.Drawing.Size(69, 20);
            this.eliteTxt.TabIndex = 2;
            this.eliteTxt.Text = "150";
            this.eliteTxt.TextChanged += new System.EventHandler(this.popSizTxt_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Erste Population Grösse";
            // 
            // popSizTxt
            // 
            this.popSizTxt.Location = new System.Drawing.Point(132, 32);
            this.popSizTxt.Name = "popSizTxt";
            this.popSizTxt.Size = new System.Drawing.Size(69, 20);
            this.popSizTxt.TabIndex = 0;
            this.popSizTxt.Text = "1500";
            this.popSizTxt.TextChanged += new System.EventHandler(this.popSizTxt_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(303, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Eingabe";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(534, 57);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Ergebniss";
            // 
            // mutMethodCB
            // 
            this.mutMethodCB.FormattingEnabled = true;
            this.mutMethodCB.Items.AddRange(new object[] {
            "Random Swap",
            "Mit Einschrankung",
            "Ohne 9 Fitness"});
            this.mutMethodCB.Location = new System.Drawing.Point(67, 22);
            this.mutMethodCB.Name = "mutMethodCB";
            this.mutMethodCB.Size = new System.Drawing.Size(143, 21);
            this.mutMethodCB.TabIndex = 14;
            this.mutMethodCB.TextChanged += new System.EventHandler(this.popSizTxt_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.mutRadTxt);
            this.groupBox2.Controls.Add(this.Radius);
            this.groupBox2.Controls.Add(this.Methode);
            this.groupBox2.Controls.Add(this.mutMethodCB);
            this.groupBox2.Location = new System.Drawing.Point(26, 358);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(216, 82);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mutation";
            // 
            // mutRadTxt
            // 
            this.mutRadTxt.Location = new System.Drawing.Point(110, 49);
            this.mutRadTxt.Name = "mutRadTxt";
            this.mutRadTxt.Size = new System.Drawing.Size(23, 20);
            this.mutRadTxt.TabIndex = 18;
            this.mutRadTxt.Text = "1";
            this.mutRadTxt.TextChanged += new System.EventHandler(this.popSizTxt_TextChanged);
            // 
            // Radius
            // 
            this.Radius.AutoSize = true;
            this.Radius.Location = new System.Drawing.Point(6, 50);
            this.Radius.Name = "Radius";
            this.Radius.Size = new System.Drawing.Size(40, 13);
            this.Radius.TabIndex = 17;
            this.Radius.Text = "Radius";
            // 
            // Methode
            // 
            this.Methode.AutoSize = true;
            this.Methode.Location = new System.Drawing.Point(6, 25);
            this.Methode.Name = "Methode";
            this.Methode.Size = new System.Drawing.Size(49, 13);
            this.Methode.TabIndex = 15;
            this.Methode.Text = "Methode";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.crossMetCB);
            this.groupBox3.Location = new System.Drawing.Point(26, 474);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(216, 82);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Crossover";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Methode";
            // 
            // crossMetCB
            // 
            this.crossMetCB.FormattingEnabled = true;
            this.crossMetCB.Items.AddRange(new object[] {
            "1-Punkt",
            "Uniform"});
            this.crossMetCB.Location = new System.Drawing.Point(67, 29);
            this.crossMetCB.Name = "crossMetCB";
            this.crossMetCB.Size = new System.Drawing.Size(143, 21);
            this.crossMetCB.TabIndex = 16;
            this.crossMetCB.TextChanged += new System.EventHandler(this.popSizTxt_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.turnIndTxt);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.selMethoCB);
            this.groupBox4.Location = new System.Drawing.Point(274, 358);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(229, 82);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Selektion";
            // 
            // turnIndTxt
            // 
            this.turnIndTxt.Location = new System.Drawing.Point(132, 52);
            this.turnIndTxt.Name = "turnIndTxt";
            this.turnIndTxt.Size = new System.Drawing.Size(31, 20);
            this.turnIndTxt.TabIndex = 20;
            this.turnIndTxt.Text = "15";
            this.turnIndTxt.TextChanged += new System.EventHandler(this.selMethoCB_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 13);
            this.label13.TabIndex = 15;
            this.label13.Text = "Eltern 1";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 55);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "Turnier Individuen";
            // 
            // selMethoCB
            // 
            this.selMethoCB.FormattingEnabled = true;
            this.selMethoCB.Items.AddRange(new object[] {
            "Turnierauswahl",
            "Glücksradauswahl"});
            this.selMethoCB.Location = new System.Drawing.Point(67, 22);
            this.selMethoCB.Name = "selMethoCB";
            this.selMethoCB.Size = new System.Drawing.Size(143, 21);
            this.selMethoCB.TabIndex = 14;
            this.selMethoCB.TextChanged += new System.EventHandler(this.selMethoCB_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(6, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(225, 198);
            this.textBox1.TabIndex = 21;
            // 
            // weiterSchrittBtn
            // 
            this.weiterSchrittBtn.Location = new System.Drawing.Point(600, 28);
            this.weiterSchrittBtn.Name = "weiterSchrittBtn";
            this.weiterSchrittBtn.Size = new System.Drawing.Size(75, 23);
            this.weiterSchrittBtn.TabIndex = 22;
            this.weiterSchrittBtn.Text = "->";
            this.weiterSchrittBtn.UseVisualStyleBackColor = true;
            this.weiterSchrittBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // weiterGehenTxt
            // 
            this.weiterGehenTxt.Location = new System.Drawing.Point(681, 28);
            this.weiterGehenTxt.Name = "weiterGehenTxt";
            this.weiterGehenTxt.Size = new System.Drawing.Size(75, 23);
            this.weiterGehenTxt.TabIndex = 23;
            this.weiterGehenTxt.Text = ">>>";
            this.weiterGehenTxt.UseVisualStyleBackColor = true;
            this.weiterGehenTxt.Click += new System.EventHandler(this.weiterGehenTxt_Click);
            // 
            // shritteTxt
            // 
            this.shritteTxt.Location = new System.Drawing.Point(651, 2);
            this.shritteTxt.Name = "shritteTxt";
            this.shritteTxt.Size = new System.Drawing.Size(45, 20);
            this.shritteTxt.TabIndex = 24;
            this.shritteTxt.Text = "1";
            // 
            // popFitTxt
            // 
            this.popFitTxt.Location = new System.Drawing.Point(3, 6);
            this.popFitTxt.Multiline = true;
            this.popFitTxt.Name = "popFitTxt";
            this.popFitTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.popFitTxt.Size = new System.Drawing.Size(107, 195);
            this.popFitTxt.TabIndex = 25;
            // 
            // genFitTxt
            // 
            this.genFitTxt.Location = new System.Drawing.Point(119, 6);
            this.genFitTxt.Multiline = true;
            this.genFitTxt.Name = "genFitTxt";
            this.genFitTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.genFitTxt.Size = new System.Drawing.Size(109, 194);
            this.genFitTxt.TabIndex = 26;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(528, 376);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(242, 233);
            this.tabControl1.TabIndex = 27;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.genFitTxt);
            this.tabPage1.Controls.Add(this.popFitTxt);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(234, 207);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Fitness";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(234, 207);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Beste jedes Versuchs";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.methodeRestCB);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.restartGeneTxt);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Location = new System.Drawing.Point(274, 474);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(229, 82);
            this.groupBox5.TabIndex = 21;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Lakales Maximum";
            // 
            // methodeRestCB
            // 
            this.methodeRestCB.FormattingEnabled = true;
            this.methodeRestCB.Items.AddRange(new object[] {
            "Restart",
            "Nichts machen",
            "Mutation machen"});
            this.methodeRestCB.Location = new System.Drawing.Point(56, 55);
            this.methodeRestCB.Name = "methodeRestCB";
            this.methodeRestCB.Size = new System.Drawing.Size(143, 21);
            this.methodeRestCB.TabIndex = 23;
            this.methodeRestCB.TextChanged += new System.EventHandler(this.methodeRestCB_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(129, 29);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(71, 13);
            this.label16.TabIndex = 22;
            this.label16.Text = "Generationen";
            // 
            // restartGeneTxt
            // 
            this.restartGeneTxt.Location = new System.Drawing.Point(92, 29);
            this.restartGeneTxt.Name = "restartGeneTxt";
            this.restartGeneTxt.Size = new System.Drawing.Size(31, 20);
            this.restartGeneTxt.TabIndex = 21;
            this.restartGeneTxt.Text = "15";
            this.restartGeneTxt.TextChanged += new System.EventHandler(this.methodeRestCB_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(53, 29);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(33, 13);
            this.label14.TabIndex = 15;
            this.label14.Text = "Nach";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(597, 5);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 13);
            this.label15.TabIndex = 28;
            this.label15.Text = "Schritte";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 621);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.shritteTxt);
            this.Controls.Add(this.weiterGehenTxt);
            this.Controls.Add(this.weiterSchrittBtn);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.resultTxt);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.sudtxt);
            this.Name = "Form1";
            this.Text = "Sudoku, eine Evolutionäre Lösung";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox sudtxt;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.TextBox resultTxt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox mutChanTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox maxPopTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox maxGenTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox eliteTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox popSizTxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox crroChanTxt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox mutMethodCB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label Radius;
        private System.Windows.Forms.Label Methode;
        private System.Windows.Forms.TextBox mutRadTxt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox crossMetCB;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox selMethoCB;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button weiterSchrittBtn;
        private System.Windows.Forms.Button weiterGehenTxt;
        private System.Windows.Forms.TextBox shritteTxt;
        private System.Windows.Forms.TextBox popFitTxt;
        private System.Windows.Forms.TextBox genFitTxt;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox turnIndTxt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox methodeRestCB;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox restartGeneTxt;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
    }
}

