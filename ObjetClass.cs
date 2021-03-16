using System.Drawing;

namespace MCD
{
    class Objet
    {
        public int x;
        public int y;
        public int sizeX;
        public int sizeY;
        public int sizeXMin;
        public int sizeYMin;
        public bool resize = false;
        public string name;
        public string code;
        public string attributs;
        protected static Pen pen;
        protected static Pen penResize = new Pen(Color.Black, 3);
        protected Font drawFont = new Font("Arial", 16);
        protected SolidBrush drawBrush = new SolidBrush(Color.Black);

        // verif -----------------------------------------------------

        public bool withinObjet(int X, int Y)
        {
            if ((X >= x) && (X <= x + sizeX) && (Y >= y) && (Y <= y + sizeY))
            {
                return true;
            }
            resize = false;
            return false;
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

        // Draw --------------------------------------------------------

        public string debugEntite()
        {
            string var = ("y = " + y + "\n"
                        + "x = " + x + "\n"
                        + "sizeX = " + sizeX + "\n"
                        + "sizeY = " + sizeY + "\n"
                        + "code = " + code);

            return var;
        }

        public virtual void drawRezise(Graphics g){}

        public virtual void draw(Graphics g){}

        public virtual void redimensionnement(Graphics g){}
    }
}
