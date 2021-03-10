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

        private Entite entiteCurrent;

        private Entite entitePrevious;

        Entite entite;

        Entite[] tabEntite = new Entite[1000];

        public MCD()
        {
            countEntite = 0;
            countAssociation = 0;
        }

        //objet --------------------------------------------------------------------------------

        public void newEntite(int X, int Y, int SizeX, int SizeY, string Code, string Name)
        {
            entite = new Entite(X, Y, countEntite, SizeX, SizeY, Code, Name); // Créer une nouvelle entité (coordonée X,coordonnée Y,compteur d'entitées créer, taille X, taille Y, Couleur,code)

            tabEntite[countEntite] = entite;
        }
        
        public void delObjet()
        {
            if(objetCurrent == "Entite")
            {
                for (int i = 0; i < countEntite; i++)
                {
                    if (tabEntite[i] == entiteCurrent) //entite actuelle = entité dans le tab 
                    {
                        tabEntite[i] = null;
                    }
                }
                reloadPage();
            }
        }
        
            //affichage -------------------------------------------------------------------------------

        public void drawCurrentEntite(int X, int Y)
        {
            entite.draw();
            entite.x = X;
            entite.y = Y;
        }

        public void reloadPage()
        {
            clearPage(); //créer un carré blanc sur tout le form
            drawAll();   //Réaffiche tout les objets créer
        }

        public void drawAll()
        {
            for (int i = 0; i < countEntite; i++)
            {
                if(tabEntite[i] != null)
                {
                    tabEntite[i].draw(); // redessine l'entitié stocké à l'emplacement i de tabEntite
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
            for (int i = 0; i < countEntite; i++)
            {
                if (tabEntite[i] != null && tabEntite[i].withinObjet(X, Y) == true ) //si il est dans une entité 
                {
                    if ((entiteCurrent == null) || (entiteCurrent != entitePrevious))
                    {
                        entiteCurrent = tabEntite[i];
                        objetCurrent = "Entite";
                        entitePrevious = entiteCurrent;
                        reloadPage();
                    }
                    return true;
                }
                else
                {
                    if (entiteCurrent == tabEntite[i])
                    {
                        entitePrevious = null;
                        entiteCurrent = null;
                        reloadPage();

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
            for (int i = 0; i < countEntite; i++)
            {
                if (tabEntite[i] != null)
                {
                    if (tabEntite[i].attributs != null)
                    {
                        file.WriteLine(tabEntite[i].makeRecording() + "\n\t%" + tabEntite[i].attributsCorrect()); //Ecriture dans le fichier stockant les valeurs de l'entité avec attributs
                    }
                    else
                    {
                        file.WriteLine(tabEntite[i].makeRecording()); //Ecriture dans le fichier stockant les valeurs de l'entité
                    }
                }
                else
                {
                    file.WriteLine("");
                }
            }
        }

        // Read -------------------------------------------------------------------------------------

        public void makeRead(string filename)
        {
            string line;
            string objetCurrent_attributs = null;

            for (int i = 0; i < countEntite; i++)
            {
                tabEntite[i] = null;
            }
            countEntite = 0;

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
                        if (objetCurrent_attributs == "E")
                        {
                            entite.attributs = line.Replace(";", "\n").Replace("\t", "").Replace("%", "");
                        }
                    }
                    else
                    {
                        String[] objet = line.Split(' ');

                        if (line.Contains("E"))
                        {
                            newEntite(Int32.Parse(objet[2]), Int32.Parse(objet[3]), Int32.Parse(objet[4]), Int32.Parse(objet[5]), objet[0], objet[1]);
                            countEntite += 1;
                            objetCurrent_attributs = "E";
                        }
                    }
                }
            } while (true);
            sr.Close();
            reloadPage();
        }

        // Getters ---------------------------------------------------------------------

        public Entite GetEntiteCurrent()
        {
            return entiteCurrent;
        }
    }
}