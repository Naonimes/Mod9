using System;

class Program
{
    static void Main(string[] args)
    {
        
        CovidConfig covidConfig = new CovidConfig();

        
        Console.WriteLine($"Berapa suhu badan anda saat ini? Dalam nilai {covidConfig.config.satuan_suhu}");
        double suhu = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala deman?");
        int hari = Convert.ToInt32(Console.ReadLine());

        
        bool kondisiSuhu = false;
        if (covidConfig.config.satuan_suhu == "celcius")
        {
            if (suhu >= 36.5 && suhu <= 37.5) kondisiSuhu = true;
        }
        else if (covidConfig.config.satuan_suhu == "fahrenheit")
        {
            if (suhu >= 97.7 && suhu <= 99.5) kondisiSuhu = true;
        }

        bool kondisiHari = hari < covidConfig.config.batas_hari_deman;

        
        if (kondisiSuhu && kondisiHari)
        {
            Console.WriteLine(covidConfig.config.pesan_diterima);
        }
        else
        {
            Console.WriteLine(covidConfig.config.pesan_ditolak);
        }

        
        covidConfig.UbahSatuan();
    }
}