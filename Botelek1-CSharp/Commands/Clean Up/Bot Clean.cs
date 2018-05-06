using Botelek1_CSharp.Style;
using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Botelek1_CSharp.Commands.Clean_Up
{
    public class CleanUp : ModuleBase
    {
        [Command("CP", RunMode = RunMode.Async)]

        public async Task cleanUp(int amount)
        {
            string channelID = Context.Channel.Id.ToString();

            if (channelID == "434111879212957706")
            {
                if (Context.User.Id == 140213467717042177)
                {
                    



                }
                else
                {
                    await Context.Message.DeleteAsync();
                    await ReplyAsync("Nice try");
                    Console.WriteLine(SystemStyle.FrameTop);
                    Console.WriteLine("User " + Context.User.Username + " Tried to User Command: Clean up " + DateTime.Now);
                    Console.WriteLine(SystemStyle.FrameBottom);

                }

            }
            else
            {
                await Context.Message.DeleteAsync();
                await ReplyAsync("wrong channel");
                return;
            }
        }
    }
}
