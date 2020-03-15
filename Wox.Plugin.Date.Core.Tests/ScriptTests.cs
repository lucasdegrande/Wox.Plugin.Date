using System;
using Xunit;

namespace Wox.Plugin.Date.Core.Tests
{
    public class ScriptTests
    {
        [Fact]
        public void ObterInicioDoDiaAteHoraAtual_DataInformada_DeveRetornarZeroHorasAteHoraAtual()
        {
            var dataInformada = new DateTime(2020, 03, 15, 20, 00, 00);

            var resultadoEsperado = "BETWEEN '2020-03-15 00:00:00' AND '2020-03-15 20:00:00'";
            Assert.Equal(resultadoEsperado, Script.ObterInicioDoDiaAteHoraAtual(dataInformada));
        }

        [Fact]
        public void ObterDiaCompleto_DataInformada_DeveRetornarZeroHorasAteUltimoSegundoDoDia()
        {
            var dataInformada = new DateTime(2020, 03, 15, 20, 20, 20);
            var resultadoEsperado = "BETWEEN '2020-03-15 00:00:00' AND '2020-03-15 23:59:59'";
            Assert.Equal(resultadoEsperado, Script.ObterDiaCompleto(dataInformada));
        }
    }
}

