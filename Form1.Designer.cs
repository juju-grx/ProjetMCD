namespace MCD
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bt_Lien = new System.Windows.Forms.Button();
            this.bt_Selection = new System.Windows.Forms.Button();
            this.bt_Association = new System.Windows.Forms.Button();
            this.bt_Entite = new System.Windows.Forms.Button();
            this.bt_ouvrir = new System.Windows.Forms.Button();
            this.bt_enregistrer = new System.Windows.Forms.Button();
            this.dataRecord = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelDonnee = new System.Windows.Forms.Panel();
            this.NameObjet = new System.Windows.Forms.TextBox();
            this.bt_off = new System.Windows.Forms.Button();
            this.TextBoxAttribut = new System.Windows.Forms.RichTextBox();
            this.debug = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelDonnee.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_Lien
            // 
            this.bt_Lien.Location = new System.Drawing.Point(245, 9);
            this.bt_Lien.Name = "bt_Lien";
            this.bt_Lien.Size = new System.Drawing.Size(75, 25);
            this.bt_Lien.TabIndex = 3;
            this.bt_Lien.Text = "Lien";
            this.bt_Lien.UseVisualStyleBackColor = true;
            this.bt_Lien.Click += new System.EventHandler(this.bt_Lien_Click);
            // 
            // bt_Selection
            // 
            this.bt_Selection.AutoSize = true;
            this.bt_Selection.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bt_Selection.Location = new System.Drawing.Point(12, 9);
            this.bt_Selection.Name = "bt_Selection";
            this.bt_Selection.Size = new System.Drawing.Size(65, 25);
            this.bt_Selection.TabIndex = 0;
            this.bt_Selection.Text = "Selection";
            this.bt_Selection.UseVisualStyleBackColor = true;
            this.bt_Selection.Click += new System.EventHandler(this.bt_Selection_Click);
            // 
            // bt_Association
            // 
            this.bt_Association.Location = new System.Drawing.Point(164, 9);
            this.bt_Association.Name = "bt_Association";
            this.bt_Association.Size = new System.Drawing.Size(75, 25);
            this.bt_Association.TabIndex = 3;
            this.bt_Association.Text = "Association";
            this.bt_Association.UseVisualStyleBackColor = true;
            this.bt_Association.Click += new System.EventHandler(this.bt_Association_Click);
            // 
            // bt_Entite
            // 
            this.bt_Entite.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bt_Entite.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bt_Entite.Location = new System.Drawing.Point(83, 9);
            this.bt_Entite.Name = "bt_Entite";
            this.bt_Entite.Size = new System.Drawing.Size(75, 25);
            this.bt_Entite.TabIndex = 1;
            this.bt_Entite.Text = "Entite";
            this.bt_Entite.UseVisualStyleBackColor = false;
            this.bt_Entite.Click += new System.EventHandler(this.bt_Entite_Click);
            // 
            // bt_ouvrir
            // 
            this.bt_ouvrir.Location = new System.Drawing.Point(722, 6);
            this.bt_ouvrir.Name = "bt_ouvrir";
            this.bt_ouvrir.Size = new System.Drawing.Size(75, 30);
            this.bt_ouvrir.TabIndex = 4;
            this.bt_ouvrir.Text = "Ouvrir";
            this.bt_ouvrir.UseVisualStyleBackColor = true;
            this.bt_ouvrir.Click += new System.EventHandler(this.bt_ouvrir_Click);
            // 
            // bt_enregistrer
            // 
            this.bt_enregistrer.Location = new System.Drawing.Point(641, 6);
            this.bt_enregistrer.Name = "bt_enregistrer";
            this.bt_enregistrer.Size = new System.Drawing.Size(75, 30);
            this.bt_enregistrer.TabIndex = 5;
            this.bt_enregistrer.Text = "Enregistrer";
            this.bt_enregistrer.UseVisualStyleBackColor = true;
            this.bt_enregistrer.Click += new System.EventHandler(this.bt_enregistrer_Click);
            // 
            // dataRecord
            // 
            this.dataRecord.FileName = "dataRecord";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox1.Location = new System.Drawing.Point(0, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(809, 422);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bt_enregistrer);
            this.panel1.Controls.Add(this.bt_ouvrir);
            this.panel1.Controls.Add(this.bt_Selection);
            this.panel1.Controls.Add(this.bt_Association);
            this.panel1.Controls.Add(this.bt_Entite);
            this.panel1.Controls.Add(this.bt_Lien);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(809, 45);
            this.panel1.TabIndex = 9;
            // 
            // panelDonnee
            // 
            this.panelDonnee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelDonnee.Controls.Add(this.NameObjet);
            this.panelDonnee.Controls.Add(this.bt_off);
            this.panelDonnee.Controls.Add(this.TextBoxAttribut);
            this.panelDonnee.Location = new System.Drawing.Point(282, 96);
            this.panelDonnee.Name = "panelDonnee";
            this.panelDonnee.Size = new System.Drawing.Size(250, 300);
            this.panelDonnee.TabIndex = 7;
            this.panelDonnee.Visible = false;
            // 
            // NameObjet
            // 
            this.NameObjet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.NameObjet.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NameObjet.Location = new System.Drawing.Point(0, 0);
            this.NameObjet.Name = "NameObjet";
            this.NameObjet.Size = new System.Drawing.Size(225, 23);
            this.NameObjet.TabIndex = 9;
            // 
            // bt_off
            // 
            this.bt_off.Location = new System.Drawing.Point(228, 1);
            this.bt_off.Margin = new System.Windows.Forms.Padding(0);
            this.bt_off.Name = "bt_off";
            this.bt_off.Size = new System.Drawing.Size(22, 22);
            this.bt_off.TabIndex = 8;
            this.bt_off.Text = "X";
            this.bt_off.UseVisualStyleBackColor = true;
            this.bt_off.Click += new System.EventHandler(this.bt_off_Click);
            // 
            // TextBoxAttribut
            // 
            this.TextBoxAttribut.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TextBoxAttribut.Enabled = false;
            this.TextBoxAttribut.Location = new System.Drawing.Point(0, 22);
            this.TextBoxAttribut.Name = "TextBoxAttribut";
            this.TextBoxAttribut.Size = new System.Drawing.Size(250, 278);
            this.TextBoxAttribut.TabIndex = 7;
            this.TextBoxAttribut.Text = "";
            // 
            // debug
            // 
            this.debug.BackColor = System.Drawing.Color.White;
            this.debug.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.debug.Enabled = false;
            this.debug.Location = new System.Drawing.Point(12, 51);
            this.debug.Name = "debug";
            this.debug.ReadOnly = true;
            this.debug.Size = new System.Drawing.Size(98, 93);
            this.debug.TabIndex = 6;
            this.debug.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(809, 467);
            this.Controls.Add(this.debug);
            this.Controls.Add(this.panelDonnee);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Projet MCD";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelDonnee.ResumeLayout(false);
            this.panelDonnee.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button bt_Entite;
        private System.Windows.Forms.Button bt_Selection;
        private System.Windows.Forms.Button bt_Lien;
        private System.Windows.Forms.Button bt_Association;
        private System.Windows.Forms.Button bt_ouvrir;
        private System.Windows.Forms.Button bt_enregistrer;
        private System.Windows.Forms.OpenFileDialog dataRecord;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox TextBoxAttribut;
        private System.Windows.Forms.Panel panelDonnee;
        private System.Windows.Forms.Button bt_off;
        private System.Windows.Forms.TextBox NameObjet;
        private System.Windows.Forms.RichTextBox debug;
    }
}