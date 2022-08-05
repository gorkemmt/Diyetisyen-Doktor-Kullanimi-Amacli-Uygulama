﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.OleDb;
using System.Windows.Forms;

namespace yzmmimariproje_v1.sınıflar
{
    class Glutensiz : IDiyet
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=diyetdatabase.accdb");



        public bool DiyetAta(string kimliknosu)
        {
            return GlutensizAta(kimliknosu);
        }

        private bool GlutensizAta(string kimliknosu)
        {

            baglanti.Open();

            OleDbCommand sorgu = new OleDbCommand("update kullanicilar set diyetturu='Glutensiz Beslenme' where kimlikno='" + kimliknosu + "'", baglanti);
            sorgu.ExecuteNonQuery();


            MessageBox.Show("Glutensiz Beslenme diyeti hastaya uygulandı");


            baglanti.Close();
            return true;
        }
    }
}
