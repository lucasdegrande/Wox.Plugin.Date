using System;

namespace Wox.Plugin.Date.Core
{
    public static class Script
    {
        private const string FormatoDataHora = "yyyy-MM-dd HH:mm:ss";
        private const string FormatoDataInicio = "yyyy-MM-dd 00:00:00";
        private const string FormatoDataHoraFinal = "yyyy-MM-dd 23:59:59";

        public static string ObterInicioDoDiaAteHoraAtual(DateTime dataHora)
        {
            return ObterMensagem(dataHora, FormatoDataInicio, FormatoDataHora);
        }

        private static string ObterMensagem(DateTime dataHora, string formatoDataInicial, string formatoDataFinal)
        {
            return $@"BETWEEN '{dataHora.ToString(formatoDataInicial)}' AND '{dataHora.ToString(formatoDataFinal)}'";
        }

        public static string ObterDiaCompleto(DateTime dataHora)
        {
            return ObterMensagem(dataHora, FormatoDataInicio, FormatoDataHoraFinal);
        }

    }
}
