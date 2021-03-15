using System;
using System.Drawing;
using static MCD.Form1;

namespace MCD
{
    class Association : Objet
    {

        Graphics g;

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

        }
        

        //affichage --------------------------------------------------------

        public void drawAssociation(Object associationCurrent)
        {
            g = pictureBox.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            SolidBrush whiteBrush = new SolidBrush(Color.White);
            Rectangle rect = new Rectangle(x, y, sizeX, sizeY);
            g.FillRectangle(whiteBrush, rect);

            if (this != associationCurrent)
            {
                g.DrawArc(new Pen(Color.Black, 3), new Rectangle(x, y, sizeX, sizeY), 0, 180);
                g.DrawArc(new Pen(Color.Black, 3), new Rectangle(x, y, sizeX, sizeY), 180, 360);

            }
            else
            {
                g.DrawArc(new Pen(Color.Black, 1), new Rectangle(x, y, sizeX, sizeY), 0, 180);
                g.DrawArc(new Pen(Color.Black, 1), new Rectangle(x, y, sizeX, sizeY), 180, 360);
            }
        }

        // Record ----------------------------------------------------

        public string makeRecording()
        {
            return (code + " " + name + " " + x + " " + y + " " + sizeX + " " + sizeY + " ");
        }

        public string attributsCorrect()
        {
            string _attributs = attributs.Replace("\n", ";");
            return _attributs;
        }
    }
}