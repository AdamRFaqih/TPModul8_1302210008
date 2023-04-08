using System;
namespace TPModul8_1302210008
{
    public class Program
    {
        public static void Main()
        {
            AppConfig app = new AppConfig();
            try
            {
                app.readConfig();
            }
            catch
            {
                app.setDefault();
                app.writeConfig();
                app.readConfig();
            }
            app.ubahSatuanSuhu();
            Console.WriteLine($"Berapa suhu badan anda saat ini? Dalam nilai {app.covidConfig.satuan_suhu}");
            double input1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam?");
            int input2 = Convert.ToInt32(Console.ReadLine());
            if ((input1 >= 36.5 && input1 < 37.5 && app.covidConfig.satuan_suhu == "celcius") || (input1 >= 97.7 && input1 < 99.5))
            {
                Console.WriteLine(app.covidConfig.pesan_diterima);
                return;
            }
            else if (input2 > app.covidConfig.batas_hari_demam)
            {
                Console.WriteLine(app.covidConfig.pesan_diterima);
                return;
            }
            Console.WriteLine(app.covidConfig.pesan_ditolak);
        }
    }
}