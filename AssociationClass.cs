using System;
using System.Drawing;

namespace MCD
{
    class Association : Objet
    {
        public Association(int X, int Y, int SizeX, int SizeY, string Code, string Name)
        {
            x = X;
            y = Y;
            sizeX = SizeX;
            sizeY = SizeY;
            sizeXMin = 115;
            sizeYMin = 100;
            pen = new Pen(Color.Black, 1);
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
            g.DrawArc(pen, new Rectangle(x, y, sizeX, sizeY), 0, 180);
            g.DrawArc(pen, new Rectangle(x, y, sizeX, sizeY), 180, 360);

            SizeF attributsSize = g.MeasureString(name, new Font("Arial", 14));
            int attributssizeX = (int)attributsSize.Width;
            int attributssizeY = (int)attributsSize.Height;

            g.DrawString(name, drawFont, drawBrush, x + (sizeX / 2 - attributssizeX / 2), y + (sizeY/2 - attributssizeY / 2));
        }
    }
}