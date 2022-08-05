using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.OleDb;   //veritabanı için kütüphane ekliyoruz
using System.IO;

namespace yzmmimariproje_v1
{
    public partial class diyetisyen_ekrani : Form
    {
        public diyetisyen_ekrani()
        {
            InitializeComponent();
        }

        OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=diyetdatabase.accdb");        //Veritabanı dosya yolunu oluşturdurk

        public static string kullaniciadi, parola, yetki;        //formlar arası veri aktarımında kullanılan değişkenler oluştu

        private void diyetisyen_Load(object sender, EventArgs e)
        {
            
            hastahastalikal.Items.Add("çölyak");
            hastahastalikal.Items.Add("obezite");
            hastahastalikal.Items.Add("şeker");

            diyetatacmmbox.Items.Add("Akdeniz Diyeti");
            diyetatacmmbox.Items.Add("Glutensiz Beslenme Diyeti");
            diyetatacmmbox.Items.Add("Deniz Ürünleri Diyeti");
            diyetatacmmbox.Items.Add("Yeşillikler Dünyası Diyeti");

            diyetduzenlecmb.Items.Add("akdeniz");
            diyetduzenlecmb.Items.Add("glutensiz");
            diyetduzenlecmb.Items.Add("denizurunu");
            diyetduzenlecmb.Items.Add("yesillik");

            hastalikatacombobox.Items.Add("çölyak");
            hastalikatacombobox.Items.Add("şeker");
            hastalikatacombobox.Items.Add("obezite");

            bilgilabel.Text = "TC: "+Form1.kimlikno;

            dosyabicimi.Items.Add("JSON");
            dosyabicimi.Items.Add("HTML");

            hastakimlikal.MaxLength = 11;
            hastatelal.MaxLength = 11;

            Hasta_goster();
        }

        private void cikis_fonk()       //ÇIKIŞ FONKSİYONU
        {
            this.Hide();
            Form1 girisform = new Form1();
            girisform.Show();
        }

        private void kayit_sayfa_temizle()        //Gerektiğinde kullanmak için kayıt olma sayfasını temizleyen fonksiyon oluşturuldu
        {
            hastakimlikal.Clear();
            hastaadal.Clear();
            hastasoyadal.Clear(); 
            hastaboyal.Clear();
            hastakiloal.Clear();
            hastasifreal.Clear();
            hastatelal.Clear();
            hastahastalikal.Text = "--Seçiniz--";

        }

        private void Diyet_Getir(string diyetadi)
        {

            string kahvalti, oglen, aksam;
 
            baglantim.Open();
 
                kahvalti = "select * from "+diyetadi+" where yemeksaati='kahvaltı'";
                oglen = "select * from " + diyetadi + " where yemeksaati='öğlen yemeği'";
                aksam = "select * from " + diyetadi + " where yemeksaati='akşam yemeği'";

                OleDbCommand kahvaltisorgu = new OleDbCommand(kahvalti, baglantim);       
                OleDbDataReader kayitoku1 = kahvaltisorgu.ExecuteReader();
                kayitoku1.Read();

                kahvaltipazartesi.Text = kayitoku1.GetValue(1).ToString();
                kahvaltisali.Text = kayitoku1.GetValue(2).ToString();
                kahvalticarsamba.Text = kayitoku1.GetValue(3).ToString();
                kahvaltipersembe.Text = kayitoku1.GetValue(4).ToString();
                kahvalticuma.Text = kayitoku1.GetValue(5).ToString();
                kahvalticumartesi.Text = kayitoku1.GetValue(6).ToString();
                kahvaltipazar.Text = kayitoku1.GetValue(7).ToString();

                OleDbCommand oglensorgu = new OleDbCommand(oglen, baglantim);       
                OleDbDataReader kayitoku2 = oglensorgu.ExecuteReader();
                kayitoku2.Read();

                oglenpazartesi.Text = kayitoku2.GetValue(1).ToString();
                oglensali.Text = kayitoku2.GetValue(2).ToString();
                oglencarsamba.Text = kayitoku2.GetValue(3).ToString();
                oglenpersembe.Text = kayitoku2.GetValue(4).ToString();
                oglencuma.Text = kayitoku2.GetValue(5).ToString();
                oglencumartesi.Text = kayitoku2.GetValue(6).ToString();
                oglenpazar.Text = kayitoku2.GetValue(7).ToString();

                OleDbCommand aksamsorgu = new OleDbCommand(aksam, baglantim);       
                OleDbDataReader kayitoku3 = aksamsorgu.ExecuteReader();
                kayitoku3.Read();

                aksampazartesi.Text = kayitoku3.GetValue(1).ToString();
                aksamsali.Text = kayitoku3.GetValue(2).ToString();
                aksamcarsamba.Text = kayitoku3.GetValue(3).ToString();
                aksampersembe.Text = kayitoku3.GetValue(4).ToString();
                aksamcuma.Text = kayitoku3.GetValue(5).ToString();
                aksamcumartesi.Text = kayitoku3.GetValue(6).ToString();
                aksampazar.Text = kayitoku3.GetValue(7).ToString();

            MessageBox.Show(diyetadi+" diyeti ekrana getirildi");
            baglantim.Close();

        }
        
        private void button4_Click(object sender, EventArgs e)  //hastalık atama butonu
        {
            string hastakimlik;

            hastakimlik=hastalardgw.CurrentRow.Cells[0].Value.ToString();

            sınıflar.HastaFabrikasi hastafabrika = new sınıflar.HastaFabrikasi();
            sınıflar.IHastalik hastalik = hastafabrika.HastalikNesnesiOlustur(hastalikatacombobox.Text);
            hastalik.HastalikAta(hastakimlik);

            Hasta_goster();
        }

        private void diyetatabuton_Click(object sender, EventArgs e)
        {
            string hastakimlik;

            hastakimlik = hastalardgw.CurrentRow.Cells[0].Value.ToString();

            sınıflar.DiyetFabrika diyetfabrika = new sınıflar.DiyetFabrika();
            sınıflar.IDiyet diyet = diyetfabrika.DiyetNesnesiOlustur(diyetatacmmbox.Text);
            diyet.DiyetAta(hastakimlik);

            Hasta_goster();
        }

        private void diyetduzenlecmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            Diyet_Getir(diyetduzenlecmb.Text);
        }

        private void diyetdegisiklikbuton_Click(object sender, EventArgs e)
        {
            baglantim.Open();

            string kahvalti,ogle,aksam;

            kahvalti = "update " + diyetduzenlecmb.Text + " set pazartesi='" + kahvaltipazartesi.Text + "',sali='" + kahvaltisali.Text + "',carsamba='" + kahvalticarsamba.Text + "',persembe='" + kahvaltipersembe.Text + "',cuma='" + kahvalticuma.Text + "',cumartesi='" + kahvalticumartesi.Text + "',pazar='" + kahvaltipazar.Text + "' where yemeksaati='kahvaltı'";
            ogle = "update " + diyetduzenlecmb.Text + " set pazartesi='" + oglenpazartesi.Text + "',sali='" + oglensali.Text + "',carsamba='" + oglencarsamba.Text + "',persembe='" + oglenpersembe.Text + "',cuma='" + oglencuma.Text + "',cumartesi='" + oglencumartesi.Text + "',pazar='" + oglenpazar.Text + "' where yemeksaati='öğlen yemeği'";
            aksam = "update " + diyetduzenlecmb.Text + " set pazartesi='" + aksampazartesi.Text + "',sali='" + aksamsali.Text + "',carsamba='" + aksamcarsamba.Text + "',persembe='" + aksampersembe.Text + "',cuma='" + aksamcuma.Text + "',cumartesi='" + aksamcumartesi.Text + "',pazar='" + aksampazar.Text + "' where yemeksaati='akşam yemeği'";

            OleDbCommand onaykomutu1 = new OleDbCommand(kahvalti, baglantim);
                onaykomutu1.ExecuteNonQuery();

                OleDbCommand onaykomutu2 = new OleDbCommand(ogle, baglantim);
                onaykomutu2.ExecuteNonQuery();

                OleDbCommand onaykomutu3 = new OleDbCommand(aksam, baglantim);
                onaykomutu3.ExecuteNonQuery();
            


            baglantim.Close();
            
            MessageBox.Show(diyetduzenlecmb.Text+" diyeti güncelleme işlemi başarılı");

            Diyet_Getir(diyetduzenlecmb.Text);
        }

        private void Dosyaya_Kisisel_Bilgi_Yaz(string kimlikal,string uzantial)
        {

            baglantim.Open();

            OleDbCommand kisiselsorgu = new OleDbCommand("select * from kullanicilar where kimlikno='" + kimlikal + "'", baglantim);
            OleDbDataReader kayitokurapor = kisiselsorgu.ExecuteReader();
            kayitokurapor.Read();

            string raporad, raporsoyad, raportel, raporhastalik, rapordiyet, raporboy, raporkilo,bos="   ",tre= "------------------------------------------------------------------------------------------------------------------";
            raporad = kayitokurapor.GetValue(1).ToString();
            raporsoyad = kayitokurapor.GetValue(2).ToString();
            raportel = kayitokurapor.GetValue(5).ToString();
            raporhastalik = kayitokurapor.GetValue(6).ToString();
            rapordiyet = kayitokurapor.GetValue(7).ToString();
            raporboy = kayitokurapor.GetValue(8).ToString();
            raporkilo = kayitokurapor.GetValue(9).ToString();

            string[] dizikisisel = {raporad,raporsoyad,raportel,raporhastalik,rapordiyet,raporboy,raporkilo,bos,tre,bos };

            string dosya_adi = kimlikal+"_hasta_raporu."+uzantial;
            string dosya_yolu = @"C:\Users\Görkem\Desktop\yzmmimariproje_v1\raporlar\";
            string hedef_yol = System.IO.Path.Combine(dosya_yolu, dosya_adi);

            string link = dosya_yolu+""+dosya_adi;


            if (uzantial == "json")
            {
                using (System.IO.StreamWriter dosya = new System.IO.StreamWriter(link, true))
                {
                    dosya.WriteLine("-----KİŞİSEL BİLGİLER-----");
                    dosya.WriteLine("TC KİMLİK NO= " + kimlikal);
                    dosya.WriteLine("ADI= " + dizikisisel[0]);
                    dosya.WriteLine("SOYADI= " + dizikisisel[1]);
                    dosya.WriteLine("TELEFONU= " + dizikisisel[2]);
                    dosya.WriteLine("HASTALIĞI= " + dizikisisel[3]);
                    dosya.WriteLine("DİYETİ= " + dizikisisel[4]);
                    dosya.WriteLine("BOYU= " + dizikisisel[5]);
                    dosya.WriteLine("KİLOSU= " + dizikisisel[6]);
                    dosya.WriteLine(dizikisisel[7]);
                    dosya.WriteLine(dizikisisel[8]);
                    dosya.WriteLine(dizikisisel[9]);
                }
            }
            else if (uzantial == "html")
            {
                using (System.IO.StreamWriter dosya = new System.IO.StreamWriter(link, true))
                {
                    dosya.WriteLine("<h3>-----KİŞİSEL BİLGİLER-----</h3>");
                    dosya.WriteLine("<p>TC KİMLİK NO= " + kimlikal+ "</p>");
                    dosya.WriteLine("<p>ADI= " + dizikisisel[0] + "</p>");
                    dosya.WriteLine("<p>SOYADI= " + dizikisisel[1] + "</p>");
                    dosya.WriteLine("<p>TELEFONU= " + dizikisisel[2] + "</p>");
                    dosya.WriteLine("<p>HASTALIĞI= " + dizikisisel[3] + "</p>");
                    dosya.WriteLine("<p>DİYETİ= " + dizikisisel[4] + "</p>");
                    dosya.WriteLine("<p>BOYU= " + dizikisisel[5] + "</p>");
                    dosya.WriteLine("<p>KİLOSU= " + dizikisisel[6] + "</p>");
                    dosya.WriteLine("<p>" + dizikisisel[7] + "</p>");
                    dosya.WriteLine("<p>" + dizikisisel[8] + "</p>");
                    dosya.WriteLine("<p>" + dizikisisel[9] + "</p>");
                }
            }

            baglantim.Close();
        }

        private void dosyaya_diyet_bilgi_yaz(string kimlikal, string uzantial,string diyetal)
        {

            baglantim.Open();

            string raporkahvalti, raporoglen, raporaksam,diyetver="boş";

                string dosya_adi = kimlikal + "_hasta_raporu."+uzantial;
            string dosya_yolu = @"C:\Users\Görkem\Desktop\yzmmimariproje_v1\raporlar\";
            string hedef_yol = System.IO.Path.Combine(dosya_yolu, dosya_adi);
      
            string link = dosya_yolu + "" + dosya_adi;

            if (diyetal == "Akdeniz") { diyetver = "akdeniz"; }
            else if (diyetal == "Yeşillikler Dünyası") { diyetver = "yesillik"; }
            else if (diyetal == "Deniz ürünleri") { diyetver = "denizurunu"; }
            else if (diyetal == "Glutensiz Beslenme") { diyetver = "glutensiz"; }
            

            raporkahvalti = "select * from "+ diyetver + " where yemeksaati='kahvaltı'";
            raporoglen = "select * from "+ diyetver + " where yemeksaati='öğlen yemeği'";
            raporaksam = "select * from " + diyetver + " where yemeksaati='akşam yemeği'";


            OleDbCommand kahvatisorgu = new OleDbCommand(raporkahvalti, baglantim);
            OleDbDataReader kayitokurapor1 = kahvatisorgu.ExecuteReader();
            kayitokurapor1.Read();

            string kahvaltiyaz ="KAHVALTI = pazartesi="+kayitokurapor1.GetValue(1).ToString()+", sali="+ kayitokurapor1.GetValue(2).ToString() + ", çarşamba=" + kayitokurapor1.GetValue(3).ToString() + ", perşembe=" + kayitokurapor1.GetValue(4).ToString() + ", cuma=" + kayitokurapor1.GetValue(5).ToString() + ", cumartesi=" + kayitokurapor1.GetValue(6).ToString() + ", pazar=" + kayitokurapor1.GetValue(7).ToString();


            OleDbCommand oglensorgu = new OleDbCommand(raporoglen, baglantim);
            OleDbDataReader kayitokurapor2 = oglensorgu.ExecuteReader();
            kayitokurapor2.Read();

            string oglenyaz = "ÖĞLEN = pazartesi=" + kayitokurapor2.GetValue(1).ToString() + ", sali=" + kayitokurapor2.GetValue(2).ToString() + ", çarşamba=" + kayitokurapor2.GetValue(3).ToString() + ", perşembe=" + kayitokurapor2.GetValue(4).ToString() + ", cuma=" + kayitokurapor2.GetValue(5).ToString() + ", cumartesi=" + kayitokurapor2.GetValue(6).ToString() + ", pazar=" + kayitokurapor2.GetValue(7).ToString();

            OleDbCommand aksamsorgu = new OleDbCommand(raporaksam, baglantim);
            OleDbDataReader kayitokurapor3 = aksamsorgu.ExecuteReader();
            kayitokurapor3.Read();

            string aksamyaz = "AKŞAM = pazartesi=" + kayitokurapor3.GetValue(1).ToString() + ", sali=" + kayitokurapor3.GetValue(2).ToString() + ", çarşamba=" + kayitokurapor3.GetValue(3).ToString() + ", perşembe=" + kayitokurapor3.GetValue(4).ToString() + ", cuma=" + kayitokurapor3.GetValue(5).ToString() + ", cumartesi=" + kayitokurapor3.GetValue(6).ToString() + ", pazar=" + kayitokurapor3.GetValue(7).ToString();


            if (uzantial == "json")
            {
                using (System.IO.StreamWriter dosya2 = new System.IO.StreamWriter(link, true)) {
                dosya2.WriteLine("-----DİYET BİLGİLERİ-----");
                dosya2.WriteLine(kahvaltiyaz);
                dosya2.WriteLine(oglenyaz);
                dosya2.WriteLine(aksamyaz);
                dosya2.WriteLine(" ");
                dosya2.WriteLine("------------------------------------------------------------------------------------------------------------------");
                dosya2.WriteLine(" ");
                }
            }
            else if (uzantial=="html")
            {
                using (System.IO.StreamWriter dosya2 = new System.IO.StreamWriter(link, true))
                {
                    dosya2.WriteLine("<h3>-----DİYET BİLGİLERİ-----</h3>");
                    dosya2.WriteLine("<p>"+kahvaltiyaz+ "</p>");
                    dosya2.WriteLine("<p>" + oglenyaz+ "</p>");
                    dosya2.WriteLine("<p>" + aksamyaz+ "</p>");
                    dosya2.WriteLine("<p> </p>");
                    dosya2.WriteLine("<p>------------------------------------------------------------------------------------------------------------------</p>");
                    dosya2.WriteLine("<p> </p>");
                }
            }

            baglantim.Close();

        }
        private void raporolustur_Click(object sender, EventArgs e)
        {

            string raporkimlik = hastalardgw.CurrentRow.Cells[0].Value.ToString();
            string diyetgonder = hastalardgw.CurrentRow.Cells[4].Value.ToString();
            string dosyatur;


            if (dosyabicimi.Text == "JSON")
            {
                dosyatur = "json";
            }
            else
            {
                dosyatur = "html";
            }


            string dosya_adi = raporkimlik + "_hasta_raporu." + dosyatur;
            string dosya_yolu = @"C:\Users\Görkem\Desktop\yzmmimariproje_v1\raporlar\";
            string hedef_yol = System.IO.Path.Combine(dosya_yolu, dosya_adi);

            string link = dosya_yolu + "" + dosya_adi;
            if (System.IO.File.Exists(link))
            {
                System.IO.File.Delete(link);
                System.IO.File.Create(hedef_yol).Close();
            }
            else
            {
                System.IO.File.Create(hedef_yol).Close();
            }

            if (raporsecenek1.Checked)
            {

                Dosyaya_Kisisel_Bilgi_Yaz(raporkimlik, dosyatur);
                dosyaya_diyet_bilgi_yaz(raporkimlik, dosyatur, diyetgonder);

                MessageBox.Show("rapor dosyası oluştu");

            }
            else if (raporsecenek2.Checked)
            {

                dosyaya_diyet_bilgi_yaz(raporkimlik, dosyatur, diyetgonder);
                Dosyaya_Kisisel_Bilgi_Yaz(raporkimlik, dosyatur);

                MessageBox.Show("rapor dosyası oluştu");
            }

        }

        private void cikisbuton_Click(object sender, EventArgs e)
        {
            cikis_fonk();
        }

        private void Hasta_goster()         // diyetisyen hesabında oturum acınca hastaları görmemiz için kayıtları getiren fonksiyon
        {

            baglantim.Open();

            OleDbDataAdapter kullanici_listele = new OleDbDataAdapter("select kimlikno AS [TC KİMLİK NO],ad AS [ADI],soyad AS [SOYADI],hastalik AS [HASTALIĞI],diyetturu AS [Diyeti],boy AS [BOY],kilo AS [KİLO] from kullanicilar where yetki='hasta' Order By ad ASC", baglantim);    //kullanicilar tablosundan bilgileri çektik

            DataSet dsbellek = new DataSet();  //bellek alanı ayırdık

            kullanici_listele.Fill(dsbellek);  //alanı doldurduk 

            hastalardgw.DataSource = dsbellek.Tables[0];  //dgw nin bilgi alacağı yeri bellekte ayırdığımız dsbellek yeri olarak gösterdik orada ki 0.tabloyu sectik
            rapordgw.DataSource = dsbellek.Tables[0];
            baglantim.Close();

        }

        private void userkayitbuton_Click(object sender, EventArgs e)
        {
            bool kayitkontrol = false;

            baglantim.Open();
            OleDbCommand selectsorgu = new OleDbCommand("select * from kullanicilar where kimlikno='" + hastakimlikal.Text + "'", baglantim);  //veritabanından tc kimliği ile uyuşan bilgileri getirdik ve admin kullanıcısının göreceği KULLANICILAR sayfasına yazdırdık
            OleDbDataReader kayitoku = selectsorgu.ExecuteReader();  // gelen bilgiler geçici olarak bellekte datareader da saklanacak->select sorgusunun sonucları burada tutuldu

            while (kayitoku.Read())
            {
                kayitkontrol = true;  //zaten sisteme üye bir kullanıcıya rastlarsa kayıtkontrol değişkeni true cevirdik
                break;
            }

            baglantim.Close();

            if (kayitkontrol == false)   //yeni kullanıcı ise aşağıdaki işlemler gerçekleşecek
            {

                if (hastakimlikal.Text != "" && hastaadal.Text != "" && hastasoyadal.Text != "" && hastasifreal.Text != "" && hastaboyal.Text != "" && hastakiloal.Text != "")  //kayıt bilgilerinin eksik girilmemesi için kontrol ettirdik
                {
                    yetki = "hasta";
                    string bos = "bos";

                    baglantim.Open();
                    OleDbCommand ekledata = new OleDbCommand("insert into kullanicilar values ('" + hastakimlikal.Text + "','" + hastaadal.Text + "','" + hastasoyadal.Text + "','" + hastasifreal.Text + "','" + yetki + "','" + hastatelal.Text + "','" + hastahastalikal.SelectedItem + "','" + bos+ "','" + hastaboyal.Text + "','" + hastakiloal.Text + "')", baglantim);  //insert ile kullanıcılar tablosuna yeni kullanıcımızı eklettik.
                    ekledata.ExecuteNonQuery(); //ekle komutu isimli sorgunun sonuclarını access e  işlettik
                    baglantim.Close();

                    MessageBox.Show("Hasta kaydı oluşturuldu");


                    kayit_sayfa_temizle();
                    Hasta_goster();
                }
                else
                {
                    MessageBox.Show("eksik bilgi girişiyaptınız formu kontrol ediniz");   //eksik bilgi girişinde kullanıcıya uyarı gösterdik
                }

            }
            else
            {
                MessageBox.Show("bu kimlik no zaten kayıtlı kullanıcı oluşturulamadı");   //zaten kayıtlı bir kullanıcının bilgisi kullanılmışşsa uyarı verdik
            }
        }
    }
}
