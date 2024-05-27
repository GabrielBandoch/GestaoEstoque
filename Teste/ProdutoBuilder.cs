using Bogus;
using Bogus.DataSets;
using Dominio;
using System;

namespace Teste
{
    internal class ProdutoBuilder
    {
        private int codigo = 1;
        private string descricao = "Produto ABC";
        private string codigoBarras = "123456789";
        private decimal precoCompra = 100.00m;
        private decimal precoVenda = 150.00m;
        private string categoria = "Roupas";
        private string fornecedor = "Fornecedor XYZ";

        public static ProdutoBuilder Novo()
        {
            return new ProdutoBuilder();
        }

        public Produto Criar()
        {
            return new Produto(
                codigo,
                descricao,
                codigoBarras,
                precoCompra,
                precoVenda,
                categoria,
                fornecedor
            );
        }

        public ProdutoBuilder GerarDados()
        {
            Faker faker = new Faker();

            codigo = faker.Random.Int(1, 999);
            descricao = faker.Random.String();
            codigoBarras = faker.Random.Long(1000000000000, 9999999999999).ToString();
            precoCompra = faker.Random.Decimal(1234.23m, 59923.52m);
            precoVenda = faker.Random.Decimal(2412.57m, 72300.99m);
            categoria = faker.Random.String();
            fornecedor = faker.Random.String();

            return this;
        }

        public ProdutoBuilder ComCodigo(int codigo)
        {
            this.codigo = codigo;
            return this;
        }

        public ProdutoBuilder ComDescricao(string descricao)
        {
            this.descricao = descricao;
            return this;
        }

        public ProdutoBuilder ComCodigoBarras(string codigoBarras)
        {
            this.codigoBarras = codigoBarras;
            return this;
        }

        public ProdutoBuilder ComPrecoCompra(decimal precoCompra)
        {
            this.precoCompra = precoCompra;
            return this;
        }

        public ProdutoBuilder ComPrecoVenda(decimal precoVenda)
        {
            this.precoVenda = precoVenda;
            return this;
        }

        public ProdutoBuilder ComCategoria(string categoria)
        {
            this.categoria = categoria;
            return this;
        }

        public ProdutoBuilder ComFornecedor(string fornecedor)
        {
            this.fornecedor = fornecedor;
            return this;
        }
    }
}
