using DSharpPlus;
using DSharpPlus.CommandsNext;
using Newtonsoft.Json;
using PunchTheClock.Commands;
using PunchTheClock.Entities;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using DSharpPlus.EventArgs;
using DSharpPlus.Entities;
using Topshelf;

namespace PunchTheClock
{
    public class Program
    {
        static void Main(string[] args)
        {
            //MainAsync().GetAwaiter().GetResult();

            var exitCode = HostFactory.Run(x =>
            {
                x.Service<DiscordBot>(d =>
                {
                    d.ConstructUsing(disc => new DiscordBot());
                    d.WhenStarted(disc => disc.MainAsync().GetAwaiter().GetResult());
                    d.WhenStopped(disc => disc.Stop());
                });

                x.RunAsLocalSystem();

                x.SetServiceName("ClockBotService");
                x.SetDisplayName("Clock Bot Service");
                x.SetDescription("This is my bot in Windows Service");
            });

            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeValue;
        }
    }
}
