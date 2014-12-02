using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace SlagalicaKvadrati
{
    class Figure
    {
        public int x { get; set; }
        public int y { get; set; }

       

        public int brojač = 0;

        const int a = 30; // Stranica kvadrana

        public SolidBrush BojaFigure;
        public Point[] tačke = new Point[4]; // Tačke figure na kojima će biti zakačeni kvadrati

        // Metodi
        public void NapraviFigure(int ID)
        {
            // Metod dodeljuje pozicije tačkama
            tačke[0].X = x;
            tačke[0].Y = y;
            switch (ID)
            {
                case 0:

                    tačke[1].X = x;
                    tačke[1].Y = y + a;

                    tačke[2].X = x + a;
                    tačke[2].Y = y + a;

                    tačke[3].X = x + 2 * a;
                    tačke[3].Y = y + a;

                    BojaFigure = new SolidBrush(Color.Red);
                    break;

                case 1:

                    tačke[1].X = x;
                    tačke[1].Y = y + a;

                    tačke[2].X = x + a;
                    tačke[2].Y = y;

                    tačke[3].X = x + a;
                    tačke[3].Y = y + a;

                    BojaFigure = new SolidBrush(Color.Blue);
                    break;

                case 2:

                    tačke[1].X = x;
                    tačke[1].Y = y + a;

                    tačke[2].X = x;
                    tačke[2].Y = y + 2 * a;

                    tačke[3].X = x - a;
                    tačke[3].Y = y + 2 * a;

                    BojaFigure = new SolidBrush(Color.Green);
                    break;

                case 3:

                    tačke[1].X = x;
                    tačke[1].Y = y + a;

                    tačke[2].X = x;
                    tačke[2].Y = y + 2 * a;

                    tačke[3].X = x;
                    tačke[3].Y = y + 3 * a;

                    BojaFigure = new SolidBrush(Color.Orange);
                    break;

            }
        }

        public void CrtajFigure(Graphics g)
        {
            
            // Metod na svaku tačku niza "zakači" kvadrat stranice a
            for (int i = 0; i < 4; i++)
            {
                g.FillRectangle(BojaFigure, tačke[i].X, tačke[i].Y, a, a);
            }
        }

        public bool Klik(int c, int d)
        {
            // Proverava da li tačka pripada figuri

            bool klik = false;

            for (int i = 0; i < 4; i++)
            {
                if (c <= tačke[i].X + a && c >= tačke[i].X && d <= tačke[i].Y + a && d >= tačke[i].Y)
                {
                    klik = true;
                }
            }

            return klik;
        }

        public int Leva()
        {
            // Metod vraća krajnje levu tačku figure

            int leva = tačke[0].X;
            for (int i = 1; i < 4; i++)
            {
                if (tačke[i].X < leva)
                {
                    leva = tačke[i].X;
                }
            }

            return leva;
        }

        public int Donja()
        {
            // Metod vraća krajnje donju tačku figure

            int donja = tačke[0].Y;
            for (int i = 1; i < 4; i++)
            {
                if (tačke[i].Y > donja)
                {
                    donja = tačke[i].Y;
                }
            }

            return donja + a;
        }

        public int Desna()
        {
            // Metod vraća krajnje desnu tačku figure

            int desna = tačke[0].X;
            for (int i = 1; i < 4; i++)
            {
                if (tačke[i].X > desna)
                {
                    desna = tačke[i].X;
                }
            }

            return desna + a;
        }
    }
}
