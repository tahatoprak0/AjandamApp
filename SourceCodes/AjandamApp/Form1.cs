using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AjandamApp
{
    public partial class Form1 : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        DatabaseHelper dbHelper = new DatabaseHelper();

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public Form1()
        {
            InitializeComponent();
            mesajlariListele();
            timer1.Start();
            timer1.Tick += timer1_Tick;

        }

        //ana ekranda mesajları listele
        private void mesajlariListele()
        {
            dataGridView1.DataSource = dbHelper.Listele();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "MESAJ";
            dataGridView1.Columns[2].HeaderText = "TARİH";
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button_Guncelle_Click(object sender, EventArgs e)
        {
            FormGuncelle formGuncelle = new FormGuncelle();
            try
            {
                formGuncelle.gelenId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
                formGuncelle.ShowDialog();
             
                    
                mesajlariListele();
            }
            catch (Exception)
            {
                MessageBox.Show($"Seçilecek not yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
               
            
        }

        private void button_Exit_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button_Ekle_Click(object sender, EventArgs e)
        {
            FormEkle formEkle = new FormEkle();
            formEkle.ShowDialog();//formEkle.ShowDialog() ile formu modal olarak açıyoruz
            mesajlariListele();//form kapandıktan sonra mesajları tekra listeler
        }

        private void button_Sil_Click(object sender, EventArgs e)
        {
            try
            {
                int silinecekId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
                DialogResult result = MessageBox.Show("Silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    dbHelper.MesajSil(silinecekId);
                    mesajlariListele();
                }
            }
            catch (Exception)
            {

                MessageBox.Show($"Seçilecek not yoktur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            List<DateTime> notTarihleriGetir = dbHelper.TumNotTarihleriniGetir();
            DateTime suankiZaman = DateTime.Now;
            foreach (DateTime notTarihleri in notTarihleriGetir) 
            {
                if (notTarihleri.Year == suankiZaman.Year && notTarihleri.Month == suankiZaman.Month && notTarihleri.Day == suankiZaman.Day && notTarihleri.Hour == suankiZaman.Hour && notTarihleri.Minute == suankiZaman.Minute) 
                { 
                    string mesaj = dbHelper.MesajiGetir(notTarihleri);
                    if (!string.IsNullOrEmpty(mesaj)) 
                    {
                        MessageBox.Show(mesaj,"Alarm",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        dbHelper.NotSil(durum:1, tarih:notTarihleri);
                        mesajlariListele();
                    }
                }
            }

        }
    }
}

