using DSharpPlus;
using Newtonsoft.Json;
using PunchTheClock.Entities;
using System;
using System.IO;
using System.Threading.Tasks;

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

        public static string GetToken()
        {
            StreamReader reader = new StreamReader("E:\\My Projects\\PunchTheClock\\config.json"); //change your local file that contains the token
            string jsonString = reader.ReadToEnd();
            BotToken botToken = JsonConvert.DeserializeObject<BotToken>(jsonString);
            return botToken.Token;
        }
    }
}
