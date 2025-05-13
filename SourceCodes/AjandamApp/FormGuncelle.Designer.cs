namespace AjandamApp
{
    partial class FormGuncelle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGuncelle));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_Exit1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker_SecilenTarih = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox_Mesaj = new System.Windows.Forms.RichTextBox();
            this.button_Guncelle = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.button_Exit1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_Exit1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(510, 51);
            this.panel1.TabIndex = 5;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown_1);
            // 
            // button_Exit1
            // 
            this.button_Exit1.Image = ((System.Drawing.Image)(resources.GetObject("button_Exit1.Image")));
            this.button_Exit1.Location = new System.Drawing.Point(459, 3);
            this.button_Exit1.Name = "button_Exit1";
            this.button_Exit1.Size = new System.Drawing.Size(42, 43);
            this.button_Exit1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.button_Exit1.TabIndex = 3;
            this.button_Exit1.TabStop = false;
            this.button_Exit1.Click += new System.EventHandler(this.button_Exit1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Bitiş Tarihi:";
            // 
            // dateTimePicker_SecilenTarih
            // 
            this.dateTimePicker_SecilenTarih.CustomFormat = "dd/MM/yyyy   HH:mm";
            this.dateTimePicker_SecilenTarih.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_SecilenTarih.Location = new System.Drawing.Point(131, 73);
            this.dateTimePicker_SecilenTarih.Name = "dateTimePicker_SecilenTarih";
            this.dateTimePicker_SecilenTarih.Size = new System.Drawing.Size(218, 20);
            this.dateTimePicker_SecilenTarih.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Mesaj:";
            // 
            // richTextBox_Mesaj
            // 
            this.richTextBox_Mesaj.Location = new System.Drawing.Point(35, 136);
            this.richTextBox_Mesaj.Name = "richTextBox_Mesaj";
            this.richTextBox_Mesaj.Size = new System.Drawing.Size(434, 188);
            this.richTextBox_Mesaj.TabIndex = 0;
            this.richTextBox_Mesaj.Text = "";
            // 
            // button_Guncelle
            // 
            this.button_Guncelle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(59)))), ((int)(((byte)(78)))));
            this.button_Guncelle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(168)))), ((int)(((byte)(83)))));
            this.button_Guncelle.FlatAppearance.BorderSize = 2;
            this.button_Guncelle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(84)))), ((int)(((byte)(138)))));
            this.button_Guncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Guncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_Guncelle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button_Guncelle.Location = new System.Drawing.Point(189, 341);
            this.button_Guncelle.Name = "button_Guncelle";
            this.button_Guncelle.Size = new System.Drawing.Size(140, 55);
            this.button_Guncelle.TabIndex = 2;
            this.button_Guncelle.Text = "Güncelle";
            this.button_Guncelle.UseVisualStyleBackColor = false;
            this.button_Guncelle.Click += new System.EventHandler(this.button_Guncelle_Click);
            // 
            // FormGuncelle
            // 
            this.AcceptButton = this.button_Guncelle;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(510, 410);
            this.Controls.Add(this.button_Guncelle);
            this.Controls.Add(this.richTextBox_Mesaj);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker_SecilenTarih);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormGuncelle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormGuncelle";
            this.Load += new System.EventHandler(this.FormGuncelle_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.button_Exit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox button_Exit1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_SecilenTarih;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox_Mesaj;
        private System.Windows.Forms.Button button_Guncelle;
    }
}