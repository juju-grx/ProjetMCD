using System;
using System.IO;
using System.Drawing;
using static MCD.Form1;

namespace MCD
{
    class Entite : Objet
    {
        public int sizeXMin = 115;
        public int sizeYMin = 100;

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

            if(sizeX < sizeXMin)
            {
                sizeX = sizeXMin;
            }
            if (sizeY < sizeYMin)
            {
                sizeY = sizeYMin;
            }
        }

        //affichage ---------------------------------------------------

        public void draw(Graphics g)
        {
            g.DrawString(name, drawFont, drawBrush, x + 2, y);

            if (attributs != null)
            {
                g.DrawString(attributs, new Font("Arial", 14), drawBrush, x + 2, y + 27);
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
            SizeF nameSize = g.MeasureString(name, drawFont);
            int namesize = (int) nameSize.Width;

            if (nameSize.Width > 115) 
            {
                sizeX = namesize + 2; 
            } else 
            {
                sizeX = 115;
            }

            if (attributs != null)
            {
                String[] objet = attributs.Split('\n');

                SizeF attributsSize = g.MeasureString(objet[0], new Font("Arial", 14));
                int attributssize = (int)attributsSize.Height;

                if(attributssize * objet.Length > 100)
                {
                    sizeY = attributssize * objet.Length;
                } else
                {
                    sizeY = 100;
                }
            }
            else
            {
                sizeY = 100;
            }
            
        }
    }
}
