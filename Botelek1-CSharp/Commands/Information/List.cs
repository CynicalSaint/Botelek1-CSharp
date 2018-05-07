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

namespace Botelek1_CSharp.Commands.Information
{


    public class CommandList : ModuleBase<SocketCommandContext>
    {



        [Command(Config.Command_List)]
        public async Task commandlistAsync()
        {

            //***********************************************************************************************************************
            //Commnad List
            EmbedBuilder builderCL = new EmbedBuilder();
            builderCL.WithTitle("Commnad List")
                        .WithDescription("Command: " + Config.bot.CmdPrefix + Config.Command_List +
                                        "\n" + "Description: " + "This Will Produce A List Of The Commands That Are Avalible On Bot " + Config.BotName +
                                        "\n"  + "Comments: " 
                                        )
                        .WithColor(Color.Red)
                        .WithThumbnailUrl(Config.ThumbnailUrl);

            //***********************************************************************************************************************
            //Daily Reminder"
            EmbedBuilder builderDR = new EmbedBuilder();
        
                         builderDR.WithTitle("Daily Reminder")
                        .WithDescription("Command: " + Config.bot.CmdPrefix + Config.Daily_Reminder +
                                        "\n" + "Description: " + "After A Daily Reminder Has Been Set This Command Will Send You Daily Reminder" +
                                        "\n"  + "Comments: " 
                                        )
                        .WithColor(Color.Orange)
                        .WithThumbnailUrl(Config.ThumbnailUrl);

            //***********************************************************************************************************************
            // Daily Reminder Add
            EmbedBuilder builderDRA = new EmbedBuilder();
                         builderDRA.WithTitle("Daily Reminder Add")
                        .WithDescription("Command: " + Config.bot.CmdPrefix + Config.Daily_Reminder_Add +
                                        "\n" + "Description: " + "To Change/Update Your Daily Reminder" +
                                        "\n"  + "Comments: " 
                                        )
                        .WithColor(Color.Green)
                        .WithThumbnailUrl(Config.ThumbnailUrl);

            //***********************************************************************************************************************
            // Clean Up
            EmbedBuilder builderCP = new EmbedBuilder();
                         builderCP.WithTitle("Clean Up")
                        .WithDescription("Command: " + Config.bot.CmdPrefix + Config.Clean_Up +
                                        "\n" + "Description: " +" This Will Delete The Amount Of Messages Set By The User. Example :  "
                                        + Config.bot.CmdPrefix + Config.Ping_Pong + "1 Will Deleted Your Message And One" +
                                        "\n"  + "Comments: " 
                                        )
                        .WithColor(Color.Blue)
                        .WithThumbnailUrl(Config.ThumbnailUrl);

            //***********************************************************************************************************************
            // Ping Pong
            EmbedBuilder builderPP = new EmbedBuilder();
                         builderPP.WithTitle("Ping Pong")
                        .WithDescription("Command: " + Config.bot.CmdPrefix + Config.Ping_Pong +
                                        "\n" + "Description: " + "PINGA-PONGO" +
                                        "\n" + "Comments: " 
                                        )
                        .WithColor(Color.Purple)
                        .WithThumbnailUrl(Config.ThumbnailUrl);


            await ReplyAsync("", false, builderCL.Build());
            await ReplyAsync("", false, builderDR.Build());
            await ReplyAsync("", false, builderDRA.Build());
            await ReplyAsync("", false, builderCP.Build());
            await ReplyAsync("", false, builderPP.Build());

            


            }

    } 
}