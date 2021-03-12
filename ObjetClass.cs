using System.Drawing;

namespace MCD
{
    class Objet
    {
        public int id;
        public int x;
        public int y;
        public int sizeX;
        public int sizeY;
        public bool resize = false;
        public string name;
        public string code;
        public string attributs;
        protected static Pen pen;

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
            string var = ("id = " + id + "\n"
                        + "y = " + y + "\n"
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
