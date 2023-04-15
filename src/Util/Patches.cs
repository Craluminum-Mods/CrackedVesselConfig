using System.Collections.Generic;
using CrackedVesselConfig.Configuration;
using Vintagestory.API.Common;
using Vintagestory.GameContent;

namespace CrackedVesselConfig;

public static class Patches
{
    public static void ApplyPatches(this ICoreAPI api, Config config)
    {
        if (config.LootLists?.Count == 0) return;

        foreach (var block in api.World.Blocks)
        {
            if (block is not BlockLootVessel blockLootVessel) continue;
            blockLootVessel.SetField("lootLists", config.LootLists);
        }
    }

    public static Config FillConfig(this ICoreAPI api, Config config)
    {
        if (config.LootLists == null) return config;

        foreach (var block in api.World.Blocks)
        {
            if (block is not BlockLootVessel blockLootVessel) continue;

            var lootLists = blockLootVessel.GetField<Dictionary<string, LootList>>("lootLists");
            foreach (var val in lootLists)
            {
                if (config.LootLists.ContainsKey(val.Key)) continue;
                config.LootLists.Add(val.Key, val.Value);
            }

            break;
        }

        return config;
    }

    public static CollectibleObject GetCollectible<T>(this ICoreAPI api, KeyValuePair<string, T> val)
    {
        return api.World.GetItem(new AssetLocation(val.Key)) as CollectibleObject ?? api.World.GetBlock(new AssetLocation(val.Key));
    }
}