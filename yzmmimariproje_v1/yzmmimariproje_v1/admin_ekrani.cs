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
    public partial class admin_ekrani : Form
    {
        public admin_ekrani()
        {
            InitializeComponent();
        }

        OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=diyetdatabase.accdb");        //Veritabanı dosya yolunu oluşturdurk

        public static string kullaniciadi, parola, yetki;        //formlar arası veri aktarımında kullanılan değişkenler oluştu

        private void admin_ekrani_Load(object sender, EventArgs e)
        {
            doktorkimlikal.MaxLength = 11;
            doktortelal.MaxLength = 11;
            kullanici_goster();
            admindgw.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void kayit_sayfa_temizle()        //Gerektiğinde kullanmak için kayıt olma sayfasını temizleyen fonksiyon oluşturuldu
        {
            doktorkimlikal.Clear();
            doktoradal.Clear();
            doktorsoyadal.Clear();
            doktorsifreal.Clear();
            doktortelal.Clear();

        }

        private void kullanici_goster()         // KULLANICI LİSTESİ SAYFASINDA KULLANICI BİLGİLERİNİ GÖSTERMEMİZE YARAYAN FONKSİYON
        {

            baglantim.Open();

            OleDbDataAdapter kullanici_listele = new OleDbDataAdapter("select kimlikno AS [TC KİMLİK NO],ad AS [ADI],soyad AS [SOYADI],parola AS [PAROLA],yetki AS [YETKİ],telefon AS [TELEFON NO],hastalik AS [HASTALIĞI],diyetturu AS [Diyeti],boy AS [BOY],kilo AS [KİLO] from kullanicilar Order By ad ASC", baglantim);    //kullanicilar tablosundan bilgileri çektik

            DataSet dsbellek = new DataSet();  //bellek alanı ayırdık

            kullanici_listele.Fill(dsbellek);  //alanı doldurduk 

            admindgw.DataSource = dsbellek.Tables[0];  //dgw nin bilgi alacağı yeri bellekte ayırdığımız dsbellek yeri olarak gösterdik orada ki 0.tabloyu sectik

            baglantim.Close();

        }

        private void cikisbuton_Click(object sender, EventArgs e)
        {
            cikis_fonk();
        }

        private void cikis_fonk()       //ÇIKIŞ FONKSİYONU
        {
            this.Hide();
            Form1 girisform = new Form1();
            girisform.Show();
        }

        private void userkayitbuton_Click(object sender, EventArgs e)
        {
            bool kayitkontrol = false;

            baglantim.Open();
            OleDbCommand selectsorgu = new OleDbCommand("select * from kullanicilar where kimlikno='" + doktorkimlikal.Text + "'", baglantim);  //veritabanından tc kimliği ile uyuşan bilgileri getirdik ve admin kullanıcısının göreceği KULLANICILAR sayfasına yazdırdık
            OleDbDataReader kayitoku = selectsorgu.ExecuteReader();  // gelen bilgiler geçici olarak bellekte datareader da saklanacak->select sorgusunun sonucları burada tutuldu

            while (kayitoku.Read())
            {
                kayitkontrol = true;  //zaten sisteme üye bir kullanıcıya rastlarsa kayıtkontrol değişkeni true cevirdik
                break;
            }

            baglantim.Close();

            if (kayitkontrol == false)   //yeni kullanıcı ise aşağıdaki işlemler gerçekleşecek
            {

                if (doktorkimlikal.Text != "" && doktoradal.Text != "" && doktorsoyadal.Text != "" && doktorsifreal.Text != "" )  //kayıt bilgilerinin eksik girilmemesi için kontrol ettirdik
                {
                    yetki = "diyetisyen";
                    string bos = "boş";

                    baglantim.Open();
                    OleDbCommand ekledata = new OleDbCommand("insert into kullanicilar values ('" + doktorkimlikal.Text + "','" + doktoradal.Text + "','" + doktorsoyadal.Text + "','" + doktorsifreal.Text + "','" + yetki + "','" + doktortelal.Text + "','" + bos + "','" + bos + "','" + bos + "','" + bos + "')", baglantim);  //insert ile kullanıcılar tablosuna yeni kullanıcımızı eklettik.
                    ekledata.ExecuteNonQuery(); //ekle komutu isimli sorgunun sonuclarını access e  işlettik
                    baglantim.Close();

                    MessageBox.Show("kullanıcı kaydı oluşturuldu");

                        
                    kayit_sayfa_temizle();
                    kullanici_goster();
                }
                else
                {
                    MessageBox.Show("eksik bilgi girişiyaptınız formu kontrol ediniz");   //eksik bilgi girişinde kullanıcıya uyarı gösterdik
                }

            }
            else
            {
                MessageBox.Show("bu kullanıcı adı zaten kayıtlı kullanıcı oluşturulamadı");   //zaten kayıtlı bir kullanıcının bilgisi kullanılmışşsa uyarı verdik
            }
        }
    }
}
