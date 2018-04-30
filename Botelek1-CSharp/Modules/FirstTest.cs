using Discord;
using Discord.Commands;
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

        private Color GetColour(string colour)
        {
            System.Drawing.Color systemColour = System.Drawing.Color.FromName(colour.Trim());
            return new Color(systemColour.R, systemColour.G, systemColour.B);
        }

    }
}
