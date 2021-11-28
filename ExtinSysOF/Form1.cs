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
    public partial class frmSplash : Form
    {
        public int barra = 0, contador = 0;
        public frmSplash()
        {
            InitializeComponent();
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            barra++;
            pbSplash.Value++;

            if (barra == 20)
            {
                lblSplash.Text = "Carregando arquivos do sistema";
            }
            else if (barra == 40)
            {
                lblSplash.Text = "Carregando perfil da empresa";
            }
            else if (barra == 60)
            {
                lblSplash.Text = "Conectando Banco de Dados";
            }
            else if (barra == 80)
            {
                lblSplash.Text = "Banco de Dados carregado.";
            }
            else if (barra == 100 && pbSplash.Value == 100)
            {
                timer1.Enabled = false;
                frmLogin frm = new frmLogin();
                frm.Show();
                this.Visible = false;
            }
        }
    }
}
