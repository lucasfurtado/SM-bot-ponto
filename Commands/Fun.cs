using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PunchTheClock.Commands
{
    public class Fun : BaseCommandModule
    {
        [Command("Dorondondon")]
        public async Task N4Speed(CommandContext ctx)
        {
            await ctx.RespondAsync("https://www.youtube.com/watch?v=IYH7_GzP4Tg");
        }
    }
}
