using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PunchTheClock.Commands
{
    class PuchingIn : BaseCommandModule
    {
        [Command("entrando")]
        public async Task GetIn(CommandContext ctx)
        {
            await ctx.RespondAsync("Entendi o comando entrou!");
        }

        [Command("pausa")]
        public async Task LunchTime(CommandContext ctx)
        {
            await ctx.RespondAsync("Entendi o comando pausa!");
        }

        [Command("voltei")]
        public async Task BackIn(CommandContext ctx)
        {
            await ctx.RespondAsync("Entendi o comando voltei!");
        }


        [Command("sai")]
        public async Task Exit(CommandContext ctx)
        {
            await ctx.RespondAsync("Entendi o comando sai!");
        }
    }
}
