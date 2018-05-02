using Discord.WebSocket;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Botelek1_CSharp.Core
{
    class Config
    {
        private const string configFolder = "res";
        private const string configFile = "config.json";
        private const string configPath = configFolder + "/" + configFile;

        private const string videoBanListFile = "bannedvideos.json";
        private const string videoBanListPath = configFolder + "/" + videoBanListFile;

        public static BotConfig bot;

        public static List<string> bannedVideos;

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

            if (!File.Exists(videoBanListPath)) 
            {
                bannedVideos = new List<string>();
                SaveBannedUrls();
                RefreshVideoLinks();
            }
            else 
            {
                RefreshVideoLinks();
            }

        }

        public static void RefreshVideoLinks()
        {
            string json = File.ReadAllText(videoBanListPath);
            bannedVideos = JsonConvert.DeserializeObject<List<string>>(json);
        }

        public static void AddBannedVideo(string url)
        {
            bannedVideos.Add(url);
            SaveBannedUrls();
            RefreshVideoLinks();
        }

        private static void SaveBannedUrls()
        {
            string json = JsonConvert.SerializeObject(bannedVideos, Formatting.Indented);
            File.WriteAllText(videoBanListPath, json);
        }

        public struct BotConfig
        {
            public string Token;
            public string CmdPrefix;
        }
    }
}
