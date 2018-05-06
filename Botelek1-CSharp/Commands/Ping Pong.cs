using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Botelek1_CSharp.Commands
{
    class Ping_Pong
    {
        public class ping_Pong : ModuleBase
        {
            [Command("ping", RunMode = RunMode.Async)]
            public async Task Ping()
            {
                await ReplyAsync($" Pong! {(Context.Client as DiscordSocketClient).Latency} as :Ping_Pong:");
            }
        }
    }
}
