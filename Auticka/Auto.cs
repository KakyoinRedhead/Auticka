using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auticka
{
    internal class Auto
    { 
        Random r = new Random();
        public float x;
        public float y;
        public int height;
        public int width;
        public float direction;
        public kolecka leftKolecko;
        public kolecka rightKolecko;
        public Brush brush;

        public Auto(float x, float y, int size1, int size2, float direction,Brush brush)
        {
            this.x = x;
            this.y = y;
            this.height = size1;
            this.width = size2;
            this.direction = direction;
            this.brush = brush;

            if(width == 40)
            {
                leftKolecko = new kolecka(x, y + height - 6, 6);
                rightKolecko = new kolecka(x + width - 12, y + height - 6, 6);
            }
            else
            {

                leftKolecko = new kolecka(x +  width - 6,y + height - 12, 6);
                rightKolecko = new kolecka(x + width - 6, y, 6);
            }

           

        }

        public void Draw(Graphics g)
        {
            g.FillEllipse(Brushes.Black, leftKolecko.x, leftKolecko.y, leftKolecko.polomer * 2, leftKolecko.polomer * 2);
            g.FillEllipse(Brushes.Black,rightKolecko.x, rightKolecko.y, rightKolecko.polomer * 2, rightKolecko.polomer * 2);
            g.FillRectangle(brush, x , y, width, height);
        }

     
        
    }
}
