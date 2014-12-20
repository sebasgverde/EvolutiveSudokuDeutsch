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
            this.SuspendLayout();
            // 
            // sudtxt
            // 
            this.sudtxt.Font = new System.Drawing.Font("Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.sudtxt.Location = new System.Drawing.Point(59, 12);
            this.sudtxt.Multiline = true;
            this.sudtxt.Name = "sudtxt";
            this.sudtxt.Size = new System.Drawing.Size(275, 181);
            this.sudtxt.TabIndex = 0;
            this.sudtxt.Text = "200406500\r\n003108700\r\n600009438\r\n500040300\r\n000371000\r\n008090004\r\n931200007\r\n0043" +
    "07200\r\n002905003";
            // 
            // RechnenBtn
            // 
            this.RechnenBtn.Location = new System.Drawing.Point(150, 218);
            this.RechnenBtn.Name = "RechnenBtn";
            this.RechnenBtn.Size = new System.Drawing.Size(90, 22);
            this.RechnenBtn.TabIndex = 1;
            this.RechnenBtn.Text = "Rechnen";
            this.RechnenBtn.UseVisualStyleBackColor = true;
            this.RechnenBtn.Click += new System.EventHandler(this.RechnenBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 268);
            this.Controls.Add(this.RechnenBtn);
            this.Controls.Add(this.sudtxt);
            this.Name = "Form1";
            this.Text = "Sudoku, eine Evolutionäre Lösung";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox sudtxt;
        private System.Windows.Forms.Button RechnenBtn;
    }
}

