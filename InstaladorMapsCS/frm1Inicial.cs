using System;
using System.IO;
using System.Windows.Forms;

namespace InstaladorMapsCS
{
    public partial class frm1Inicial : Form
    {       
        public frm1Inicial()
        {
            InitializeComponent();
        }

        private void btnAvancar_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frm2Instalacao(this).Show();
        }

        private void bntSearchFolder_Click(object sender, EventArgs e)
        {            
            FolderBrowserDialog fbd = new FolderBrowserDialog() { SelectedPath = txtPath.Text };
            //abre caixa de dialogo para selecao da pasta e coloca no a path no txt
            txtPath.Text = fbd.ShowDialog() == DialogResult.OK ? fbd.SelectedPath : "";
        }

        private void txtPath_TextChanged(object sender, EventArgs e)
        {
            //habilita botao se diretorio existir
            btnAvancar.Enabled = Directory.Exists(txtPath.Text);
        }
    }
}
