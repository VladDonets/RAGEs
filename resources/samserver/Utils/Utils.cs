using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;

namespace samserver.Utils
{
    class Utils
    {
        public static string ReturnRPName(GTANetworkAPI.Player player)
        {
            string RPName = player.Name.Replace('_', ' ');
            return RPName;
        }
    }
}
