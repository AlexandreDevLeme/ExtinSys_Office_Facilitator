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
    public partial class frmCadUsers : Form
    {
        public int cod;

        public frmCadUsers()
        {
            InitializeComponent();
        }
        private void exibe_users()
        {
            SqlDataAdapter adaptador;
            string connectionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\ExtinDB.mdf;Integrated Security=true";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            DataTable dt = new DataTable();
            adaptador = new SqlDataAdapter("SELECT * FROM Usuarios", con);
            adaptador.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void frmCadUsers_Load(object sender, EventArgs e)
        {
            exibe_users();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\ExtinDB.mdf;Integrated Security=true";
            string sql = "INSERT INTO USUARIOS (nome,email,users,pass) " + "VALUES ('" + txtNome.Text + "', '" + txtEmail.Text + "' ,'" + txtUser.Text + "' ,'" + txtPass.Text + "')";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Usuário cadastrado com sussesso");
            con.Close();
            exibe_users();
            txtNome.Text = "";
            txtEmail.Text = "";
            txtUser.Text = "";
            txtPass.Text = "";
            btnSave.Enabled = false;
            btnNovo.Enabled = true;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            txtNome.Enabled = true;
            txtEmail.Enabled = true;
            txtUser.Enabled = true;
            txtPass.Enabled = true;
            btnNovo.Enabled = false;
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnDel.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            cod = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
            string connectionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\ExtinDB.mdf;Integrated Security=true";
            string sql = "UPDATE USUARIOS SET nome='" + txtNome.Text + "', email='" + txtEmail.Text + "' , users='" + txtUser.Text + "' , pass='" + txtPass.Text + "' WHERE codigo=" + cod;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Usuário atualizados com sussesso");
            con.Close();
            exibe_users();
            txtNome.Text = "";
            txtEmail.Text = "";
            txtUser.Text = "";
            txtPass.Text = "";
            txtNome.Enabled = false;
            txtEmail.Enabled = false;
            txtUser.Enabled = false;
            txtPass.Enabled = false;
            dataGridView1.Enabled = true;
            btnEdit.Enabled = false;
            btnDel.Enabled = false;
            btnNovo.Enabled = true;
            btnSave.Enabled = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cod = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
            btnDel.Enabled = true;
            
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cod = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
            //Lançando os campos do DataGridView para as variavel da classe
            txtNome.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
            txtEmail.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
            txtUser.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
            txtPass.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
            dataGridView1.Enabled = false;
            txtNome.Enabled = true;
            txtEmail.Enabled = true;
            txtUser.Enabled = true;
            txtPass.Enabled = true;
            btnEdit.Enabled = true;
            btnNovo.Enabled = false;
            btnSave.Enabled = false;
            btnDel.Enabled = false;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            cod = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
            string connectionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\ExtinDB.mdf;Integrated Security=true";
            string sql = "DELETE FROM USUARIOS WHERE codigo=" + cod;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Usuário excluido com sussesso");
            con.Close();
            exibe_users();
            btnDel.Enabled = false;
            btnNovo.Enabled = true;
            btnSave.Enabled = false;
            btnEdit.Enabled = false;
            dataGridView1.Enabled = true;
            txtNome.Enabled = true;
            txtEmail.Enabled = true;
            txtUser.Enabled = true;
            txtPass.Enabled = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.Show();
            this.Visible = false;
        }

    }
}
