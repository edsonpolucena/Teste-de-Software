using Almoxarifado.Teste._Builders;
using Almoxarifado.Teste._Util;
using Bogus;
using ExpectedObjects;

namespace CategoriaTeste
{
    public class CategoriaTeste
    {
        private int _codigoCategoria;
        private string _nomeCategoria;

        public CategoriaTeste()
        {

            Faker faker = new Faker();
            this._codigoCategoria = faker.Random.Int(1, 100);
            this._nomeCategoria = faker.Random.Words(20);
       
        }


        [Fact]
        public void CriarCategoria()
        {
            // Arrange
            var categoriaEsperado = new
            {
                CodigoCategoria = _codigoCategoria,
                NomeCategoria = _nomeCategoria
            };

            // Act
            Categoria novaCategoria = new Categoria(
                categoriaEsperado.CodigoCategoria,
                categoriaEsperado.NomeCategoria);

            // Assert
            categoriaEsperado.ToExpectedObject().ShouldMatch(novaCategoria);
        }


        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void CategoriaCodigoInvalido(int codigoCategoria)
        {
            Assert.Throws<ArgumentException>( () =>
                CategoriaBuilder.Novo().ComCodigoCategoria(codigoCategoria).Criar()    
            ).ComMensagem("Código Categoria Invalido!");
        }
    
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void CategoriaNomeVazio(string nomeCategoria)
        {
            Assert.Throws<ArgumentException>( () =>
                CategoriaBuilder.Novo().ComNomeCategoria(nomeCategoria).Criar()
            );
        }


        public class Categoria
        {
            // campo
            private int codigoCategoria;
            private string nomeCategoria;

            // propriedade
            public int CodigoCategoria { get => codigoCategoria; set => codigoCategoria = value; }
            public string NomeCategoria { get => nomeCategoria; set => nomeCategoria = value; }

            public Categoria(int codigoCategoria, string nomeCategoria)
            {
                //if (nome == string.Empty) throw new ArgumentException();
                //if (nome == null) throw new ArgumentNullException();
                if (string.IsNullOrEmpty(nomeCategoria)) throw new ArgumentException();
                if (codigoCategoria <= 0) throw new ArgumentException("Código Categoria Invalido!");

                this.CodigoCategoria = codigoCategoria;
                this.NomeCategoria = nomeCategoria;
            }

        }
    }
}
