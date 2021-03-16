using System;
using System.Drawing;

namespace MCD
{
    class Lien : Objet
    {
        public Objet depart = null;
        public Objet arriver = null;

        public Lien(int X, int Y, int SizeX, int SizeY, string Code, Objet Depart, Objet Arriver)
        {
            x = X;
            y = Y;
            sizeX = SizeX;
            sizeY = SizeY;
            pen = new Pen(Color.Black, 2);
            code = Code;
            depart = Depart;
            arriver = Arriver;
        }

        //affichage --------------------------------------------------------

        public override void draw(Graphics g)
        {
            g.DrawLine(pen, new Point(x, y),new Point(sizeX, sizeY));

            g.DrawString(code, drawFont, drawBrush, sizeX - 10, sizeY - 10);
        }

        // Record ----------------------------------------------------

        public string makeRecording()
        {
            return (code + " " + x + " " + y + " " + sizeX + " " + sizeY + " " + depart.code + " " + arriver.code);
        }
    }
}