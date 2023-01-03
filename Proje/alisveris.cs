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
    public partial class alisveris : Form
    {
        public alisveris()
        {
            InitializeComponent();
        }

        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt;
        string con = "Server=localhost;Database=proje;Uid=root;Pwd='';";
        private void alisveris_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection(con);
                dt = new DataTable();
                conn.Open();
                adapter = new MySqlDataAdapter("SELECT * FROM urunler", conn);
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();

                conn = new MySqlConnection(con);
                string sql = "DELETE FROM sepet";
                cmd = new MySqlCommand(sql, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                conn = new MySqlConnection(con);
                dt = new DataTable();
                conn.Open();
                adapter = new MySqlDataAdapter("SELECT * FROM sepet", conn);
                adapter.Fill(dt);
                dataGridView2.DataSource = dt;
                conn.Close();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection(con);
                dt = new DataTable();
                conn.Open();
                adapter = new MySqlDataAdapter("SELECT * FROM urunler where isim like '" + textBox1.Text + "%'", conn);
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public static string spekle;
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            spekle = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            label2.Text = spekle;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection baglan = new MySqlConnection(con);
                string sorgu = "Insert into sepet values ('" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "','" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "','" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "','" + dataGridView1.CurrentRow.Cells[3].Value.ToString() + "','" + dataGridView1.CurrentRow.Cells[4].Value.ToString() + "')";
                MySqlCommand cmd = new MySqlCommand(sorgu, baglan);
                baglan.Open();
                cmd.ExecuteNonQuery();
                baglan.Close();

                conn = new MySqlConnection(con);
                dt = new DataTable();
                conn.Open();
                adapter = new MySqlDataAdapter("SELECT * FROM sepet", conn);
                adapter.Fill(dt);
                dataGridView2.DataSource = dt;
                conn.Close();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection(con);
                string sql = "DELETE FROM sepet WHERE isim='" + dataGridView2.CurrentRow.Cells[1].Value.ToString() + "'";
                cmd = new MySqlCommand(sql, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                dt = new DataTable();
                conn.Open();
                adapter = new MySqlDataAdapter("SELECT * FROM sepet", conn);
                adapter.Fill(dt);
                dataGridView2.DataSource = dt;
                conn.Close();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            sepet spt = new sepet();
            spt.Show();
            this.Hide();
        }

        private void alisveris_FormClosing(object sender, FormClosingEventArgs e)
        {
            anasayfa an = new anasayfa();
            an.Show();
        }
    }
}
