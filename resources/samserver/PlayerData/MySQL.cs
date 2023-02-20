using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using MySql.Data.MySqlClient;

namespace samserver.PlayerData
{
    class MySQL
    {
        public static MySqlConnection _connection;
        private string _Host { get; set; }
        private string _User { get; set; }
        private string _Pass { get; set; }
        private string _BaseName { get; set; }


        public MySQL()              //ДАННЫЕ ВХОДА ОТ БАЗЫ ДАННЫХ
        {
            this._Host = "localhost";
            this._BaseName = "samserver_base";
            this._User = "root";
            this._Pass = "";   
        }

        public static void InitConnection()
        {
            MySQL sql = new MySQL();
            string SQLconnection = $"SERVER={sql._Host}; DATABASE={sql._BaseName}; UID={sql._User}; PASSWORD={sql._Pass};";
            _connection = new MySqlConnection(SQLconnection);


            try
            {
                _connection.Open();
                NAPI.Util.ConsoleOutput("DataBase_SQL ПОДКЛЮЧЕНА К СЕРВЕРУ");
            }

            catch (Exception ex)
            {
                NAPI.Util.ConsoleOutput("DataBase_SQL НЕ ПОДКЛБЧЕНА! рот ебал");
                NAPI.Util.ConsoleOutput("Исключение:" + ex);
            }
        }     

    }
}
