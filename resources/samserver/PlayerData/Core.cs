using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using MySql.Data.MySqlClient;

namespace samserver.PlayerData
{
    class Core : Script
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
 

        }




        // [ServerEvent{Event.PlayerConnected]
        //public async void OnPlayerConnected(Player player)
        //    {
        //   Data temp = Data.GetDataFromClient(player);
        //   NAPI.ClientEvent.TriggerClientEvent(player, "FreezePlayerClient", true);
        //   player.Transparency = 0;

        //    if (await temp.AccountExists())
        //    {
        //    Main.Log_Server("Account exists!");
        //   NAPI.ClientEvent.TriggerClientEvent(player, "ShowLoginCEF", true);
        // }    
        //    else
        //    {
        //   Main.Log_Server("Account does not exists!")
        //   NAPI.ClientEvent.TriggerClientEvent(player, "ShowRegiserPage", true);
        //   }
    }
}

