using System.Drawing;
using static MCD.Form1;

namespace MCD
{
    class Lien : Objet
    {
        Graphics g;

        public int sizeXMin = 115;
        public int sizeYMin = 100;

        public Lien(int X, int Y, int Id, int SizeX, int SizeY, string Colors, string Code)
        {
            x = X;
            y = Y;
            id = Id;
            sizeX = SizeX;
            sizeY = SizeY;
            pen = new Pen(Color.Black, 3);
            code = Code;
        }

        //affichage --------------------------------------------------------

        public void drawAssociation(Graphics g)
        {
            g.DrawLine(pen, x, y, sizeX, sizeY);
        }
    }
}