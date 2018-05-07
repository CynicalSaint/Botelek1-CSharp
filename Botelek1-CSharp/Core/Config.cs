using Discord.WebSocket;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using static Botelek1_CSharp.Core.Config;

namespace Botelek1_CSharp.Core
{
    public class Config
    {

        // Location of Bot's Config
        public const string configFolder = "res";
        private const string configFile = "config.json";
        private const string configPath = configFolder + "/" + configFile;

        // Location of User's information
        public const string userFolder = "Users";
        public const string UserPath = configFolder + "/" + userFolder;

        // Bot Referance Detials
        public static BotConfig bot;
        public static string BotName = "Ragnarök";

        // Embed var
        public const string ThumbnailUrl = "https://i2.wp.com/www.4ye.co.uk/wp-content/uploads/2015/08/tumblr_nta0dbtNl11qewsw4o2_r1_500.jpg?fit=500%2C281";

        // List of all commands to Referance NOTE: this will update all command referance
        public const string Command_List = "CL";                           // List of all commands, What & How (Maybe why)
        //***********************************************************************************************************************
        public const string Daily_Reminder = "DR";                       // Sends Users Daily Reminder 
        public  const string Daily_Reminder_Add = "DRAdd";              // Changes Link That Daily Reminder Sends
        //***********************************************************************************************************************
        public const string Clean_Up = "CU";                          // Clears Amount Of Messages That Users Requests 
        //***********************************************************************************************************************
        public const string Ping_Pong = "Ping";                     // Ping Pong Game 



        static Config()
        {
            if (!Directory.Exists(configFolder))
                Directory.CreateDirectory(configFolder);

            if (!File.Exists(configPath))
            {
                bot = new BotConfig();

                string config = JsonConvert.SerializeObject(bot, Formatting.Indented);
                File.WriteAllText(configPath, config);
            }
            else
            {
                string json = File.ReadAllText(configPath);
                bot = JsonConvert.DeserializeObject<BotConfig>(json);
            }



        }

        public struct BotConfig
        {
            public string Token;
            public string CmdPrefix;
        }


    }
}