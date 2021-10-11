using System;
using System.Collections.Generic;
using System.Text;

namespace PunchTheClock.Helpers
{
    public class StaticMessages
    {
        public static class Unauthorized
        {
            public static string UnauthorizedChannel = "Comando não autorizado neste canal.";
        }

        public static class Helper
        {
            public static string HelloWorld = "👉\"!ola\" para verificar se estou online.";
            public static string RandomCommand = "👉\"!random NumeroInicial NumeroFinal\".";
            public static string JoinCommand = "👉\"!entrando\" ";
            public static string PauseCommand = "👉\"!pausa\"";
            public static string ReJoinCommand = "👉\"!voltei\"";
            public static string ExitCommand = "👉\"!saindo\"";
            public static string TimeCommand = "👉\"!time\"";
            public static string StatusCommand = "👉\"!status\"";
        }
    }
}
