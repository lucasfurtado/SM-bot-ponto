using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PunchTheClock.Commands
{
    class GenerateRandomNumber : BaseCommandModule
    {
        [Command("random")]
        public async Task GererateRandomNumberAsync(CommandContext ctx, int min, int max)
        {
            await ctx.TriggerTypingAsync();
            Random random = new Random();
            int number = random.Next(min,max);
            await ctx.RespondAsync($"Seu número é: {number}");
        }
    }
}
