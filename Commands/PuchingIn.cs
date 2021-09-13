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
using PunchTheClock.Helpers;

namespace PunchTheClock.Commands
{
    public class PuchingIn : BaseCommandModule
    {
        [Command("entrando")]
        [Aliases("entrei")]
        [Description("Comando para informar ao bot que entrou.")]
        public async Task GetInAsync(CommandContext ctx)
        {
            PuchingInBBL gBBL = new PuchingInBBL();
            if (gBBL.AddUser(ctx.User.Id))
            {
                await ctx.RespondAsync($"{ctx.User.Username} entrou as {DateTime.Now}!");
            }
            else
            {
                await ctx.RespondAsync($"{ctx.User.Username} você já entrou hoje!");
            }
        }

        [Command("pausando")]
        [Aliases("pausa")]
        [Description("Comando para informar que está ausente no momento.")]
        public async Task LunchTimeAsync(CommandContext ctx)
        {
            PuchingInBBL gBBL = new PuchingInBBL();
            if (gBBL.PauseTime(ctx.User.Id))
            {
                await ctx.RespondAsync($"{ctx.User.Username} pausou as {DateTime.Now}!");
            }
            else
            {
                await ctx.RespondAsync($"{ctx.User.Username} você não usou o comando !entrei hoje ou ainda está em pausa!");
            }
        }

        [Command("voltando")]
        [Aliases("voltei")]
        [Description("Comando para informar que o funcionário está voltando da pausa.")]
        public async Task BackInAsync(CommandContext ctx)
        {
            PuchingInBBL gBBL = new PuchingInBBL();
            if (gBBL.BackIn(ctx.User.Id))
            {
                await ctx.RespondAsync($"{ctx.User.Username} voltou as {DateTime.Now}!");
            }
            else
            {
                await ctx.RespondAsync($"{ctx.User.Username} você não está pausado(a) ou não usou o comando !entrei hoje");
            }
        }


        [Command("saindo")]
        [Aliases("sair")]
        [Description("Comando para informar que está saindo e para informar quantas horas o funcionário fez hoje.")]
        public async Task ExitAsync(CommandContext ctx)
        {
            PuchingInBBL gBBL = new PuchingInBBL();
            double aux = gBBL.ExitTime(ctx.User.Id);
            if(aux != 0)
            {
                await ctx.RespondAsync($"{ctx.User.Username} saiu as {DateTime.Now} " + $"Tempo total: {aux.ToString("F2", CultureInfo.InvariantCulture)}");
                await gBBL.RemoveUser(ctx.User.Id);
            }
            else
            {
                await ctx.RespondAsync($"{ctx.User.Username} você não usou !entrei hoje ou ainda está em pausa");
            }
            
        }
    }
}
