using Bogus;
using Bogus.DataSets;
using Dominio;
using ExpectedObjects;
using System;
using System.Collections.Generic;
using Xunit;

namespace Teste
{
    public class FornecedorTeste
    {
        [Fact]
        public void CriarObjetoFornecedor()
        {
            var fornecedor = FornecedorBuilder.Novo().GerarDados().Criar();

            var fornecedorEsperado = new
            {
                Id = fornecedor.Id,
                Nome = fornecedor.Nome,
                Endereco = fornecedor.Endereco,
                Email = fornecedor.Email,
                Telefone = fornecedor.Telefone,
                TermosPagamento = fornecedor.TermosPagamento
            };
            fornecedorEsperado.ToExpectedObject().ShouldMatch(fornecedor);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(0)]
        [InlineData(-1)]
        public void FornecedorCodigoInvalido(int id)
        {
            Assert.Throws<ArgumentException>(
            () =>
                FornecedorBuilder.Novo().GerarDados().ComCodigo(id).Criar()
                ).ComMensagem("Código Inválido");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void FornecedorNomeInvalido(string nome)
        {
            Assert.Throws<ArgumentException>(
                () =>
                FornecedorBuilder.Novo().GerarDados().ComNome(nome).Criar()
                ).ComMensagem("Nome da empresa é obrigatório");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void FornecedorEnderecoInvalido(string end)
        {
            Assert.Throws<ArgumentException>(
                () =>
                FornecedorBuilder.Novo().GerarDados().ComEndereco(end).Criar()
                ).ComMensagem("Endereço é obrigatório");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("teste@")]
        [InlineData("teste@.co")]
        [InlineData("@gmail.com")]
        [InlineData("@sjak.c")]
        public void FornecedorEmailInvalido(string email)
        {
            Assert.Throws<ArgumentException>(
                () =>
                FornecedorBuilder.Novo().GerarDados().ComEmail(email).Criar()
                ).ComMensagem("Email Inválido");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void FornecedorTelefoneInvalido(string tel)
        {
            Assert.Throws<ArgumentException>(
                () =>
                FornecedorBuilder.Novo().GerarDados().ComTelefone(tel).Criar()
                ).ComMensagem("Telefone é obrigatório");
        }

        [Fact]
        public void AtualizarFornecedor()
        {
            var fornecedor = FornecedorBuilder.Novo().GerarDados().Criar();
            var novoEndereco = "Nova Rua, 123";
            var novoTelefone = "987654321";
            var novoEmail = "novoemail@email.com";
            var novosTermosPagamento = "60 dias";

            fornecedor.Atualizar(novoEndereco, novoTelefone, novoEmail, novosTermosPagamento);

            Assert.Equal(novoEndereco, fornecedor.Endereco);
            Assert.Equal(novoTelefone, fornecedor.Telefone);
            Assert.Equal(novoEmail, fornecedor.Email);
            Assert.Equal(novosTermosPagamento, fornecedor.TermosPagamento);
        }

        [Fact]
        public void BuscarFornecedoresPorNome()
        {
            
        var fornecedores = new List<Fornecedor>
        {
            FornecedorBuilder.Novo().GerarDados().ComNome("Empresa A").Criar(),
            FornecedorBuilder.Novo().GerarDados().ComNome("Empresa B").Criar(),
            FornecedorBuilder.Novo().GerarDados().ComNome("Empresa C").Criar()
        };

            var resultados = Fornecedor.BuscarFornecedores(fornecedores, "Empresa");

            Assert.Equal(3, resultados.Count);
        }

        [Fact]
        public void BuscarFornecedoresPorEmail()
        {
            // Arrange
            var fornecedores = new List<Fornecedor>
            {
                FornecedorBuilder.Novo().GerarDados().ComEmail("email1@email.com").Criar(),
                FornecedorBuilder.Novo().GerarDados().ComEmail("email2@email.com").Criar(),
                FornecedorBuilder.Novo().GerarDados().ComEmail("email3@email.com").Criar()
            };

            var resultados = Fornecedor.BuscarFornecedores(fornecedores, "email");

            Assert.Equal(3, resultados.Count);
        }

        [Fact]
        public void FornecedorNomeDuplicado()
        {
            var fornecedorExistente = FornecedorBuilder.Novo().GerarDados().Criar();

            Assert.Throws<ArgumentException>(() =>
                FornecedorBuilder.Novo().ComNome(fornecedorExistente.Nome).Criar()
            ).ComMensagem("Já existe um fornecedor com esse nome");
        }

        [Fact]
        public void FornecedorTelefoneDuplicado()
        {
            var fornecedorExistente = FornecedorBuilder.Novo().GerarDados().Criar();

            Assert.Throws<ArgumentException>(() =>
                FornecedorBuilder.Novo().ComTelefone(fornecedorExistente.Telefone).Criar()
            ).ComMensagem("Já existe um fornecedor com esse número de telefone");
        }
    }
}