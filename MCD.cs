using System;
using System.Drawing;
using System.IO;
using static MCD.Form1;

namespace MCD
{
    class MCD
    {
        Graphics g;

        public int countEntite;
        public int countAssociation;
        public int countLien;

        public Objet objetCurrent;
        public Objet objetPrevious;

        Entite[] tabEntite = new Entite[1000];
        Association[] tabAssociation = new Association[1000];
        Lien[] tabLien = new Lien[1000];

        public MCD(Graphics G)
        {
            countEntite = 0;
            countAssociation = 0;
            countLien = 0;
            g = G;
        }

        //objet --------------------------------------------------------------------------------

        public void newEntite(int X, int Y, int SizeX, int SizeY, string Code, string Name)
        {
            objetCurrent = tabEntite[countEntite] = new Entite(X, Y, SizeX, SizeY, Code, Name);
        }

        public void newAssociation(int X, int Y, int SizeX, int SizeY, string Code, string Name)
        {
            objetCurrent = tabAssociation[countAssociation] = new Association(X, Y, SizeX, SizeY, Code, Name);
        }

        public void newLien(string Code, Objet Depart, Objet Arriver)
        {
            objetCurrent = tabLien[countLien] = new Lien(Code, Depart, Arriver);
        }

        public void delObjet()
        {
            if (objetCurrent is Entite)
            {
                if (countLien != 0)
                {
                    for (int i = 0; i < tabLien.Length; i++)
                    {
                        if (objetCurrent == tabLien[i].depart || objetCurrent == tabLien[i].arriver)
                        {
                            delLien(tabLien[i]);
                        }
                    }
                }
                delEntite(objetCurrent);
            }
            else if (objetCurrent is Association)
            {
                delAssociation(objetCurrent);
            }
            else if (objetCurrent is Lien)
            {
                delLien(objetCurrent);
            }
            objetCurrent = null;
            redrawPage();
            updateScriptSql();
        }

        public void delEntite(Objet objet)
        {
            for (int i = 0; i < countEntite; i++)
            {
                if (tabEntite[i] == objet)
                {
                    tabEntite[i] = tabEntite[i + 1];
                    for (int j = i; j < countEntite; j++)
                    {
                        if (tabEntite[j] == tabEntite[j + 1])
                        {
                            tabEntite[j + 1] = tabEntite[j + 2];
                        }
                        else
                        {
                            tabEntite[j + 1] = null;
                        }
                    }
                }
            }
            countEntite--;
        }

        public void delAssociation(Objet objet)
        {
            for (int i = 0; i < countAssociation; i++)
            {
                if (tabAssociation[i] == objet)
                {
                    tabAssociation[i] = tabAssociation[i + 1];
                    for (int j = i; j < countAssociation; j++)
                    {
                        if (tabAssociation[j] == tabAssociation[j + 1])
                        {
                            tabAssociation[j + 1] = tabAssociation[j + 2];
                        }
                        else
                        {
                            tabAssociation[j + 1] = null;
                        }
                    }
                }
            }
            countAssociation--;
        }
        public void delLien(Objet objet)
        {
            for (int i = 0; i < countLien; i++)
            {
                if (tabLien[i] == objet)
                {
                    tabLien[i] = tabLien[i + 1];
                    for (int j = i; j < countLien; j++)
                    {
                        if (tabLien[j] == tabLien[j + 1])
                        {
                            tabLien[j + 1] = tabLien[j + 2];
                        }
                        else
                        {
                            tabLien[j + 1] = null;
                        }
                    }
                }
            }
            countLien--;
        }

        //affichage -------------------------------------------------------------------------------

        public void drawCurrentObjet(int X, int Y)
        {
            objetCurrent.x = X;
            objetCurrent.y = Y;
            objetCurrent.draw(g);
        }

        public void redrawPage()
        {
            clearPage();
            drawAll();
        }

        public void drawAll()
        {
            for (int i = 0; i < countLien; i++)
            {
                if (tabLien[i] != null)
                {
                    tabLien[i].draw(g);
                }
            }
            for (int i = 0; i < countAssociation; i++)
            {
                if (tabAssociation[i] != null)
                {
                    tabAssociation[i].draw(g);
                }
            }
            for (int i = 0; i < countEntite; i++)
            {
                if (tabEntite[i] != null)
                {
                    tabEntite[i].draw(g);
                }
            }
        }

        public void clearPage()
        {
            g = pictureBox.CreateGraphics();
            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, pictureBox.Width, pictureBox.Height));
        }

        //verif ----------------------------------------------------------------------------------------

        public bool checkObjet(int X, int Y)
        {
            for (int i = 0; i < countEntite; i++)
            {
                if (tabEntite[i] != null && tabEntite[i].withinObjet(X, Y) == true)
                {
                    if ((objetCurrent == null) || (objetCurrent != objetPrevious))
                    {
                        objetCurrent = tabEntite[i];
                        objetPrevious = objetCurrent;
                    }
                    return true;
                }
                else
                {
                    if (objetCurrent == tabEntite[i])
                    {
                        objetPrevious = null;
                        objetCurrent = null;
                    }
                }
            }

            for (int i = 0; i < countAssociation; i++)
            {
                if (tabAssociation[i] != null && tabAssociation[i].withinObjet(X, Y) == true)
                {
                    if ((objetCurrent == null) || (objetCurrent != objetPrevious))
                    {
                        objetCurrent = tabAssociation[i];
                        objetPrevious = objetCurrent;
                    }
                    return true;
                }
                else
                {
                    if (objetCurrent == tabAssociation[i])
                    {
                        objetPrevious = null;
                        objetCurrent = null;
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
                        file.WriteLine(tabEntite[i].makeRecording() + "\n\t@" + tabEntite[i].attributsCorrect());
                    }
                    else
                    {
                        file.WriteLine(tabEntite[i].makeRecording());
                    }
                }
                else
                {
                    file.WriteLine("");
                }
            }
            for (int i = 0; i < countAssociation; i++)
            {
                if (tabAssociation[i] != null)
                {
                    if (tabAssociation[i].attributs != null)
                    {
                        file.WriteLine(tabAssociation[i].makeRecording() + "\n\t@" + tabAssociation[i].attributsCorrect());
                    }
                    else
                    {
                        file.WriteLine(tabAssociation[i].makeRecording());
                    }
                }
            }
            for (int i = 0; i < countLien; i++)
            {
                if (tabLien[i] != null)
                {
                    file.WriteLine(tabLien[i].makeRecording());
                }
            }
        }

        // Read -------------------------------------------------------------------------------------

        public void makeRead(string filename)
        {
            string line;

            for (int i = 0; i < countEntite; i++)
            {
                tabEntite[i] = null;
            }
            countEntite = 0;
            for (int i = 0; i < countAssociation; i++)
            {
                tabAssociation[i] = null;
            }
            countAssociation = 0;
            for (int i = 0; i < countLien; i++)
            {
                tabLien[i] = null;
            }
            countLien = 0;

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
                        objetCurrent.attributs = line.Replace(";", "\n").Replace("\t", "").Replace("%", "");

                        String[] objet = objetCurrent.attributs.Split('\n');
                        objetCurrent.attributs = "";

                        for (int i = 0; i < objet.Length; i++)
                        {
                            if (objet[i].Contains("#"))
                            {
                                objetCurrent.idAttribut = objet[i];
                            }
                            else
                            {
                                objetCurrent.attributs += objet[i] + "\n";
                            }
                        }
                    }
                    else
                    {
                        String[] objet = line.Split(' ');

                        if (line.Contains("E"))
                        {
                            newEntite(Int32.Parse(objet[2]), Int32.Parse(objet[3]), Int32.Parse(objet[4]), Int32.Parse(objet[5]), objet[0], objet[1]);
                            countEntite += 1;
                        }
                        else if (line.Contains("A"))
                        {
                            newAssociation(Int32.Parse(objet[2]), Int32.Parse(objet[3]), Int32.Parse(objet[4]), Int32.Parse(objet[5]), objet[0], objet[1]);
                            countAssociation += 1;
                        }
                        else if (line.Contains("L"))
                        {
                            Objet depart = null;
                            Objet arriver = null;

                            for (int i = 0; i < tabEntite.Length; i++)
                            {
                                if (objet[1] == tabEntite[i].code)
                                {
                                    depart = tabEntite[i];
                                }
                                if (objet[2] == tabEntite[i].code)
                                {
                                    arriver = tabEntite[i];
                                }
                            }

                            newLien(objet[0], depart, arriver);
                            countLien += 1;
                        }
                    }
                }
            } while (true);
            sr.Close();
            redrawPage();
        }

        public void ifLienLink(Objet objetLink)
        {
            for (int i = 0; i < tabLien.Length; i++)
            {
                if (tabLien[i] != null)
                {
                    if (objetLink == tabLien[i].depart)
                    {
                        tabLien[i].x = objetLink.x + objetLink.sizeX / 2;
                        tabLien[i].y = objetLink.y + objetLink.sizeY / 2 + 25;
                    }
                    else if (objetLink == tabLien[i].arriver)
                    {
                        tabLien[i].sizeX = objetLink.x + objetLink.sizeX / 2;
                        tabLien[i].sizeY = objetLink.y + objetLink.sizeY / 2 + 25;
                    }
                }

            }
        }

        public void ifLienExist()
        {
            for (int i = 0; i < tabLien.Length; i++)
            {
                if (tabLien[i] != null)
                {

                }

            }
        }

        public void ifLinkDupli(Lien lien)
        {
            for (int i = 0; i < tabLien.Length; i++)
            {
                /*if((lien.depart == tabLien[i].depart) && (lien.arriver == tabLien[i].arriver))
                {
                    delLien(lien);
                }*/
            }
        }

        public string generationScriptSQL()
        {
            string scriptSql = "";
            for (int i = 0; i < countEntite; i++)
            {
                if (tabEntite[i].attributs != null)
                {
                    scriptSql += "CREATE TABLE " + tabEntite[i].name + " (";
                    String[] objet = tabEntite[i].attributs.Split('\n');
                    string attributs = "";
                    string idAttributs = "";
                    bool ID = false;
                    if(tabEntite[i].idAttribut != null)
                    {
                        idAttributs = tabEntite[i].idAttribut.Replace("#", "");
                        scriptSql += "\n    " + idAttributs + ",";
                        ID = true;
                    }
                    for (int j = 0; j < objet.Length; j++)
                    {
                        attributs += "\n    " + objet[j] + ",";
                    }
                    scriptSql += attributs;
                    if(ID)
                    {
                        scriptSql += "\n    PRIMARY KEY(" + idAttributs + "),";
                    }
                    scriptSql += "\n );\n\n";
                }
            }
            return scriptSql;
        }

        public void updateScriptSql()
        {
            string sql = generationScriptSQL();
            richTextSql.Text = sql;
            if (sql != "")
            { buttonScript.Text = "Recharger SQL"; }
            else
            { buttonScript.Text = "Generer SQL"; }
        }

        // Getters ---------------------------------------------------------------------

        public Objet GetObjetCurrent()
        {
            return objetCurrent;
        }

        // Setters ----------------------------------------------------------------------

        public void SetObjetCurrent(Objet objet)
        {
            objetCurrent = objet;
        }
    }
}