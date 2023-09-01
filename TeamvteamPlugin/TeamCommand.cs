using JetBrains.Annotations;
using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainPlugin
{

 
    public class TeamCommand : IRocketCommand
    { 
        public AllowedCaller AllowedCaller => AllowedCaller.Player; // Dont let the console call the command, only the player.

        public string Name => "team";  // Setting the name of the command as "ammo".

        public string Help => "Choose a team"; // When /help ammo, this shall print.

        public string Syntax => "/team 1 or /team 2"; // <> is required and [] is optional

        public List<string> Aliases { get; } = new List<string>() { "t" }; // By using { get; } you create a property of the list rather than creating a new list.
        public List<string> Permissions { get; } = new List<string>() { "ac.ammo" }; // ac.ammo is the code/id of the permisson group allowed to use the /ammo command

        public void Execute(IRocketPlayer caller, string[] command) // when /ammo is used, the following string is thrown to the player who used the command
        {
            if (caller is not UnturnedPlayer player) return;
        }
    }
    
}
