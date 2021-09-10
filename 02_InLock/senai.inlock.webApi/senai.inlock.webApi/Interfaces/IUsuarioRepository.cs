using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Método utilizado para que sejam listados todos os  Usuarios cadastrados
        /// </summary>
        /// <returns>Lista de Usuarios</returns>
        List<UsuarioDomain> Listar_Todos();

        /// <summary>
        /// Método utilizado para buscar um usuario pelo seu email e senha
        /// </summary>
        /// <param name="email">Email buscado</param>
        /// <param name="senha">Senah buscada</param>
        /// <returns></returns>
        UsuarioDomain BuscarporEmaileSenha(string email, string senha);

        /// <summary>
        /// Método utilizado para cadastrar novos usuarios
        /// </summary>
        /// <param name="UsuarioNovo">Usuario a ser cadastrado</param>
        void Cadastrar(UsuarioDomain UsuarioNovo);

        /// <summary>
        /// Método Utilizado para Deletar Usuarios
        /// </summary>
        /// <param name="IdUsuario">Id a ser Deletado</param>
        void Deletar(int IdUsuario);

        /// <summary>
        /// Método Utilizado para atualizar as informações de um Usuario
        /// </summary>
        /// <param name="UsuarioAtualizado">Novos Dados</param>
        /// <param name="IdUsuario">Id a ser atualizado</param>
        void AtualizarIdUrl(UsuarioDomain UsuarioAtualizado, int IdUsuario);
    }
}
