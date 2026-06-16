using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaCombatSimulator
{
    enum KarakterRolleri { Attacker, Defender, Runner };
    struct Konum
    {
        public int x;
        public int y;
    }
    static class OyunMotoru
    {
        public const string Surum = "v1.0";
        public static int ToplamKarakterSayısı = 0;
    }
    class Karakter
    {
        public readonly string Isım;
        public KarakterRolleri Rol;
        public Konum MevcutKonum;
        private int _can;
        public int Can
        {
            get
            {
                return _can;
            }
            set
            {
                if (value <= 0)
                    _can = 0;
                else if (value >= 100)
                    _can = 100;
                else
                    _can = value;
            }
        }
        public Karakter(string isim, KarakterRolleri rol, Konum BaslangıcKonumu)
        {
            Can = 100;
            Isım = isim;
            Rol = rol;
            MevcutKonum = BaslangıcKonumu;
            OyunMotoru.ToplamKarakterSayısı++;
        }
        public static bool operator true(Karakter c)
        {
            return c._can > 0;
        }
        public static bool operator false(Karakter c)
        {
            return c._can <= 0;
        }
        public static bool operator >(Karakter a, Karakter b)
        {
            return a._can > b._can;
        }
        public static bool operator <(Karakter a, Karakter b)
        {
            return a._can < b._can;
        }
        public static explicit operator string(Karakter c)
        {
            return c.Isım;
        }
    }
    class Takim
    {
        private Karakter[] Kadro = new Karakter[3];
        public Karakter this[int index]
        {
            get
            {
                return Kadro[index];
            }
            set
            {
                Kadro[index] = value;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Takim BenimTakim = new Takim();
            Karakter k1 = new Karakter("Kuzan", KarakterRolleri.Defender, new Konum { x = 10, y = 20 });
            Karakter k2 = new Karakter("Roger", KarakterRolleri.Attacker, new Konum { x = 30, y = 40 });
            k2.Can = 50;
            BenimTakim[0] = k1;
            BenimTakim[1] = k2;
            Console.WriteLine((string)k1);
            if (BenimTakim[0])
            {
                Console.WriteLine("Karakter savaşa hazır.");
            }
            if (BenimTakim[0] > BenimTakim[1])
            {
                Console.WriteLine("Kuzan daha dayanıklı.");
            }
            Console.WriteLine(OyunMotoru.ToplamKarakterSayısı);
        }
    }
}
