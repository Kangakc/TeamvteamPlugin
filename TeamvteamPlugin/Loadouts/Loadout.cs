using Rocket.API;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamvteamPlugin.Loadouts;

public class Loadout
{
   

    public string Id { get; set; }
    public List<Item> items { get; set; }
    public List<Clothing> clothings {  get; set; }

}
public class Item
{
    public Guid id { get; set; }
    public byte page {  get; set; }    
    public byte x {  get; set; }
    public byte y { get; set; }
    public byte rotation { get; set; }
    public byte[] metadata { get; set; }

}
public class Clothing
{
    public Guid Clothingid { get; set; }
    public byte[] metadata { get; set; }

}