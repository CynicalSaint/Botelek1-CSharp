using Botelek1_CSharp.Core;
using Botelek1_CSharp.Style;
using Discord;
using Discord.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Botelek1_CSharp.Commands.Daily_Reminder
{


    public class DR : ModuleBase<SocketCommandContext>
    {

        [Command(Config.Daily_Reminder)]
        public async Task drAsync()
        {

            using (StreamReader file = File.OpenText(Config.UserPath + "/" + Context.User.Username + ".json"))
            {
              
                JsonSerializer serializer = new JsonSerializer();
                UserDetails userDetails = (UserDetails)serializer.Deserialize(file, typeof(UserDetails));
                

                if (userDetails.DailyReminder.Equals(""))
                {
                    EmbedBuilder builder = new EmbedBuilder();

                    builder.WithTitle("You have no Daily Reminder!!!")
                        .WithDescription("Type " + Config.bot.CmdPrefix +"")
                        .WithColor(Color.DarkRed)
                        .WithThumbnailUrl(Config.ThumbnailUrl);

                    await ReplyAsync("", false, builder.Build());
                }
                else
                {
                    EmbedBuilder builder = new EmbedBuilder();

                    builder.WithTitle("WOw Cool Wow")
                        .WithDescription("Would you look at that")
                        .WithColor(Color.DarkRed)
                        .WithThumbnailUrl(Config.ThumbnailUrl);

                    await ReplyAsync("", false, builder.Build());

                    Context.Channel.SendMessageAsync(userDetails.DailyReminder);


                    Console.WriteLine(SystemStyle.FrameTop);
                    Console.WriteLine("User " + Context.User.Username + " Has Request their DailyReminder!: " + userDetails.DailyReminder + " " + DateTime.Now);
                    Console.WriteLine(SystemStyle.FrameTop);

                }
            }
        }
    }
}