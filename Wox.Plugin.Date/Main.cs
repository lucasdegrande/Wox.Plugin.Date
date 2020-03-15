using System.Collections.Generic;
using System.Windows.Forms;
using Wox.Plugin.Date.Core;

namespace Wox.Plugin.Date
{
    public class Main : IPlugin
    {
        private const string Icone = "Images\\icon.png";
        public void Init(PluginInitContext context)
        {
        }

        public List<Result> Query(Query query)
        {
            var results = new List<Result>();
            var texto = query.Search.Replace(".", "");
            var dataHora = Data.Obter(texto);

            results.Add(new Result()
            {
                Title = $"{dataHora}",
                SubTitle = $"Data/Hora Atual - Enviar para o clipboard",
                IcoPath = Icone,
                Action = e =>
                {
                    EnviarMensagemParaClipboard($"{dataHora}");
                    return true;
                }
            });

            var dataDoInicioDoDiaAteHoraAtual = Script.ObterInicioDoDiaAteHoraAtual(dataHora);
            results.Add(new Result()
            {
                Title = $"Inicio do dia atual até a hora atual para pesquisas no banco",
                SubTitle = $"{dataDoInicioDoDiaAteHoraAtual}",
                IcoPath = Icone,
                Action = e =>
                {
                    EnviarMensagemParaClipboard(dataDoInicioDoDiaAteHoraAtual);
                    return true;
                }
            });

            var diaCompletoParaPesquisaNoBanco = Script.ObterDiaCompleto(dataHora);
            results.Add(new Result()
            {
                Title = $"Dia completo atual para pesquisas no banco",
                SubTitle = $"{diaCompletoParaPesquisaNoBanco}",
                IcoPath = Icone,
                Action = e =>
                {
                    EnviarMensagemParaClipboard(diaCompletoParaPesquisaNoBanco);
                    return true;
                }
            });

            return results;
        }

        private void EnviarMensagemParaClipboard(string mensagem) => Clipboard.SetText(mensagem);
    }
}
