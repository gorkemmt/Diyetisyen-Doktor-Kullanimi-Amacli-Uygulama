using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.OleDb;
using System.Windows.Forms;

namespace yzmmimariproje_v1.sınıflar
{
    public class Cölyak : IHastalik
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=diyetdatabase.accdb");

        

        public bool HastalikAta(string kimliknosu)
        {
            return CölyakAta(kimliknosu);
        }

        private bool CölyakAta(string kimliknosu)
        {

            baglanti.Open();

            OleDbCommand sorgu = new OleDbCommand("update kullanicilar set hastalik='çölyak' where kimlikno='" + kimliknosu + "'", baglanti);
            sorgu.ExecuteNonQuery();


            MessageBox.Show("çölyak hastalığı kişiye Atandı");
            

            baglanti.Close();
            return true;
        }
    }
}
