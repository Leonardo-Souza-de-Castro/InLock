using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface IJogosRepository
    {
        /// <summary>
        /// Método utilizado para que sejam listados todos os jogos cadastrados
        /// </summary>
        /// <returns>Lista de Jogos</returns>
        List<JogosDomain> Listar_Todos();

        /// <summary>
        /// Método utilizado para buscar um determinado jogo pelo seu Id
        /// </summary>
        /// <param name="Id">Id a ser buscado</param>
        /// <returns>Jogo com aquele Id</returns>
        JogosDomain BuscarporId(int Id);

        /// <summary>
        /// Método utilizado para cadastrar novos jogos
        /// </summary>
        /// <param name="JogoNovo">jogo a ser cadastrado</param>
        void Cadastrar(JogosDomain JogoNovo);

        /// <summary>
        /// Método Utilizado para Deletar jogos
        /// </summary>
        /// <param name="IdJogo">Id a ser Deletado</param>
        void Deletar(int IdJogo);

        /// <summary>
        /// Método Utilizado para atualizar as informações de um jogo
        /// </summary>
        /// <param name="JogoAtualizado">Novos Dados</param>
        /// <param name="IdJogo">Id a ser atualizado</param>
        void AtualizarIdUrl(JogosDomain JogoAtualizado, int IdJogo);
    }
}
