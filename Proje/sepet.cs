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
    public partial class sepet : Form
    {
        public sepet()
        {
            InitializeComponent();
        }
        public static int tp = 0;
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt;
        string con = "Server=localhost;Database=proje;Uid=root;Pwd='';";
        private void sepet_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection(con);
                dt = new DataTable();
                conn.Open();
                adapter = new MySqlDataAdapter("SELECT * FROM sepet", conn);
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
                // label1.Text = dataGridView1.RowCount.ToString();
                for (int i = 0; i < int.Parse(dataGridView1.RowCount.ToString()) - 1; i++)
                {
                    tp += int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                }
                label1.Text = "TOPLAM FİYAT: " + tp.ToString("C2");
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection(con);
                string sql = "DELETE FROM sepet WHERE isim='" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "'";
                cmd = new MySqlCommand(sql, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                dt = new DataTable();
                conn.Open();
                adapter = new MySqlDataAdapter("SELECT * FROM sepet", conn);
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();

                for (int i = 0; i < int.Parse(dataGridView1.RowCount.ToString()) - 1; i++)
                {
                    tp += int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                }
                label1.Text = "TOPLAM FİYAT: " + tp.ToString("C2");

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            ödeme öd = new ödeme();
            öd.Show();
            this.Hide();
        }

        private void sepet_FormClosing(object sender, FormClosingEventArgs e)
        {
            anasayfa an = new anasayfa();
            an.Show();
        }
    }
}
