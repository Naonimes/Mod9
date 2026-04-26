using System;
using System.IO;
using System.Text.Json;

public class CovidConfig
{
    public Config config;
    private const string filePath = "covid_config.json";

    public CovidConfig()
    {
        try
        {
            ReadConfigFile();
        }
        catch (Exception)
        {
            SetDefault();
            WriteNewConfigFile();
        }
    }

    private void ReadConfigFile()
    {
        string configJsonData = File.ReadAllText(filePath);
        config = JsonSerializer.Deserialize<Config>(configJsonData);
    }

    private void SetDefault()
    {
        config = new Config
        {
            satuan_suhu = "celcius",
            batas_hari_deman = 14,
            pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini",
            pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini"
        };
    }

    private void WriteNewConfigFile()
    {
        JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(config, options);
        File.WriteAllText(filePath, jsonString);
    }

    public void UbahSatuan()
    {
        
        if (config.satuan_suhu == "celcius")
        {
            config.satuan_suhu = "fahrenheit";
        }
        else
        {
            config.satuan_suhu = "celcius";
        }
        WriteNewConfigFile();
    }
}