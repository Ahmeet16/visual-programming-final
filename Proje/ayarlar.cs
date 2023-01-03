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
    public partial class ayarlar : Form
    {
        public ayarlar()
        {
            InitializeComponent();
        }

        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt;
        string con = "Server=localhost;Database=proje;Uid=root;Pwd='';";
        private void ayarlar_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection(con);
                dt = new DataTable();
                conn.Open();
                adapter = new MySqlDataAdapter("SELECT * FROM kullanici WHERE ka='" + kgiris.ad + "'", conn);
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();

                textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ayarlar_FormClosing(object sender, FormClosingEventArgs e)
        {
            anasayfa an = new anasayfa();
            an.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection(con);
                string sql = "UPDATE kullanici SET ka='" + textBox1.Text + "', sf='" + textBox2.Text + "',posta='" + textBox3.Text + "'where ka='" + kgiris.ad + "'";
                cmd = new MySqlCommand(sql, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Bilgiler Kaydedildi.");
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
