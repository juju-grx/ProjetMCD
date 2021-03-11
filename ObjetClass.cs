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
        public int sizeXMin = 115;
        public int sizeYMin = 100;
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
            return false;
        }
    }
}
