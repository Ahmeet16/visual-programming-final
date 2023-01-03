using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Proje
{
    public partial class kgiris : Form
    {
        public kgiris()
        {
            InitializeComponent();
        }
        public static string ad;
        kontrol gkontrol = new kontrol();
        private void button1_Click(object sender, EventArgs e)
        {
            if (gkontrol.giris(textBox1.Text, textBox2.Text) == 1)
            {
                MessageBox.Show("giriş başarılı", "kullanıcı girişi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ad = textBox1.Text;
                anasayfa an = new anasayfa();
                an.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("giriş yapılamadı", "hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            kayıt f2 = new kayıt();
            f2.Show();
            this.Hide();
        }

        private void kgiris_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            animasyon an = new animasyon();
            an.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sıfreu sf=new sıfreu();
            sf.Show();
        }
    }
}
