#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace Classes
{
    class Point
    {
        private int x, y;

        public Point(int a, int b)//nokta2 burdan yaratılıyor
        {
            //Console.WriteLine("x:{0},y:{1},x,y");
            this.x = a;
            this.y = b;
        }

        public Point()//nokta1 burdan yaratılıyor
        {
            this.x = 1;
            this.y = 2;
        }

        public double UzaklıkOlc(Point nokta_nesne_parametresi)
        {
            int xFark = this.x - nokta_nesne_parametresi.x;
            int yFark = this.y - nokta_nesne_parametresi.y;
            return Math.Sqrt(xFark*xFark + yFark*yFark);
        }

        public int DegerGosterx()
        {
            return x;
        }

        public int DegerGostery()
        {
            return y;
        }

    }
}