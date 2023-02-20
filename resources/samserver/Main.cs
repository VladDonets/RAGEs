using System;
using GTANetworkAPI;
using MySqlConnector;
using RAGE;

namespace samserver
{
    public class Main : Script
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            PlayerData.MySQL.InitConnection();


            NAPI.Util.ConsoleOutput("░██████╗░█████╗░███╗░░░███╗░██████╗███████╗██████╗░██╗░░░██╗███████╗██████╗░");
            NAPI.Util.ConsoleOutput("██╔════╝██╔══██╗████╗░████║██╔════╝██╔════╝██╔══██╗██║░░░██║██╔════╝██╔══██╗ ");
            NAPI.Util.ConsoleOutput("╚█████╗░███████║██╔████╔██║╚█████╗░█████╗░░██████╔╝╚██╗░██╔╝█████╗░░██████╔╝ ");
            NAPI.Util.ConsoleOutput("░╚═══██╗██╔══██║██║╚██╔╝██║░╚═══██╗██╔══╝░░██╔══██╗░╚████╔╝░██╔══╝░░██╔══██╗ ");
            NAPI.Util.ConsoleOutput("██████╔╝██║░░██║██║░╚═╝░██║██████╔╝███████╗██║░░██║░░╚██╔╝░░███████╗██║░░██║ ");
            NAPI.Util.ConsoleOutput("╚═════╝░╚═╝░░╚═╝╚═╝░░░░░╚═╝╚═════╝░╚══════╝╚═╝░░╚═╝░░░╚═╝░░░╚══════╝╚═╝░░╚═╝ ");

            NAPI.Server.SetGlobalServerChat(false);


        }

        [ServerEvent(Event.PlayerConnected)]
        public void OnPlayerConnected(Player player)
        {
            PlayerData.Data playerD = new PlayerData.Data(player);
            player.SetData(PlayerData.Data.DataIdentifier, playerD);


        }

        [ServerEvent(Event.PlayerDisconnected)]
        public void OnPlayerDisconnected(Player player, DisconnectionType type, string message)
        {
            if (player.HasData(PlayerData.Data.DataIdentifier))
            {
                player.ResetData(PlayerData.Data.DataIdentifier);
            }
        }


        [ServerEvent(Event.PlayerSpawn)]
        public void OnPlayerSpawn(Player Player)
        {
            

            if (PlayerData.Data.ReturnFirstSpawnValue(Player))
            {
               NAPI.Chat.SendChatMessageToAll($"{Player.Name} появился!");
               PlayerData.Data.SetFirtSpawnValue(Player, false);
            }
            else
            {
                NAPI.Chat.SendChatMessageToAll($"{Player.Name} возродился!");

            }
        }
       


    }  
}
