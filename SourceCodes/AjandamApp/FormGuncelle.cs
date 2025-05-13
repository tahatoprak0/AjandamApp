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
    public partial class FormGuncelle : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public int gelenId;
        DatabaseHelper DbHelper = new DatabaseHelper();

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public FormGuncelle()
        {
            InitializeComponent();
        }


        private void panel1_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void FormGuncelle_Load(object sender, EventArgs e)
        {
            dateTimePicker_SecilenTarih.MinDate = DateTime.Now;
            DataTable dt = DbHelper.IdyeGoreGetir(gelenId);
            if (dt.Rows.Count > 0)
            {
                
                richTextBox_Mesaj.Text = dt.Rows[0]["Mesaj"].ToString();
                if (DateTime.TryParse(dt.Rows[0]["MesajTarihi"].ToString(), out DateTime result) && DateTime.Now < DateTime.MinValue)
                {
                    dateTimePicker_SecilenTarih.Value = result;
                  
                }

            }
            else
            {
                MessageBox.Show("Güncellenecek mesaj bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button_Exit1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void button_Guncelle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(richTextBox_Mesaj.Text))
            {
                DbHelper.MesajGuncelle(gelenId, dateTimePicker_SecilenTarih.Value.ToString("dd/MM/yyyy HH:mm"), richTextBox_Mesaj.Text);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Lütfen mesajınızı giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
