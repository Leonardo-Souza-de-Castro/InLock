using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public void AtualizarIdUrl(UsuarioDomain UsuarioAtualizado, int IdUsuario)
        {
            throw new NotImplementedException();
        }

        public UsuarioDomain BuscarporEmaileSenha(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(UsuarioDomain UsuarioNovo)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int IdUsuario)
        {
            throw new NotImplementedException();
        }

        public List<UsuarioDomain> Listar_Todos()
        {
            throw new NotImplementedException();
        }
    }
}
