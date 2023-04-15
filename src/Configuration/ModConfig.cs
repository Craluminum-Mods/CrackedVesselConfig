using Vintagestory.API.Common;

namespace CrackedVesselConfig.Configuration;

static class ModConfig
{
    private const string jsonConfig = "ConfigureEverything/LootVessels.json";
    private static Config config;

    public static void ReadConfig(ICoreAPI api)
    {
        try
        {
            config = LoadConfig(api);
            config = api.FillConfig(config);

            if (config == null)
            {
                GenerateConfig(api);
                config = LoadConfig(api);
                config = api.FillConfig(config);
            }
            else
            {
                GenerateConfig(api, config);
                config = api.FillConfig(config);
            }
        }
        catch
        {
            GenerateConfig(api);
            config = LoadConfig(api);
            config = api.FillConfig(config);
        }

        api.ApplyPatches(config);
    }

    private static Config LoadConfig(ICoreAPI api) => api.LoadModConfig<Config>(jsonConfig);
    private static void GenerateConfig(ICoreAPI api) => api.StoreModConfig(new Config(), jsonConfig);
    private static void GenerateConfig(ICoreAPI api, Config previousConfig) => api.StoreModConfig(new Config(previousConfig), jsonConfig);
}