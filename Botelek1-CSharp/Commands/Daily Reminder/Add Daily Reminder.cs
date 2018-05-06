using Botelek1_CSharp.Core;
using Botelek1_CSharp.Style;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Botelek1_CSharp.Commands.Daily_Reminder
{ 

    public class DRAdd : ModuleBase<SocketCommandContext>
    {
        List<DiscordUser> discordUsers;
        private SocketUser guildUser;
        

        [Command("dradd")]
        public async Task draddAsync(string add)
        {
            guildUser = Context.User;

            string userConfig = Config.UserPath + "/" + guildUser.Username + ".json";

            if (!File.Exists(userConfig))
            {
                DiscordUser user = new DiscordUser();
                user.Username = guildUser.Username;
                user.DailyReminder = add;
                user.Motd = "";

                Directory.CreateDirectory(Config.UserPath);
                string json = JsonConvert.SerializeObject(user, Formatting.Indented);
                File.WriteAllText(userConfig, json);
                discordUsers.Add(user);
                Console.WriteLine(SystemStyle.FrameTop);
                Console.WriteLine(guildUser.Username + " Has Requested to be added");
                Console.WriteLine(userConfig + " Has Been Created " + "{" + DateTime.Now + "}");
                Console.WriteLine("User " + user + " Has Been Added " + "{" + DateTime.Now + "}");
                Console.WriteLine(SystemStyle.FrameBottom);
            }
            else
            {

                string json = File.ReadAllText(userConfig);
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                jsonObj["DailyReminder"] = add;
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(userConfig, output);

                
                Console.WriteLine(SystemStyle.FrameTop);
                Console.WriteLine(guildUser.Username + " Has Update Their DR: " + add);
                Console.WriteLine("User " + guildUser.Username + " Already Existed " + "{" + DateTime.Now + "}");
                Console.WriteLine(SystemStyle.FrameBottom);
            }

            await Context.Message.DeleteAsync();

            EmbedBuilder builder = new EmbedBuilder();

                builder.WithTitle("WOw Cool Wow")
                    .WithDescription("Would you look at that:")
                    .WithColor(Color.Red);
                
                await ReplyAsync("", false, builder.Build());
                 Context.Channel.SendMessageAsync(add);

                Console.WriteLine(SystemStyle.FrameTop);
                Console.WriteLine("User " + Context.User.Username + " Has Request their DailyReminder!: " + add + " " + DateTime.Now);
                Console.WriteLine(SystemStyle.FrameTop);
                
            


        }
    }
}

