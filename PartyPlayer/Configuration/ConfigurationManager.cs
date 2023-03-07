using System;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace PartyPlayer.Configuration;

public class ConfigurationManager<T>
{
    public readonly string FilePath;
    public T DefaultConfiguration;

    public ConfigurationManager(T defaultConfiguration, bool loadImmediately = true) : this(FindConfig(),
        defaultConfiguration, loadImmediately)
    {
    }

    public ConfigurationManager(string filePath, T defaultConfiguration, bool loadImmediately = true)
    {
        if (filePath == null) throw new ArgumentNullException(nameof(filePath));
        if (!filePath.EndsWith(".json"))
            throw new ArgumentException("Specified file is not a json file: " + filePath);

        FilePath = filePath;
        DefaultConfiguration = defaultConfiguration;
        if (loadImmediately) Load();
    }

    public T Configuration { get; private set; }

    public void Load()
    {
        // Attempting to create a configuration file it is absent
        if (!File.Exists(FilePath))
        {
            if (DefaultConfiguration == null)
                throw new FileNotFoundException(
                    "The configuration file is not found and DefaultConfiguration is null");

            File.WriteAllText(FilePath, JsonConvert.SerializeObject(DefaultConfiguration, Formatting.Indented));
            Configuration = DefaultConfiguration;
            return;
        }

        // if it already exists, simply loading it
        Configuration = JsonConvert.DeserializeObject<T>(File.ReadAllText(FilePath));
    }

    public void Save()
    {
        File.WriteAllText(FilePath, JsonConvert.SerializeObject(Configuration, Formatting.Indented));
    }

    private static string FindConfig()
    {
        var exeFile = Assembly.GetExecutingAssembly().Location;
        var exeDirectory = Path.GetDirectoryName(exeFile);

        return exeDirectory == null ? null : Path.Combine(exeDirectory, "config.json");
    }
}