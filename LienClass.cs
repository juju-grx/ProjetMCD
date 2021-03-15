using System;
using System.IO;
using System.Drawing;
using static MCD.Form1;

namespace MCD
{
    class Lien : Objet
    {
        Graphics g;
        public Objet objetdepart;
        public Objet objetarrive;
        MCD mcd;

        public Lien(int X, int Y, int Id, int SizeX, int SizeY,Objet Objetdepart, Objet Objetarrive, string Code, string Name)
        {
            x = X;
            y = Y;
            id = Id;
            pen = new Pen(Color.Black, 3);
            code = Code;
            name = Name;
            float startAngle = 45.0F;
            float sweepAngle = 270.0F;

        }

        //affichage --------------------------------------------------------

        public void drawLien()
        {
            g = pictureBox.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.DrawLine(pen, x, y, sizeX, sizeY);
            
        }
        public bool lienNotExist(string filename)
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
    }
}