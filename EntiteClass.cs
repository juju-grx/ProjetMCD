using System;
using System.Drawing;

namespace MCD
{
    class Entite : Objet
    {
        public int sizeXMin = 115;
        public int sizeYMin = 100;

        Font drawFont = new Font("Arial", 16);
        SolidBrush drawBrush = new SolidBrush(Color.Black);

        Pen pen = new Pen(Color.Black, 1);

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

        public override  void draw(Graphics g)
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

            g.DrawLines(pen, pointsTitre);
            g.DrawLines(pen, pointsAttributs);

            if(resize == true)
            {
                drawRezise(g);
            }
        }

        public override void drawRezise(Graphics g) 
        {
            g.DrawRectangle(pen, x - 2        , y - 2, 4, 4);
            g.DrawRectangle(pen, x + sizeX - 2, y - 2, 4, 4);
            g.DrawRectangle(pen, x - 2        , y + sizeY + 23, 4, 4);
            g.DrawRectangle(pen, x + sizeX - 2, y + sizeY + 23, 4, 4);
        }

        public override void redimensionnement(Graphics g)
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

                SizeF attributsSizeY = g.MeasureString(objet[0], new Font("Arial", 14));
                int attributssizeY = (int)attributsSizeY.Height;

                if(attributssizeY * objet.Length > 100)
                {
                    sizeY = attributssizeY * objet.Length;
                } else
                {
                    sizeY = 100;
                }

                for (int i = 0; i <objet.Length; i++)
                {
                    SizeF attributsSizeX = g.MeasureString(objet[i], new Font("Arial", 14));
                    int attributssizeX = (int)attributsSizeX.Width;

                    if (attributssizeX > sizeX)
                    {
                        sizeX = attributssizeX;
                    }
                }
            }
            else
            {
                sizeY = 100;
            }
            
        }
    }
}
