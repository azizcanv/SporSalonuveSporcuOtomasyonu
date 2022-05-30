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
    public partial class UyeProgramlariGuncelle : Form
    {
        public UyeProgramlariGuncelle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\azizc\Documents\sporsalonuDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void puyeler()
        {
            baglanti.Open();
            string query = "select * from pUyeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            UpbDGV.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void AdFiltreleme()
        {
            baglanti.Open();
            string query = "select * from pUyeTbl where pAdSoyad='" + uyeAraTb.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            UpbDGV.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void UyeProgramlariGuncelle_Load(object sender, EventArgs e)
        {
            puyeler();
        }

        int key = 0;
        private void UpbDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            key = Convert.ToInt32(UpbDGV.SelectedRows[0].Cells[0].Value.ToString());
            pAdSoyadTb.Text = UpbDGV.SelectedRows[0].Cells[1].Value.ToString();
            pUkiloTb.Text = UpbDGV.SelectedRows[0].Cells[2].Value.ToString();
            pUboyTb.Text = UpbDGV.SelectedRows[0].Cells[3].Value.ToString();
            pUyagTB.Text = UpbDGV.SelectedRows[0].Cells[4].Value.ToString();
            pUomuzTb.Text = UpbDGV.SelectedRows[0].Cells[5].Value.ToString();
            pUbelTb.Text = UpbDGV.SelectedRows[0].Cells[6].Value.ToString();
            pUprogram1TB.Text = UpbDGV.SelectedRows[0].Cells[7].Value.ToString();
            pUprogram2TB.Text = UpbDGV.SelectedRows[0].Cells[8].Value.ToString();
            pUprogram3TB.Text = UpbDGV.SelectedRows[0].Cells[9].Value.ToString();
            pUprogram4TB.Text = UpbDGV.SelectedRows[0].Cells[10].Value.ToString();
            pUprogram5TB.Text = UpbDGV.SelectedRows[0].Cells[11].Value.ToString();
            pUprogram6TB.Text = UpbDGV.SelectedRows[0].Cells[12].Value.ToString();
            pUprogram7TB.Text = UpbDGV.SelectedRows[0].Cells[13].Value.ToString();
            pUprogram8TB.Text = UpbDGV.SelectedRows[0].Cells[14].Value.ToString();
            pUprogram9TB.Text = UpbDGV.SelectedRows[0].Cells[15].Value.ToString();
            pUprogram10TB.Text = UpbDGV.SelectedRows[0].Cells[16].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
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
                    string query = "delete from pUyeTbl where pUyeId=" + key + "";
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Uye Basariyla Silindi");
                    baglanti.Close();
                    puyeler();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
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
                    string query = "update pUyeTbl set pAdSoyad='" + pAdSoyadTb.Text + "','" + pUkiloTb.Text + "','" + pUboyTb.Text + "','" + pUyagTB.Text + "','" + pUomuzTb.Text + "','" + pUbelTb.Text + "','" + pUprogram1TB.Text + "','" + pUprogram2TB.Text + "','" + pUprogram3TB.Text + "','" + pUprogram4TB.Text + "','" + pUprogram5TB.Text + "','" + pUprogram6TB.Text + "','" + pUprogram7TB.Text + "','" + pUprogram8TB.Text + "','" + pUprogram9TB.Text + "','" + pUprogram10TB.Text + "' where pUyeId=" + key + "";
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Uye Basariyla Guncellendi");
                    baglanti.Close();
                    puyeler();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AdFiltreleme();
            uyeAraTb.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            puyeler();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
