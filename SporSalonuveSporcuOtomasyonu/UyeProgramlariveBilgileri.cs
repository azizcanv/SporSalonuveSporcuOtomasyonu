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
    public partial class UyeProgramlariveBilgileri : Form
    {
        public UyeProgramlariveBilgileri()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\azizc\Documents\sporsalonuDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AnaSayfa anasayfa = new AnaSayfa();
            anasayfa.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pAdSoyadTb.Text == "" || pUkiloTb.Text == "" || pUboyTb.Text == "" || pUyagTB.Text == "" || pUomuzTb.Text == "" || pUbelTb.Text == "" || pUprogram1TB.Text == "")
            {
                MessageBox.Show("Eksik Bilgi!");
            }
            else
            {
                try
                {
                    baglanti.Open();
                    string query = "insert into pUyeTbl values('" + pAdSoyadTb.Text + "','" + pUkiloTb.Text + "','" + pUboyTb.Text + "','" + pUyagTB.Text + "','" + pUomuzTb.Text + "','" + pUbelTb.Text + "','" + pUprogram1TB.Text + "','" + pUprogram2TB.Text + "','" + pUprogram3TB.Text + "','" + pUprogram4TB.Text + "','" + pUprogram5TB.Text + "','" + pUprogram6TB.Text + "','" + pUprogram7TB.Text + "','" + pUprogram8TB.Text + "','" + pUprogram9TB.Text + "','" + pUprogram10TB.Text + "')";
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Uye Basariyla Eklendi");
                    baglanti.Close();
                    pAdSoyadTb.Text = "";
                    pUkiloTb.Text = "";
                    pUboyTb.Text = "";
                    pUyagTB.Text = "";
                    pUomuzTb.Text = "";
                    pUbelTb.Text = "";
                    pUprogram1TB.Text = "";
                    pUprogram2TB.Text = "";
                    pUprogram3TB.Text = "";
                    pUprogram4TB.Text = "";
                    pUprogram5TB.Text = "";
                    pUprogram6TB.Text = "";
                    pUprogram7TB.Text = "";
                    pUprogram8TB.Text = "";
                    pUprogram9TB.Text = "";
                    pUprogram10TB.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ex.Message");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pAdSoyadTb.Text = "";
            pUkiloTb.Text = "";
            pUboyTb.Text = "";
            pUyagTB.Text = "";
            pUomuzTb.Text = "";
            pUbelTb.Text = "";
            pUprogram1TB.Text = "";
            pUprogram2TB.Text = "";
            pUprogram3TB.Text = "";
            pUprogram4TB.Text = "";
            pUprogram5TB.Text = "";
            pUprogram6TB.Text = "";
            pUprogram7TB.Text = "";
            pUprogram8TB.Text = "";
            pUprogram9TB.Text = "";
            pUprogram10TB.Text = "";
        }
    }
}
