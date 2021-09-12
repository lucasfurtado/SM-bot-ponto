using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PunchTheClock.Commands
{
    public class Greetings : BaseCommandModule
    {
        [Command("ola")]
        public async Task BotOnline(CommandContext ctx)
        {
            await ctx.RespondAsync("Olá, eu estou online");
        }
    }
}
