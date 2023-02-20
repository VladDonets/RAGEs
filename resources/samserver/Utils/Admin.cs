using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;

namespace samserver
{
    class Admin
    {
        public enum Rank : int
        {
            Admin_None,
            Admin_GameMaste,
            Admin_Supporter,
            Admin_Junior,
            Admin_Developer,
            Admin_Admin
        }
    }
}
