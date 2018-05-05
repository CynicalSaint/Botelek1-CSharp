using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Botelek1_CSharp.Core
{
    class CommandHandler
    {
        DiscordSocketClient _client;
        CommandService _service;


        public async Task InitializeAsync(DiscordSocketClient client)
        {
            _client = client;
            _service = new CommandService();

            await _service.AddModulesAsync(Assembly.GetEntryAssembly());
            _client.MessageReceived += HandleCommandAsync;
            
        }

        private async Task HandleCommandAsync(SocketMessage message)
        {
            var msg = message as SocketUserMessage;
            if (msg == null) return;
            SocketCommandContext context = new SocketCommandContext(_client, msg);
            int argPos = 0;
            if (msg.HasStringPrefix(Config.bot.CmdPrefix, ref argPos)
                || msg.HasMentionPrefix(_client.CurrentUser, ref argPos))
            {
                IResult result = await _service.ExecuteAsync(context, argPos);
                if (!result.IsSuccess && result.Error != CommandError.UnknownCommand)
                {
                    await context.Channel.SendMessageAsync($"[ERROR] {result.ErrorReason}");
                }
            }
        }
    }

}
