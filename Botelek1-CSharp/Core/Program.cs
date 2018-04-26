using Discord;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace Botelek1_CSharp.Core
{
    class Program
    {
        DiscordSocketClient _client;
        CommandHandler _commands;

        static void Main(string[] args) => new Program().StartAsync().GetAwaiter().GetResult();

        public async Task StartAsync()
        {
            if (Config.bot.Token == "" || Config.bot.Token == null) return;

            _client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Verbose,
                MessageCacheSize = 75
            });

            _client.Log += Log;
            _commands = new CommandHandler();

            await _client.LoginAsync(TokenType.Bot, Config.bot.Token);
            await _client.StartAsync();

            await _commands.InitializeAsync(_client);
            await Task.Delay(-1);
        }

        private async Task Log(LogMessage message)
        {
            Console.WriteLine(message.Message);
        }
    }
}
