using System;
using tpmodul8_103082400042;

class Program
{
    static void Main(string[] args)
    {
        CovidConfig configObj = new CovidConfig();

        RunScreening(configObj);

        configObj.UbahSatuan();
        Console.WriteLine("\n--- Satuan telah diubah oleh sistem ---");
        RunScreening(configObj);
    }

    static void RunScreening(CovidConfig c)
    {
        Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {c.conf.satuan_suhu}: ");
        double suhu = double.Parse(Console.ReadLine());

        Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
        int hariGejala = int.Parse(Console.ReadLine());

        bool cekSuhu = false;
        if (c.conf.satuan_suhu == "celcius")
            cekSuhu = (suhu >= 36.5 && suhu <= 37.5);
        else
            cekSuhu = (suhu >= 97.7 && suhu <= 99.5);

        bool cekHari = hariGejala < c.conf.batas_hari_demam;

        if (cekSuhu && cekHari)
            Console.WriteLine(c.conf.pesan_diterima);
        else
            Console.WriteLine(c.conf.pesan_ditolak);
    }
}