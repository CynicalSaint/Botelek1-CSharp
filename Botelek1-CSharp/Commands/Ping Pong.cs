using Discord;
using Discord.Commands;
using System.Threading.Tasks;


namespace Botelek1_CSharp.Core
{

    public class Ping : ModuleBase<SocketCommandContext>
    {
        
        [Command(Config.Ping_Pong)]
        public async Task PingAsync()
        {

                EmbedBuilder builder = new EmbedBuilder();

            builder.WithTitle("Ping!")
                .WithDescription($"PONG back to you {Context.User.Mention} (This will be a never ending game of Ping/Pong)")
                .WithColor(Color.DarkRed)
                .WithThumbnailUrl(Config.ThumbnailUrl);

            await ReplyAsync("", false, builder.Build());
            
        }
        }
    }

