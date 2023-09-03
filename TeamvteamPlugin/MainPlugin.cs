using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Steamworks;
using TeamvteamPlugin.Loadouts;

namespace TeamvteamPlugin
{
    public class MainPlugin : RocketPlugin
    {
        protected override void Load()
        {
            Level.onLevelLoaded += OnLevelLoaded;
            LoadoutManager.read();

            Logger.Log("fortnitesyndrome");
            base.Load();

        }
        protected override void Unload()
        {
            Level.onLevelLoaded -= OnLevelLoaded;
            base.Unload();
        }

        private void OnLevelLoaded(int level)
        {
            GroupManager.getOrAddGroup(new CSteamID(1), "team 1", out _);
            GroupManager.getOrAddGroup(new CSteamID(2), "team 2", out _);
            Logger.Log("The level is loaded");
            GroupManager.save();
        }
    }


}

