using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PunchTheClock.Helpers;
using DSharpPlus.Entities;
using System.Linq;

namespace PunchTheClock.Commands
{
    public class Fun : BaseCommandModule
    {
        [Command("dorondondon")]
        public async Task N4Speed(CommandContext ctx)
        {
            if(ctx.Channel.Id != StaticVariables.ChannelsId.PunchInChannel)
            {
                await ctx.RespondAsync("https://www.youtube.com/watch?v=IYH7_GzP4Tg");
            }
            else
            {
                await ctx.RespondAsync(StaticMessages.Unauthorized.UnauthorizedChannel);
            }
        }

        [Command("testDaily")]
        public async Task Pull(CommandContext ctx)
        {
            if (ctx.Guild.OwnerId == 437051906599157761)
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
                        ctx.Channel.PlaceMemberAsync(member);
                    }
                }
            }
        }
    }
}
