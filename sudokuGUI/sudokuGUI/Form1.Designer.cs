namespace sudokuGUI
{
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
            this.RechnenBtn = new System.Windows.Forms.Button();
            this.resultTxt = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sudtxt
            // 
            this.sudtxt.Font = new System.Drawing.Font("Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.sudtxt.Location = new System.Drawing.Point(297, 61);
            this.sudtxt.Multiline = true;
            this.sudtxt.Name = "sudtxt";
            this.sudtxt.Size = new System.Drawing.Size(136, 208);
            this.sudtxt.TabIndex = 0;
            this.sudtxt.Text = "080301004\r\n530674800\r\n006080700\r\n190832400\r\n003067095\r\n067000300\r\n008013040\r\n3005" +
    "06900\r\n674098031";
            // 
            // RechnenBtn
            // 
            this.RechnenBtn.Location = new System.Drawing.Point(177, 303);
            this.RechnenBtn.Name = "RechnenBtn";
            this.RechnenBtn.Size = new System.Drawing.Size(90, 22);
            this.RechnenBtn.TabIndex = 1;
            this.RechnenBtn.Text = "Rechnen";
            this.RechnenBtn.UseVisualStyleBackColor = true;
            this.RechnenBtn.Click += new System.EventHandler(this.RechnenBtn_Click);
            // 
            // resultTxt
            // 
            this.resultTxt.Location = new System.Drawing.Point(474, 61);
            this.resultTxt.Multiline = true;
            this.resultTxt.Name = "resultTxt";
            this.resultTxt.Size = new System.Drawing.Size(202, 290);
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
            this.groupBox1.Location = new System.Drawing.Point(26, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 229);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parameters";
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
            this.maxPopTxt.Location = new System.Drawing.Point(110, 110);
            this.maxPopTxt.Name = "maxPopTxt";
            this.maxPopTxt.Size = new System.Drawing.Size(100, 20);
            this.maxPopTxt.TabIndex = 6;
            this.maxPopTxt.Text = "3000";
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
            this.maxGenTxt.Location = new System.Drawing.Point(110, 84);
            this.maxGenTxt.Name = "maxGenTxt";
            this.maxGenTxt.Size = new System.Drawing.Size(100, 20);
            this.maxGenTxt.TabIndex = 4;
            this.maxGenTxt.Text = "500";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Elites";
            // 
            // eliteTxt
            // 
            this.eliteTxt.Location = new System.Drawing.Point(110, 58);
            this.eliteTxt.Name = "eliteTxt";
            this.eliteTxt.Size = new System.Drawing.Size(100, 20);
            this.eliteTxt.TabIndex = 2;
            this.eliteTxt.Text = "150";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Population Grösse";
            // 
            // popSizTxt
            // 
            this.popSizTxt.Location = new System.Drawing.Point(110, 32);
            this.popSizTxt.Name = "popSizTxt";
            this.popSizTxt.Size = new System.Drawing.Size(100, 20);
            this.popSizTxt.TabIndex = 0;
            this.popSizTxt.Text = "3000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(170, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "%";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(170, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "%";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(294, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Eingabe";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(471, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Ergebniss";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 381);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.resultTxt);
            this.Controls.Add(this.RechnenBtn);
            this.Controls.Add(this.sudtxt);
            this.Name = "Form1";
            this.Text = "Sudoku, eine Evolutionäre Lösung";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox sudtxt;
        private System.Windows.Forms.Button RechnenBtn;
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
    }
}

