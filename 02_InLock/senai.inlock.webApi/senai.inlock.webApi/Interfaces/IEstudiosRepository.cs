using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface IEstudiosRepository
    {
        /// <summary>
        /// Método utilizado para que sejam listados todos os Estudios cadastrados
        /// </summary>
        /// <returns>Lista de Estudios</returns>
        List<EstudiosDomain> Listar_Todos();
        
        /// <summary>
        /// Método utilizado para buscar um determinado Estudio pelo seu Id
        /// </summary>
        /// <param name="Id">Id a ser buscado</param>
        /// <returns>Estudio com aquele Id</returns>
        EstudiosDomain BuscarporId(int Id);

        /// <summary>
        /// Método utilizado para cadastrar novos Estudios
        /// </summary>
        /// <param name="EstudioNovo">Estudio a ser cadastrado</param>
        void Cadastrar(EstudiosDomain EstudioNovo);

        /// <summary>
        /// Método Utilizado para Deletar Estudios
        /// </summary>
        /// <param name="IdEstudio">Id a ser Deletado</param>
        void Deletar(int IdEstudio);

        /// <summary>
        /// Método Utilizado para atualizar as informações de um Estudio
        /// </summary>
        /// <param name="estudioatualizado">Novos Dados</param>
        /// <param name="IdEstudio">Id a ser atualizado</param>
        void AtualizarIdUrl(EstudiosDomain estudioatualizado, int IdEstudio);
    }
}
