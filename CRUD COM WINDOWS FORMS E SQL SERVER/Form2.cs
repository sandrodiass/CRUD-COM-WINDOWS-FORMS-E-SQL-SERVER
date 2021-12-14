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
namespace CRUD_COM_WINDOWS_FORMS_E_SQL_SERVER
{
    public partial class Form2 : Form
    {
        SqlConnection conexao;
        SqlCommand comando;
        SqlDataAdapter da;
        SqlDataReader dr;
        string strsql;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {

                conexao = new SqlConnection(@"Data Source=BÁRBARAFARIA-PC\SQLSERVER;Initial Catalog=loja;User ID=sa;Password=1234");

                strsql = "INSERT INTO CAD_CLIENTE(NOME,NUMERO) VALUES (@NOME, @NUMERO) ";

                comando = new SqlCommand(strsql, conexao);

                comando.Parameters.AddWithValue("@NOME", txtnome.Text);
                comando.Parameters.AddWithValue("@NUMERO", txtnumero.Text);
                conexao.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("SALVO COM SUCESSO");
                txtnome.Text = "";
                txtnumero.Text = "";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {

                conexao.Close();
                comando.Clone();
                conexao = null;
                comando = null;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {



            try
            {

                conexao = new SqlConnection(@"Data Source=BÁRBARAFARIA-PC\SQLSERVER;Initial Catalog=loja;User ID=sa;Password=1234");

                strsql = "SELECT * FROM CAD_CLIENTE WHERE ID =  @ID ";

                comando = new SqlCommand(strsql, conexao);

                comando.Parameters.AddWithValue("ID", txtid.Text);

                conexao.Open();
                dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    txtnome.Text = Convert.ToString(dr["nome"]);
                    txtnumero.Text = Convert.ToString(dr["numero"]);



                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {

                conexao.Close();
                comando.Clone();
                conexao = null;
                comando = null;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            try
            {

                conexao = new SqlConnection(@"Data Source=BÁRBARAFARIA-PC\SQLSERVER;Initial Catalog=loja;User ID=sa;Password=1234");

                strsql = "SELECT * FROM CAD_CLIENTE";

                DataSet ds = new DataSet();
                da = new SqlDataAdapter(strsql, conexao);



                conexao.Open();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {

                conexao.Close();
                conexao = null;
                comando = null;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                conexao = new SqlConnection(@"Data Source=BÁRBARAFARIA-PC\SQLSERVER;Initial Catalog=loja;User ID=sa;Password=1234");

                strsql = "DELETE CAD_CLIENTE WHERE ID =  @ID";

                comando = new SqlCommand(strsql, conexao);

                comando.Parameters.AddWithValue("@ID", txtid.Text);

                conexao.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {

                conexao.Close();
                comando.Clone();
                conexao = null;
                comando = null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                conexao = new SqlConnection(@"Data Source=BÁRBARAFARIA-PC\SQLSERVER;Initial Catalog=loja;User ID=sa;Password=1234");

                strsql = "UPDAT CAD_CLIENTE SET NOME = @NOME, NUMERO = @NUMERO, WERE ID = @ID ";

                comando = new SqlCommand(strsql, conexao);

                comando.Parameters.AddWithValue("@NOME", txtnome.Text);
                comando.Parameters.AddWithValue("@NUMERO", txtnumero.Text);
                comando.Parameters.AddWithValue("@NOME", txtid.Text);
                conexao.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {

                conexao.Close();
                comando.Clone();
                conexao = null;
                comando = null;
            }
        }
    }
}
            



