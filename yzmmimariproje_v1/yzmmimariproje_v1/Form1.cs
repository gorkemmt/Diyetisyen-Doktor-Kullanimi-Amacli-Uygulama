using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.OleDb;        //Veritabanı kullanabilmek için OLEDB kütüphanesini ekliyoruz
using System.IO;        //giriş çıkış işlemleri için İO kütüphanesini ekledik

namespace yzmmimariproje_v1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=diyetdatabase.accdb");        //Veritabanı dosya yolunu oluşturdurk

        public static string kimlikno, parola, yetki;        //formlar arası veri aktarımında kullanılan değişkenler oluştu

        private void button1_Click(object sender, EventArgs e)
        {

            bool durum = false;

            baglantim.Open();        //bağlantıyı oluşturduk
            OleDbCommand selectsorgu = new OleDbCommand("select * from kullanicilar", baglantim);          //veritabanında bulundan kullanicilar tablosunun bilgilerini çektik
            OleDbDataReader kayitoku = selectsorgu.ExecuteReader();          // gelen bilgiler geçici olarak bellekte datareader da saklanacak

            while (kayitoku.Read())
            {
                if (adminradiobuton.Checked == true)         //hangi türde kullanıcı girişi yapılacağını if yapısı ve radiobuton sayesinde ayırdık
                {
                    if (kayitoku["kimlikno"].ToString() == giriskimlik.Text && kayitoku["parola"].ToString() == girisparola.Text && kayitoku["yetki"].ToString() == "admin")         //veritabanından çekilen bilgiler ile giriş ekranındaki bilgilerin doğruluğu kontrol edildi
                    {
                        durum = true;

                        kimlikno = kayitoku.GetValue(0).ToString();
                        parola = kayitoku.GetValue(3).ToString();
                        yetki = kayitoku.GetValue(4).ToString();

                        this.Hide();
                        admin_ekrani adminform = new admin_ekrani();   //bilgiler doğruluğunda giriş sayfası gizlendi ve admin ekranı açılması sağlandı
                        adminform.Show();
                        break;
                    }
                }

                if (diyetisyenradiobuton.Checked == true)
                {
                    if (kayitoku["kimlikno"].ToString() == giriskimlik.Text && kayitoku["parola"].ToString() == girisparola.Text && kayitoku["yetki"].ToString() == "diyetisyen")
                    {
                        durum = true;

                        kimlikno = kayitoku.GetValue(0).ToString();
                        parola = kayitoku.GetValue(3).ToString();
                        yetki = kayitoku.GetValue(4).ToString();

                        this.Hide();
                        diyetisyen_ekrani userform = new diyetisyen_ekrani();         //bilgiler doğruluğunda giriş sayfası gizlendi ve kullanıcı ekranı açılması sağlandı
                        userform.Show();
                        break;
                    }
                }

            }
            if (durum == false)         //bilgilerin yanlış girilmesi durumunda kullanıcıya bir uyarı verildi 
            {
                MessageBox.Show("hatalı giriş oturum açılamadı");
            }

            baglantim.Close();



        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.AcceptButton = girisyap;
            giriskimlik.MaxLength = 11;
        }
    }
}
