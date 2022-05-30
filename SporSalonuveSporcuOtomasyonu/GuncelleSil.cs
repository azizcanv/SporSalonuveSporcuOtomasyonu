using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace sporsalonuotomasyonu
{
    public partial class GuncelleSil : Form
    {
        public GuncelleSil()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\azizc\Documents\sporsalonuDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void uyeler()
        {
            baglanti.Open();
            string query = "select * from uyeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            uyeDGV.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void AdFiltreleme()
        {
            baglanti.Open();
            string query = "select * from uyeTbl where uyeAdSoyad='" + uyeAraTb.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            uyeDGV.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void GuncelleSil_Load(object sender, EventArgs e)
        {
            uyeler();
        }

        int key = 0;
        private void uyeDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            key = Convert.ToInt32(uyeDGV.SelectedRows[0].Cells[0].Value.ToString());
            AdSoyadTb.Text = uyeDGV.SelectedRows[0].Cells[1].Value.ToString();
            TelefonTb.Text = uyeDGV.SelectedRows[0].Cells[2].Value.ToString();
            CinsiyetCb.Text = uyeDGV.SelectedRows[0].Cells[3].Value.ToString();
            YasTb.Text = uyeDGV.SelectedRows[0].Cells[4].Value.ToString();
            OdemeTb.Text = uyeDGV.SelectedRows[0].Cells[5].Value.ToString();
            ZamanlamaCb.Text = uyeDGV.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdSoyadTb.Text = "";
            TelefonTb.Text = "";
            CinsiyetCb.Text = "";
            YasTb.Text = "";
            OdemeTb.Text = "";
            ZamanlamaCb.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AnaSayfa anasayfa = new AnaSayfa();
            anasayfa.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Silinecek Uyeyi Seciniz!");
            }
            else
            {
                try
                {
                    baglanti.Open();
                    string query = "delete from uyeTbl where uyeId=" + key + "";
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Uye Basariyla Silindi");
                    baglanti.Close();
                    uyeler();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (key == 0 || AdSoyadTb.Text == "" || TelefonTb.Text == "" || CinsiyetCb.Text == "" || YasTb.Text == "" || OdemeTb.Text == "" || ZamanlamaCb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi!");
            }
            else
            {
                try
                {
                    baglanti.Open();
                    string query = "update uyeTbl set uyeAdSoyad='" + AdSoyadTb.Text + "', uyeTelefon='" + TelefonTb.Text + "', uyeCinsiyet='" + CinsiyetCb.Text + "', uyeYas='" + YasTb.Text + "', uyeOdeme='" + OdemeTb.Text + "', uyeZamanlama='" + ZamanlamaCb.Text + "' where uyeId=" + key + "";
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Uye Basariyla Guncellendi");
                    baglanti.Close();
                    uyeler();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AdFiltreleme();
            uyeAraTb.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            uyeler();
        }
    }
}
