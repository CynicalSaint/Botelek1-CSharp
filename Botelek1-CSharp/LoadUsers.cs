using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Botelek1_CSharp;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Newtonsoft.Json;

namespace Botelek1_CSharp
{
    public class FirstTest : ModuleBase
    {
        [Command("addusers", RunMode = RunMode.Async)]
        public async Task addUsers(DiscordSocketClient client)
        {
            SocketGuild guild = client.GetGuild(140212795592409088);

            List<DiscordUser> discordUsers = new List<DiscordUser>();

            foreach (SocketGuildUser guildUser in guild.Users)

            {
                string userConfig = Config.userFolder + "/" + guildUser.Username + ".json";

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

                // Console.WriteLine(DiscordUser user);
            }
        }
    }
}
    

