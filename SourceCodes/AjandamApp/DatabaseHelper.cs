using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AjandamApp
{
    class DatabaseHelper
    {
        private OleDbConnection connection;
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\AjandamAppDb1.mdb";

        public DatabaseHelper()
        {
            connection = new OleDbConnection(connectionString);
        }

        //Tüm ajanda kayıtlarını listele
        public DataTable Listele() 
        { 
            DataTable dataTable = new DataTable();
            string query = "SELECT * FROM Ajanda";
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
            adapter.Fill(dataTable);
            return dataTable;
        }

        private void ExcecuteQuery(OleDbCommand command)
        {
            try
            {
                if (connection.State == ConnectionState.Closed) {
                    connection.Open();
                }
                
                command.ExecuteNonQuery();
                MessageBox.Show("İşlem Başarılı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {

               MessageBox.Show($"Hata oluştu. Lütfen tekrar deneyin.{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

        }

        //Ajanda tablosuna yeni mesaj ekle
        public void MesajEkle(string mesajTarihi, string metin) 
        {
            string query = "INSERT INTO Ajanda (Mesaj,MesajTarihi) VALUES (@mesaj,@mesajTarihi)";
            OleDbCommand command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("@mesaj", metin);
            command.Parameters.AddWithValue("@mesajTarihi", mesajTarihi);
            ExcecuteQuery(command);

        }

        //Id ye göre notları FormGuncelleye getirir
        public DataTable IdyeGoreGetir(int gelenId) { 
            DataTable dataTable = new DataTable();
            string query = "SELECT * FROM Ajanda WHERE Id=@id";
            using (OleDbCommand command = new OleDbCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", gelenId);
                connection.Open();
                OleDbDataAdapter da = new OleDbDataAdapter(command);
                da.Fill(dataTable);
            }
            return dataTable;
        }

        //Güncelleme işlemi
        public void MesajGuncelle(int id, string mesajTarihi, string metin)
        {
            string query = "UPDATE Ajanda SET  mesaj = @metin, mesajTarihi = @mesajTarihi WHERE Id = @id";
            OleDbCommand command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("@mesaj", metin);
            command.Parameters.AddWithValue("@mesajTarihi", mesajTarihi);
            command.Parameters.AddWithValue("@id", id);
            ExcecuteQuery(command);
        }
        //Silme işlemi
        public void MesajSil(int id) {
            string query = "DELETE FROM Ajanda WHERE Id = @id";
            OleDbCommand command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            ExcecuteQuery(command);
        }

        //Tablodaki tüm Tarihleri Liste haline getir.
        public List<DateTime> TumNotTarihleriniGetir() {
            List<DateTime> tarihListesi = new List<DateTime>();
            string query = "SELECT MesajTarihi FROM Ajanda";
            using (OleDbCommand command = new OleDbCommand(query,connection))
            {
                connection.Open();
                using (OleDbDataReader reader = command.ExecuteReader()) 
                {
                    while (reader.Read()) 
                    {
                        if (reader["Mesajtarihi"] != DBNull.Value && DateTime.TryParse(reader["MesajTarihi"].ToString(),out DateTime dbTarih))
                        {
                            tarihListesi.Add(dbTarih);
                        }
                    }
                }
                connection.Close();
            }
                return tarihListesi;
        }

        //Belirli tariher ait mesajları getirir
        public string MesajiGetir(DateTime mesajTarihi) 
        {
            string query = "SELECT Mesaj FROM Ajanda WHERE MesajTarihi = @mesajTarihi";
            string mesaj = string.Empty;
            using (OleDbCommand command = new OleDbCommand(query, connection))
            {
                command.Parameters.AddWithValue("@mesajTarihi", mesajTarihi);
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    mesaj = result.ToString();
                }
            }
            return mesaj;

        }

        //Not sil
        public void NotSil(int id = int.MinValue, int durum = 0, DateTime? tarih = null ) 
        {
            if (durum == 0)
            {
                string query = "DELETE FROM Ajanda WHERE Id = @id";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                ExcecuteQuery(command);
            }
            else if (durum == 1)
            {
                string query = "DELETE FROM Ajanda WHERE MesajTarihi = @mesajTarihi";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("@mesajTarihi", tarih);
                ExcecuteQuery(command);

            }
        }
    }
}
