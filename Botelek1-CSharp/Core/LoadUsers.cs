using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Botelek1_CSharp;
using Botelek1_CSharp.Style;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Newtonsoft.Json;

namespace Botelek1_CSharp.Core
{
    public class LoadAllUsers
    {
        public static void LoadUsers(DiscordSocketClient client)
        {
            SocketGuild guild = client.GetGuild(140212795592409088);

            List<DiscordUser> discordUsers = new List<DiscordUser>();

            foreach (SocketGuildUser guildUser in guild.Users)

            {
                string userConfig = Config.UserPath + "/" + guildUser.Username + ".json";

                if (!File.Exists(userConfig))
                {
                    DiscordUser user = new DiscordUser();
                    user.Username = guildUser.Username;
                    user.DailyReminder = "";
                    user.Motd = "";

                    Directory.CreateDirectory(Config.UserPath);
                    string json = JsonConvert.SerializeObject(user, Formatting.Indented);
                    File.WriteAllText(userConfig, json);
                    discordUsers.Add(user);
                    Console.WriteLine(SystemStyle.FrameTop);
                    Console.WriteLine(userConfig + " Has Been Created " + "{" + DateTime.Now + "}");
                    Console.WriteLine("User " + user + " Has Been Added " + "{" + DateTime.Now + "}");
                    Console.WriteLine(SystemStyle.FrameBottom);
                }
                else
                {
                  

                    Console.WriteLine(SystemStyle.FrameTop);
                    Console.WriteLine("User " + guildUser.Username + " Already Existed " + "{" + DateTime.Now + "}");
                    Console.WriteLine(SystemStyle.FrameBottom);
                }

            }

        }
    }
}

    

