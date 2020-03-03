using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Wox.Plugin.Date
{
    public class Main : IPlugin
    {
        public void Init(PluginInitContext context)
        {
        }

        public List<Result> Query(Query query)
        {
            var results = new List<Result>();

            var dataHoraAtual = DateTime.Now;
            results.Add(new Result()
            {
                Title = $"{dataHoraAtual}",
                SubTitle = $"Data/Hora Atual - Enviar para o clipboard",
                IcoPath = "Images\\icon.png",
                Action = e =>
                {
                    Clipboard.SetText($"{dataHoraAtual}");
                    return true;
                }
            });

            var dataDoInicioDoDiaAteHoraAtual = $@"BETWEEN ""{dataHoraAtual.ToString("yyyy-MM-dd")} 00:00:00"" AND ""{dataHoraAtual.ToString("yyyy-MM-dd HH:mm:ss")}""";
            results.Add(new Result()
            {
                Title = $"Inicio do dia atual até a hora atual para pesquisas no banco",
                SubTitle = $"{dataDoInicioDoDiaAteHoraAtual}",
                IcoPath = "Images\\icon.png",
                Action = e =>
                {
                    Clipboard.SetText(dataDoInicioDoDiaAteHoraAtual);
                    return true;
                }
            });

            var diaCompletoParaPesquisaNoBanco = $@"BETWEEN ""{dataHoraAtual.ToString("yyyy-MM-dd")} 00:00:00"" AND ""{dataHoraAtual.ToString("yyyy-MM-dd")} 23:59:59""";
            results.Add(new Result()
            {
                Title = $"Dia completo atual para pesquisas no banco",
                SubTitle = $"{diaCompletoParaPesquisaNoBanco}",
                IcoPath = "Images\\icon.png",
                Action = e =>
                {
                    Clipboard.SetText(diaCompletoParaPesquisaNoBanco);
                    return true;
                }
            });

            return results;
        }

    }
}
