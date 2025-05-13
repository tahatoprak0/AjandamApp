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
    public partial class FormEkle: Form
    {

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        DatabaseHelper dbHelper = new DatabaseHelper();

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public FormEkle()
        {
            InitializeComponent();
        }

        private void button_Exit1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button_Ekle_Click(object sender, EventArgs e)
        {
            dateTimePicker_SecilenTarih.MinDate = DateTime.Now;
            if (!string.IsNullOrEmpty(richTextBox_Mesaj.Text))
            {
                try
                {
                    dbHelper.MesajEkle(dateTimePicker_SecilenTarih.Value.ToString("dd/MM/yyyy HH:mm"), richTextBox_Mesaj.Text);
                    this.Hide();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata oluştu. Lütfen tekrar deneyin.{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
               

            }
            else { 
            MessageBox.Show("Lütfen mesajınızı giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
        }

        private void FormEkle_Load(object sender, EventArgs e)
        {
            dateTimePicker_SecilenTarih.MinDate = DateTime.Now;
        }
    }
}
