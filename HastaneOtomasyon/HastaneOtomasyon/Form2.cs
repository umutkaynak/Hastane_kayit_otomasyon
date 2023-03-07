using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneOtomasyon
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data source=hastaneBilgileri.accdb");
            bag.Open();
            OleDbCommand giris = new OleDbCommand("select * from Uyeler where TC=@TC and Sifre=@Sifre",bag);
            giris.Parameters.Add("TC", textBox1.Text);
            giris.Parameters.Add("Sifre", textBox2.Text);
            OleDbDataReader oku=giris.ExecuteReader();
            if (oku.Read()) { 
            Form3 ac=new Form3();
                ac.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("hatalı giriş");

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 ac = new Form4();
            ac.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.CadetBlue;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox3.Text=="admin" & textBox4.Text=="admin")
            {
                Form5 ac = new Form5();
                ac.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("yanlış bilgi girdiniz");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 ac =new Form6();
            ac.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.linkedin.com/in/umut-kaynak-88824019a/");
            
        }
    }
    }
