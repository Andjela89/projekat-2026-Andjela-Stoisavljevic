namespace projekat_2026_Andjela_Stoisavljevic
{
    partial class NoviTermin
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
            this.dtpDatum = new System.Windows.Forms.DateTimePicker();
            this.numTrajanje = new System.Windows.Forms.NumericUpDown();
            this.cmbTrener = new System.Windows.Forms.ComboBox();
            this.cmbTeren = new System.Windows.Forms.ComboBox();
            this.btnZakazi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbTipTermina = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpPocetak = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.numTrajanje)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpDatum
            // 
            this.dtpDatum.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDatum.Location = new System.Drawing.Point(225, 68);
            this.dtpDatum.Name = "dtpDatum";
            this.dtpDatum.Size = new System.Drawing.Size(200, 27);
            this.dtpDatum.TabIndex = 2;
            // 
            // numTrajanje
            // 
            this.numTrajanje.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTrajanje.Location = new System.Drawing.Point(225, 163);
            this.numTrajanje.Name = "numTrajanje";
            this.numTrajanje.Size = new System.Drawing.Size(200, 27);
            this.numTrajanje.TabIndex = 4;
            // 
            // cmbTrener
            // 
            this.cmbTrener.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTrener.FormattingEnabled = true;
            this.cmbTrener.Location = new System.Drawing.Point(225, 209);
            this.cmbTrener.Name = "cmbTrener";
            this.cmbTrener.Size = new System.Drawing.Size(200, 26);
            this.cmbTrener.TabIndex = 5;
            // 
            // cmbTeren
            // 
            this.cmbTeren.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTeren.FormattingEnabled = true;
            this.cmbTeren.Location = new System.Drawing.Point(225, 258);
            this.cmbTeren.Name = "cmbTeren";
            this.cmbTeren.Size = new System.Drawing.Size(200, 26);
            this.cmbTeren.TabIndex = 6;
            // 
            // btnZakazi
            // 
            this.btnZakazi.BackColor = System.Drawing.Color.Gold;
            this.btnZakazi.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZakazi.ForeColor = System.Drawing.Color.DarkRed;
            this.btnZakazi.Location = new System.Drawing.Point(225, 321);
            this.btnZakazi.Name = "btnZakazi";
            this.btnZakazi.Size = new System.Drawing.Size(200, 62);
            this.btnZakazi.TabIndex = 8;
            this.btnZakazi.Text = "Zakaži";
            this.btnZakazi.UseVisualStyleBackColor = false;
            this.btnZakazi.Click += new System.EventHandler(this.btnZakazi_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "Tip termina";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 18);
            this.label3.TabIndex = 11;
            this.label3.Text = "Datum ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 18);
            this.label5.TabIndex = 13;
            this.label5.Text = "Trajanje(min)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(26, 217);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 18);
            this.label6.TabIndex = 14;
            this.label6.Text = "Trener";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(26, 266);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 18);
            this.label7.TabIndex = 15;
            this.label7.Text = "Teren";
            // 
            // cmbTipTermina
            // 
            this.cmbTipTermina.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipTermina.FormattingEnabled = true;
            this.cmbTipTermina.Location = new System.Drawing.Point(225, 17);
            this.cmbTipTermina.Name = "cmbTipTermina";
            this.cmbTipTermina.Size = new System.Drawing.Size(200, 26);
            this.cmbTipTermina.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 18);
            this.label2.TabIndex = 18;
            this.label2.Text = "Vreme početka";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dtpPocetak
            // 
            this.dtpPocetak.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPocetak.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpPocetak.Location = new System.Drawing.Point(225, 119);
            this.dtpPocetak.Name = "dtpPocetak";
            this.dtpPocetak.ShowUpDown = true;
            this.dtpPocetak.Size = new System.Drawing.Size(200, 27);
            this.dtpPocetak.TabIndex = 17;
            // 
            // NoviTermin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpPocetak);
            this.Controls.Add(this.cmbTipTermina);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnZakazi);
            this.Controls.Add(this.cmbTeren);
            this.Controls.Add(this.cmbTrener);
            this.Controls.Add(this.numTrajanje);
            this.Controls.Add(this.dtpDatum);
            this.Name = "NoviTermin";
            this.Text = "NoviTermin";
            this.Load += new System.EventHandler(this.NoviTermin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numTrajanje)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtpDatum;
        private System.Windows.Forms.NumericUpDown numTrajanje;
        private System.Windows.Forms.ComboBox cmbTrener;
        private System.Windows.Forms.ComboBox cmbTeren;
        private System.Windows.Forms.Button btnZakazi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbTipTermina;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpPocetak;
    }
}