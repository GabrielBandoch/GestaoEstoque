using Bogus;
using Dominio;
using ExpectedObjects;
using System.Numerics;

namespace Teste
{
    public class ClienteTeste
    {
        [Fact]
        public void CriarObjetoCliente()
        {
            var cli = ClienteBuilder.Novo().GerarDados().Criar();

            var clienteEsperado = new
            {
                Codigo = cli.Codigo,
                Nome = cli.Nome,
                Endereco = cli.Endereco,
                Email = cli.Email,
                Telefone = cli.Telefone
            };

            clienteEsperado.ToExpectedObject().ShouldMatch(cli);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(0)]
        [InlineData(-1)]
        public void ClienteCodigoInvalido(int cod)
        {
            Assert.Throws<ArgumentException>(
                () =>
                ClienteBuilder.Novo().GerarDados().ComCodigo(cod).Criar()
                ).ComMensagem("Código Inválido");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ClienteNomeInvalido(string nome)
        {
            Assert.Throws<ArgumentException>(
                () =>
                ClienteBuilder.Novo().GerarDados().ComNome(nome).Criar()
                ).ComMensagem("Nome Inválido");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ClienteEnderecoInvalido(string end)
        {
            Assert.Throws<ArgumentException>(
                () =>
                ClienteBuilder.Novo().GerarDados().ComEndereco(end).Criar()
                ).ComMensagem("Endereço Inválido");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("teste@")]
        [InlineData("teste@.co")]
        [InlineData("@gmail.com")]
        [InlineData("@sjak.c")]
        public void ClienteEmailInvalido(string email)
        {
            Assert.Throws<ArgumentException>(
                () =>
                ClienteBuilder.Novo().GerarDados().ComEmail(email).Criar()
                ).ComMensagem("Email Inválido");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ClienteTelefoneInvalido(string tel)
        {
            Assert.Throws<ArgumentException>(
                () =>
                ClienteBuilder.Novo().GerarDados().ComTelefone(tel).Criar()
                ).ComMensagem("Telefone inválido");
        }

        [Fact]
        public void AtualizarInformacoesCliente()
        {
            var cliente = ClienteBuilder.Novo().GerarDados().Criar();

            cliente.AtualizarInformacoes("Novo Endereço", "987654321");

            Assert.Equal("Novo Endereço", cliente.Endereco);
            Assert.Equal("987654321", cliente.Telefone);
        }

        [Fact]
        public void BuscarClientePorNome()
        {
            var cliente1 = ClienteBuilder.Novo().GerarDados().Criar();
            var cliente2 = ClienteBuilder.Novo().GerarDados().ComNome("João").Criar();
            var cliente3 = ClienteBuilder.Novo().GerarDados().ComNome("Maria").Criar();
            var clientes = new List<Cliente> { cliente1, cliente2, cliente3 };

            var resultado = Cliente.BuscarCliente(clientes, "Maria");

            Assert.Single(resultado);
            Assert.Equal("Maria", resultado.First().Nome);
        }

        [Fact]
        public void BuscarClientePorEmail()
        {
            var cliente1 = ClienteBuilder.Novo().GerarDados().Criar();
            var cliente2 = ClienteBuilder.Novo().GerarDados().ComEmail("joao@teste.com").Criar();
            var cliente3 = ClienteBuilder.Novo().GerarDados().ComEmail("maria@teste.com").Criar();
            var clientes = new List<Cliente> { cliente1, cliente2, cliente3 };

            var resultado = Cliente.BuscarCliente(clientes, "joao@teste.com");

            Assert.Single(resultado);
            Assert.Equal("joao@teste.com", resultado.First().Email);
        }

        [Fact]
        public void BuscarClientePorTelefone()
        {
            var cliente1 = ClienteBuilder.Novo().GerarDados().Criar();
            var cliente2 = ClienteBuilder.Novo().GerarDados().ComTelefone("987654321").Criar();
            var cliente3 = ClienteBuilder.Novo().GerarDados().ComTelefone("123456789").Criar();
            var clientes = new List<Cliente> { cliente1, cliente2, cliente3 };

            var resultado = Cliente.BuscarCliente(clientes, "987654321");

            Assert.Single(resultado);
            Assert.Equal("987654321", resultado.First().Telefone);
        }

        [Fact]
        public void ClienteNomeDuplicado()
        {
            var clienteExistente = ClienteBuilder.Novo().GerarDados().Criar();

            Assert.Throws<ArgumentException>(() =>
                ClienteBuilder.Novo().ComNome(clienteExistente.Nome).Criar()
            ).ComMensagem("Já existe um cliente com esse nome");
        }

        [Fact]
        public void ClienteTelefoneDuplicado()
        {
            var clienteExistente = ClienteBuilder.Novo().GerarDados().Criar();

            Assert.Throws<ArgumentException>(() =>
                ClienteBuilder.Novo().ComTelefone(clienteExistente.Telefone).Criar()
            ).ComMensagem("Já existe um cliente com esse número de telefone");
        }













    }
}