using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje
{
    public partial class animasyon : Form
    {
        public animasyon()
        {
            InitializeComponent();
        }

        Graphics g;
        int x = 0, y = 0, m = 0, q = 0;

        private void animasyon_FormClosing(object sender, FormClosingEventArgs e)
        {
            kgiris k = new kgiris();
            k.Show();
        }

        private void animasyon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            kgiris k = new kgiris();
            k.Show();
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            g = CreateGraphics();
            if (y == 0)
            {
                for (int i = 0; i < ClientSize.Width; i++)
                {
                    g.DrawLine(new Pen(Color.Red, 1), 0, x, x, ClientSize.Height);
                    g.DrawLine(new Pen(Color.Green, 1), (ClientSize.Width / 2 - 136) + x, ClientSize.Height, ClientSize.Width, ClientSize.Height - x);
                    g.DrawLine(new Pen(Color.Orange, 1), ClientSize.Width, ClientSize.Height - x, ClientSize.Width - x, 0);
                    g.DrawLine(new Pen(Color.Blue, 1), (ClientSize.Width / 2 + 136) - x, 0, 0, x);
                    x += 15;
                }
                y++;
                x = 0;
            }
            else if (y == 1)
            {
                for (int i = 0; i < ClientSize.Width; i++)
                {
                    g.DrawLine(new Pen(Color.Blue, 1), 0, x, x, ClientSize.Height);
                    g.DrawLine(new Pen(Color.Red, 1), (ClientSize.Width / 2 - 136) + x, ClientSize.Height, ClientSize.Width, ClientSize.Height - x);
                    g.DrawLine(new Pen(Color.Green, 1), ClientSize.Width, ClientSize.Height - x, ClientSize.Width - x, 0);
                    g.DrawLine(new Pen(Color.Orange, 1), (ClientSize.Width / 2 + 136) - x, 0, 0, x);
                    x += 15;
                }
                y++;
                x = 0;
            }
            else if (y == 2)
            {
                for (int i = 0; i < ClientSize.Width; i++)
                {
                    g.DrawLine(new Pen(Color.Orange, 1), 0, x, x, ClientSize.Height);
                    g.DrawLine(new Pen(Color.Blue, 1), (ClientSize.Width / 2 - 136) + x, ClientSize.Height, ClientSize.Width, ClientSize.Height - x);
                    g.DrawLine(new Pen(Color.Red, 1), ClientSize.Width, ClientSize.Height - x, ClientSize.Width - x, 0);
                    g.DrawLine(new Pen(Color.Green, 1), (ClientSize.Width / 2 + 136) - x, 0, 0, x);
                    x += 15;
                }
                y++;
                x = 0;
            }
            else if (y == 3)
            {
                for (int i = 0; i < ClientSize.Width; i++)
                {
                    g.DrawLine(new Pen(Color.Green, 1), 0, x, x, ClientSize.Height);
                    g.DrawLine(new Pen(Color.Orange, 1), (ClientSize.Width / 2 - 136) + x, ClientSize.Height, ClientSize.Width, ClientSize.Height - x);
                    g.DrawLine(new Pen(Color.Blue, 1), ClientSize.Width, ClientSize.Height - x, ClientSize.Width - x, 0);
                    g.DrawLine(new Pen(Color.Red, 1), (ClientSize.Width / 2 + 136) - x, 0, 0, x);
                    x += 15;
                }
                y = 0;
                x = 0;
            }
        }

        private void animasyon_MouseClick(object sender, MouseEventArgs e)
        {
            if (m == 0)
            {
                timer1.Enabled = false;
                m = 1;
                label1.Visible = false;
                label2.Visible = false;
            }
            else if (m == 1)
            {
                timer1.Interval = 1;
                timer1.Enabled = true;
                m = 0;
                label1.Visible = true;
                label2.Visible = true;
            }
        }

        private void animasyon_Load(object sender, EventArgs e)
        {
            label1.Location = new Point((ClientSize.Width/2)-label1.Size.Width/2,(ClientSize.Height/2)-label1.Size.Height/2);
            label2.Location = new Point((ClientSize.Width / 2) - label2.Size.Width / 2, (ClientSize.Height / 2+ label1.Size.Height) - label2.Size.Height / 2);
        }
    }
}
