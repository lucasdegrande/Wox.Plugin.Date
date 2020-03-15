using System;
using Xunit;

namespace Wox.Plugin.Date.Core.Tests
{
    public class DataTests
    {
        [Fact]
        public void Obter_TextoNaoInformado_DeveRetornarDataAtual()
        {
            Assert.Equal(DateTime.Now.Date, Data.Obter().Date);
        }

        [Theory]
        [InlineData("ontem")]
        [InlineData("ONTEM")]
        public void Obter_OntemInformado_DeveRetornarDataDeOntem(string texto)
        {
            var dataDeOntem = DateTime.Now.AddDays(-1);
            Assert.Equal(dataDeOntem.Date, Data.Obter(texto).Date);
        }

        [Theory]
        [InlineData("20/01/2020")]
        [InlineData("20-01-2020")]
        [InlineData("2020-01-20")]
        public void Obter_DataSemHoraInformada_DeveRetornarDataInformada(string texto)
        {
            var dataEsperada = new DateTime(2020, 01, 20);
            Assert.Equal(dataEsperada, Data.Obter(texto));
        }

        [Theory]
        [InlineData("15/03/2020 12:59:59")]
        [InlineData("15-03-2020 12:59:59")]
        [InlineData("2020-03-15 12:59:59")]
        public void Obter_DataComHoraInformada_DeveRetornarDataInformada(string texto)
        {
            var dataEsperada = new DateTime(2020, 03, 15, 12, 59, 59);
            Assert.Equal(dataEsperada, Data.Obter(texto));
        }
    }
}
