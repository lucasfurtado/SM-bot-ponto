using DSharpPlus;
using System;
using System.Threading.Tasks;

namespace PunchTheClock
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            DiscordClient discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = "ODg1NjM1NzY3MTYwOTQyNjQy.YTp6lQ.RW7OFlZHmr8y8TL_3um-IS7M0HU",
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged
            });

            discord.MessageCreated += async (s, e) =>
            {
                if (e.Message.Content.ToLower().StartsWith("ping"))
                    await e.Message.RespondAsync("pong!");
            };

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
