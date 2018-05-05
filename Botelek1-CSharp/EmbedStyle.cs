using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;
using Discord.Commands;
using Discord;

namespace Botelek1_CSharp
{

    public class EmbedStyles
    {
        public static Embed CreateEmbed(string type, string title, string message, ICommandContext context)
        {
            EmbedBuilder result = new EmbedBuilder();
            switch (type.ToLower())
            {
                case "DR":
                    result.WithTitle("${title}");
                    result.WithDescription($"{message}");
                    result.WithColor(Color.DarkOrange);
                    break;

                case "info":
                    result.WithTitle("${title}");
                    result.WithDescription($"{message}");
                    result.WithColor(Color.Teal);
                    break;
            }
            return result.Build();
        }

    }
}