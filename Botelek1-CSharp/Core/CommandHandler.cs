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
        CommandService _commands;

        public async Task InitializeAsync(DiscordSocketClient client)
        {
            _client = client;
            _commands = new CommandService();

            await _commands.AddModulesAsync(Assembly.GetEntryAssembly());
            _client.MessageReceived += HandleCommandAsync;
        }

        private async Task HandleCommandAsync(SocketMessage message)
        {
            SocketUserMessage msg = message as SocketUserMessage;

            if (msg == null) return;

            SocketCommandContext context = new SocketCommandContext(_client, msg);

            int argPos = 0;

            if (msg.Content.Contains("https://www.youtube.com/") || msg.Content.Contains("https://youtu.be/"))
            {
                foreach (Match item in Regex.Matches(msg.Content, @"(http|ftp|https):\/\/([\w\-_]+(?:(?:\.[\w\-_]+)+))([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?"))
                {
                    if (Config.bannedVideos.Contains(item.Value))
                    {
                        await DeleteMessage(msg);
                        break;
                    }

                    foreach (string url in Config.bannedVideos)
                    {
                        if (item.Value.Contains(url))
                        {
                            await DeleteMessage(msg);
                        }
                    }

                }
            }

            if (msg.HasStringPrefix(Config.bot.CmdPrefix, ref argPos) || msg.HasMentionPrefix(_client.CurrentUser, ref argPos))
            {
                IResult result = await _commands.ExecuteAsync(context, argPos);
                if (!result.IsSuccess && result.Error != CommandError.UnknownCommand)
                {
                    await context.Channel.SendMessageAsync($"[ERROR] {result.ErrorReason}");
                }
            }
        }

        private async Task DeleteMessage(SocketUserMessage msg)
        {
            await msg.DeleteAsync();
            await msg.Channel.SendMessageAsync("Get that shit outta here!");
        }
    }
}
