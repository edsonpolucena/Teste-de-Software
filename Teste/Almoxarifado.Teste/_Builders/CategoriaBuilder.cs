using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almoxarifado.Teste._Builders
{
    public class CategoriaBuilder
    {
        //campos
        private int _codigoCategoria = 1;
        private string _nomeCategoria = "Permanente";
        
        public static CategoriaBuilder Novo()
        {
            return new CategoriaBuilder();
        }
        public CategoriaTeste.CategoriaTeste.Categoria Criar()
        {
            return new CategoriaTeste.CategoriaTeste.Categoria(_codigoCategoria, _nomeCategoria);
        }
        public CategoriaBuilder ComCodigoCategoria(int codigoCategoria)
        {
            _codigoCategoria = codigoCategoria;
            return this;
        }
        public CategoriaBuilder ComNomeCategoria(string nomeCategoria)
        {
            _nomeCategoria = nomeCategoria;
            return this;
        }
    }
}
