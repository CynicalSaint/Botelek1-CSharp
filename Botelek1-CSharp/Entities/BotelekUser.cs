using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;

namespace Botelek1_CSharp.Entities
{
    public class BotelekUser
    {
        public SocketGuildUser User { get; set; }
        public Dictionary<string, string> UserProperties { get; set; }
    }
}
