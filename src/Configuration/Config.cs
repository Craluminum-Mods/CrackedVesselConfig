using System.Collections.Generic;
using Vintagestory.GameContent;

namespace CrackedVesselConfig.Configuration
{
    public class Config
    {
        public Dictionary<string, LootList> LootLists = new() { };

        public Config() { }
        public Config(Config previousConfig)
        {
            foreach (var list in previousConfig.LootLists)
            {
                if (LootLists.ContainsKey(list.Key)) continue;
                LootLists.Add(list.Key, list.Value);
            }
        }
    }
}
