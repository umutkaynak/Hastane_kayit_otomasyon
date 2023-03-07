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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
 
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Çocuk Sağlığı Ve Hastalıkları")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Ali NESİN");
                comboBox2.Items.Add("VELİ BİRİNCİ");
               
            }
            if (comboBox1.Text == " Deri Ve Zührevi Hastalıkları(Cildiye)") 
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("AZİZ NESİN");
                comboBox2.Items.Add("UMUT KAYNAK");
            }
            if (comboBox1.Text == "Fizik Tedavi Ve Rehabilitasyon")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("FATMA ŞENDEMİR");
                comboBox2.Items.Add("UMUT KAN");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        OleDbConnection Veritabani_Baglanti = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0; Data source=hastaneBilgileri.accdb");
        OleDbDataAdapter Veri_Adaptor;
        OleDbCommand Veri_Komutu;
        OleDbDataReader Veri_Oku;
        DataSet Veri_Seti;
        void Tablo_Listele()
        {
            Veri_Adaptor = new OleDbDataAdapter("Select * from Randevular", Veritabani_Baglanti);
            Veri_Seti = new DataSet();
            Veritabani_Baglanti.Open();

            Veri_Adaptor.Fill(Veri_Seti, "Randevular");
            dataGridView1.DataSource = Veri_Seti.Tables["Randevular"];

            Veritabani_Baglanti.Close();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            Tablo_Listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Veri_Komutu = new OleDbCommand();
            Veritabani_Baglanti.Open();
            Veri_Komutu.Connection = Veritabani_Baglanti;
            Veri_Komutu.CommandText = "Insert into Randevular (Tc, KlinikAdi,DoktorAdi,Saat) values " + "('" + textBox1.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "')";
            Veri_Komutu.ExecuteNonQuery();
            Veritabani_Baglanti.Close();
            Tablo_Listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Veri_Komutu = new OleDbCommand();
            Veritabani_Baglanti.Open();

            Veri_Komutu.Connection = Veritabani_Baglanti;
            Veri_Komutu.CommandText = "Delete from Randevular where Tc='" + textBox1.Text + "'";
            Veri_Komutu.ExecuteNonQuery();

            Veritabani_Baglanti.Close();
            Tablo_Listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Veri_Komutu = new OleDbCommand();
            Veritabani_Baglanti.Open();

            Veri_Komutu.Connection = Veritabani_Baglanti;
            Veri_Komutu.CommandText = "Update Randevular set Tc='" + textBox1.Text + "',KlinikAdi='" + comboBox1.Text + "',DoktorAdi='" + comboBox2.Text + "',Saat='" + comboBox3.Text +  "' where Tc='" + textBox1.Text + "'";
            Veri_Komutu.ExecuteNonQuery();

            Veritabani_Baglanti.Close();
            Tablo_Listele();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 ac = new Form2();
            ac.Show();
            this.Hide();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form7 ac=new Form7();
            ac.Show();
            this.Hide();
            }

        }
}

