using Dominio;
using ExpectedObjects;
using Xunit;

namespace Teste
{
    public class ProdutoTeste
    {
        [Fact]
        public void CriarObjetoProduto()
        {
            var produto = ProdutoBuilder.Novo().GerarDados().Criar();

            var produtoEsperado = new
            {
                Codigo = produto.Codigo,
                Descricao = produto.Descricao,
                CodigoBarras = produto.CodigoBarras,
                PrecoCompra = produto.PrecoCompra,
                PrecoVenda = produto.PrecoVenda,
                Categoria = produto.Categoria,
                Fornecedor = produto.Fornecedor
            };
            produtoEsperado.ToExpectedObject().ShouldMatch(produto);
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
        public void ProdutoDescricaoInvalido(string Descricao)
        {
            Assert.Throws<ArgumentException>(
                () =>
                ProdutoBuilder.Novo().GerarDados().ComDescricao(Descricao).Criar()
                ).ComMensagem("Descrição Obrigatória");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ProdutoCodigoBarraInvalido(string CodBarra)
        {
            Assert.Throws<ArgumentException>(
                () =>
                ProdutoBuilder.Novo().GerarDados().ComCodigoBarras(CodBarra).Criar()
                ).ComMensagem("Código de Barra Obrigátorio");
        }

        [Theory]
        [InlineData(null)]
        [InlineData(0)]
        [InlineData(-1)]
        public void PrecoCompraInvalido(int precoCompra)
        {
            Assert.Throws<ArgumentException>(
                () =>
                ProdutoBuilder.Novo().GerarDados().ComPrecoCompra(precoCompra).Criar()
                ).ComMensagem("Preço Obrigatório");
        }

        [Theory]
        [InlineData(null)]
        [InlineData(0)]
        [InlineData(-1)]
        public void PreçoVendaInvalido(int precoVenda)
        {
            Assert.Throws<ArgumentException>(
                () =>
                ProdutoBuilder.Novo().GerarDados().ComPrecoVenda(precoVenda).Criar()
                ).ComMensagem("Preço de venda Obrigatório");
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void CategoriaObrigatoria(string categoria)
        {
            Assert.Throws<ArgumentException>(
                () =>
                ProdutoBuilder.Novo().GerarDados().ComCategoria(categoria).Criar()
                ).ComMensagem("Categoria Obrigatória");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void FornecedorObrigatorio(string fornecedor)
        {
            Assert.Throws<ArgumentException>(
                () =>
                ProdutoBuilder.Novo().GerarDados().ComFornecedor(fornecedor).Criar()
                ).ComMensagem("Fornecedor Obrigatório");
        }

        [Fact]
        public void AtualizarPrecoVenda()
        {
            var produto = ProdutoBuilder.Novo().GerarDados().Criar();
            var novoPrecoVenda = 200.00m;

            produto.AtualizarInformacoes(novoPrecoVenda);

            Assert.Equal(novoPrecoVenda, produto.PrecoVenda);
        }

        [Fact]
        public void BuscarDescricao()
        {
            var produtos = new List<Produto>
            {
                new Produto(1, "Camisa Azul", "123456789", 20.00m, 30.00m, "Vestuário", "Fornecedor A"),
                new Produto(2, "Calça Jeans", "987654321", 50.00m, 70.00m, "Vestuário", "Fornecedor B"),
                new Produto(3, "Tênis Preto", "456123789", 80.00m, 100.00m, "Calçado", "Fornecedor C")
            };

            var resultados = Produto.BuscarPorDescricao(produtos, "Azul");

            Assert.Single(resultados);
            Assert.Equal("Camisa Azul", resultados[0].Descricao);
        }

        [Fact]
        public void BuscarCodigoBarras()
        {
            var produtos = new List<Produto>
            {
                new Produto(1, "Camisa Azul", "123456789", 20.00m, 30.00m, "Vestuário", "Fornecedor A"),
                new Produto(2, "Calça Jeans", "987654321", 50.00m, 70.00m, "Vestuário", "Fornecedor B"),
                new Produto(3, "Tênis Preto", "456123789", 80.00m, 100.00m, "Calçado", "Fornecedor C")
            };

            var resultados = Produto.BuscarPorCodigoBarras(produtos, "123");

            Assert.Single(resultados);
            Assert.Equal("Camisa Azul", resultados[0].Descricao);
        }



        [Fact]
        public void BuscarCategoria()
        {
            var produtos = new List<Produto>
            {
                new Produto(1, "Camisa Azul", "123456789", 20.00m, 30.00m, "Vestuário", "Fornecedor A"),
                new Produto(2, "Calça Jeans", "987654321", 50.00m, 70.00m, "Vestuário", "Fornecedor B"),
                new Produto(3, "Tênis Preto", "456123789", 80.00m, 100.00m, "Calçado", "Fornecedor C")
            };

            var resultados = Produto.BuscarPorCategoria(produtos, "Vestuário");

            Assert.Equal(2, resultados.Count);
            Assert.Contains(produtos[0], resultados);
            Assert.Contains(produtos[1], resultados);
        }

    }
}
