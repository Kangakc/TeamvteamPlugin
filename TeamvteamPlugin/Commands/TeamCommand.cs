using JetBrains.Annotations;
using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamvteamPlugin.Commands;

public class TeamCommand : IRocketCommand
{ 
    public AllowedCaller AllowedCaller => AllowedCaller.Player; 
    public string Name => "team";  
    public string Help => "Choose a team"; 
    public string Syntax => "/team 1 or /team 2"; 
    public List<string> Aliases { get; } = new List<string>() { "t" }; 
    public List<string> Permissions { get; } = new List<string>() { "tc.team" };
    public void Execute(IRocketPlayer caller, string[] command)
    {
        if (caller is not UnturnedPlayer player) return;
        if (command.Length == 0 || !int.TryParse(command[0], out int id) || (id != 1 && id != 2))
        {
            UnturnedChat.Say(caller, "Not a vaid team");
            return;
        }
        UnturnedChat.Say("You have now joined team " + id);
        player.Player.quests.ServerAssignToGroup(new CSteamID((ulong)id), EPlayerGroupRank.MEMBER, true);
    }

}


