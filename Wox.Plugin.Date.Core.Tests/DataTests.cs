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
    }
}
