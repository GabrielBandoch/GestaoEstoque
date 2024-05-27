using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


// Dupla: Felipe Da Silva Chawischi & Gabriel Felipe Alves Bandoch
namespace Dominio
{
    public class Produto
    {
        private int codigo;
        private string descricao;
        private string codigoBarras;
        private decimal precoCompra;
        private decimal precoVenda;
        private string categoria;
        private string fornecedor;
        private decimal quantidadeEstoque;
        private decimal valorCusto;

        public Produto(int codigo, string descricao, string codigoBarras, decimal precoCompra, decimal precoVenda, string categoria, string fornecedor)
        {
            if (codigo < 1) throw new ArgumentException("Código Inválido");
            if (string.IsNullOrEmpty(descricao)) throw new ArgumentException("Descrição Obrigatória");
            if (string.IsNullOrEmpty(codigoBarras)) throw new ArgumentException("Código de Barra Obrigátorio");
            if (precoCompra < 1) throw new ArgumentException("Preço Obrigatório");
            if (precoVenda < 1) throw new ArgumentException("Preço de venda Obrigatório");
            if (string.IsNullOrEmpty(categoria)) throw new ArgumentException("Categoria Obrigatória");
            if (string.IsNullOrEmpty(fornecedor)) throw new ArgumentException("Fornecedor Obrigatório");

            this.codigo = codigo;
            this.descricao = descricao;
            this.codigoBarras = codigoBarras;
            this.precoCompra = precoCompra;
            this.precoVenda = precoVenda;
            this.categoria = categoria;
            this.fornecedor = fornecedor;

            this.quantidadeEstoque = 0;
            this.valorCusto = 0;
        }

        public int Codigo { get => codigo; set => codigo = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public string CodigoBarras { get => codigoBarras; set => codigoBarras = value; }
        public decimal PrecoCompra { get => precoCompra; set => precoCompra = value; }
        public decimal PrecoVenda { get => precoVenda; set => precoVenda = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public string Fornecedor { get => fornecedor; set => fornecedor = value; }
        public decimal QuantidadeEstoque { get => quantidadeEstoque; set => quantidadeEstoque = value; }
        public decimal ValorCusto { get => valorCusto; set => valorCusto = value; }

        public void AtualizarInformacoes(decimal novoPrecoVenda)
        {
            if (novoPrecoVenda < 0)
                throw new ArgumentException("Preço de venda inválido");
            this.precoVenda = novoPrecoVenda;
        }

        public static List<Produto> BuscarPorCodigoBarras(List<Produto> produtos, string termoBusca = "")
        {
            List<Produto> resultados = new List<Produto>();

            foreach (Produto produto in produtos)
            {
                if (produto.CodigoBarras.Contains(termoBusca, StringComparison.OrdinalIgnoreCase))
                {
                    resultados.Add(produto);
                }
            }

            return resultados.Take(1).ToList();
        }

        public static List<Produto> BuscarPorDescricao(List<Produto> produtos, string termoBusca = "")
        {
            List<Produto> resultados = new List<Produto>();

            foreach (Produto produto in produtos)
            {
                if (produto.Descricao.Contains(termoBusca, StringComparison.OrdinalIgnoreCase))
                {
                    resultados.Add(produto);
                }
            }

            return resultados.Take(1).ToList();
        }

        public static List<Produto> BuscarPorCategoria(List<Produto> produtos, string termoBusca = "")
        {
            List<Produto> resultados = new List<Produto>();

            foreach (Produto produto in produtos)
            {
                if (produto.Categoria.Contains(termoBusca, StringComparison.OrdinalIgnoreCase))
                {
                    resultados.Add(produto);
                }
            }

            return resultados;
        }






    }
}
