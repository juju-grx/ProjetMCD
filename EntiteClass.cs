using System;
using System.IO;
using System.Drawing;
using static MCD.Form1;

namespace MCD
{
    class Entite : Objet
    {
        Graphics g;

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

        public void drawEntite(Object entiteCurrent)
        {
            g = pictureBox.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Point[] points =
                        {
                        new Point(x, y),
                        new Point(x, y+sizeY),
                        new Point(x+sizeX , y+sizeY),
                        new Point(x+sizeX, y),
                        new Point(x, y),
                        new Point(x, y+(sizeY/5)),
                        new Point(x+sizeX, y+(sizeY/5))
                    };

            SolidBrush whiteBrush = new SolidBrush(Color.White);
            Rectangle rect = new Rectangle(x, y, sizeX, sizeY);
            g.FillRectangle(whiteBrush, rect);

            if (this != entiteCurrent)
            {
                g.DrawLines(new Pen(Color.Black, 3), points);
            }
            else
            {
                g.DrawLines(new Pen(Color.Black, 1), points);
            }

        }
        

        // test ---------------------------------------------

        public bool entiteNotExist(string filename)
        {
            string line;
            StreamReader sr = new StreamReader(@filename);
            line = sr.ReadLine();
            while (line != null)
            {
                String[] objet = line.Split(' ');
                if (objet[1] == code)
                {
                    return false;
                }
                line = sr.ReadLine();
            }
            sr.Close();
            return true;
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
    }
}
