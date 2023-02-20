using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;

namespace samserver.Chat
{
    class Core : Script
    {
        [ServerEvent(Event.ChatMessage)]
        public void OnChatMessage(GTANetworkAPI.Player player, string message)                  
        {
            Chat.Utils.ProxDetector(player, $"{samserver.Utils.Utils.ReturnRPName(player)} сказал: {message}", 20, samserver.Utils.Colors.COLOR_yellow);    //отображение сообщения в радиусе 20 метров
        }       

    }
}
