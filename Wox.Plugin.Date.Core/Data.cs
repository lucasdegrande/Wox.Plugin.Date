using System;

namespace Wox.Plugin.Date.Core
{
    public static class Data
    {
        public static DateTime Obter(string texto = null)
        {
            var resultado = DateTime.Now;

            if (string.IsNullOrEmpty(texto))
                return resultado;

            if (texto.ToLower() == "ontem")
                return resultado.AddDays(-1);

            DateTime.TryParse(texto, out resultado);

            return resultado;
        }
    }
}
