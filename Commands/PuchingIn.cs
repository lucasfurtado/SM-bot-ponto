using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using PunchTheClock.BBL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace PunchTheClock.Commands
{
    public class PuchingIn : BaseCommandModule
    {
        [Command("entrando")]
        public async Task GetInAsync(CommandContext ctx)
        {
            PuchingInBBL gBBL = new PuchingInBBL();
            await gBBL.AddUser(ctx.User.Id);
            await ctx.RespondAsync($"{ctx.User.Username} entrou as {DateTime.Now}!");
        }

        [Command("pausa")]
        public async Task LunchTimeAsync(CommandContext ctx)
        {
            PuchingInBBL gBBL = new PuchingInBBL();
            await gBBL.PauseTime(ctx.User.Id);
            await ctx.RespondAsync($"{ctx.User.Username} pausou as {DateTime.Now}!");
        }

        [Command("voltei")]
        public async Task BackInAsync(CommandContext ctx)
        {
            PuchingInBBL gBBL = new PuchingInBBL();
            await gBBL.BackIn(ctx.User.Id);
            await ctx.RespondAsync($"{ctx.User.Username} voltou as {DateTime.Now}!");
        }


        [Command("saindo")]
        public async Task ExitAsync(CommandContext ctx)
        {
            PuchingInBBL gBBL = new PuchingInBBL();
            double aux = gBBL.ExitTime(ctx.User.Id);
            await ctx.RespondAsync($"{ctx.User.Username}! saiu as {DateTime.Now} " + $"Tempo total: {aux.ToString("F2",CultureInfo.InvariantCulture)}");
        }
    }
}
