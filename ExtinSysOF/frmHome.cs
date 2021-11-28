using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtinSysOF
{
    public partial class frmHome : Form
    {
        public string tempCase = "";
        public int contador = 0;

        public frmHome()
        {
            InitializeComponent();
        }

        private void frmHome_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MessageBox.Show("Deseja realmente fechar o sistema?", "Fechar o Programa?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void relogarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja voltar a tela de login?", "Sair do Sistema?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                tempCase = "Login";
                timer1.Enabled = true;
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente fechar o sistema?", "Fechar o Programa?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                tempCase = "Sair";
                timer1.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tempCase == "Sair" || tempCase == "Login")
            {
                contador++;
                toolStripProgressBar1.Value++;

                if (contador == 1)
                {
                    toolStripStatusLabel1.Text = "Server: Offline";
                    toolStripStatusLabel6.Text = "Desligando Servidor";
                }
                else if (contador == 20)
                {
                    toolStripStatusLabel6.Text = "Deslogando Empresa";
                    toolStripStatusLabel2.Text = "Empressa: Offline";
                    toolStripStatusLabel3.Text = "licença: Teste";
                    pictureBox1.Image = ExtinSysOF.Properties.Resources.plano_de_fundo_ExtinSys;
                }
                else if (contador == 50)
                {
                    toolStripStatusLabel6.Text = "Deslogando Usuário";
                    toolStripStatusLabel4.Text = "Usuário: Teste";
                }
                else if (contador == 80)
                {
                    toolStripStatusLabel6.Text = "Fechando Sistema";
                }
                else if (contador == 100 && toolStripProgressBar1.Value == 100)
                {
                    if (tempCase == "Login")
                    {
                        timer1.Enabled = false;
                        frmLogin frm = new frmLogin();
                        frm.Show();
                        this.Visible = false;
                    }
                    else if (tempCase == "Sair")
                    {
                        timer1.Enabled = false;
                        Application.Exit();
                    }
                }
            }
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            int wt = this.Width - 55;
            int ht = this.Height - 100;

            pictureBox1.Size = new Size(wt, ht);

            MessageBox.Show(wt + "e " + ht);
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSobre frm = new frmSobre();
            frm.Show();
        }
    }
}
