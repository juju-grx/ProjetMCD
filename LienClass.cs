using System;
using System.IO;
using System.Drawing;
using static MCD.Form1;

namespace MCD
{
    class Lien : Objet
    {
        Graphics g;
        public string objetdepart;
        public string objetarrive;
        Association associationliee;
        MCD mcd;

        public Lien(int X, int Y, int Id, int SizeX, int SizeY, string Code, string Name)
        {
            x = X;
            y = Y;
            id = Id;
            sizeX = SizeX;
            sizeY = SizeY;
            pen = new Pen(Color.Black, 3);
            code = Code;
            name = Name;
            
        }

        //affichage --------------------------------------------------------

        public void drawLien()
        {
            g = pictureBox.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.DrawLine(pen, x, y, sizeX, sizeY);
            
        }
        public bool lienNotExist(string filename)
        {
            string line;
            StreamReader sr = new StreamReader(@filename);
            line = sr.ReadLine();
            while (line != null)
            {
                String[] objet = line.Split(' ');
                if (objet[1] == code)
                {
                    return false;
                }
                line = sr.ReadLine();
            }
            sr.Close();
            return true;
        }
        public void centrerLien()
        {
            if (objetdepart.Contains("E"))
            {
               for (int i=0; i <mcd.countEntite; i++)
                {

                }
            }
            else if (objetdepart == "A")
            {
                for (int i = 0; i < mcd.countAssociation; i++)
                {
                    associationliee = mcd.GetTabAssociation()[i]; 
                    if (associationliee.code==objetdepart)
                    {
                        x = associationliee.x;
                        y = associationliee.y;
                    }
                    
                }
            }
        }

        // Record ----------------------------------------------------

        public string makeRecording()
        {
            return (code + " " + name + " " + x + " " + y + " " + sizeX + " " + sizeY);
        }
    }
}