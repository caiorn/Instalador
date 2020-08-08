using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace InstaladorMapsCS
{
    public partial class frm2Instalacao : Form
    {
        private frm1Inicial form1;

        public frm2Instalacao(frm1Inicial form)
        {
            InitializeComponent();

            this.form1 = form;
            label1.Text = "Diretorio selecionado:\n" + form1.txtPath.Text;

            string[] mapsNames = EmbeddedResources.getNameItemsFromPath("cstrike.maps").Select(c => c.Replace(".bsp", "")).ToArray();
            listarNaLabel(mapsNames, label2, 2);
        }   

        private void btnVoltar_Click(object sender, EventArgs e)
        {            
            form1.Show();
            this.Close();
        }

        private void frm2Instalacao_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!form1.Visible)
            {
                Environment.Exit(0);
            }
        }

        private void btnInstalar_Click(object sender, EventArgs e)
        {
            bool sucessInstall = false;

            if (btnInstalar.Text == "Fechar") {                
                Environment.Exit(0);
                return;
            }

            btnInstalar.Enabled = false;

            BackgroundWorker workerLeituraArquivos = new BackgroundWorker();
            workerLeituraArquivos.WorkerReportsProgress = true;
            workerLeituraArquivos.DoWork += (sender1, e1) =>
            {
                try
                {
                    string[] items = EmbeddedResources.getResourceLocationFiles("cstrike");
                    for (int i = 0; i < items.Length; i++)
                    {
                        //remove o nome do projeto e retorna pastas e subpastas em diretorios 
                        string pathDir = EmbeddedResources.transformStringPathEmbeddedResourcesInDirectories(items[i]);
                        //concateno o destino com todas as pastas filho incluindo o item na (newpath)
                        EmbeddedResources.ExtractEmbeddedResource(form1.txtPath.Text.Replace(@"\cstrike", "") + @"\" + pathDir, items[i]);

                        int porcentagem = (i + 1) * 100 / items.Length;
                        workerLeituraArquivos.ReportProgress(porcentagem);
                    }

                    sucessInstall = true;
                }
                catch (Exception ex)
                 {
                    MessageBox.Show(ex.Message);
                    throw;
                }
            };

            workerLeituraArquivos.ProgressChanged += (sender1, e1) =>
            {
                lblStatus.Text = string.Format("Copiando arquivos. {0}% concluído", e1.ProgressPercentage); 
                progressBar1.Value = e1.ProgressPercentage;
            };

            workerLeituraArquivos.RunWorkerCompleted += (sender1, e1) =>
            {
                if (sucessInstall) { 
                    lblStatus.Text = "Instalação Finalizada.";
                    btnInstalar.Enabled = true;
                    btnInstalar.Text = "Fechar";
                    btnVoltar.Visible = false;
                }
            };

            workerLeituraArquivos.RunWorkerAsync();
        }

        private void listarNaLabel(string[] lista, Label label, int espacamento)
        {
            //ordena a lista pelo tamanho das palavras e alfabeto
            lista = lista.OrderBy(x => x.Length).ThenBy(x => x).ToArray();

            //quantidade de linhas que cabe ate o final da label (cima para baixo) 
            int qnt_line = label.Height / label.Font.Height;
            int qnt_colunas_necessario = lista.Length / qnt_line;// (int)Math.Ceiling(lista.Length / (double)qnt_line);
            int qnt_sobra = lista.Length % qnt_line;


            int[] maiorPalavraCadaColuna = new int[qnt_colunas_necessario];
            //int[] maiorPalavraCadaColuna = new int[qnt_colunas_necessario + (qnt_sobra > 0 ? 1 : 0)];

            int temp = 0;
            for (int i = 0; i < qnt_colunas_necessario; i++)
            {
                maiorPalavraCadaColuna[i] = 0;
                //caça a maior palavra de cada coluna
                for (int j = temp; j < qnt_line * (i + 1); j++)
                    if (maiorPalavraCadaColuna[i] < lista[j].Length)
                        maiorPalavraCadaColuna[i] = lista[j].Length;

                //adiciona espaçamento em todas palavras conforme o tamanho da maior palavra
                for (int j = temp; j < qnt_line * (i + 1); j++)
                    lista[j] = lista[j].PadRight(maiorPalavraCadaColuna[i] + espacamento);


                temp = qnt_line * (i + 1);
            }
            ////maior palavra da coluna de sobra. *133
            //for (int i = temp; i < temp + qnt_sobra; i++)            
            //    if (maiorPalavraCadaColuna[maiorPalavraCadaColuna.Length - 1] < lista[i].Length)                
            //        maiorPalavraCadaColuna[maiorPalavraCadaColuna.Length - 1] = lista[i].Length;

            //formata a string cabendo os array
            string listaFormatada = "";


            if (qnt_colunas_necessario > 1)
            {
                for (int i = 0; i < qnt_line; i++)
                {
                    for (int j = 0; j < qnt_colunas_necessario; j++)
                        listaFormatada += lista[i + qnt_line * j];

                    if (qnt_sobra > 0)
                        listaFormatada += lista[lista.Length - qnt_sobra--];

                    listaFormatada += "\n";
                }
            }
            else
            {
                if (lista.Length < qnt_line)
                {
                    foreach (string item in lista)
                    {
                        listaFormatada += item + "\n";
                    }
                }
            }

            label.Text = listaFormatada;
            /* Label
                Caracteres      Width 
                                8       9       10      11    14
                -------------------------
                1               13      14        14    16       20
                2               19      21        21    24       30
                3               25      28        28             40
                4               31      35        35             50
                borders = 7
                caracter = 6

                //
             */
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(null, "installer created by: caio s.", "thanks.");
        }
    }
}

