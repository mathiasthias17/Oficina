using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oficina.Dados.MecanicaDBTableAdapters;

namespace Oficina.Forms
{
    public partial class Pagamento_OS : Form
    {
        FinanceiroTableAdapter financeiro = new FinanceiroTableAdapter();
        OS_PagamentosTableAdapter pagamentos = new OS_PagamentosTableAdapter();
        int id_OS;
        public Pagamento_OS()
        {
            InitializeComponent();
        }

        private void Pagamento_OS_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = pagamentos.pegar_os_pendentes();
            carregardados();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            carregardados();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                if (textBox5.Text != null && comboBox1.SelectedIndex != -1)
                {
                    decimal valor = Convert.ToDecimal(textBox5.Text);
                    if (valor > 0 && valor < Convert.ToDecimal(textBox4.Text))
                    {
                        try
                        {
                            financeiro.registrarpagamento(id_OS, valor, comboBox1.Text);
                            textBox5.Text = "";
                            comboBox1.SelectedIndex = -1;
                            MessageBox.Show("OS paga com sucesso");
                            dataGridView1.DataSource = null;
                            dataGridView1.DataSource = pagamentos.pegar_os_pendentes();
                            carregardados();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Informe valores maiores que zero e menores do total pendente");
                    }
                }
                else
                {
                    MessageBox.Show("Informe o valor e a forma de pagamento");
                }
            }
            else
            {
                MessageBox.Show("Primeiro selecione uma OS");
            }
        }
        private void carregardados()
        {
            id_OS = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID_OS"].Value);
            string total = "", ja_pago = "", pendente = "";
            total = Convert.ToString(dataGridView1.CurrentRow.Cells["Total_OS"].Value);
            ja_pago = Convert.ToString(dataGridView1.CurrentRow.Cells["Total_Pago"].Value);
            pendente = Convert.ToString(dataGridView1.CurrentRow.Cells["Valor_Pendente"].Value);
            textBox1.Text = id_OS.ToString();
            textBox2.Text = total;
            textBox3.Text = ja_pago;
            textBox4.Text = pendente;
        }
    }
}
