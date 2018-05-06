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

        private const string configFolder = "res";
        private const string configFile = "config.json";
        private const string configPath = configFolder + "/" + configFile;

        public const string userFolder = "Users";
        public const string UserPath = configFolder + "/" + userFolder;

        
        public static BotConfig bot;

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