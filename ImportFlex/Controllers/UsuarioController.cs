using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImportFlex.Messages.Catalogos;
using ImportFlex.Models;

namespace ImportFlex.Controllers
{
    public class UsuarioController
    {
        ImportFlexEntities db = new ImportFlexEntities();

        public UsuarioResponse GetUsuarioLogin(string username, string password)
        {
            var response = new UsuarioResponse();

            try
            {
                foreach (var usr in db.imf_usuarios_usr)
                {
                    if (usr.usrUserName == username && usr.usrPassword == password)
                    {
                        response.Usuario = usr;
                        response.Success = true;
                        break;
                    }
                }

                if (!response.Success)
                {
                    response.Success = false;
                    response.Message = "Usuario no encontrado";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Ha ocurrido un error. {ex.Message}";
            }

            return response;
        }

        public UsuarioResponse GetUsuarioByCorreo(string correo)
        {
            var response = new UsuarioResponse();

            try
            {
                foreach (var usr in db.imf_usuarios_usr)
                {
                    if (usr.usrEmail == correo)
                    {
                        response.Usuario = usr;
                        response.Success = true;
                        break;
                    }
                }

                if (!response.Success)
                {
                    response.Success = false;
                    response.Message = "Usuario no encontrado";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Ha ocurrido un error. {ex.Message}";
            }

            return response;
        }


        public UsuarioResponse InsertUsuario(imf_usuarios_usr usuario)
        {
            var response = new UsuarioResponse();

            try
            {
                if (!GetUsuarioByCorreo(usuario.usrEmail).Success)
                {
                    var nvoUsuario = db.imf_usuarios_usr.Add(usuario);
                    db.SaveChanges();

                    response.Usuario = nvoUsuario;
                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Ya existe un usuario registrado con este correo";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

    }
}