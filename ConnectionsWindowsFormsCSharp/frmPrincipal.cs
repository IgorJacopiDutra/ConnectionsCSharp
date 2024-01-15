using ConnectionsWindowsFormsCSharp.Context;
using ConnectionsWindowsFormsCSharp.Model;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;

namespace ConnectionsWindowsFormsCSharp
{
    public partial class frmPrincipal : Form
    {
        private string strCon = "User=SYSDBA;Password=masterkey;Database=C:\\geiewin\\SubProjetos\\Curso\\Git\\ConnectionsWindowsFormsCSharp\\data\\DATA.FDB;DataSource=localhost;Port=3051;Dialect=3";
        private string strSQL = string.Empty;
        FbConnection fbCon = null;
        FbCommand fbComando = null;

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            //  insertSQL();
            insertEntity();
        }
        private void insertSQL()
        {
            try
            {
                strSQL = "insert into CLIENTES (Id, Nome, TpDocto, Docto, Telefone) values (@Id, @Nome, @TpDocto, @Docto, @Telefone)";

                using (FbConnection fbCon = new FbConnection(strCon))
                {
                    fbCon.Open();

                    using (FbCommand fbComando = new FbCommand("SELECT GEN_ID(GEN_CLIENTES, 1) FROM RDB$DATABASE", fbCon))
                    {
                        int novoValor = Convert.ToInt32(fbComando.ExecuteScalar());

                        using (FbCommand insertCommand = new FbCommand(strSQL, fbCon))
                        {
                            insertCommand.Parameters.Add("@Id", FbDbType.VarChar, 15).Value = novoValor.ToString();
                            insertCommand.Parameters.Add("@Nome", FbDbType.VarChar).Value = tbNome.Text;
                            insertCommand.Parameters.Add("@TpDocto", FbDbType.VarChar).Value = tbTpDocto.Text;
                            insertCommand.Parameters.Add("@Docto", FbDbType.VarChar).Value = tbDocto.Text;
                            insertCommand.Parameters.Add("@Telefone", FbDbType.VarChar).Value = tbTelefone.Text;

                            insertCommand.ExecuteNonQuery();
                            MessageBox.Show("Cadastro realizado com sucesso!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar cliente: " + ex.Message);
            }
        }
        private void insertEntity()
        {
            using (var context = new MyDbContext())
            {
                var novoCliente = new Cliente
                {
                    Id = (int?)context.GetNextClienteId(),
                    Nome = "nome",
                    TpDocto = "1",
                    Docto = "docto",
                    Telefone = "123"
                };

                context.CLIENTES.Add(novoCliente);
                context.SaveChanges();
            }
        }

        private bool IsTransientException(Exception ex)
        {
            // Adicione l�gica para identificar exce��es transit�rias aqui
            // Por exemplo, voc� pode verificar se a exce��o � do tipo de exce��o espec�fico que indica uma falha transit�ria.
            // Voc� pode expandir esta l�gica conforme necess�rio.

            // Exemplo simples: verifica se a mensagem de exce��o cont�m "transient"
            return ex.Message.Contains("transient", StringComparison.OrdinalIgnoreCase);
        }
        private void btnSelect_Click(object sender, EventArgs e)
        {
            selectEntity();
            //selectSQL();
        }
        private void selectEntity()
        {
            using (var context = new MyDbContext())
            {
                // Validate search input
                if (string.IsNullOrEmpty(tbSearch.Text))
                {
                    throw new Exception("Por favor, informe o c�digo do cliente para a pesquisa.");
                }

                var cliente = context.CLIENTES.FirstOrDefault(c => c.Id.ToString() == tbSearch.Text);

                if (cliente != null)
                {
                    tbID.Text = cliente.Id.ToString();
                    tbNome.Text = cliente.Nome;
                    tbTpDocto.Text = cliente.TpDocto;
                    tbDocto.Text = cliente.Docto;
                    tbTelefone.Text = cliente.Telefone;
                }
                else
                {
                    MessageBox.Show("Cliente n�o cadastrado.");
                }
            }
        }
        private void selectSQL()
        {
            try
            {
                // Validate search input
                if (string.IsNullOrEmpty(tbSearch.Text))
                {
                    throw new Exception("Por favor, informe o c�digo do cliente para a pesquisa.");
                }

                using (FbConnection fbCon = new FbConnection(strCon))
                {
                    fbCon.Open();

                    strSQL = "select * from CLIENTES where ID = @ID";

                    using (FbCommand fbComando = new FbCommand(strSQL, fbCon))
                    {
                        fbComando.Parameters.Add("@COD_CLIENTE", FbDbType.VarChar).Value = tbSearch.Text;

                        using (FbDataReader dr = fbComando.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                tbSearch.Text = dr["Cliente"].ToString();
                                tbNome.Text = dr["Nome"].ToString();
                                tbTpDocto.Text = dr["TpDocto"].ToString();
                                tbDocto.Text = dr["DOCTO"].ToString();
                                tbTelefone.Text = dr["TELEFONE"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Cliente n�o cadastrado.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar cliente: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //updateEntity();
            updateSQL();
        }

        private void updateEntity()
        {
            {
                try
                {
                    // Validate input
                    if (string.IsNullOrEmpty(tbID.Text))
                    {
                        throw new Exception("Por favor, informe o c�digo do cliente para a edi��o.");
                    }

                    if (string.IsNullOrEmpty(tbNome.Text))
                    {
                        throw new Exception("Por favor, informe o nome do cliente.");
                    }

                    using (var context = new MyDbContext())
                    {
                        var cliente = context.CLIENTES.Find(tbID.Text);  // Retrieve the entity to update

                        if (cliente == null)
                        {
                            MessageBox.Show("Cliente n�o encontrado.");
                            return;
                        }

                        // Update the entity properties
                        cliente.Nome = tbNome.Text;
                        cliente.TpDocto = tbTpDocto.Text;
                        cliente.Docto = tbDocto.Text;
                        cliente.Telefone = tbTelefone.Text;

                        context.SaveChanges();  // Persist the changes to the database

                        MessageBox.Show("Cliente editado com sucesso!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao editar cliente: " + ex.Message);
                }
            }
        }
        private void updateSQL()
        {
            try
            {
                // Validate input
                if (string.IsNullOrEmpty(tbID.Text))
                {
                    throw new Exception("Por favor, informe o c�digo do cliente para a edi��o.");
                }

                if (string.IsNullOrEmpty(tbNome.Text))
                {
                    throw new Exception("Por favor, informe o nome do cliente.");
                }

                using (FbConnection fbCon = new FbConnection(strCon))
                {
                    fbCon.Open();

                    strSQL = "update CLIENTES set NOME = @NOME, TPDOCTO = @TPDOCTO, DOCTO = @DOCTO, TELEFONE = @TELEFONE where COD_CLIENTE = @COD_CLIENTE";

                    using (FbCommand fbComando = new FbCommand(strSQL, fbCon))
                    {
                        fbComando.Parameters.Add("@ID", FbDbType.VarChar).Value = tbID.Text;
                        fbComando.Parameters.Add("@NOME", FbDbType.VarChar).Value = tbNome.Text;
                        fbComando.Parameters.Add("@TPDOCTO", FbDbType.VarChar).Value = tbTpDocto.Text;
                        fbComando.Parameters.Add("@DOCTO", FbDbType.VarChar).Value = tbDocto.Text;
                        fbComando.Parameters.Add("@TELEFONE", FbDbType.VarChar).Value = tbTelefone.Text;

                        int rowsAffected = fbComando.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            MessageBox.Show("Erro ao editar cliente.");
                        }
                        else
                        {
                            MessageBox.Show("Cliente editado com sucesso!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input
                if (string.IsNullOrEmpty(tbID.Text))
                {
                    throw new Exception("Por favor, informe o c�digo do cliente para a exclus�o.");
                }

                using (var context = new MyDbContext())
                {
                    int id = int.Parse(tbID.Text);  // Assuming tbID.Text contains a valid integer string
                    var cliente = context.CLIENTES.Find(id);  // Use the integer value for Find

                    if (cliente == null)
                    {
                        MessageBox.Show("Cliente n�o encontrado.");
                        return;
                    }

                    context.CLIENTES.Remove(cliente);  // Mark the entity for deletion
                    context.SaveChanges();  // Persist the deletion to the database

                    MessageBox.Show("Cliente exclu�do com sucesso!");

                    // Clear textboxes after successful deletion
                    tbID.Text = string.Empty;
                    tbNome.Text = string.Empty;
                    tbTpDocto.Text = string.Empty;
                    tbDocto.Text = string.Empty;
                    tbTelefone.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir cliente: " + ex.Message);
            }
        }
        private void deleteEntity()
        {
            // deleteSQL();
            deleteEntity();
        }
        private void deleteSQL()
        {
            try
            {
                // Validate input
                if (string.IsNullOrEmpty(tbID.Text))
                {
                    throw new Exception("Por favor, informe o c�digo do cliente para a exclus�o.");
                }

                using (FbConnection fbCon = new FbConnection(strCon))
                {
                    fbCon.Open();

                    strSQL = "delete from CLIENTES where ID = @ID";

                    using (FbCommand fbComando = new FbCommand(strSQL, fbCon))
                    {
                        fbComando.Parameters.Add("@COD_CLIENTE", FbDbType.VarChar).Value = tbID.Text;

                        int rowsAffected = fbComando.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            MessageBox.Show("Cliente n�o encontrado.");
                        }
                        else
                        {
                            MessageBox.Show("Cliente exclu�do com sucesso!");
                            // Clear textboxes after successful deletion
                            tbID.Text = string.Empty;
                            tbNome.Text = string.Empty;
                            tbTpDocto.Text = string.Empty;
                            tbDocto.Text = string.Empty;
                            tbTelefone.Text = string.Empty;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir cliente: " + ex.Message);
            }
        }

        private void btnProcedure_Click(object sender, EventArgs e)
        {
            //procedureSQL();
            procedureEF();
        }

        private void procedureSQL()
        {
            try
            {
                using (FbConnection fbCon = new FbConnection(strCon))
                {
                    fbCon.Open();

                    using (FbCommand fbComando = new FbCommand("SP_BUSCASEQUENCIA", fbCon))
                    {
                        fbComando.CommandType = CommandType.StoredProcedure;

                        FbParameter origemParam = new FbParameter("@origem", FbDbType.VarChar);
                        origemParam.Value = "CLIENTE";
                        fbComando.Parameters.Add(origemParam);

                        FbParameter retornoParam = new FbParameter();
                        retornoParam.ParameterName = "@sequencia";
                        retornoParam.Direction = ParameterDirection.Output;
                        retornoParam.FbDbType = FbDbType.Integer;
                        fbComando.Parameters.Add(retornoParam);

                        fbComando.ExecuteNonQuery();

                        int retorno = Convert.ToInt32(retornoParam.Value);

                        if (retorno == -1)
                        {
                            MessageBox.Show("Erro na busca da sequ�ncia.");
                        }
                        else
                        {
                            MessageBox.Show("Sequ�ncia obtida com sucesso: " + retorno);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        private void procedureEF()
        {
            using (var dbContext = new MyDbContext())
            {
                // Chamar o m�todo GetNextSequence
                int nextSequence = dbContext.GetNextSequence("CLIENTE");

                // Usar o valor retornado conforme necess�rio
                Console.WriteLine($"Pr�xima sequ�ncia: {nextSequence}");
            }
        }
    }
}