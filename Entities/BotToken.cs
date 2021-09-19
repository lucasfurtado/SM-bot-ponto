using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PunchTheClock.Entities
{
    class BotToken
    {
        public string Token { get; set; }

        public BotToken() { }

        public void SetToken()
        {
            //StreamReader reader = new StreamReader("E:\\My Projects\\PunchTheClock\\config.json"); //notebook lucas
            StreamReader reader = new StreamReader("C:\\Users\\lucas\\Documents\\Punch-In\\bot-punch-the-clock\\config.json");  //computador lucas
            string jsonString = reader.ReadToEnd();
            BotToken botToken = JsonConvert.DeserializeObject<BotToken>(jsonString);
            Token = botToken.Token;
        }

    }
}
