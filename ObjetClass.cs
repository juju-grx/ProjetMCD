using System.Drawing;

namespace MCD
{
    class Objet
    {
        public int id;
        public int x;
        public int y;
        public int sizeX = 100;
        public int sizeY = 125;
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
