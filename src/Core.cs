using CrackedVesselConfig.Configuration;
using Vintagestory.API.Common;
using Vintagestory.API.Server;

[assembly: ModInfo("Cracked Vessel Config",
    Authors = new[] { "Craluminum2413" })]

namespace CrackedVesselConfig;

class Core : ModSystem
{
    public override bool ShouldLoad(EnumAppSide forSide) => forSide == EnumAppSide.Server;

    public override void StartServerSide(ICoreServerAPI api)
    {
        base.StartServerSide(api);
        ModConfig.ReadConfig(api);
        ModConfig.ReadConfig(api);
        api.World.Logger.Event("started 'Cracked Vessel Config' mod");
    }
}