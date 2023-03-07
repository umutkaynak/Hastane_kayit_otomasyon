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

namespace HastaneOtomasyon
{
    public partial class Form5 : Form
    {
        OleDbConnection Veritabani_Baglanti = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0; Data source=hastaneBilgileri.accdb");
        OleDbDataAdapter Veri_Adaptor;
        OleDbCommand Veri_Komutu;
        OleDbDataReader Veri_Oku;
        DataSet Veri_Seti;

        void Tablo_Listele()
        {
            Veri_Adaptor = new OleDbDataAdapter("Select * from sikayetOneri", Veritabani_Baglanti);
            Veri_Seti = new DataSet();
            Veritabani_Baglanti.Open();

            Veri_Adaptor.Fill(Veri_Seti, "sikayetOneri");
            dataGridView1.DataSource = Veri_Seti.Tables["sikayetOneri"];

            Veritabani_Baglanti.Close();
        }
        public Form5()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            Tablo_Listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 ac = new Form2();
            ac.Show();
            this.Hide();
        }
    }
}
