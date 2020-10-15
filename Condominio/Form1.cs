using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Condominio {
    public partial class Form1 : Form {

        SqlConnection conexao;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;

        string strSql;

        public Form1() {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e) {
            try {
                conexao = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=bruno;Data Source=SANTOS");
                strSql = "INSERT INTO CONDOMINIO (ID, NOME, ANIVERSARIO, BLOCO, APARTAMENTO, TELEFONE, EMAIL) VALUES (@ID, @NOME, @ANIVERSARIO, @BLOCO, @APARTAMENTO, @TELEFONE, @EMAIL)";

                cmd = new SqlCommand(strSql, conexao);

                cmd.Parameters.AddWithValue("@ID", tbId.Text);
                cmd.Parameters.AddWithValue("@NOME", tbNome.Text);
                cmd.Parameters.AddWithValue("@ANIVERSARIO", mtbAniversario.Text);
                cmd.Parameters.AddWithValue("@BLOCO", tbBloco.Text);
                cmd.Parameters.AddWithValue("@APARTAMENTO", tbApartamento.Text);
                cmd.Parameters.AddWithValue("@TELEFONE", mtbTelefone.Text);
                cmd.Parameters.AddWithValue("@EMAIL", tbEmail.Text);

                conexao.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Morador Registrado com Sucesso");
                tbId.Text = null;
                tbNome.Text = null;
                mtbAniversario.Text = null;
                tbBloco.Text = null;
                tbApartamento.Text = null;
                mtbTelefone.Text = null;
                tbEmail.Text = null;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                conexao.Close();
                conexao = null;
                cmd = null;
            }
            

        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void btnExibir_Click(object sender, EventArgs e) {
            try {
                conexao = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=bruno;Data Source=SANTOS");
                strSql = "SELECT * FROM CONDOMINIO";

                cmd = new SqlCommand(strSql, conexao);

                DataSet ds = new DataSet();
                da = new SqlDataAdapter(strSql, conexao);
                
                conexao.Open();

                da.Fill(ds);

                dgvDados.DataSource = ds.Tables[0];
                /*dr = cmd.ExecuteReader();



                while(dr.Read()){

                    tbNome.Text = (string)dr["NOME"];
                    mtbAniversario.Text = (string)dr["ANIVERSARIO"];
                    tbBloco.Text = (string)dr["BLOCO"];
                    
                }*/
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);

            }
            finally {
                conexao.Close();
                conexao = null;
                cmd = null;
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e) {
            try {
                conexao = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=bruno;Data Source=SANTOS");
                strSql = "SELECT * FROM CONDOMINIO WHERE APARTAMENTO = @APARTAMENTO OR ID = @ID";

                cmd = new SqlCommand(strSql, conexao);

                cmd.Parameters.AddWithValue("@APARTAMENTO", tbApartamento.Text);
                cmd.Parameters.AddWithValue("@ID", tbId.Text);

                conexao.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read()) {
                    tbBloco.Text = (string)dr["BLOCO"];
                    tbApartamento.Text = (string)dr["APARTAMENTO"];
                    tbId.Text = Convert.ToString(dr["ID"]);
                    tbNome.Text = (string)dr["NOME"];
                    mtbAniversario.Text = (string)dr["ANIVERSARIO"];
                    mtbTelefone.Text = (string)dr["TELEFONE"];
                    tbEmail.Text = (string)dr["EMAIL"];

                }


            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                conexao.Close();
                conexao = null;
                cmd = null;
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e) {
            tbApartamento.Text = null;
            tbBloco.Text = null;
            tbEmail.Text = null;
            tbId.Text = null;
            tbNome.Text = null;
            mtbTelefone.Text = null;
            mtbAniversario.Text = null;
        }

        private void btnAtualizar_Click(object sender, EventArgs e) {
            try {
                conexao = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=bruno;Data Source=SANTOS");
                strSql = "UPDATE CONDOMINIO SET NOME=@NOME, ANIVERSARIO=@ANIVERSARIO, BLOCO=@BLOCO, APARTAMENTO=@APARTAMENTO, TELEFONE=@TELEFONE, EMAIL=@EMAIL WHERE ID=@ID";

                cmd = new SqlCommand(strSql, conexao);

                cmd.Parameters.AddWithValue("@ID", tbId.Text);
                cmd.Parameters.AddWithValue("@NOME", tbNome.Text);
                cmd.Parameters.AddWithValue("@ANIVERSARIO", mtbAniversario.Text);
                cmd.Parameters.AddWithValue("@BLOCO", tbBloco.Text);
                cmd.Parameters.AddWithValue("@APARTAMENTO", tbApartamento.Text);
                cmd.Parameters.AddWithValue("@TELEFONE", mtbTelefone.Text);
                cmd.Parameters.AddWithValue("@EMAIL", tbEmail.Text);

                conexao.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Morador Atualizado com Sucesso");
                tbId.Text = null;
                tbNome.Text = null;
                mtbAniversario.Text = null;
                tbBloco.Text = null;
                tbApartamento.Text = null;
                mtbTelefone.Text = null;
                tbEmail.Text = null;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                conexao.Close();
                conexao = null;
                cmd = null;
            }

        }

        private void btnExcluir_Click(object sender, EventArgs e) {
            try {
                conexao = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=bruno;Data Source=SANTOS");
                strSql = "DELETE CONDOMINIO WHERE ID=@ID";

                cmd = new SqlCommand(strSql, conexao);

                cmd.Parameters.AddWithValue("@ID", tbId.Text);

                conexao.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Registro Excluído!");
                tbId.Text = null;
                tbNome.Text = null;
                mtbAniversario.Text = null;
                tbBloco.Text = null;
                tbApartamento.Text = null;
                mtbTelefone.Text = null;
                tbEmail.Text = null;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                conexao.Close();
                conexao = null;
                cmd = null;
            }
        }
    }
}
