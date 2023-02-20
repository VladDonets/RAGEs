using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;

namespace samserver.Chat
{
    class Utils
    {
        public static void ProxDetector(GTANetworkAPI.Player player, string message, double radius, string color)
        {
            List<GTANetworkAPI.Player> neardyPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(radius, player);
            foreach (GTANetworkAPI.Player item in neardyPlayers)
            {

                if (item.Dimension != player.Dimension)
                    continue;
                else

                    item.SendChatMessage($"{color} {message}");
            }
        }
    }
}
