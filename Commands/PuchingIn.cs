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
            if(ctx.Channel.Id == StaticVariables.ChannelsId.PunchInChannel)
            {
                PuchingInBBL gBBL = new PuchingInBBL();
                if (gBBL.AddUser(ctx.User.Id))
                {
                    DateTime now = new DateTime();
                    await ctx.RespondAsync($"{ctx.User.Username} entrou às {DateTime.Now.ToString("HH:mm:ss")}!");
                }
                else
                {
                    await ctx.RespondAsync($"{ctx.User.Username} você já usuou o comando !entrou antes.");
                }
            }
            else
            {
                await ctx.RespondAsync(StaticMessages.Unauthorized.UnauthorizedChannel);
            }
        }

        [Command("pausando")]
        [Aliases("pausa")]
        [Description("Comando para informar que está ausente no momento.")]
        public async Task LunchTimeAsync(CommandContext ctx)
        {
            if (ctx.Channel.Id == StaticVariables.ChannelsId.PunchInChannel)
            {
                PuchingInBBL gBBL = new PuchingInBBL();
                if (gBBL.PauseTime(ctx.User.Id))
                {
                    await ctx.RespondAsync($"{ctx.User.Username} pausou às {DateTime.Now.ToString("HH:mm:ss")}!");
                }
                else
                {
                    await ctx.RespondAsync($"{ctx.User.Username} você não usou o comando !entrei hoje ou você ainda está em pausa!");
                }
            }
            else
            {
                await ctx.RespondAsync(StaticMessages.Unauthorized.UnauthorizedChannel);
            }
            
        }

        [Command("voltando")]
        [Aliases("voltei")]
        [Description("Comando para informar que o funcionário está voltando da pausa.")]
        public async Task BackInAsync(CommandContext ctx)
        {
            if (ctx.Channel.Id == StaticVariables.ChannelsId.PunchInChannel)
            {
                PuchingInBBL gBBL = new PuchingInBBL();
                if (gBBL.BackIn(ctx.User.Id))
                {
                    await ctx.RespondAsync($"{ctx.User.Username} voltou às {DateTime.Now.ToString("HH:mm:ss")}!");
                }
                else
                {
                    await ctx.RespondAsync($"{ctx.User.Username} você não está em !pausa ou ainda não usou o comando !entrei hoje.");
                }
            }
            else
            {
                await ctx.RespondAsync(StaticMessages.Unauthorized.UnauthorizedChannel);
            }
        }

        [Command("saindo")]
        [Aliases("sair")]
        [Description("Comando para informar que está saindo e para informar quantas horas o funcionário fez hoje.")]
        public async Task ExitAsync(CommandContext ctx)
        {
            if(ctx.Channel.Id == StaticVariables.ChannelsId.PunchInChannel)
            {
                PuchingInBBL gBBL = new PuchingInBBL();
                double aux = gBBL.ExitTime(ctx.User.Id);
                if (aux != 0)
                {
                    await ctx.RespondAsync($"{ctx.User.Username} saiu às {DateTime.Now.ToString("HH:mm:ss")} " + $"Tempo total: {aux.ToString("F2", CultureInfo.InvariantCulture)}.");
                    await gBBL.RemoveUser(ctx.User.Id);
                }
                else
                {
                    await ctx.RespondAsync($"{ctx.User.Username} você não usou !entrei hoje ou ainda está em pausa.");
                }
            }
            else
            {
                await ctx.RespondAsync(StaticMessages.Unauthorized.UnauthorizedChannel);
            }
        }


    }
}
