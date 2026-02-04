using DEV0102.DAL;
using DEV0102.Utils;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DEV0102
{
    public partial class cadUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.ServerVariables["QUERY_STRING"].Contains("novoUsuario"))
            {
                panelUsuarioCadastrado.Visible = false;
            }
            else
            {
                if (Session["codigoUsuario"] == null)
                { 
                    Response.Redirect("Login.aspx");
                }
                else
                { 
                panelUsuarioCadastrado.Visible = true;
                }
            }
        }

        protected void btnConsultaCEP_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ws = new wsCorreios.AtendeClienteService())
                {
                    var resultado = ws.consultaCEP(txtCEP.Text);

                    txtEndereco.Text = resultado.end;
                    txtBairro.Text = resultado.bairro;
                    txtCidade.Text = resultado.cidade;
                    txtUF.Text = resultado.uf;
                }
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message);
            }
        }

        public void ExibirMensagem(string msg)
        {
            Response.Write("<script>alert('" + msg + "')</script>");
        }

        public void LimparCampos()
        {
            txtBairro.Text = "";
            txtCEP.Text = "";
            txtCidade.Text = "";
            txtEmail.Text = "";
            txtEndereco.Text = "";
            txtNome.Text = "";
            txtSenha.Text = "";
            txtUF.Text = "";
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                tabUsuario objusuario = new tabUsuario();
                objusuario.bairro = txtBairro.Text;
                objusuario.cep = txtCEP.Text;
                objusuario.cidade = txtCidade.Text;
                objusuario.email = txtEmail.Text;
                objusuario.endereco = txtEndereco.Text;
                objusuario.nome = txtNome.Text;
                objusuario.senha = txtSenha.Text;
                objusuario.uf = txtUF.Text;

                tabUsuario objValidador = new tabUsuario();
                usuarioDAL uDal = new usuarioDAL();

                bool emEdicao = hiddenFieldCodigo.Value != "0";
                if (emEdicao)
                {
                    objusuario.codigo = Convert.ToInt32(hiddenFieldCodigo.Value);
                }

                if (fupFoto.HasFile)
                {
                    string caminhoArquivo = Server.MapPath("/fotoUsuario/");
                    string nomeArquivo = fupFoto.FileName;

                    fupFoto.SaveAs(caminhoArquivo + nomeArquivo);
                    objusuario.nomeFoto = fupFoto.FileName;
                }
                else if (emEdicao)
                {
                    tabUsuario usuarioAtual = uDal.ConsultarUsuarioPorCodigo(objusuario.codigo);
                    if (usuarioAtual == null)
                    {
                        ExibirMensagem("Usuário não encontrado para edição.");
                        return;
                    }

                    objusuario.nomeFoto = usuarioAtual.nomeFoto;
                }
                else
                {
                    ExibirMensagem("Selecione uma foto para o usuário");
                    return;
                }

                if (emEdicao)
                {
                    uDal.Editar(objusuario);
                    hiddenFieldCodigo.Value = "0";
                    btnCadastrar.Text = "Cadastrar";
                    gridUsuario.DataBind();
                    LimparCampos();
                    ExibirMensagem("Usuário Editado com sucesso!");

                }
                else
                {

                    objValidador = uDal.consultarUsuarioPorEmail(txtEmail.Text);

                    if (objValidador != null)
                    {
                        ExibirMensagem("Usuário já existe no banco de dados!");
                    }
                    else
                    {
                        uDal.cadastrarUsuario(objusuario);
                        gridUsuario.DataBind();

                        ExibirMensagem("Usuário cadastrado com sucesso!");
                        Suporte objsup = new Suporte();
                        string corpoEmail = "Olá " + txtNome.Text + ", bem vindo ao sistema, você já está cadastrado!";
                        objsup.EnviarEmail("Bem vindo ao Sistema Desenvti", txtEmail.Text, corpoEmail);
                        LimparCampos();
                    }
                }

            }
            catch (Exception ex)
            {
                ExibirMensagem("Erro ao salvar cadastro! Entre em contato com o administrador do sistema.");
            }

        }

        protected void gridUsuario_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Deletar")
            {
                int linhaClicada = Convert.ToInt32(e.CommandArgument);
                int codigo = Convert.ToInt32(gridUsuario.DataKeys[linhaClicada]["codigo"].ToString());

                usuarioDAL uDal = new usuarioDAL();
                uDal.deletarUsuario(codigo);

                gridUsuario.DataBind();
                ExibirMensagem("Usuário excluido");
            }
            else if (e.CommandName == "Editar")
            {
                int linhaClicada = Convert.ToInt32(e.CommandArgument);
                int codigo = Convert.ToInt32(gridUsuario.DataKeys[linhaClicada]["codigo"].ToString());

                usuarioDAL objDal = new usuarioDAL();
                tabUsuario obj =  objDal.ConsultarUsuarioPorCodigo(codigo);

                txtBairro.Text = obj.bairro;
                txtCEP.Text = obj.cep;
                txtCidade.Text = obj.cidade;
                txtEmail.Text = obj.email;
                txtEndereco.Text = obj.endereco;
                txtNome.Text = obj.nome;
                txtUF.Text = obj.uf;

                hiddenFieldCodigo.Value = obj.codigo.ToString();
                btnCadastrar.Text = "Salvar";
                ExibirMensagem("Liberado para edição!");
            }
        }

        protected void btnAtualizar_Click(object sender, EventArgs e)
        {
            List<tabUsuario> objlstUsuario = new List<tabUsuario>();
            usuarioDAL uDal = new usuarioDAL();
            objlstUsuario = uDal.ListarTodosUsuarios();
            
            foreach (tabUsuario objU in objlstUsuario)
            {
                ExibirMensagem(objU.nome);   
            }

        }
    }
}
