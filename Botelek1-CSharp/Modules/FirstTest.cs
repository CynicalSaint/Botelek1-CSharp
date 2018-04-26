using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Botelek1_CSharp.Modules
{
    public class FirstTest : ModuleBase
    {
        [Command("ping", RunMode = RunMode.Async)]
        public async Task Pong()
        {
            await Context.Channel.SendMessageAsync($"Pong!");
        }
    }
}
