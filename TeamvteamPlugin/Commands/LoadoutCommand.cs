using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamvteamPlugin.Loadouts;
using Item = TeamvteamPlugin.Loadouts.Item;

namespace TeamvteamPlugin.Commands
{
    internal class LoadoutCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "kit";

        public string Help => "Create a new loadout";

        public string Syntax => "/kit <create>";

        public List<string> Aliases { get; } = new List<string>() { "l" };

        public List<string> Permissions { get; } = new List<string>() { "lc.kit" };

        public void Execute(IRocketPlayer caller, string[] command)
        {

            if (caller is not UnturnedPlayer player) return;
            if (command.Length == 0)
            {
                UnturnedChat.Say(caller, "didnt supply kit id");
                return;
            }
            if (LoadoutManager.loadouts == null)
            {
                LoadoutManager.loadouts = new List<Loadout>();
            }
            Items[] pages = player.Player.inventory.items;
            Loadout loadout = new Loadout();
            loadout.Id = command[0];
            loadout.items = new List<Item>();
            loadout.clothings = new List<Clothing>();
            for (int i = 0; i < PlayerInventory.STORAGE; i++)
            {
                Items items = pages[i];
                byte count = items.getItemCount();
                for (int j = 0; j < count; j++)
                {
                    ItemJar item = items.getItem((byte)j);
                    ItemAsset asset = item.GetAsset();
                    if (asset == null)
                    {
                        continue;
                    }
                    Item newitem = new Item
                    {
                        id = asset.GUID,
                        page = (byte)i,
                        x = item.x,
                        y = item.y,
                        rotation = item.rot,
                        metadata = item.item.metadata
                    };

                    loadout.items.Add(newitem);


                }

            }

            PlayerClothing playerClothes = player.Player.clothing;

            if (playerClothes.shirtAsset != null)
            {
                Clothing newclothing = new Clothing
                {
                    Clothingid = playerClothes.shirtAsset.GUID,
                    metadata = playerClothes.shirtState
                };
                loadout.clothings.Add(newclothing);
            }
            if (playerClothes.pantsAsset != null)
            {
                Clothing newclothing = new Clothing
                {
                    Clothingid = playerClothes.pantsAsset.GUID,
                    metadata = playerClothes.pantsState
                };
                loadout.clothings.Add(newclothing);
            }
            if (playerClothes.vestAsset != null)
            {
                Clothing newclothing = new Clothing
                {
                    Clothingid = playerClothes.vestAsset.GUID,
                    metadata = playerClothes.vestState
                };
                loadout.clothings.Add(newclothing);
            }
            if (playerClothes.hatAsset != null)
            {
                Clothing newclothing = new Clothing
                {
                    Clothingid = playerClothes.hatAsset.GUID,
                    metadata = playerClothes.hatState
                };
                loadout.clothings.Add(newclothing);
            }
            if (playerClothes.maskAsset != null)
            {
                Clothing newclothing = new Clothing
                {
                    Clothingid = playerClothes.maskAsset.GUID,
                    metadata = playerClothes.maskState
                };
                loadout.clothings.Add(newclothing);
            } 
            if (playerClothes.backpackAsset != null)
            {
                Clothing newclothing = new Clothing
                {
                    Clothingid = playerClothes.backpackAsset.GUID,
                    metadata = playerClothes.backpackState
                };
                loadout.clothings.Add(newclothing);
            } 
            if (playerClothes.glassesAsset != null)
            {
                Clothing newclothing = new Clothing
                {
                    Clothingid = playerClothes.glassesAsset.GUID,
                    metadata = playerClothes.glassesState
                };
                loadout.clothings.Add(newclothing);
            }
            UnturnedChat.Say("You created loadout " + loadout.Id);
            LoadoutManager.loadouts.Add(loadout);
            LoadoutManager.write();


        }
    }
}
