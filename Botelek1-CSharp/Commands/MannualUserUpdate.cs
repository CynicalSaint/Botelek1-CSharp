using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;


namespace Botelek1_CSharp.Core
{
    class MannualUserUpdate
    {
        class FirstTest : ModuleBase
        {
            [Command("MUP")]

            public async Task AddUsers(DiscordSocketClient client)
            {

                LoadAllUsers.LoadUsers(client);

                Context.Channel.SendMessageAsync(Context.Message.Author.Mention + "User List Has Been Updated" + DateTime.Now);
                Console.WriteLine("***********************************************************************");
                Console.WriteLine("User List Has Been Updated" + DateTime.Now);


            }
        }

    }
}
