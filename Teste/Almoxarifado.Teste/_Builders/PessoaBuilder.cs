using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almoxarifado.Teste._Builders
{
    public class PessoaBuilder
    {
        private int _matriculaPessoa     = 8;
        private string _nomePessoa       = "Gilberto Andrade";
        private string _nomeDepartamento = "Fábrica";
        
        public static PessoaBuilder Novo()
        {
            return new PessoaBuilder();
        }
        public PessoaTeste.PessoaTeste.Pessoa Criar()
        {
            return new PessoaTeste.PessoaTeste.Pessoa(_matriculaPessoa, _nomePessoa, _nomeDepartamento);
        }

        public PessoaBuilder ComMatriculaPessoa(int matriculaPessoa)
        {
            _matriculaPessoa = matriculaPessoa;
            return this;
        }
        public PessoaBuilder ComNomePessoa(string nomePessoa)
        {
            _nomePessoa = nomePessoa;
            return this;
        }
        public PessoaBuilder ComNomeDepartamento(string nomeDepartamento)
        {
            _nomeDepartamento = nomeDepartamento;
            return this;
        }
    }
}
