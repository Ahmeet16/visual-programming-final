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
    public partial class ödeme : Form
    {
        public ödeme()
        {
            InitializeComponent();
        }
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt;
        string con = "Server=localhost;Database=proje;Uid=root;Pwd='';";
        double hs, kdv, tp;

        private void ödeme_FormClosing(object sender, FormClosingEventArgs e)
        {
            anasayfa an = new anasayfa();
            an.Show();
        }

        private void ödeme_Load(object sender, EventArgs e)
        {
            hs = sepet.tp;
            kdv = hs * 8 / 100;
            tp = hs + kdv;
            label6.Text = "FİYAT: " + hs.ToString();
            label8.Text = "KDV(%8): " + kdv.ToString("N2");
            label9.Text = "TOPLAM FİYAT: " + tp.ToString("N2");


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection baglan = new MySqlConnection(con);
                string sorgu = "Insert into odeme values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.SelectedItem.ToString() + "','" + comboBox2.SelectedItem.ToString() + "','" + tp.ToString() + "')";
                MySqlCommand cmd = new MySqlCommand(sorgu, baglan);
                baglan.Open();
                cmd.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Kayıt Başarıyla Alındı Kargo Şirketi Tarafınfan Telefonunuza SMS Gönderilecektir.");
                anasayfa an = new anasayfa();
                an.Show();
                this.Close();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
