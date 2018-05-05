using Discord;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace Botelek1_CSharp.Core
{
    class Program
    {
        DiscordSocketClient _client;
        CommandHandler _service;
        public int Wait = 10000; // 1000 = 1 second


        static void Main(string[] args) => new Program().StartAsync().GetAwaiter().GetResult();


        /* public static void Startup(string[] args)
         {
             // Wait on a single task with no timeout specified.
             Task taskA = Task.Factory.StartNew(() => Task.Delay(-1));
             taskA.Wait();
             Console.WriteLine("taskA has completed.");
             //LoadAllUsers.LoadUsers(_client);
         }*/


        public async Task StartAsync()
        {
            if (Config.bot.Token == "" || Config.bot.Token == null) return;

            _client = new DiscordSocketClient
                (new DiscordSocketConfig
                {
                    LogLevel = LogSeverity.Verbose,
                    MessageCacheSize = 75
                });

            _client.Log += Log;
            _service = new CommandHandler();


            await _client.LoginAsync(TokenType.Bot, Config.bot.Token);
            await _client.StartAsync();

            await _service.InitializeAsync(_client);
            await Task.Delay(Wait);
            await Task.Factory.StartNew(() => LoadAllUsers.LoadUsers(_client));
            await Task.Delay(-1);









        }


        private async Task Log(LogMessage message)
        {
            Console.WriteLine(message.Message);

        }
    }
}