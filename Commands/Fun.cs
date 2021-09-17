using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PunchTheClock.Helpers;
using DSharpPlus.Entities;
using System.Linq;
using DSharpPlus.VoiceNext;
using DSharpPlus;

namespace PunchTheClock.Commands
{
    public class Fun : BaseCommandModule
    {
        [Command("dorondondon")]
        public async Task N4Speed(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            if (ctx.Channel.Id != StaticVariables.ChannelsId.PunchInChannel)
            {
                await ctx.RespondAsync("https://www.youtube.com/watch?v=IYH7_GzP4Tg");
            }
            else
            {
                await ctx.RespondAsync(StaticMessages.Unauthorized.UnauthorizedChannel);
            }
        }

        [Command("daily")]
        public async Task TestDayli(CommandContext ctx, [RemainingText] DiscordChannel channel = null)
        {
            await ctx.TriggerTypingAsync();
            ulong dailyChannel = (channel != null) ? channel.Id : StaticVariables.ChannelsId.DailyChannel;
            if (ctx.Guild.OwnerId == ctx.User.Id)
            {
                List<DiscordMember> listDiscordMembers = new List<DiscordMember>();
                List<ulong> listId = new List<ulong>();
                var aux = ctx.Guild.Members;
                for (int i = 0; i < aux.Count; i++)
                {
                    listId = aux.Select(x => x.Key).ToList();
                }
                foreach (var item in listId)
                {
                    if(aux.TryGetValue(item, out DiscordMember member))
                    {
                        await member.PlaceInAsync(ctx.Guild.GetChannel(dailyChannel));
                    }
                }
            }
        }

        [Command("joinbot")]
        public async Task Join(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            var vnexta = ctx.Client.UseVoiceNext();
            var vnc = vnexta.GetConnection(ctx.Guild);
            if (vnc != null)
                throw new InvalidOperationException("Eu já estou conectado no canal.");

            var chn = ctx.Member?.VoiceState?.Channel;
            if (chn == null)
                throw new InvalidOperationException("Você precisa estar em um canal para me puxar.");

            vnc = await vnexta.ConnectAsync(chn);
            await ctx.RespondAsync("👌");
        }
    }
}
