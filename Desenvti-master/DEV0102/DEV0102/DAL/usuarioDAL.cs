using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DEV0102.DAL
{
    public class usuarioDAL
    {
        public tabUsuario consultarUsuarioPorEmail(string email)
        {
            using (DEV0102Entities ctx = new DEV0102Entities())
            {
                return ctx.tabUsuario.Where(c => c.email == email).FirstOrDefault();
            }
        }

        public tabUsuario consultarEmaileSenha(string varEmail, string varSenha)
        {
            using (DEV0102Entities ctx = new DEV0102Entities())
            {
                return ctx.tabUsuario.Where(c => c.email == varEmail && c.senha == varSenha).FirstOrDefault();
            }
        }

        public void cadastrarUsuario(tabUsuario objU)
        {
            using (DEV0102Entities ctx = new DEV0102Entities())
            {
                ctx.tabUsuario.Add(objU);
                ctx.SaveChanges();
            }
        }

        public void deletarUsuario(int codigo)
        {
            using (DEV0102Entities ctx = new DEV0102Entities())
            {
                tabUsuario obj = ctx.tabUsuario.Where(c => c.codigo == codigo).FirstOrDefault();

                ctx.tabUsuario.Remove(obj);
                ctx.SaveChanges();
            }
        
        
        }

        public tabUsuario ConsultarUsuarioPorCodigo(int usuarioCodigo)
        {
            using (DEV0102Entities ctx = new DEV0102Entities())
            {
                tabUsuario obj = ctx.tabUsuario.Where(c => c.codigo == usuarioCodigo).FirstOrDefault();
                return obj;
            }
        }

        public void Editar(tabUsuario objEnt)
        {
            using (DEV0102Entities ctx = new DEV0102Entities())
            {
                ctx.tabUsuario.Attach(objEnt);
                ctx.Entry(objEnt).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
            }
        }
    }
}