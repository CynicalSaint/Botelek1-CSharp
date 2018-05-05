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

        public const string userFolder = "User";
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

        /*public static void LoadUser(DiscordSocketClient client)
        {
            SocketGuild guild = client.GetGuild(140212795592409088);
                                               
            List<DiscordUser> discordUsers = new List<DiscordUser>();

            foreach (SocketGuildUser guildUser in guild.Users)

            {
                string userConfig = userFolder + "/" + guildUser.Username + ".json";

                if (!File.Exists(userConfig))
                {
                    DiscordUser user = new DiscordUser();
                    user.Username = guildUser.Username;
                    user.DailyReminder = "";
                    user.Motd = "";

                    string json = JsonConvert.SerializeObject(user, Formatting.Indented);
                    File.WriteAllText(userConfig, json);
                    discordUsers.Add(user);

                }
                else
                {
                    DiscordUser user = JsonConvert.DeserializeObject<DiscordUser>(userConfig);
                    discordUsers.Add(user);
                }

            }

        }*/
    }



    public struct BotConfig
    {
        public string Token;
        public string CmdPrefix;
    }


}


