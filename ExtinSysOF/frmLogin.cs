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

namespace ExtinSysOF
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja sair do sistema?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            frmCadUsers frm = new frmCadUsers();
            frm.Show();
            this.Visible = false;
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            bool Result = false;
            bool Resultado = false;

            string connectionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\ExtinDB.mdf;Integrated Security=true";
            SqlConnection con = new SqlConnection(connectionString);

            try
            {
                SqlCommand cmd = new SqlCommand("SELECT users FROM Usuarios where users='" + txtUser.Text + "' and pass='" + txtPass.Text + "';", con);
                con.Open();
                SqlDataReader dados = cmd.ExecuteReader();
                Result = dados.HasRows;
            }
            catch (System.Data.SqlClient.SqlException sqlException)
            {
                System.Windows.Forms.MessageBox.Show(sqlException.Message);
            }
            finally
            {
                con.Close();
            }

            Resultado = Result;

            if (Result)
            {
                MessageBox.Show("Seja bem vindo");
                frmPerfil frm = new frmPerfil();
                frm.Show();
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorreto!");
            }  
        }
    }
}
