using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Discord.WebSocket;

namespace Botelek1_CSharp
{
    public class DiscordUser
    {
        public String Username { get; set; }
        public String DailyReminder { get; set; }
        public String Motd { get; set; }


    }

    public class UserDetails
    {
        public String DailyReminder { get; set; }
        public String Motd { get; set; }
    }


}