using System;
using System.IO;
using System.Drawing;
using static MCD.Form1;

namespace MCD
{
    class Entite : Objet
    {
        Graphics g;

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

        public void draw()
        {
            g = pictureBox.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

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
