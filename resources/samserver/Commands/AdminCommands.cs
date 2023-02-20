using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTANetworkAPI;



namespace samserver.Commands
{

    class AdminCommands : Script
    {

        [Command("samseven6753")]  // активация админки
        public void CMD_MakeMeAdmin(Player player)
        {
            PlayerData.Data.ReturnPlayerData(player).AdminLevel = Admin.Rank.Admin_Admin;
        }
        /////////////////////

        [Command("car", "/car спавнит авто")]    // команда для спавна техники  /car -название- -число1(хеш цвета) -число2(хеш цвета)
        public void CMD_CreateVehicle(Player player, string vehicleName, int color1, int color2)
        {

            uint hash = NAPI.Util.GetHashKey(vehicleName);

            /* if (PlayerData.Data.ReturnPlayerData(player).AdminLevel < Admin.Rank.Admin_Admin)          //проверка на анличие прав администратора
            {
                player.SendChatMessage("~r~ERROR: ~y~ нет прав использовать эту команду");
                return;
            } */

            if (hash == 0)
            {
                player.SendChatMessage("~r~ERROR: ~w~ неверное название техники.");
                return;
            }
            Vehicle vehicle = NAPI.Vehicle.CreateVehicle(hash, player.Position.Around(5), player.Rotation.Z, color1, color2);
            vehicle.Locked = false;
            vehicle.EngineStatus = false;
            player.SendChatMessage($"{Utils.Colors.COLOR_pink} INFO: Создана техника {vehicle.DisplayName} ");
            return;
        }



        [Command("veh", "~o~Usage: ~w~/veh [Vehicle Name]", GreedyArg = true)]    // команда для спавна техники случайного цвета  /car -название-
        public void CMD_CreateVehicle(Player player, string vehicleName)
        {

            uint hash = NAPI.Util.GetHashKey(vehicleName);

            if (hash == 0)
            {
                player.SendChatMessage("~r~ERROR: ~w~ неверное название техники.");
                return;
            }

            Random random = new Random();
            Vehicle vehicle = NAPI.Vehicle.CreateVehicle(hash, player.Position.Around(5), player.Rotation.Z, random.Next(160), random.Next(160));
            vehicle.Locked = false;
            vehicle.EngineStatus = false;
            player.SendChatMessage($"{samserver.Utils.Colors.COLOR_pink} INFO: Создана техника {vehicle.DisplayName} ");
            return;
        }


        /////////////////////////



        [Command("kill")]   // самоубийство /kill
        public void CMD_kill(Player player)
        {


            player.Kill();
            return;
        }

        ////////////////
        [Command("hp")] //выставляет хп  /hp
        public void CMD_SetPlayerHealth(Player player, int health)
        {


            player.Health = health;
            return;
        }
        ////////////////
        [Command("gun")] // выдача оружия /gun -названи- (хеш)
        public void CMD_Gun(Player player, WeaponHash hash)
        {


            NAPI.Player.GivePlayerWeapon(player, hash, 500);
            return;
        }
        //////////////     ПРОВЕРИТЬ     //////////////     ПРОВЕРИТЬ     //////////////     ПРОВЕРИТЬ
        [Command("ammo")]
        public void CMD_ammo(Player player, WeaponHash hash)
        {


            NAPI.Player.GetPlayerWeaponAmmo(player, hash);
        }
        //////////////
        [Command("skin")] //смена скина  
        public void CMD_skin(Player player, PedHash hash)
        {


            NAPI.Player.SetPlayerSkin(player, hash);
        }
        //////////////
        [Command("pos")] //получить координаты позиции игрока
        public void CMD_Pos(Player player)
        {
            Vector3 position = player.Position; // получение координат
            player.SendChatMessage($"Your position is: X: {position.X}, Y: {position.Y}, Z: {position.Z}");
        }
        //////////////
        [Command("weather")] //смена погоды
        public void CMD_Weather(Player player, string newWeather)
        {
            NAPI.World.SetWeather(newWeather);
            player.SendChatMessage($"{ Utils.Colors.COLOR_pink} INFO: Погода изменена {newWeather}!");
        }
        /////////////
        [Command("setmoney")]
        public void CMD_Setmoney(Player player, long cash)
        {
            player.SetData("Cash", cash);

            if (cash < 0)
            {
                player.SendChatMessage($"~g~INFO: ~w~ вы отдали { cash }");
                return;
            }
            if (cash > 0)
            {
                player.SendChatMessage($"~g~INFO: ~w~ вы получили { cash }");
                return;
            }

        }
        
      


        [Command("vspawn")]
        public void ShowMenu(Player player)
        {
            var muscleCars = new Dictionary<string, uint>
            {
                { "Dominator", (uint)VehicleHash.Dominator },
                { "Gauntlet", (uint)VehicleHash.Gauntlet },
                { "Phoenix", (uint)VehicleHash.Phoenix },
                { "Dominator5", (uint)VehicleHash.Dominator5 }
            };

            var motorcycles = new Dictionary<string, uint>
            {
                { "Akuma", (uint)VehicleHash.Akuma },
                { "Bagger", (uint)VehicleHash.Bagger },
                { "Hexer", (uint)VehicleHash.Hexer },
                { "Nemesis", (uint)VehicleHash.Nemesis }
            };

            var military = new Dictionary<string, uint>
            {
                
                { "Грузовик", (uint)VehicleHash.Barracks },
                { "грузовик2", (uint)VehicleHash.Barracks2 },
                { "Crusader", (uint)VehicleHash.Crusader }
            };

            var police = new Dictionary<string, uint>
            {
                { "Police", (uint)VehicleHash.Police },
                { "Police2", (uint)VehicleHash.Police2 },
                { "Police3", (uint)VehicleHash.Police3 },
                { "Police Interceptor", (uint)VehicleHash.Police4 },
                { "sheriff2", (uint)VehicleHash.Sheriff2 },
                { "fbi2", (uint)VehicleHash.Fbi2 },
                { "Police Transporter", (uint)VehicleHash.Policet }
            };

            var emergency = new Dictionary<string, uint>
            {
                { "Ambulance", (uint)VehicleHash.Ambulance },
                { "Fire Truck", (uint)VehicleHash.Firetruk },
                { "lguard", (uint)VehicleHash.Lguard }
            };

            var allVehicles = new Dictionary<string, Dictionary<string, uint>>
            {
                { "Muscle Cars", muscleCars },
                { "Motorcycles", motorcycles },
                { "Military", military },
                { "Police", police },
                { "Emergency", emergency }
            };

            var menuText = "Select a vehicle:\n";
            foreach (var vehicletype in allVehicles)
            {
                menuText += $"{vehicletype.Key}\n";
            }

            NAPI.ClientEvent.TriggerClientEvent(player, "chatMessage", "[Vehicle Spawner]", menuText);

            player.TriggerEvent("enableInput");
            player.SetSharedData("inputEnabled", "vehicleSpawn");

            player.TriggerEvent("vehicleSpawnHashes", NAPI.Util.ToJson(allVehicles));
        }
    }
}            
    
   
        
