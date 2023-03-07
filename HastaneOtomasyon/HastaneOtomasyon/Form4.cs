using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HastaneOtomasyon
{
    public partial class Form4 : Form
    {
        OleDbConnection Veritabani_Baglanti = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0; Data source=hastaneBilgileri.accdb");
        OleDbDataAdapter Veri_Adaptor;
        OleDbCommand Veri_Komutu;
        OleDbDataReader Veri_Oku;
        DataSet Veri_Seti;
        public Form4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 ac = new Form2();
            ac.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Veri_Komutu = new OleDbCommand();
            Veritabani_Baglanti.Open();
            Veri_Komutu.Connection = Veritabani_Baglanti;
            Veri_Komutu.CommandText = "Insert into Uyeler (TC, Ad,Soyad, Cinsiyet,DogumYer,DogumTarih,BabaAd,AnneAd,CepTel,Eposta,Sifre) values " + "('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + "')";
            Veri_Komutu.ExecuteNonQuery();
            Veritabani_Baglanti.Close();
            Tablo_Listele();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            MessageBox.Show("ÜYELİK İŞLEMLERİNİZ BAŞARIYLA GERÇEKLEŞTİ!!!!");

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        void Tablo_Listele()
        {
            Veri_Adaptor = new OleDbDataAdapter("Select * from Uyeler", Veritabani_Baglanti);
            Veri_Seti = new DataSet();
            Veritabani_Baglanti.Open();

            Veri_Adaptor.Fill(Veri_Seti, "Uyeler");
            dataGridView1.DataSource = Veri_Seti.Tables["Uyeler"];

            Veritabani_Baglanti.Close();
        }
        private void Form4_Load(object sender, EventArgs e)
        {
           Tablo_Listele();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Veri_Komutu = new OleDbCommand();
            Veritabani_Baglanti.Open();

            Veri_Komutu.Connection = Veritabani_Baglanti;
            Veri_Komutu.CommandText = "Update Uyeler set TC='" + textBox1.Text + "',Ad='" + textBox2.Text + "',Soyad='" + textBox3.Text + "',Cinsiyet='" + textBox4.Text + "',DogumYer='" + textBox5.Text + "',DogumTarih='" + textBox6.Text + "',BabaAd='" + textBox7.Text + "',AnneAd='" + textBox8.Text + "',CepTel='" + textBox9.Text + "',Eposta='" + textBox10.Text + "',Sifre='" + textBox11.Text + "' where TC='" + textBox1.Text + "'";
            Veri_Komutu.ExecuteNonQuery();

            Veritabani_Baglanti.Close();
            Tablo_Listele();
            MessageBox.Show("DÜZENLEME İŞLEMİNİZ BAŞARILI");
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            textBox11.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            
            


            //textBox5.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Veri_Komutu = new OleDbCommand();
            Veritabani_Baglanti.Open();

            Veri_Komutu.Connection = Veritabani_Baglanti;
            Veri_Komutu.CommandText = "Delete from Uyeler where TC='" + textBox1.Text + "'";
            Veri_Komutu.ExecuteNonQuery();

            Veritabani_Baglanti.Close();
            Tablo_Listele();
            MessageBox.Show("SİLME İŞLEMİNİZ BAŞARILI.");
        }

        
    }
}
