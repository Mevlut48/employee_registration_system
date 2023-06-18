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


namespace WindowsFormsApp1
{
    public partial class frmanaform : Form
    {
        public frmanaform()
        {
            InitializeComponent();
        }

        baglantisinif bgl = new baglantisinif();
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }


        void temizle()
        {
            txtmeslek.Text = "";
            txtpersonelAD.Text = "";
            txtPersonelSoyad.Text = "";
            txtpersoneLıd.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked=false;
            cxsehir.Text = "";
            mskmaas.Text = "";
            txtpersonelAD.Focus();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.tbl_personelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_personel);
         
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            this.tbl_personelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_personel);
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(bgl.adres);
            conn.Open();

            SqlCommand komut = new SqlCommand("insert into Tbl_personel (perAd,persoyad,persehir,permaaş,permeslek,perdurum) values (@p1,@p2,@p3,@p4,@p5,@p6)",conn);
            komut.Parameters.AddWithValue("@p1",txtpersonelAD.Text);
            komut.Parameters.AddWithValue("@p2", txtPersonelSoyad.Text);
            komut.Parameters.AddWithValue("@p3", cxsehir.Text);
            komut.Parameters.AddWithValue("@p4", mskmaas.Text);
            komut.Parameters.AddWithValue("@p5", txtmeslek.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("personel eklendi");
            conn.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked==true)
            {

                label8.Text = "True";
            }
       
        }

       
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        
        {
            if (radioButton2.Checked==true)
            {
                label8.Text = "False";


            }
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtpersoneLıd.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtpersonelAD.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtPersonelSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cxsehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mskmaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtmeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        
        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text=="True")
            {
                radioButton1.Checked = true;


            }
            if (label8.Text=="False") {
                radioButton2.Checked = true;
            }

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(bgl.adres);
            conn.Open();
            SqlCommand komutsil1=new SqlCommand("delete from tbl_personel where perID=@k1",conn);
            komutsil1.Parameters.AddWithValue("@k1", txtpersoneLıd.Text);
            komutsil1.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("kayıt silindi");
        }

        private void btngucelle_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(bgl.adres);
            conn.Open();
            SqlCommand guncelle = new SqlCommand("update tbl_personel set perad=@perad1,persoyad=@persoyad1,persehir=@persehir1,permaaş=@permaaş1,perdurum=@perdurum1,permeslek=@permeslek1 where perId=@perId1",conn);
           guncelle.Parameters.AddWithValue("@perad1",txtpersonelAD.Text);
            guncelle.Parameters.AddWithValue("@persoyad1", txtPersonelSoyad.Text);
            guncelle.Parameters.AddWithValue("@perSehir1", cxsehir.Text);
            guncelle.Parameters.AddWithValue("@permaaş1", mskmaas.Text);
            guncelle.Parameters.AddWithValue("@perdurum1", label8.Text);
            guncelle.Parameters.AddWithValue("@permeslek1", txtmeslek.Text);
            guncelle.Parameters.AddWithValue("perId1", txtpersoneLıd.Text);
            guncelle.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("veriler güncellendi");
        }

        private void btnistatistik_Click(object sender, EventArgs e)
        {
            frmistatistik fr = new frmistatistik();
            fr.Show();
        }

        private void btngrafik_Click(object sender, EventArgs e)
        {
           frmgrafikler frg=new frmgrafikler();
            frg.Show(); 
        }
    }
}
