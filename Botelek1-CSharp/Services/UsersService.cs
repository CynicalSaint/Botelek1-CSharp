using Botelek1_CSharp.Entities;
using Discord.Commands;
using Discord.WebSocket;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Botelek1_CSharp.Services
{
    public class UsersService
    {
        public static List<BotelekUser> BotelekUsers = new List<BotelekUser>();

        private const string configFolder = "res";
        private const string configFile = "UsersInfo.json";
        private const string configPath = configFolder + "/" + configFile;

        static UsersService()
        {
            // Load Data
            if (!ValidateStorageFile())
                return;

            string json = File.ReadAllText(configPath);
            BotelekUsers = JsonConvert.DeserializeObject<List<BotelekUser>>(json);
        }

        public void AddTemplateUser(ICommandContext context)
        {
            BotelekUser TemplateUser = new BotelekUser
            {
                User = (SocketGuildUser)context.Message.Author
            };
            TemplateUser.UserProperties = new Dictionary<string, string>();
            TemplateUser.UserProperties.Add("DailyReminder", "https://www.youtube.com/watch?v=_X6VoFBCE9k");
            TemplateUser.UserProperties.Add("MOTD", "You're all gay!");
            BotelekUsers.Add(TemplateUser);
            SaveData();
        }

        public static void SaveData()
        {
            // Save Data
            string json = JsonConvert.SerializeObject(BotelekUsers, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            File.WriteAllText(configPath, json);
        }

        private static bool ValidateStorageFile()
        {
            if (!Directory.Exists(configFolder))
                Directory.CreateDirectory(configFolder);

            if (!File.Exists(configPath))
            {
                File.WriteAllText(configPath, "");
                SaveData();
                return false;
            }

            return true;
        }
    }
}
