using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yzmmimariproje_v1.sınıflar
{
    public class DiyetFabrika
    {
        public IDiyet DiyetNesnesiOlustur(string hastalikTipi)
        {
            if (hastalikTipi == "Akdeniz Diyeti")
            {
                return new Akdeniz();
            }
            else if (hastalikTipi == "Glutensiz Beslenme Diyeti")
            {
                return new Glutensiz();
            }
            else if (hastalikTipi == "Deniz Ürünleri Diyeti")
            {
                return new Denizurunu();
            }
            else if (hastalikTipi == "Yeşillikler Dünyası Diyeti")
            {
                return new Yesillik();
            }
            else return null;
        }
    }
}
