using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yzmmimariproje_v1.sınıflar
{
    public class HastaFabrikasi
    {
        public IHastalik HastalikNesnesiOlustur(string hastalikTipi)
        {
            if (hastalikTipi == "obezite")
            {
                return new Obezite();
            }
            else if (hastalikTipi == "çölyak")
            {
                return new Cölyak();
            }
            else if (hastalikTipi == "şeker")
            {
                return new Seker();
            }
            else return null;
        }
    }
}
