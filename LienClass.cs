using System;
using System.Drawing;

namespace MCD
{
    class Lien : Objet
    {
        public Objet depart = null;
        public Objet arriver = null;

        public Lien(string Code, Objet Depart, Objet Arriver)
        {
            x = Depart.x + Depart.sizeX/2;
            y = Depart.y + (Depart.sizeY + 25)/2;
            if(Arriver != null)
            {
                sizeX = Arriver.x + Arriver.sizeX/2;
                sizeY = Arriver.y + (Arriver.sizeY + 25) / 2;
            } else
            {
                sizeX = x;
                sizeY = y;
            }
            pen = new Pen(Color.Black, 2);
            code = Code;
            depart = Depart;
            arriver = Arriver;
        }

        //affichage --------------------------------------------------------

        public override void draw(Graphics g)
        {
            g.DrawLine(pen, new Point(x, y),new Point(sizeX, sizeY));
        }

        // Record ----------------------------------------------------

        new public string makeRecording()
        {
            return (code + " " + depart.code + " " + arriver.code);
        }
    }
}