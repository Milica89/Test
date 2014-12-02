using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace SlagalicaKvadrati
{
    public partial class Slagalica : Form
    {
        const int s = 30; // stranica kvadrata u mreži
        Figure Odabrana;

        

        Figure[] f = new Figure[4];
        

        public Slagalica()
        {
            InitializeComponent();
        }

        private void Slagalica_Load(object sender, EventArgs e)
        {
            // Kreira objekte (figure)
            for (int i = 0; i < 4; i++)
            {
                f[i] = new Figure();
            }

            PostaviPočetnePozicije();

        }

        private void Slagalica_Paint(object sender, PaintEventArgs e)
        {
            // Crtanje figura
            for (int i = 0; i < 4; i++)
            {
                f[i].NapraviFigure(i);
                f[i].CrtajFigure(e.Graphics);
            }

            // Crtanje mreže

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    e.Graphics.DrawRectangle(new Pen(Color.Black), 5 + i * s, 5 + j * s, s, s);
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Invalidate();

            ProveraPreklapanja();

            ProveraRešenja();
        }

        private void Slagalica_MouseClick(object sender, MouseEventArgs e)
        {
            // Proverava koja figura je kliknuta
            for (int i = 0; i < 4; i++)
            {
                if (f[i].Klik(e.X, e.Y) && e.Button == MouseButtons.Left)
                {
                    Odabrana = f[i];
                    Odabrana.brojač++;
                    break;
                }
            }

            // Postavlja figure tečno u mrežu
            if (Odabrana != null)
            {   
                // Ograničenje da zelena figure ne može da se postavi na pola polja, tj da viri sa desne strane
                if (Odabrana.x > Odabrana.Leva() && Odabrana.x >=125 && Odabrana.x<= 155 && e.Button == MouseButtons.Left)
                {
                    Odabrana.brojač++;
                }


                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (e.X <= 5 + (i + 1) * s && e.X >= 5 + i * s && e.Y <= 5 + (j + 1) * s && e.Y >= 5 + j * s && e.Button == MouseButtons.Left && Odabrana.Klik(e.X, e.Y))
                        {
                            Odabrana.x = 5 + i * s;
                            Odabrana.y = 5 + j * s;

                            // Ograničenja u mreži
                            for (int p = 0; p < 4; p++)
                            {
                                if (Odabrana.Donja() >= 155 + p * s && Odabrana.Donja() <= 155 + (p + 1) * s)
                                {
                                    Odabrana.y -= (p + 1) * s;
                                }
                            }

                            if (Odabrana.Leva() < 5)
                            {
                                Odabrana.x += s;
                            }

                            for (int q = 0; q <= 2; q++)
                            {
                                if (Odabrana.Desna() >= 125 + q * s && Odabrana.Desna() <= 125 + (q + 1) * s)
                                {
                                    Odabrana.x -= q * s;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void Slagalica_MouseMove(object sender, MouseEventArgs e)
        {
            if (Odabrana != null && Odabrana.brojač % 2 != 0)
            {
                Odabrana.x = e.X;
                Odabrana.y = e.Y;


                // Ograničenja u prozoru, nešto strožija nego što je potrebno

                if (Odabrana.x < 5 && Odabrana.y >= 0)
                {
                    Odabrana.x = 5;
                }

                if (Odabrana.y < 5 && Odabrana.y >= 0)
                {
                    Odabrana.y = 5;
                }

                if (Odabrana.y + 120 > this.ClientRectangle.Height)
                {
                    Odabrana.y = this.ClientRectangle.Height - 120;
                }

                if (Odabrana.x + 120 > this.ClientRectangle.Width)
                {
                    Odabrana.x = this.ClientRectangle.Width - 120;
                }
                
            }
        }

        public void ProveraPreklapanja()
        {
            // Proverava da li se neke dve figure preklapaju; to će se desiti ako i samo ako se neke tačke njihovih kvadrata poklapaju
            for (int i = 0; i < 4; i++)
            {
                for (int j = i + 1; j < 4; j++)
                {
                    for (int p = 0; p < 4; p++)
                    {
                        for (int q = 0; q < 4; q++)
                        {
                            if (f[i].tačke[p] == f[j].tačke[q] && Odabrana.brojač % 2 == 0)
                            {
                                label.Text = "Ne sme biti preklapanja u mreži!";
                                label.MaximumSize = new Size(400, 100);
                                label.AutoSize = true;
                                Odabrana.brojač++;
                            }
                        }
                    }
                }
            }

            // Ukoliko odabrana figure klikne na f[a], potreban je ovaj deo da se ne bi neka figura ostavila na pola polja
            for (int a = 0; a < 4; a++)
            {
                if (f[a] != Odabrana)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (f[a].x < 5 + (i + 1) * s && f[a].x > 5 + i * s && f[a].y < 5 + (j + 1) * s && f[a].y > 5 + j * s)
                            {
                                f[a].x = 5 + i * s;
                                f[a].y = 5 + j * s;

                                // Ograničenja u mreži
                                for (int p = 0; p < 4; p++)
                                {
                                    if (f[a].Donja() >= 155 + p * s && f[a].Donja() <= 155 + (p + 1) * s)
                                    {
                                        f[a].y -= (p + 1) * s;
                                    }
                                }

                                if (f[a].Leva() < 5)
                                {
                                    f[a].x += s;
                                }

                                for (int q = 0; q <= 2; q++)
                                {
                                    if (f[a].Desna() >= 125 + q * s && f[a].Desna() <= 125 + (q + 1) * s)
                                    {
                                        f[a].x -= q * s;
                                    }
                                }
                            }
                        }

                    }
                }
            }
        }

        public void ProveraRešenja()
        {
            // Proverava da li je slagalica složena; ovo je tačno ako i samo ako su sve figure u mreži
            int brojač = 0;
            for (int i = 0; i < 4; i++)
            {
                if (f[i].x >= 5 && f[i].x <= 125 && f[i].y >= 5 && f[i].y <= 125)
                {
                    brojač++;
                }
            }

            if (brojač == 4 && Odabrana.brojač % 2 == 0)
            {
                label.Text = "Slagalica je složena";
            }
        }

        public void PostaviPočetnePozicije()
        {
            for (int i = 0; i < 4; i++)
            {
                f[i].x = 10 + i * 100;
                f[i].y = 250;
            }
        }

        private void RestartDugme_Click(object sender, EventArgs e)
        {
            PostaviPočetnePozicije();
            label.Text = "";
            Odabrana = null;
        }
    }
}
