using Discord.WebSocket;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Botelek1_CSharp
{
    class Config
    {
        private const string configFolder = "res";
        private const string configFile = "config.json";
        private const string configPath = configFolder + "/" + configFile;

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

    class ServerProperties
    {
        public struct ServerPropertiesStruct

        {
            public string VoiceChannelID;
            public string GuildID;
            public List<SocketGuildUser> Users;

        }
    }
}

