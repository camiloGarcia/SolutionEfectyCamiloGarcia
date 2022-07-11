using Domain;
using Persistence;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{

    public class UsuariosService
    {
        private readonly ModelEfecty modelEfecty;
        public UsuariosService()
        {
            modelEfecty = new ModelEfecty();
        }
        public bool GuardarUsuario(UsuarioDto usuarioDto)
        {
            var result = false;
            try
            {
                Usuario usuario = FromDto(usuarioDto);
                modelEfecty.Usuarios.Add(usuario);
                var affected=modelEfecty.SaveChanges();
                result = affected == 1;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"{e.Message}{Environment.NewLine}{e.StackTrace}");
            }
            return result;
        }

        public List<UsuarioDto> ListaUsuarios()
        {
            List<UsuarioDto> result = new List<UsuarioDto>();
            try
            {
                result=modelEfecty
                    .Usuarios
                    //.Select(x => ToDto(x))
                    .Select(usuario => new UsuarioDto
                    {
                        Id = usuario.Id,
                        Apellidos = usuario.Apellidos,
                        EstadoCivil = usuario.EstadoCivil,
                        FechaNacimiento = usuario.FechaNacimiento,
                        Nombres = usuario.Nombres,
                        TipoDocumento = usuario.TipoDocumento,
                        ValorAGanar = usuario.ValorAGanar
                    })
                    .ToList();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"{e.Message}{Environment.NewLine}{e.StackTrace}");
            }
            return result;
        }

        private UsuarioDto ToDto(Usuario usuario)
        {
            return new UsuarioDto
            {
                Id=usuario.Id,
                Apellidos = usuario.Apellidos,
                EstadoCivil = usuario.EstadoCivil,
                FechaNacimiento = usuario.FechaNacimiento,
                Nombres = usuario.Nombres,
                TipoDocumento = usuario.TipoDocumento,
                ValorAGanar = usuario.ValorAGanar
            };
        }

        private Usuario FromDto(UsuarioDto usuarioDto)
        {
            return new Usuario { 
                Apellidos=usuarioDto.Apellidos,
                EstadoCivil=usuarioDto.EstadoCivil,
                FechaNacimiento=usuarioDto.FechaNacimiento,
                Nombres=usuarioDto.Nombres,
                TipoDocumento=usuarioDto.TipoDocumento,
                ValorAGanar=usuarioDto.ValorAGanar
            };
        }
    }
}
