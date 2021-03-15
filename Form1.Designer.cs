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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.debug2 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelDonnee.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_Lien
            // 
            resources.ApplyResources(this.bt_Lien, "bt_Lien");
            this.bt_Lien.Name = "bt_Lien";
            this.bt_Lien.UseVisualStyleBackColor = true;
            this.bt_Lien.Click += new System.EventHandler(this.bt_Lien_Click);
            // 
            // bt_Selection
            // 
            resources.ApplyResources(this.bt_Selection, "bt_Selection");
            this.bt_Selection.Name = "bt_Selection";
            this.bt_Selection.UseVisualStyleBackColor = true;
            this.bt_Selection.Click += new System.EventHandler(this.bt_Selection_Click);
            // 
            // bt_Association
            // 
            resources.ApplyResources(this.bt_Association, "bt_Association");
            this.bt_Association.Name = "bt_Association";
            this.bt_Association.UseVisualStyleBackColor = true;
            this.bt_Association.Click += new System.EventHandler(this.bt_Association_Click);
            // 
            // bt_Entite
            // 
            resources.ApplyResources(this.bt_Entite, "bt_Entite");
            this.bt_Entite.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bt_Entite.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bt_Entite.Name = "bt_Entite";
            this.bt_Entite.UseVisualStyleBackColor = false;
            this.bt_Entite.Click += new System.EventHandler(this.bt_Entite_Click);
            // 
            // bt_ouvrir
            // 
            resources.ApplyResources(this.bt_ouvrir, "bt_ouvrir");
            this.bt_ouvrir.Name = "bt_ouvrir";
            this.bt_ouvrir.UseVisualStyleBackColor = true;
            this.bt_ouvrir.Click += new System.EventHandler(this.bt_ouvrir_Click);
            // 
            // bt_enregistrer
            // 
            resources.ApplyResources(this.bt_enregistrer, "bt_enregistrer");
            this.bt_enregistrer.Name = "bt_enregistrer";
            this.bt_enregistrer.UseVisualStyleBackColor = true;
            this.bt_enregistrer.Click += new System.EventHandler(this.bt_enregistrer_Click);
            // 
            // dataRecord
            // 
            this.dataRecord.FileName = "dataRecord";
            resources.ApplyResources(this.dataRecord, "dataRecord");
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.debug2);
            this.panel1.Controls.Add(this.bt_enregistrer);
            this.panel1.Controls.Add(this.bt_ouvrir);
            this.panel1.Controls.Add(this.bt_Selection);
            this.panel1.Controls.Add(this.bt_Association);
            this.panel1.Controls.Add(this.bt_Entite);
            this.panel1.Controls.Add(this.bt_Lien);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Name = "panel1";
            // 
            // panelDonnee
            // 
            resources.ApplyResources(this.panelDonnee, "panelDonnee");
            this.panelDonnee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelDonnee.Controls.Add(this.NameObjet);
            this.panelDonnee.Controls.Add(this.bt_off);
            this.panelDonnee.Controls.Add(this.TextBoxAttribut);
            this.panelDonnee.Name = "panelDonnee";
            // 
            // NameObjet
            // 
            resources.ApplyResources(this.NameObjet, "NameObjet");
            this.NameObjet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.NameObjet.Name = "NameObjet";
            // 
            // bt_off
            // 
            resources.ApplyResources(this.bt_off, "bt_off");
            this.bt_off.Name = "bt_off";
            this.bt_off.UseVisualStyleBackColor = true;
            this.bt_off.Click += new System.EventHandler(this.bt_off_Click);
            // 
            // TextBoxAttribut
            // 
            resources.ApplyResources(this.TextBoxAttribut, "TextBoxAttribut");
            this.TextBoxAttribut.Name = "TextBoxAttribut";
            // 
            // debug
            // 
            resources.ApplyResources(this.debug, "debug");
            this.debug.BackColor = System.Drawing.Color.White;
            this.debug.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.debug.Name = "debug";
            this.debug.ReadOnly = true;
            // 
            // debug2
            // 
            resources.ApplyResources(this.debug2, "debug2");
            this.debug2.BackColor = System.Drawing.Color.LightGray;
            this.debug2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.debug2.Name = "debug2";
            this.debug2.ReadOnly = true;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.debug);
            this.Controls.Add(this.panelDonnee);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
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
        private System.Windows.Forms.RichTextBox debug2;
    }
}