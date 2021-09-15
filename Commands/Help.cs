using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PunchTheClock.Helpers;

namespace PunchTheClock.Commands
{
    public class Help : BaseCommandModule
    {
        [Command("ajuda")]
        public async Task HelpCommand(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync(
                StaticMessages.Helper.HelloWorld+"\r\n"+
                StaticMessages.Helper.RandomCommand + "\r\n" +
                StaticMessages.Helper.JoinCommand + "\r\n" +
                StaticMessages.Helper.PauseCommand + "\r\n" +
                StaticMessages.Helper.ReJoinCommand + "\r\n" +
                StaticMessages.Helper.ExitCommand + "\r\n" +
                StaticMessages.Helper.TimeCommand + "\r\n" +
                StaticMessages.Helper.StatusCommand + "\r\n"
                );
        }
    }
}
