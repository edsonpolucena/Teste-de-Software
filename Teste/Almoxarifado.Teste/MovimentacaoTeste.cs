using Almoxarifado.Teste._Builders;
using Almoxarifado.Teste._Util;
using Bogus;
using ExpectedObjects;
using static CategoriaTeste.CategoriaTeste;

namespace MovimentacaoTeste
{
    public class MovimentacaoTeste
    {
        private int _idMovimentacao;
        private string _data;
        private int _quantidade;
        private string _descricao;

        public MovimentacaoTeste()
        {
            Faker faker = new Faker();

            this._idMovimentacao = faker.Random.Int(1, 100);
            this._data = faker.Random.Words();
            this._quantidade = faker.Random.Int(1, 1000);
            this._descricao = faker.Random.Words(20);

           
        }


        [Fact]
        public void CriarMovimentacao()
        {
            // Arrange
            var movimentacaoEsperado = new
            {
                IdMovimentacao = _idMovimentacao,
                Data = _data,
                Quantidade = _quantidade,
                Descricao = _descricao           
            };

            // Act
            Movimentacao novaMovimentacao = new Movimentacao(
                    movimentacaoEsperado.IdMovimentacao,
                    movimentacaoEsperado.Data,
                    movimentacaoEsperado.Quantidade,
                    movimentacaoEsperado.Descricao);

            // Assert
            movimentacaoEsperado.ToExpectedObject().ShouldMatch(novaMovimentacao);
        }


        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void MovimentacaoIdInvalido(int idMovimentacao)
        {
            Assert.Throws<ArgumentException>( () =>
                MovimentacaoBuilder.Novo().ComIdMovimentacao(idMovimentacao).Criar()
            ).ComMensagem("Id Movimentação Inválido!");
        }


        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void MovimentacaoDataInvalida(string data)
        {
            Assert.Throws<ArgumentException>( () =>
                MovimentacaoBuilder.Novo().ComData(data).Criar()
            );
        }


        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void MovimentacaoQuantidadeInvalido(int quantidade)
        {
            Assert.Throws<ArgumentException>( () =>
                MovimentacaoBuilder.Novo().ComQuantidade(quantidade).Criar()
            ).ComMensagem("Quantidade Inválida!");
        }


        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void MovimentacaoDescricaoInvalida(string descricao)
        {
            Assert.Throws<ArgumentException>( () =>
                MovimentacaoBuilder.Novo().ComDescricao(descricao).Criar()
            );
        }


        public class Movimentacao
        {
            // campo
            private int idMovimentacao;
            private string data;
            private int quantidade;
            private string descricao;

            // propriedade
            public int IdMovimentacao { get => idMovimentacao; set => idMovimentacao = value; }
            public string Data { get => data; set => data = value; }
            public int Quantidade { get => quantidade; set => quantidade = value; }
            public string Descricao { get => descricao; set => descricao = value; }

            public Movimentacao(int idMovimentacao, string data, int quantidade, string descricao)
            {
                if (string.IsNullOrEmpty(data)) throw new ArgumentException();
                if (string.IsNullOrEmpty(descricao)) throw new ArgumentException();
                if (idMovimentacao <= 0) throw new ArgumentException("Id Movimentação Inválido!");
                if (quantidade <= 0) throw new ArgumentException("Quantidade Inválida!");

                this.IdMovimentacao = idMovimentacao;
                this.Data = data;
                this.Quantidade = quantidade;
                this.Descricao = descricao;
            }
        }       
    }
}
