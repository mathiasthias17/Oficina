using System;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data;
using System.IO;
using Oficina.Dados.MecanicaDBTableAdapters;

namespace Oficina.Forms
{
    public partial class Relatorios : Form
    {
        public Relatorios()
        {
            InitializeComponent();
        }

        private void Relatorios_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "Conteúdo";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ExportarPDF();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ExportarExcel();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExportarPDF()
        {
            byte[] arquivo = reportViewer1.LocalReport.Render("PDF");

            using (SaveFileDialog salvar = new SaveFileDialog())
            {
                salvar.Filter = "Arquivo PDF (*.pdf)|*.pdf";
                salvar.FileName = "Relatorio.pdf";

                if (salvar.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(salvar.FileName, arquivo);

                    MessageBox.Show(
                        "Relatório exportado com sucesso!",
                        "",
                        MessageBoxButtons.OK
                    );
                }
            }
        }
        private void ExportarExcel()
        {
            byte[] arquivo = reportViewer1.LocalReport.Render("EXCELOPENXML");

            using (SaveFileDialog salvar = new SaveFileDialog())
            {
                salvar.Filter = "Arquivo Excel (*.xlsx)|*.xlsx";
                salvar.FileName = "Relatorio.xlsx";

                if (salvar.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(salvar.FileName, arquivo);

                    MessageBox.Show(
                        "Relatório exportado com sucesso!",
                        "",
                        MessageBoxButtons.OK
                    );
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            reportViewer1.PrintDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                reportViewer1.LocalReport.DataSources.Clear();

                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.LocalReport.ReportPath = Path.Combine(Application.StartupPath, "relatorios", "OS.rdlc");

                        var osAdapter = new RelatorioOSTableAdapter();
                        DataTable dadosOS = osAdapter.relatorio();

                        reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("OSrdlc", dadosOS));
                        break;

                    case 1:
                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.LocalReport.ReportPath = Path.Combine(Application.StartupPath, "relatorios", "Financeiro.rdlc");
                        var financeiroAdapter = new FinanceiroRelatorioTableAdapter();
                        DataTable dadosFinanceiro = financeiroAdapter.relatorio();

                        reportViewer1.LocalReport.DataSources.Add( new ReportDataSource("Financeiro_relatorio", dadosFinanceiro));
                        break;

                    case 2:
                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.LocalReport.ReportPath = Path.Combine(Application.StartupPath, "relatorios", "FinanceiroOS.rdlc");
                        var osFinanceiroAdapter = new FinanceiroOSTableAdapter();
                        DataTable dadosOSFinanceiro = osFinanceiroAdapter.relatorio();

                        reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("FinanceiroOS_relatorio", dadosOSFinanceiro));
                        break;

                    default:
                        break;
                }

                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
