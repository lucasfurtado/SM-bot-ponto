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
        public string ConfigFile { get; set; }

        public BotToken()
        {
            ConfigFile = "config.json";
        }

        public void SetToken()
        {
            //StreamReader reader = new StreamReader("E:\\My Projects\\PunchTheClock\\config.json"); //notebook lucas
            string path = AppDomain.CurrentDomain.BaseDirectory + ConfigFile;
            StreamReader reader = new StreamReader(path);
            string jsonString = reader.ReadToEnd();
            BotToken botToken = JsonConvert.DeserializeObject<BotToken>(jsonString);
            Token = botToken.Token;
        }

    }
}
