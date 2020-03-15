using System.Collections.Generic;
using System.Windows.Forms;
using Wox.Plugin.Date.Core;

namespace Wox.Plugin.Date
{
    public class Main : IPlugin
    {
        private string texto;

        public void Init(PluginInitContext context)
        {
        }

        public List<Result> Query(Query query)
        {
            var results = new List<Result>();
            texto = query.Search.Replace(".", "");
            var dataHora = Data.Obter(texto);

            results.Add(new Result()
            {
                Title = $"{dataHora}",
                SubTitle = $"Data/Hora Atual - Enviar para o clipboard",
                IcoPath = "Images\\icon.png",
                Action = e =>
                {
                    Clipboard.SetText($"{dataHora}");
                    return true;
                }
            });

            var dataDoInicioDoDiaAteHoraAtual = $@"BETWEEN '{dataHora.ToString("yyyy-MM-dd")} 00:00:00' AND '{dataHora.ToString("yyyy-MM-dd HH:mm:ss")}'";
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

            var diaCompletoParaPesquisaNoBanco = $@"BETWEEN '{dataHora.ToString("yyyy-MM-dd")} 00:00:00' AND '{dataHora.ToString("yyyy-MM-dd")} 23:59:59'";
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
