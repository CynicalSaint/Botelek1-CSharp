using Botelek1_CSharp.Core;
using Botelek1_CSharp.Entities;
using Botelek1_CSharp.Services;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Botelek1_CSharp.Modules
{
    public class FirstTest : ModuleBase
    {
        [Command("updatevideos", RunMode = RunMode.Async)]
        public async Task RefreshBannedVideos()
        {
            Config.RefreshVideoLinks();

            await Context.Channel.SendMessageAsync("Video ban list updated");
            //string message = "Current banned urls:\n";

            //message += string.Join("\n", Config.bannedVideos.ToArray());

            //await Context.Channel.SendMessageAsync(message);
        }

        [Command("addvideo", RunMode = RunMode.Async)]
        public async Task AddBannedVideo([Remainder]string url)
        {
            int delay = 3000;

            IMessage message = await Context.Channel.GetMessageAsync(Context.Message.Id);

            if (url.Contains("https://www.youtube.com/") || url.Contains("https://youtu.be/"))
            {
                if (!Config.bannedVideos.Contains(url))
                {
                    Config.AddBannedVideo(url);
                    IUserMessage botMessage = await Context.Channel.SendMessageAsync($"{url} added to ban list. Deleting both messages in {delay / 1000} seconds.");

                    await Task.Delay(delay);

                    await botMessage.DeleteAsync();
                    await message.DeleteAsync();
                }
                else
                {
                    IUserMessage botMessage = await Context.Channel.SendMessageAsync($"{url} is already on the ban list. Deleting both messages in {delay / 1000} seconds.");

                    await Task.Delay(delay);

                    await botMessage.DeleteAsync();
                    await message.DeleteAsync();
                }

            }
            else
            {
                IUserMessage botMessage = await Context.Channel.SendMessageAsync($"{url} is not a valid url, not added to list. Deleting both messages in {delay / 1000} seconds.");

                await Task.Delay(delay);

                await botMessage.DeleteAsync();
                await message.DeleteAsync();
            }
        }

        [Command("ping", RunMode = RunMode.Async)]
        public async Task Pong()
        {
            await Context.Channel.SendMessageAsync($"Pong!");
        }

        [Command("embed", RunMode = RunMode.Async)]
        public async Task EmbedDemo([Remainder]string message)
        {
            EmbedBuilder embed = new EmbedBuilder();
            string[] messageParts = message.Split(":");

            if (messageParts.Length < 2 || messageParts.Length > 3)
            {
                embed.WithTitle("Error!");
                embed.WithDescription("Incorrect syntax, command usage : !embed {title}:{message}:{colour}");
                embed.WithColor(Color.Red);

                await Context.Channel.SendMessageAsync($"", false, embed.Build());
            }

            if (messageParts.Length == 2)
            {
                embed.WithTitle(messageParts[0]);
                embed.WithDescription(messageParts[1]);
                embed.WithColor(Color.Green);

                await Context.Channel.SendMessageAsync($"", false, embed.Build());
            }

            if (messageParts.Length == 3)
            {
                embed.WithTitle(messageParts[0]);
                embed.WithDescription(messageParts[1]);
                embed.WithColor(GetColour(messageParts[2]));

                await Context.Channel.SendMessageAsync($"", false, embed.Build());
            }
        }

        [Command("whisper", RunMode = RunMode.Async)]
        public async Task Whisper()
        {
            IDMChannel dmChannel = await Context.User.GetOrCreateDMChannelAsync();
            await dmChannel.SendMessageAsync("Hey how ya doing lil momma let me whisper in ya ear");
        }

        [Command("template", RunMode = RunMode.Async)]
        public async Task AddTemplate()
        {
            UsersService service = new UsersService();
            service.AddTemplateUser(Context);
            await Context.Channel.SendMessageAsync("Done");
        }

        [Command("add", RunMode = RunMode.Async)]
        public async Task GetData([Remainder] string args)
        {
            string[] Args = args.Split(" ");
            string key = Args[0];
            string value = Args[1];

            BotelekUser checkUser = UsersService.BotelekUsers
                                    .Where(bu => bu.User.Username == Context.Message.Author.Username)
                                    .Select(bu => bu).FirstOrDefault();

            if (checkUser != null)
            {
                checkUser.UserProperties.Add(key, value);
                UsersService.SaveData();
            }
            else
            {
                checkUser = new BotelekUser
                {
                    User = (SocketGuildUser)Context.Message.Author,
                    UserProperties = new Dictionary<string, string>()
                };
                checkUser.UserProperties.Add(key, value);
                UsersService.SaveData();
            }

            await Context.Channel.SendMessageAsync($"User Properties has {UsersService.BotelekUsers.Count} number of users stored in it.");
            await Context.Channel.SendMessageAsync($"User {checkUser.User.Username} has had the following key/value pair added: {key} : {value}");
        }

        private Color GetColour(string colour)
        {
            System.Drawing.Color systemColour = System.Drawing.Color.FromName(colour.Trim());
            return new Color(systemColour.R, systemColour.G, systemColour.B);
        }
    }
}
