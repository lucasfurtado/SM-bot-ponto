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
using PunchTheClock.Entities;

namespace PunchTheClock.Commands
{
    public class PuchingIn : BaseCommandModule
    {
        [Command("entrando")]
        [Aliases("entrei")]
        [Description("Comando para informar ao bot que entrou.")]
        public async Task GetInAsync(CommandContext ctx)
        {
            if (ctx.Channel.Id == StaticVariables.ChannelsId.PunchInChannel)
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
            if (ctx.Channel.Id == StaticVariables.ChannelsId.PunchInChannel)
            {
                PuchingInBBL gBBL = new PuchingInBBL();
                double aux = gBBL.ExitTime(ctx.User.Id);
                if (aux != 0)
                {
                    await ctx.RespondAsync($"{ctx.User.Username} saiu às {DateTime.Now.ToString("HH:mm:ss")}" + $"Tempo total: {aux.ToString("F2")}.");
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

        [Command("time")]
        [Aliases("tempo")]
        [Description("Comando para que o usuário saiba o tempo que está online.")]
        public async Task ReturnTime(CommandContext ctx, [RemainingText] DiscordUser user = null)
        {
            if (ctx.Channel.Id == StaticVariables.ChannelsId.PunchInChannel)
            {
                PuchingInBBL pBBL = new PuchingInBBL();
                double time = 0;
                if (user != null)
                {
                    time = pBBL.CurrentTime(user, ctx);
                    switch (time)
                    {
                        case -1:
                            double currentTime = 0;
                            if (Users.AllUsers.TryGetValue(user.Id, out User auxUser))
                            {
                                currentTime = auxUser.CalculeteTotalTimeAsPaused();
                            }
                            await ctx.RespondAsync($"{user.Username} está online tem {currentTime.ToString("F2")} horas.");
                            //await ctx.RespondAsync($"{user.Username} não foi possível calcular pois o usuário está em pausa e não existe esse método para calcular a hora ainda. Peço perdão pelo vacilo =)");
                            break;
                        case -2:
                            await ctx.RespondAsync($"{user.Username} não entrou ainda.");
                            break;
                        default:
                            await ctx.RespondAsync($"{user.Username} está online {time.ToString("F2")} horas.");
                            break;
                    }
                }
                else
                {
                    time = pBBL.CurrentTime(null, ctx);
                    switch (time)
                    {
                        case -1:
                            double currentTime = 0;
                            if (Users.AllUsers.TryGetValue(ctx.User.Id, out User auxUser))
                            {
                                currentTime = auxUser.CalculeteTotalTimeAsPaused();
                            }
                            await ctx.RespondAsync($"{ctx.User.Username} você está online tem {currentTime.ToString("F2")} horas. Atenção, você ainda está em pausa!");
                            //await ctx.RespondAsync($"{ctx.User.Username} não foi possível calcular pois você está em pausa e não existe esse método para calcular a hora ainda. Peço perdão pelo vacilo =)");
                            break;
                        case -2:
                            await ctx.RespondAsync($"{ctx.User.Username} você não entrou ainda.");
                            break;
                        default:
                            await ctx.RespondAsync($"{ctx.User.Username} está online {time.ToString("F2")} horas.");
                            break;
                    }
                }
            }
            else
            {
                await ctx.RespondAsync(StaticMessages.Unauthorized.UnauthorizedChannel);
            }
        }

        [Command("status")]
        [Aliases("agora")]
        [Description("Comando que informa ao usuário qual status no momento do usuário.")]
        public async Task UserStatus(CommandContext ctx, [RemainingText] DiscordUser user = null)
        {
            if (ctx.Channel.Id == StaticVariables.ChannelsId.PunchInChannel)
            {
                PuchingInBBL pBBL = new PuchingInBBL();
                if (user != null)
                {
                    switch (pBBL.UserStatus(user, ctx))
                    {
                        case 1:
                            await ctx.RespondAsync($"{user.Username} está em pausa.");
                            break;
                        case 2:
                            await ctx.RespondAsync($"{user.Username} está online.");
                            break;
                        case 3:
                            await ctx.RespondAsync($"{user.Username} está offline.");
                            break;
                    }
                }
                else
                {
                    switch (pBBL.UserStatus(user, ctx))
                    {
                        case 1:
                            await ctx.RespondAsync($"{ctx.User.Username} você está em pausa.");
                            break;
                        case 2:
                            await ctx.RespondAsync($"{ctx.User.Username} você está online.");
                            break;
                        case 3:
                            await ctx.RespondAsync($"{ctx.User.Username} você está offline.");
                            break;
                    }
                }
            }
        }
    }
}
