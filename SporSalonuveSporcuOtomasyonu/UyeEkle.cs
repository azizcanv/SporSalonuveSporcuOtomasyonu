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
    public partial class UyeEkle : Form
    {
        public UyeEkle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\azizc\Documents\sporsalonuDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void UyeEkle_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (AdSoyadTb.Text == "" || TelefonTb.Text == "" || OdemeTb.Text == "" || YasTB.Text == "")
            {
                MessageBox.Show("Eksík Bilgi!");
            }
            else
            {
                try
                {
                    baglanti.Open();
                    string query = "insert into uyeTbl values('" + AdSoyadTb.Text + "','" + TelefonTb.Text + "','" + CinsiyetCb.SelectedItem.ToString() + "','" + YasTB.Text + "','" + OdemeTb.Text + "','" + ZamanlamaCb.SelectedItem.ToString() + "')";
                    SqlCommand komut=new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Uye Basariyla Eklendi");
                    baglanti.Close();
                    AdSoyadTb.Text = "";
                    TelefonTb.Text = "";
                    CinsiyetCb.Text = "";
                    YasTB.Text = "";
                    OdemeTb.Text = "";
                    ZamanlamaCb.Text = "";
                }
                catch(Exception ex)
                {
                    MessageBox.Show("ex.Message");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdSoyadTb.Text = "";
            TelefonTb.Text = "";
            CinsiyetCb.Text = "";
            YasTB.Text = "";
            OdemeTb.Text = "";
            ZamanlamaCb.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AnaSayfa anasayfa = new AnaSayfa();
            anasayfa.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}