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

namespace PunchTheClock
{
    public class Program
    {
        private static DiscordClient _discord;

        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            BotToken newToken = new BotToken();
            newToken.SetToken();

            _discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = newToken.Token,
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged,
                GatewayCompressionLevel = GatewayCompressionLevel.Stream,
                ReconnectIndefinitely = true,
                MinimumLogLevel = LogLevel.Debug,
                AutoReconnect = true,
            });

            _discord.Ready += Bot_Ready;

            CommandsNextExtension command = _discord.UseCommandsNext(new CommandsNextConfiguration()
            {
                StringPrefixes = new[] { "!" },
                CaseSensitive = false,
                IgnoreExtraArguments = true,
                EnableDms = false,
            });

            command.RegisterCommands<Greetings>();
            command.RegisterCommands<GenerateRandomNumber>();
            command.RegisterCommands<PuchingIn>();
            command.RegisterCommands<Fun>();
            command.RegisterCommands<Help>();

            await _discord.ConnectAsync();
            await Task.Delay(-1);
        }

        public static Task Bot_Ready(DiscordClient sender, ReadyEventArgs e)
        {
            _discord.UpdateStatusAsync(new DiscordActivity("!ajuda", ActivityType.Playing), UserStatus.Online);
            return Task.CompletedTask;
        }
    }
}
