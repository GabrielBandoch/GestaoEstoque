using ExpectedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste
{
    public class RegistroTeste
    {
        [Fact]
        public void criarObjetoRegistro()
        {
            var reg = RegistroBuilder.Novo().GerarDados().Criar();

            var registroEsperado = new
            {
                DataEntrada = reg.DataEntrada,
                Qtd = reg.Qtd,
                FornecedorCliente = reg.FornecedorCliente,
                MotivoEntrada = reg.MotivoEntrada,
                NumFatura = reg.NumFatura,
                ValorCompra = reg.ValorCompra,
                Codigo = reg.Codigo
            };

            registroEsperado.ToExpectedObject().ShouldMatch(reg);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(0)]
        [InlineData(-1)]
        public void QtdInvalido(int qtdInvalida)
        {
            Assert.Throws<ArgumentException>(
                () =>
                    RegistroBuilder.Novo().GerarDados().ComQtd(qtdInvalida).Criar()
                ).ComMensagem("Quantidade inválida");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ForCli(string forCli)
        {
            Assert.Throws<ArgumentException>(
                () =>
                    RegistroBuilder.Novo().GerarDados().ComForCli(forCli).Criar()
                ).ComMensagem("Fornecedor ou cliente inválido");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void MotivoEntradaInvalido(string motEInvalida)
        {
            Assert.Throws<ArgumentException>(
                () =>
                    RegistroBuilder.Novo().GerarDados().ComMotivo(motEInvalida).Criar()
                ).ComMensagem("Motivo inválido");
        }

        [Theory]
        [InlineData(null)]
        [InlineData(0)]
        [InlineData(-1)]
        public void numFaturaInvalido(int faturaInvalida)
        {
            Assert.Throws<ArgumentException>(
                () =>
                    RegistroBuilder.Novo().GerarDados().ComFatura(faturaInvalida).Criar()
                ).ComMensagem("Numero de fatura inválido");
        }

        [Theory]
        [InlineData(null)]
        [InlineData(0)]
        [InlineData(-1)]
        public void ValorCompraInvalido( decimal valCInvalida)
        {
            Assert.Throws<ArgumentException>(
                () =>
                    RegistroBuilder.Novo().GerarDados().ComValor(valCInvalida).Criar()
                ).ComMensagem("Valor de compra inválido");
        }

        [Theory]
        [InlineData(null)]
        [InlineData(0)]
        [InlineData(-1)]
        public void codigoInvalido(int codInvalida)
        {
            Assert.Throws<ArgumentException>(
                () =>
                    RegistroBuilder.Novo().GerarDados().ComCodigo(codInvalida).Criar()
                ).ComMensagem("Codigo inválido");
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void MotivoSaidaInvalido(string motSInvalida)
        {
            Assert.Throws<ArgumentException>(
                () =>
                    RegistroBuilder.Novo().GerarDados().ComMotivo(motSInvalida).Criar()
                ).ComMensagem("Motivo inválido");
        }

        [Theory]
        [InlineData(null)]
        [InlineData(0)]
        [InlineData(-1)]
        public void ValorVendaInvalido(decimal valVInvalida)
        {
            Assert.Throws<ArgumentException>(
                () =>
                    RegistroBuilder.Novo().GerarDados().ComValor(valVInvalida).Criar()
                ).ComMensagem("Valor de compra inválido");
        }


        [Fact]
        public void AtualizarEstoque()
        {
            // Arrange
            var reg = RegistroBuilder.Novo().GerarDados().Criar();

            // Act
            reg.AtualizarEstoque(15, 22.50m);

            // Assert
            Assert.Equal(15, reg.Qtd);
            Assert.Equal(22.50m, reg.ValorVenda);
        }
        [Fact]
        public void ExcederEstoque()
        {
            // Arrange
            var qtdEstoque = 5; // quantidade disponível em estoque
            var reg = RegistroBuilder.Novo().GerarDados().ComQtd(10).Criar();

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => reg.ExcederEstoque(qtdEstoque));
            Assert.Equal("Quantidade do estoque excedida", exception.Message);
        }




    }
}


