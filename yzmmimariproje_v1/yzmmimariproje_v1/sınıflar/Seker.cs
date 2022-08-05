using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.OleDb;
using System.Windows.Forms;

namespace yzmmimariproje_v1.sınıflar
{
    class Seker : IHastalik
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=diyetdatabase.accdb");



        public bool HastalikAta(string kimliknosu)
        {
            return SekerAta(kimliknosu);
        }

        private bool SekerAta(string kimliknosu)
        {

            baglanti.Open();

            OleDbCommand sorgu = new OleDbCommand("update kullanicilar set hastalik='şeker' where kimlikno='" + kimliknosu + "'", baglanti);
            sorgu.ExecuteNonQuery();


            MessageBox.Show("şeker hastalığı kişiye Atandı");


            baglanti.Close();
            return true;
        }
    }
}
