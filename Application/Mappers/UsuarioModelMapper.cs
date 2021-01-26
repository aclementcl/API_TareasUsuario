using Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappers
{
    public static class UsuarioModelMapper
    {
        public static DataAccess.Entities.Usuario MapToData(Application.Models.Usuario usuario)
        {
            return new DataAccess.Entities.Usuario
            {
                ID = usuario.ID,
                UserName = usuario.UserName,
                Password = usuario.Password,
                Name = usuario.Name
            };
        }

        public static Application.Models.Usuario MapToView(DataAccess.Entities.Usuario usuario)
        {
            return new Application.Models.Usuario
            {
                ID = usuario.ID,
                UserName = usuario.UserName,
                Password = usuario.Password,
                Name = usuario.Name
            };
        }
    }
}

