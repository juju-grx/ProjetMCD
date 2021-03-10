using System;
using System.IO;
using System.Drawing;
using static MCD.Form1;

namespace MCD
{
    class Entite : Objet
    {

        Font drawFont = new Font("Arial", 16);
        SolidBrush drawBrush = new SolidBrush(Color.Black);


        public Entite(int X, int Y, int Id, int SizeX, int SizeY, string Code, string Name)
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

        //affichage ---------------------------------------------------

        public void draw(Graphics g)
        {
            g.DrawString(name, drawFont, drawBrush, x + 2, y);

            if (attributs != null)
            {
                g.DrawString(attributs, new Font("Arial", 14), drawBrush, x + 2, y + (sizeY / 5) + 2);
            }
            Point[] pointsTitre =
                        {
                        new Point(x, y),
                        new Point(x + sizeX, y),
                        new Point(x + sizeX, y + 25),
                        new Point(x, y + 25),
                        new Point(x, y)
                    };

            Point[] pointsAttributs =
                        {
                        new Point(x, y + 25),
                        new Point(x, y + 25 + sizeY ),
                        new Point(x + sizeX, y + 25 + sizeY),
                        new Point(x + sizeX, y + 25),
                        new Point(x, y + 25)
                    };

            g.DrawLines(new Pen(Color.Black, 1), pointsTitre);
            g.DrawLines(new Pen(Color.Black, 1), pointsAttributs);
        }

        public void redimensionnement(Graphics g)
        {
            String[] objet = attributs.Split('\n');
            SizeF nameSize = g.MeasureString(name, drawFont);
            int namesize = (int) nameSize.Width;
            if (nameSize.Width > 115) 
            {
                sizeX = namesize + 2; 
            } else
            {
                sizeX = 115;
            }
            if (objet[0] != null)
            {
                if (5 + objet[0].Length * 11 > 100)
                {
                    sizeX = 5 + objet[0].Length * 11;
                }
            }
            if (objet.Length > 4)
            {
                sizeY = 97 + (objet.Length - 4) * 28;
            }
        }

        // Record ----------------------------------------------------

        public string makeRecording()
        {
            return (code + " " + name + " " + x + " " + y + " " + sizeX + " " + sizeY);
        }

        public string attributsCorrect()
        {
            string _attributs = attributs.Replace("\n", ";");
            return _attributs;
        }

        public string debugEntite()
        {
            string var = ("x = "     + x     + "\n" 
                        + "y = "     + y     + "\n" 
                        + "id = "    + id    + "\n" 
                        + "sizeX = " + sizeX + "\n" 
                        + "sizeY = " + sizeY + "\n" 
                        + "code = "  + code);

            return var;
        }
    }
}
