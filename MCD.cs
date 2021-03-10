using System;
using System.Drawing;
using System.IO;
using static MCD.Form1;

namespace MCD
{
    class MCD
    {
        Graphics g;

        public int countEntite = 0;
        public int countAssociation = 0;

        public string objetCurrent = null;

        private Association associationCurrent;

        private Association associationPrevious;

        Association association;

        Association[] tabAssociation = new Association[1000];

        public MCD()
        {
            countEntite = 0;
            countAssociation = 0;
        }

        //objet --------------------------------------------------------------------------------

        public void newAssociation(int X, int Y, int SizeX, int SizeY, string Code, string Name)
        {
            association = new Association(X, Y, countAssociation, SizeX, SizeY, Code, Name);

            tabAssociation[countAssociation] = association;
        }
        
        public void delObjet()
        {
            if (objetCurrent == "Association")
            {
                for (int i = 0; i < countAssociation; i++)
                {
                    if (tabAssociation[i] == associationCurrent) //association actuelle = association dans le tab 
                    {
                        tabAssociation[i] = null;
                    }
                }
                reloadPage();
            }
        }
        
        //affichage -------------------------------------------------------------------------------

        public void drawCurrentAssociation(int X, int Y)
        {
            association.draw();
            association.x = X;
            association.y = Y;
        }

        public void reloadPage()
        {
            clearPage(); //créer un carré blanc sur tout le form
            drawAll();   //Réaffiche tout les objets créer
        }

        public void drawAll()
        {
            for (int i = 0; i < countAssociation; i++)
            {
                if (tabAssociation[i] != null)
                {
                    tabAssociation[i].draw();
                }
            }
        }

        public void clearPage()
        {
            // Créer un carré blancsur le formulaire
            g = pictureBox.CreateGraphics();
            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, 1000, 1000));
        }

        //verif ----------------------------------------------------------------------------------------

        public bool checkObjet(int X, int Y)
        {
            for (int i = 0; i < countAssociation; i++)
            {
                if (tabAssociation[i] != null && tabAssociation[i].withinObjet(X, Y) == true) //si il est dans une association
                {
                    if ((associationCurrent == null) || (associationCurrent != associationPrevious))
                    {
                        associationCurrent = tabAssociation[i];
                        objetCurrent = "Association";
                        reloadPage();
                        associationPrevious = associationCurrent;
                    }
                    return true;
                }
                else
                {
                    if (associationCurrent == tabAssociation[i])
                    {
                        associationPrevious = null;
                        reloadPage();
                        associationCurrent = null;
                    }
                }
            }

            // Si entiteCourante(True) != nouvelle coor (False) alors sortie donc réaffichage  
            // mais Si entiteCourante(False) != nouvelle coor (True) alors rentrée donc réaffichage 
            // mais Si entiteCourrante(False) == nouvelle coor (False) alors on est toujours à l'exterieur donc ne rien faire
            // mais Si entitieCourante(True) == nouvelle coor (True) alors on est toujours dedans donc ne rien faire
            return false;
        }

        // Write -----------------------------------------------------------------------------------

        public void makeRecording(string filename)
        {
            using StreamWriter file = new StreamWriter(@filename, false);
            
            for (int i = 0; i < countAssociation; i++)
            {
                if (tabAssociation[i] != null)
                {
                    if (tabAssociation[i].attributs != null)
                    {
                        file.WriteLine(tabAssociation[i].makeRecording() + "\n\t%" + tabAssociation[i].attributsCorrect()); //Ecriture dans le fichier stockant les valeurs de l'entité avec attributs
                    }
                    else
                    {
                        file.WriteLine(tabAssociation[i].makeRecording()); //Ecriture dans le fichier stockant les valeurs de l'entité
                    }
                }
            }
        }

        // Read -------------------------------------------------------------------------------------

        public void makeRead(string filename)
        {
            string line;
            string objetCurrent_attributs = null;

            for (int i = 0; i < countAssociation; i++)
            {
                tabAssociation[i] = null;
            }
            countAssociation = 0;

            StreamReader sr = new StreamReader(@filename);
            do
            {
                line = sr.ReadLine();
                if (line == null) break;
                line = line.Trim();
                if (line != "")
                {
                    if (line.Contains("%"))
                    {
                        if (objetCurrent_attributs == "A")
                        {
                            association.attributs = line.Replace(";", "\n").Replace("\t", "").Replace("%", "");
                        }
                    }
                    else
                    {
                        String[] objet = line.Split(' ');

                        if (line.Contains("A"))
                        {
                            newAssociation(Int32.Parse(objet[2]), Int32.Parse(objet[3]), Int32.Parse(objet[4]), Int32.Parse(objet[5]), objet[0], objet[1]);
                            countAssociation += 1;
                            objetCurrent_attributs = "A";
                        }
                    }
                }
            } while (true);
            sr.Close();
            reloadPage();
        }

        // Getters ---------------------------------------------------------------------

        public Association GetAssociationCurrent()
        {
            return associationCurrent;
        }
    }
}