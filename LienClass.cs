using System.Drawing;
using static MCD.Form1;

namespace MCD
{
    class Lien : Objet
    {
        Graphics g;

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

        public void drawAssociation(Lien LienCurrent)
        {
            g = pictureBox.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if (this != LienCurrent)
            {
                g.DrawLine(pen, x, y, sizeX, sizeY);
            }
            else
            {
                g.DrawLine(pen, x, y, sizeX, sizeY);
            }
        }

        // Record ----------------------------------------------------

        public string makeRecording()
        {
            return (code + " " + name + " " + x + " " + y + " " + sizeX + " " + sizeY);
        }
    }
}