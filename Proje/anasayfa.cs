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
    public partial class anasayfa : Form
    {
        public anasayfa()
        {
            InitializeComponent();
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            alisveris al = new alisveris();
            al.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            depo dp = new depo();
            dp.Show();
            this.Hide();
        }

        private void anasayfa_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


       
        private void anasayfa_Load(object sender, EventArgs e)
        {
            DateTime dt11 = new DateTime();
            dt11 = DateTime.Now.Date;
            label1.Text =  kgiris.ad;
            label2.Text = dt11.ToString().TrimEnd('0',':');
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ayarlar ay = new ayarlar();
            ay.Show();
            this.Hide();
        }
    }
}
