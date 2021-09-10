using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface ITiposUsuarioRepository
    {
        /// <summary>
        /// Método utilizado para que sejam listados todos os tipos de usuarios cadastrados
        /// </summary>
        /// <returns>Lista de Tipos</returns>
        List<TiposUsuarioDomain> Listar_Todos();

        /// <summary>
        /// Método utilizado para buscar um determinado tipo de usuário pelo seu Id
        /// </summary>
        /// <param name="Id">Id a ser buscado</param>
        /// <returns>Tipo de usuário com aquele Id</returns>
        TiposUsuarioDomain BuscarporId(int Id);

        /// <summary>
        /// Método utilizado para cadastrar novos Tipos
        /// </summary>
        /// <param name="TipoNovo">Tipo a ser cadastrado</param>
        void Cadastrar(TiposUsuarioDomain TipoNovo);

        /// <summary>
        /// Método Utilizado para Deletar Tipos
        /// </summary>
        /// <param name="IdTipo">Id a ser Deletado</param>
        void Deletar(int IdTipo);

        /// <summary>
        /// Método Utilizado para atualizar as informações de um Tipo
        /// </summary>
        /// <param name="TipoAtualizado">Novos Dados</param>
        /// <param name="IdTipo">Id a ser atualizado</param>
        void AtualizarIdUrl(TiposUsuarioDomain TipoAtualizado, int IdTipo);
    }
}
