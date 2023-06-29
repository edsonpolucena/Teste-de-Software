using Almoxarifado.Teste._Builders;
using Almoxarifado.Teste._Util;
using Bogus;
using ExpectedObjects;

namespace ProdutoTeste
{
    public class ProdutoTeste
    {
        private int _codigoProduto;
        private string _nomeProduto;
        private int _qtdProdutoTotal;
        private string _unidadeMedida;
        private string _categoria;

        public ProdutoTeste()
        {
            Faker faker = new Faker();
            this._codigoProduto = faker.Random.Int(1, 100);
            this._nomeProduto = faker.Random.Words(20);
            this._qtdProdutoTotal = faker.Random.Int(1, 1000);
            this._unidadeMedida = faker.Random.Words(20);
            this._categoria= faker.Random.Words(20);

        }

        
        [Fact]
        public void CriarProduto()
        {
            // Arrange
            var produtoEsperado = new
            {
                CodigoProduto = _codigoProduto,
                NomeProduto = _nomeProduto,
                QtdProdutoTotal = _qtdProdutoTotal,
                UnidadeMedida = _unidadeMedida,
                Categoria = _categoria
            };

            // Act
            Produto novoProduto = new Produto(
                    produtoEsperado.CodigoProduto,
                    produtoEsperado.NomeProduto,
                    produtoEsperado.QtdProdutoTotal,
                    produtoEsperado.UnidadeMedida,
                    produtoEsperado.Categoria);

            // Assert
            produtoEsperado.ToExpectedObject().ShouldMatch(novoProduto);
        }
        
        
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void ProdutoCodigoInvalido(int codigoProduto)
        {
            Assert.Throws<ArgumentException>( () =>
                ProdutoBuilder.Novo().ComCodigoProduto(codigoProduto).Criar()
            ).ComMensagem("Codigo Produto Inválido!");
        }

        
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ProdutoNomeVazio(string nomeProduto)
        {
            Assert.Throws<ArgumentException>( () =>
                ProdutoBuilder.Novo().ComNomeProduto(nomeProduto).Criar()
            );
        }

       
        [Theory]
        [InlineData(-1)]
        public void ProdutoQtdEstoqueInvalido(int qtdProdutoTotal)
        {
            Assert.Throws<ArgumentException>( () =>
                ProdutoBuilder.Novo().ComQtdProdutoTotal(qtdProdutoTotal).Criar()
            );
        }


        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ProdutoUnidadeMedidaVazio(string unidadeMedida)
        {
            Assert.Throws<ArgumentException>( () =>
                ProdutoBuilder.Novo().ComUnidadeMedida(unidadeMedida).Criar()
            );
        }


        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ProdutoClassificacaoVazio(string categoria)
        {
            Assert.Throws<ArgumentException>( () =>
                ProdutoBuilder.Novo().ComCategoria(categoria).Criar()
            );
        }
       

        public class Produto
        {
            // campo
            private int codigoProduto;
            private string nomeProduto;
            private int qtdProdutoTotal;
            private string unidadeMedida;
            private string categoria;

            // propriedade
            public int CodigoProduto { get => codigoProduto; set => codigoProduto = value; }
            public string NomeProduto { get => nomeProduto; set => nomeProduto = value; }
            public int QtdProdutoTotal { get => qtdProdutoTotal; set => qtdProdutoTotal = value; }
            public string UnidadeMedida { get => unidadeMedida; set => unidadeMedida = value; }
            public string Categoria { get => categoria; set => categoria = value; }
            
            public Produto(int codigoProduto, string nomeProduto, int qtdProdutoTotal, string unidadeMedida, string categoria)
            {
                //if (nome == string.Empty) throw new ArgumentException();
                //if (nome == null) throw new ArgumentNullException();
                if (string.IsNullOrEmpty(nomeProduto)) throw new ArgumentException();
                if (string.IsNullOrEmpty(unidadeMedida)) throw new ArgumentException();
                if (string.IsNullOrEmpty(categoria)) throw new ArgumentException();
                if (codigoProduto <= 0) throw new ArgumentException("Codigo Produto Inválido!");
                if (qtdProdutoTotal <= 0) throw new ArgumentException("Codigo Produto Inválido!");


                this.CodigoProduto = codigoProduto;
                this.NomeProduto = nomeProduto;
                this.QtdProdutoTotal = qtdProdutoTotal;
                this.UnidadeMedida = unidadeMedida;
                this.Categoria = categoria;
            }

        }
    }
}