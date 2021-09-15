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
            public static string HelloWorld = "\"!ola\" para verificar se estou online.";
            public static string RandomCommand = "\"!random NumeroInicial NumeroFinal\" para retornar um número entrei o mínimo e máximo.";
            public static string JoinCommand = "\"!entrando\" ou \"!entrei\" para informar que entrou.";
            public static string PauseCommand = "\"!pausando\" ou \"!pausa\" para informar que está em pausa.";
            public static string ReJoinCommand = "\"!voltando\" ou \"!voltei\" para informar que voltou da pausa.";
            public static string ExitCommand = "\"!saindo\" ou \"!sair\" para informar que saiu.";
            public static string TimeCommand = "\"!time\" ou \"!time @nome\"(opcional para saber o tempo de alguem), \"!tempo\" ou \"!tempo @nome\"(opcional para saber o tempo de alguem)para verificar quanto tempo você está no serviço.";
            public static string StatusCommand = "\"!status\" ou \"!agora\", \"!status @nome\"(opcional para verificar status de outra pessoa) ou \"!agora @nome\"(opcional para verificar status de outra pessoa) para verificar seu status atual.";
        }
    }
}
