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
    public partial class sıfreu : Form
    {
        public sıfreu()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt;
        string con = "Server=localhost;Database=proje;Uid=root;Pwd='';";
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection(con);
                dt = new DataTable();
                conn.Open();
                adapter = new MySqlDataAdapter("SELECT * FROM kullanici where  posta='" + textBox1.Text + "' and ka='" + textBox2.Text + "' ", conn);
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();

                label4.Text = "ŞİFRENİZ: " + dataGridView1.CurrentRow.Cells[1].Value.ToString();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void sıfreu_Load(object sender, EventArgs e)
        {

        }
    }
}
