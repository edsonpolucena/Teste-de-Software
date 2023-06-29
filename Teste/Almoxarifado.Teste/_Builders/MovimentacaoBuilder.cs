using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CategoriaTeste.CategoriaTeste;

namespace Almoxarifado.Teste._Builders
{
    public class MovimentacaoBuilder
    {
        // campos
        private int _idMovimentacao  = 3;
        private string _data         = "10/05/2023";
        private int _quantidade      = 50;
        private string _descricao    = "Entrada";
        
        public static MovimentacaoBuilder Novo()
        { 
            return new MovimentacaoBuilder();
        }
        public MovimentacaoTeste.MovimentacaoTeste.Movimentacao Criar()
        {
            return new MovimentacaoTeste.MovimentacaoTeste.Movimentacao(_idMovimentacao, _data, _quantidade, _descricao);
        }
        public MovimentacaoBuilder ComIdMovimentacao(int idMovimentacao)
        {
            _idMovimentacao = idMovimentacao;
            return this;
        }
        public MovimentacaoBuilder ComData(string data)
        {
            _data = data;
            return this;
        }
        public MovimentacaoBuilder ComQuantidade(int quantidade)
        {
            _quantidade = quantidade;
            return this;
        }
        public MovimentacaoBuilder ComDescricao(string Descricao)
        {
            _descricao = Descricao;
            return this;
        }
    }
}
