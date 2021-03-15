using System;
using System.Drawing;
using static MCD.Form1;

namespace MCD
{
    class Association : Objet
    {
        public int sizeXMin = 115;
        public int sizeYMin = 100;

        Font drawFont = new Font("Arial", 16);
        SolidBrush drawBrush = new SolidBrush(Color.Black);

        public Association(int X, int Y, int Id, int SizeX, int SizeY, string Code, string Name)
        {
            x = X;
            y = Y;
            id = Id;
            sizeX = SizeX;
            sizeY = SizeY;
            pen = new Pen(Color.Black, 3);
            code = Code;
            name = Name;

            if (sizeX < sizeXMin)
            {
                sizeX = sizeXMin;
            }
            if (sizeY < sizeYMin)
            {
                sizeY = sizeYMin;
            }
        }

        //affichage --------------------------------------------------------

        public override void draw(Graphics g)
        {
            g.DrawArc(new Pen(Color.Black, 1), new Rectangle(x, y, sizeX, sizeY), 0, 180);
            g.DrawArc(new Pen(Color.Black, 1), new Rectangle(x, y, sizeX, sizeY), 180, 360);
        }
    }
}