using System;
using System.Drawing;
using System.Windows.Forms;


namespace MCD
{
    public partial class Form1 : Form
    {
        Graphics g;

        public static PictureBox pictureBox = null;
        public static RichTextBox richTextBox = null;

        int x;
        int y;
        int dX;
        int dY;

        MCD mcd;

        Objet objetCurrent;

        string mode = "Selection";
        string PhaseCourante = "null";
        string mouse = "null";
        bool Delete = false;

        public Form1()
        {
            InitializeComponent();
            //panelDonnee.Location = new Point(Size.Width / 2 - panelDonnee.Width/2, Size.Height / 2 - panelDonnee.Height / 2); 
            pictureBox = pictureBox1;
            richTextBox = TextBoxAttribut;
            g = pictureBox.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            mcd = new MCD(g);
        }
        //Bouton ---------------------------------------------------------------

        private void bt_Selection_Click(object sender, EventArgs e)
        {
            mode = "Selection";
            PasserEnPhase_Selection_Attente();
        }

        private void bt_Entite_Click(object sender, EventArgs e)
        {
            mode = "Entite";
            PasserEnPhase_Entite_Attente();
        }

        private void bt_Association_Click(object sender, EventArgs e)
        {
            mode = "Association";
            PasserEnPhase_Association_Attente();
        }

        private void bt_Lien_Click(object sender, EventArgs e)
        {
            mode = "Lien";
            PasserEnPhase_Lien_Attente();
        }

        private void bt_ouvrir_Click(object sender, EventArgs e)
        {
            dataRecords("ouvrir");
        }

        private void bt_enregistrer_Click(object sender, EventArgs e)
        {
            dataRecords("enregistrer");
        }

        public void changeEnabled(bool mode)
        {
            bt_Association.Enabled = mode;
            bt_Entite.Enabled = mode;
            bt_Lien.Enabled = mode;
            bt_Selection.Enabled = mode;
            bt_enregistrer.Enabled = mode;
            bt_ouvrir.Enabled = mode;
        }

        // Mouse----------------------------------------------------------------

        private void pictureBox_MouseDown(object sender, MouseEventArgs e) //Evenement : le clic gauche est enfoncé
        {
            if (mode == "Entite")
            {
                PasserEnPhase_Entite_Nouvelle();
            }
            else if (mode == "Association")
            {
                PasserEnPhase_Association_Nouvelle();
            }
            else if (mode == "Selection")
            {
                PasserEnPhase_Selection_Nouvelle();
            }
            else if (mode == "Lien")
            {
                PasserEnPhase_Lien_Nouvelle();
            }

            Iterer();
            x = e.X;
            y = e.Y;
            mouse = "Down";
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e) //Evenement : la souris bouge
        {
            if (mode == "Entite")
            {
                debugSize();
                PasserEnPhase_Entite_Position();
            }
            else if (mode == "Association")
            {
                debugSize();
                PasserEnPhase_Association_Position();
            }
            else if (mode == "Selection")
            {
                debugSize();
                if (mouse != "Down")
                {
                    mcd.checkObjet(e.X, e.Y);
                }
                if (objetCurrent != null)
                {
                    debug.Visible = true;
                    debug.Text = objetCurrent.debugEntite();
                }
                else
                {
                    debug.Visible = false;
                }
                PasserEnPhase_Selection_Position();
            }
            else if (mode == "Lien")
            {
                debugSize();
                PasserEnPhase_Lien_Position();
            }

            Iterer();
            x = e.X;
            y = e.Y;
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e) //Evenement : le clic gauche de la souris est relevé
        {
            if (mode == "Entite")
            {
                PasserEnPhase_Entite_PositionDefinitive();
            }
            else if (mode == "Association")
            {
                PasserEnPhase_Association_PositionDefinitive();
            }
            else if (mode == "Selection")
            {
                PasserEnPhase_Selection_PositionDefinitive();
            }
            else if (mode == "Lien")
            {
                PasserEnPhase_Lien_PositionDefinitive();
            }

            Iterer();
            mouse = "Up";
        }

        //Selection ----------------------------------------------------------------------

        private void PasserEnPhase_Selection_Attente()
        {
            PhaseCourante = "Selection_Attente";
        }

        private void ItererPhase_Selection_Attente()
        {

        }

        private void PasserEnPhase_Selection_Nouvelle()
        {
            PhaseCourante = "Selection_Nouvelle";
        }

        private void ItererPhase_Selection_Nouvelle()
        {

            mcd.checkObjet(x, y);
            objetCurrent = mcd.GetObjetCurrent();

            if (objetCurrent != null)
            {
                objetCurrent.resize = true;
                dX = x - objetCurrent.x;
                dY = y - objetCurrent.y;
                mcd.redrawPage();
            }
        }

        private void PasserEnPhase_Selection_Position()
        {
            PhaseCourante = "Selection_Position";
        }

        private void ItererPhase_Selection_Position()
        {
            if (mouse == "Down")
            {
                if (objetCurrent != null)
                {
                    objetCurrent.x = x - dX;
                    objetCurrent.y = y - dY;
                    is_in_limit();
                    mcd.redrawPage();
                    objetCurrent.draw(g);
                }
            }
        }

        private void PasserEnPhase_Selection_PositionDefinitive()
        {
            PhaseCourante = "Selection_PositionDefinitive";
        }

        private void ItererPhase_Selection_PositionDefinitive()
        {
            PasserEnPhase_Selection_Attente();
        }

        //Lien ----------------------------------------------------------------------

        private void PasserEnPhase_Lien_Attente()
        {
            PhaseCourante = "Lien_Attente";
        }

        private void ItererPhase_Lien_Attente()
        {

        }

        private void PasserEnPhase_Lien_Nouvelle()
        {
            PhaseCourante = "Lien_Nouvelle";
        }

        private void ItererPhase_Lien_Nouvelle()
        {

        }

        private void PasserEnPhase_Lien_Position()
        {
            PhaseCourante = "Lien_Position";
        }

        private void ItererPhase_Lien_Position()
        {

        }

        private void PasserEnPhase_Lien_PositionDefinitive()
        {
            PhaseCourante = "Lien_PositionDefinitive";
        }

        private void ItererPhase_Lien_PositionDefinitive()
        {
            PasserEnPhase_Lien_Attente();
        }

        //Entite ----------------------------------------------------------------

        private void PasserEnPhase_Entite_Attente()
        {
            PhaseCourante = "Entite_Attente";
        }

        private void ItererPhase_Entite_Attente()
        {

        }

        private void PasserEnPhase_Entite_Nouvelle()
        {
            PhaseCourante = "Entite_Nouvelle";
        }

        private void ItererPhase_Entite_Nouvelle()
        {
            mcd.checkObjet(x, y);
            objetCurrent = mcd.GetObjetCurrent();

            if (objetCurrent == null)
            {
                int sizeX = 115;
                int sizeY = 100;
                dX = x - sizeX / 2;
                dY = y - sizeY / 2;

                mcd.newEntite(dX, dY, sizeX, sizeY, ("E" + x + "_" + y), ("E" + x + "_" + y));
                objetCurrent = mcd.GetObjetCurrent();
                mcd.drawCurrentObjet(dX, dY);
            }
        }

        private void PasserEnPhase_Entite_Position()
        {
            PhaseCourante = "Entite_Position";
        }

        private void ItererPhase_Entite_Position()
        {
            if (mouse == "Down")
            {
                objetCurrent.x = x - objetCurrent.sizeX / 2;
                objetCurrent.y = y - objetCurrent.sizeY / 2;
                is_in_limit();
                mcd.redrawPage();
                objetCurrent.draw(g);
            }
        }

        private void PasserEnPhase_Entite_PositionDefinitive()
        {
            PhaseCourante = "Entite_PositionDefinitive";
        }

        private void ItererPhase_Entite_PositionDefinitive()
        {
            objetCurrent = null;
            mcd.countEntite += 1;
            PasserEnPhase_Entite_Attente();
        }

        //Association -----------------------------------------------------------

        private void PasserEnPhase_Association_Attente()
        {
            PhaseCourante = "Association_Attente";
        }

        private void ItererPhase_Association_Attente()
        {

        }

        private void PasserEnPhase_Association_Nouvelle()
        {
            PhaseCourante = "Association_Nouvelle";
        }

        private void ItererPhase_Association_Nouvelle()
        {
            mcd.checkObjet(x, y);
            objetCurrent = mcd.GetObjetCurrent();

            if (objetCurrent == null)
            {
                int sizeX = 115;
                int sizeY = 100;
                dX = x - sizeX / 2;
                dY = y - sizeY / 2;

                mcd.newAssociation(dX, dY, sizeX, sizeY, ("A" + x + "_" + y), ("A" + x + "_" + y));
                objetCurrent = mcd.GetObjetCurrent();
                mcd.drawCurrentObjet(dX, dY);
            }
        }

        private void PasserEnPhase_Association_Position()
        {
            PhaseCourante = "Association_Position";
        }

        private void ItererPhase_Association_Position()
        {
            if (mouse == "Down")
            {
                objetCurrent.x = x - objetCurrent.sizeX / 2;
                objetCurrent.y = y - objetCurrent.sizeY / 2;
                is_in_limit();
                mcd.redrawPage();
                objetCurrent.draw(g);
            }
        }

        private void PasserEnPhase_Association_PositionDefinitive()
        {
            PhaseCourante = "Association_PositionDefinitive";
        }

        private void ItererPhase_Association_PositionDefinitive()
        {
            mcd.countAssociation += 1;
            PasserEnPhase_Association_Attente();
        }

        //Iterer ----------------------------------------------------------------

        private void Iterer()
        {
            if (mode != "EcritDonnee")
            {
                if (mode == "Selection")
                {
                    if (PhaseCourante == "Selection_Attente")
                    {
                        ItererPhase_Selection_Attente();
                    }
                    else if (PhaseCourante == "Selection_Nouvelle")
                    {
                        ItererPhase_Selection_Nouvelle();
                    }
                    else if (PhaseCourante == "Selection_Position")
                    {
                        ItererPhase_Selection_Position();
                    }
                    else if (PhaseCourante == "Selection_PositionDefinitive")
                    {
                        ItererPhase_Selection_PositionDefinitive();
                    }
                }
                else if (mode == "Entite")
                {
                    if (PhaseCourante == "Entite_Attente")
                    {
                        ItererPhase_Entite_Attente();
                    }
                    else if (PhaseCourante == "Entite_Nouvelle")
                    {
                        ItererPhase_Entite_Nouvelle();
                    }
                    else if (PhaseCourante == "Entite_Position")
                    {
                        ItererPhase_Entite_Position();
                    }
                    else if (PhaseCourante == "Entite_PositionDefinitive")
                    {
                        ItererPhase_Entite_PositionDefinitive();
                    }
                }
                else if (mode == "Association")
                {
                    if (PhaseCourante == "Association_Attente")
                    {
                        ItererPhase_Association_Attente();
                    }
                    else if (PhaseCourante == "Association_Nouvelle")
                    {
                        ItererPhase_Association_Nouvelle();
                    }
                    else if (PhaseCourante == "Association_Position")
                    {
                        ItererPhase_Association_Position();
                    }
                    else if (PhaseCourante == "Association_PositionDefinitive")
                    {
                        ItererPhase_Association_PositionDefinitive();
                    }
                }
                else if (mode == "Lien")
                {
                    if (PhaseCourante == "Lien_Attente")
                    {
                        ItererPhase_Lien_Attente();
                    }
                    else if (PhaseCourante == "Lien_Nouvelle")
                    {
                        ItererPhase_Lien_Nouvelle();
                    }
                    else if (PhaseCourante == "Lien_Position")
                    {
                        ItererPhase_Lien_Position();
                    }
                    else if (PhaseCourante == "Lien_PositionDefinitive")
                    {
                        ItererPhase_Lien_PositionDefinitive();
                    }
                }

            }
        }

        public void dataRecords(string methode)
        {
            string fileName;
            // On interdit la sélection de plusieurs fichiers.
            dataRecord.Multiselect = false;

            // On supprime le nom de fichier, qui ici vaut "openFileDialog1" (avant sélection d'un fichier).
            dataRecord.FileName = string.Empty;

            // On met des filtres pour les types de fichiers : "Nom|*.extension|autreNom|*.autreExtension" (autant de filtres qu'on veut).
            dataRecord.Filter = "Fichiers texte|*.txt|Tous les fichiers|*.*";

            // Le filtre sélectionné : le 2e (là on ne commence pas à compter à 0).
            dataRecord.FilterIndex = 2;

            // On affiche le dernier dossier ouvert.
            dataRecord.RestoreDirectory = true;

            // Si l'utilisateur clique sur "Ouvrir"...
            if (dataRecord.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // On récupère le nom du fichier.
                    fileName = dataRecord.FileName;
                    // On lit le fichier.
                    if (methode == "ouvrir")
                    {
                        mcd.makeRead(fileName);
                    }
                    else if (methode == "enregistrer")
                    {
                        mcd.makeRecording(fileName);
                    }
                }
                // En cas d'erreur...
                catch (Exception ex)
                {
                    MessageBox.Show(/*"Une erreur est survenue lors de l'ouverture du fichier : {0}.",*/ ex.Message + " " + ex.Source);
                }
            }
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (mode == "Selection")
            {
                if (mcd.checkObjet(e.X, e.Y))
                {
                    panelDonnee.Visible = true;
                    panelDonnee.Enabled = true;
                    NameObjet.Text = objetCurrent.name;
                    TextBoxAttribut.Text = objetCurrent.attributs;
                    mode = "EcritDonnee";
                    changeEnabled(false);
                }
            }
        }

        private void bt_off_Click(object sender, EventArgs e)
        {
            panelDonnee.Visible = false;
            panelDonnee.Enabled = false;
            mode = "Selection";
            changeEnabled(true);
            if (mcd.objetCurrent is Entite)
            {
                objetCurrent.name = NameObjet.Text;
                String[] objet = TextBoxAttribut.Text.Split('\n');
                objetCurrent.attributs = objet[0];
                for (int i = 1; i < objet.Length; i++)
                {
                    if (objet[i] != "")
                    {
                        objetCurrent.attributs = objetCurrent.attributs + '\n' + objet[i];
                    }
                }
                if (objetCurrent.attributs == "")
                {
                    objetCurrent.attributs = null;
                }
                objetCurrent.redimensionnement(g);

                objetCurrent = null;
            }
            else if (mcd.objetCurrent is Association)
            {
                objetCurrent.name = NameObjet.Text;
                objetCurrent.attributs = TextBoxAttribut.Text;
                objetCurrent = null;
            }
            mcd.redrawPage();
        }

        private void form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (Delete && (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete))
            {
                mcd.delObjet();
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (mode == "Selection")
            {
                if (mcd.checkObjet(x, y))
                {
                    Delete = true;
                }
                else if (mcd.checkObjet(x, y) == false)
                {
                    Delete = false;
                }
                mcd.redrawPage();
            }
        }

        public void is_in_limit()
        {
            if (objetCurrent.x < 0) { objetCurrent.x = 3; }
            if (objetCurrent.y < 75) { objetCurrent.y = 75; }
            if (objetCurrent.x + objetCurrent.sizeX > pictureBox1.Width) { objetCurrent.x = pictureBox1.Width - objetCurrent.sizeX - 3; }
            if (objetCurrent.y + objetCurrent.sizeY + 25 > pictureBox1.Height) { objetCurrent.y = pictureBox1.Height - objetCurrent.sizeY - 3; }
        }

        public void debugSize()
        {
            int maxsizeX = pictureBox.Width;
            int maxsizeY = pictureBox.Height;
            debug2.Text = "Width = " + maxsizeX + "\n" + "Height = " + maxsizeY;
        }
    }
}