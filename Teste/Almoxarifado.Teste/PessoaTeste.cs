using Almoxarifado.Teste._Builders;
using Almoxarifado.Teste._Util;
using Bogus;
using ExpectedObjects;

namespace PessoaTeste
{
    public class PessoaTeste
    {
        private int _matriculaPessoa;
        private string _nomePessoa;
        private string _nomeDepartamento;

        public PessoaTeste()
        {
            Faker faker = new Faker();
            this._matriculaPessoa = faker.Random.Int(1, 100);
            this._nomePessoa = faker.Random.Words(20);
            this._nomeDepartamento = faker.Random.Words(20);
           
        }


        [Fact]
        public void CriarPessoa()
        {
            // Arrange
            var pessoaEsperado = new
            {
                MatriculaPessoa = _matriculaPessoa,
                NomePessoa = _nomePessoa,
                NomeDepartamento = _nomeDepartamento
            };

            // Act
            Pessoa novaPessoa = new Pessoa(
                    pessoaEsperado.MatriculaPessoa,
                    pessoaEsperado.NomePessoa,
                    pessoaEsperado.NomeDepartamento);

            // Assert
            pessoaEsperado.ToExpectedObject().ShouldMatch(novaPessoa);
        }


        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void PessoaMatriculaInvalido(int matriculaPessoa)
        {
            Assert.Throws<ArgumentException>( () =>
                PessoaBuilder.Novo().ComMatriculaPessoa(matriculaPessoa).Criar()
            ).ComMensagem("Matricula da Pessoa Inválida!");
        }


        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void PessoaNomeVazio(string nomePessoa)
        {
            Assert.Throws<ArgumentException>( () =>
                PessoaBuilder.Novo().ComNomePessoa(nomePessoa).Criar()
            );
        }


        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void PessoaNomeDepartamentoVazio(string nomeDepartamento)
        {
            Assert.Throws<ArgumentException>( () =>
                PessoaBuilder.Novo().ComNomeDepartamento(nomeDepartamento).Criar()
            );
        }


        public class Pessoa
        {
            // campo
            private int matriculaPessoa;
            private string nomePessoa;
            private string nomeDepartamento;

            // propriedade
            public int MatriculaPessoa { get => matriculaPessoa; set => matriculaPessoa = value; }
            public string NomePessoa { get => nomePessoa; set => nomePessoa = value; }
            public string NomeDepartamento { get => nomeDepartamento; set => nomeDepartamento = value; }



            public Pessoa(int matriculaPessoa, string nomePessoa, string nomeDepartamento)
            {
                if (string.IsNullOrEmpty(nomeDepartamento)) throw new ArgumentException();
                if (string.IsNullOrEmpty(nomePessoa)) throw new ArgumentException();
                if (matriculaPessoa <= 0) throw new ArgumentException("Matricula da Pessoa Inválida!");

                this.MatriculaPessoa = matriculaPessoa;
                this.NomePessoa = nomePessoa;
                this.NomeDepartamento = nomeDepartamento;
            }
        }
    }
}
