using System;
using System.Collections.Generic;
using GTANetworkAPI;


namespace samserver.Commands
{
    class PlayerComands : Script
    {
        [Command("me","~w~/me [acction]", GreedyArg = true)]
        public void CMD_Me(GTANetworkAPI.Player player, string action)
        {
            action = action.Trim();

            List<GTANetworkAPI.Player> neardyPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(20, player);

            foreach (GTANetworkAPI.Player item in neardyPlayers)
            {
                item.SendChatMessage($"{Utils.Colors.COLOR_sea} {Utils.Utils.ReturnRPName (player)} {action}");
            }
        }
        //////////////     ПРОВЕРИТЬ

        /////////////

    }
}
