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
    public partial class kayıt : Form
    {
        public kayıt()
        {
            InitializeComponent();
        }
        private void kayıt_FormClosed(object sender, FormClosedEventArgs e)
        {
            kgiris f = new kgiris();
            f.Show();
        }

        string con = "Server=localhost;Database=proje;Uid=root;Pwd='';";
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection baglan = new MySqlConnection(con);
                string sorgu = "Insert into kullanici values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
                MySqlCommand cmd = new MySqlCommand(sorgu, baglan);
                baglan.Open();
                cmd.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Kayıt Eklendi.");
                kgiris f = new kgiris();
                f.Show();
                this.Close();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString(),"HATA",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
           


        }

        private void kayıt_Load(object sender, EventArgs e)
        {

        }
    }
}
