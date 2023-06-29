using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almoxarifado.Teste._Builders
{
  
    public class ProdutoBuilder
    {
        // campos
        private int _codigoProduto     = 8;
        private string _nomeProduto    = "Prego 17x27";
        private int _qtdProdutoTotal   = 2;
        private string _unidadeMedida  = "Kilograma";
        private string _categoria      = "Permanente";

        public static ProdutoBuilder Novo() 
        {
            return new ProdutoBuilder();
        }
        public ProdutoTeste.ProdutoTeste.Produto Criar() 
        {
            return new ProdutoTeste.ProdutoTeste.Produto(_codigoProduto, _nomeProduto, _qtdProdutoTotal, _unidadeMedida, _categoria);
        }

        public ProdutoBuilder ComCodigoProduto(int codigoProduto)
        {
            _codigoProduto = codigoProduto;
            return this;
        }

        public ProdutoBuilder ComNomeProduto(string nomeProduto)
        {
            _nomeProduto = nomeProduto;
            return this;
        }

        public ProdutoBuilder ComQtdProdutoTotal(int qtdProdutoTotal)
        {
            _qtdProdutoTotal = qtdProdutoTotal;
            return this;
        }

        public ProdutoBuilder ComUnidadeMedida(string unidadeMedida)
        {
            _unidadeMedida=unidadeMedida;
            return this;
        }

        public ProdutoBuilder ComCategoria(string categoria)
        {
            _categoria = categoria;
            return this;
        }
    }
}
