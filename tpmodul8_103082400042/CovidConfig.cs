using System;
using System.IO;
using System.Text.Json;

namespace tpmodul8_103082400042
{
    public class Config
    {
        public string satuan_suhu { get; set; }
        public int batas_hari_demam { get; set; }
        public string pesan_ditolak { get; set; }
        public string pesan_diterima { get; set; }

        public Config() { }
        public Config(string s, int b, string d, string a)
        {
            satuan_suhu = s;
            batas_hari_demam = b;
            pesan_ditolak = d;
            pesan_diterima = a;
        }
    }

    public class CovidConfig
    {
        public Config conf;
        public string path = Directory.GetCurrentDirectory() + "/covid_config.json";

        public CovidConfig()
        {
            try { ReadConfigFile(); }
            catch { SetDefault(); WriteConfigFile(); }
        }

        private void SetDefault()
        {
            conf = new Config("celcius", 14,
                "Anda tidak diperbolehkan masuk ke dalam gedung ini",
                "Anda dipersilahkan untuk masuk ke dalam gedung ini");
        }

        private void ReadConfigFile()
        {
            string jsonString = File.ReadAllText(path);
            conf = JsonSerializer.Deserialize<Config>(jsonString);
        }

        private void WriteConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(conf, options);
            File.WriteAllText(path, jsonString);
        }

        public void UbahSatuan()
        {
            conf.satuan_suhu = conf.satuan_suhu == "celcius" ? "fahrenheit" : "celcius";
            WriteConfigFile();
        }
    }
}