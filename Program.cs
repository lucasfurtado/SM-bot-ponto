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
    class Program
    {
        static void Main(string[] args)
        {
            string bearerToken = GetToken();
            MainAsync(bearerToken).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string token)
        {
            DiscordClient discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = token,
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged,
                GatewayCompressionLevel = GatewayCompressionLevel.Stream,
                ReconnectIndefinitely = true,
                MinimumLogLevel = LogLevel.Debug,
                AutoReconnect = true,
            });

            CommandsNextExtension command = discord.UseCommandsNext(new CommandsNextConfiguration()
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

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }

        public static string GetToken()
        {
            StreamReader reader = new StreamReader("E:\\My Projects\\PunchTheClock\\config.json"); //notebook lucas
            //StreamReader reader = new StreamReader("C:\\Users\\lucas\\Documents\\Punch-In\\bot-punch-the-clock\\config.json");  //computador lucas
            string jsonString = reader.ReadToEnd();
            BotToken botToken = JsonConvert.DeserializeObject<BotToken>(jsonString);
            return botToken.Token;
        }
    }
}
