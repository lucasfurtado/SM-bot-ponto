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
        public static DiscordClient _discord;

        static void Main(string[] args)
        {
            string bearerToken = GetToken();
            MainAsync(bearerToken).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string token)
        {
            _discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = token,
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
                EnableDms = false
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

        public static string GetToken()
        {
            //StreamReader reader = new StreamReader("E:\\My Projects\\PunchTheClock\\config.json"); //notebook lucas
            StreamReader reader = new StreamReader("C:\\Users\\lucas\\Documents\\Punch-In\\bot-punch-the-clock\\config.json");  //computador lucas
            string jsonString = reader.ReadToEnd();
            BotToken botToken = JsonConvert.DeserializeObject<BotToken>(jsonString);
            return botToken.Token;
        }
    }
}
