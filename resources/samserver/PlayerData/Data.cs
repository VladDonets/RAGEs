using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace samserver.PlayerData
{
    class Data
    {
        public static String DataIdentifier = "PlayerInfo";

        public Player PlayerData { get; set; }
        public string ID         { get; set; }
        public string Name       { get; set; }
        public int Cash          { get; set; }
        public bool FirstSpawned { get; set; }
        public Admin.Rank AdminLevel { get; set; }
        public int Health        { get; set; }
        public int MMR           { get; set; }
        public int Email         { get; set; }
        public int Password      { get; set; }
        public Vector3 position  { get; set; }
        public bool IsLoggedIn   { get; set; }



        public Data(Player Player)
        {
            this.FirstSpawned = true;
            this.PlayerData = Player;
            this.AdminLevel = Admin.Rank.Admin_None;
            this.Cash = 0;
            this.MMR = 0;
            this.Name = Player.Name;
            this.Health = 100;
            this.IsLoggedIn = false;

        }

        public static bool ReturnFirstSpawnValue(Player playerD)
        {
            return playerD.GetData<Data>(DataIdentifier).FirstSpawned;
        }
        public static void SetFirtSpawnValue(Player playerD, bool value)
        {
            playerD.GetData<Data>(DataIdentifier).FirstSpawned = value;
        }

        public static Data ReturnPlayerData(Player playerD)
        {
            if (playerD.HasData(DataIdentifier))
                playerD.SetData(DataIdentifier, new Data(playerD));

            return playerD.GetData<Data>(DataIdentifier);
        }

        public void SetHelth(int health)
        {
            this.Health = health;
            this.PlayerData.Health = health;
        }

        public static  Data GetDataFromClient(Player playerD) 
        {
            if (playerD == null)
                return null;
            
            if (playerD.HasData(DataIdentifier))
            {
                return playerD.GetData<Data>(DataIdentifier);
            }
            else
            {
                Data tmp = new Data(playerD);
                playerD.SetData(DataIdentifier, tmp);
                return playerD.GetData<Data>(DataIdentifier);
            }
        }
        
    }
}
