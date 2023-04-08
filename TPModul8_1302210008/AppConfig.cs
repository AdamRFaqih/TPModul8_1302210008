using System;
using System.Text.Json;
namespace TPModul8_1302210008
{
	public class AppConfig
	{
		public CovidConfig covidConfig;
		public AppConfig()
		{
		}

		public void readConfig()
		{
			string text = File.ReadAllText(@"./covid_config.json");
			covidConfig = JsonSerializer.Deserialize<CovidConfig>(text);
		}

		public void setDefault()
		{
			covidConfig = new CovidConfig("celcius", 14, "Anda tidak diperbolehkan masuk kedalam gedung ini", "Anda dipersilahkan masuk kedalam gedung ini");
            
        }
		public void writeConfig()
		{
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(covidConfig, options);
            File.WriteAllText(@"./covid_config.json", jsonString);
        }
		public void ubahSatuanSuhu()
		{
			if (covidConfig.satuan_suhu == "celcius")
			{
				covidConfig.satuan_suhu = "fahreinheit";
				writeConfig();
				return;
			}
            covidConfig.satuan_suhu = "celcius";
            writeConfig();
        }
    }
}

