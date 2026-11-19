using System;
using System.Data;
using System.Windows.Forms;
using Oficina.Dados.MecanicaDBTableAdapters;

namespace Oficina.Forms
{
    public partial class CadastroOS : Form
    {
        #region Declaração das variaveis globais
        OrdensServicoTableAdapter OS = new OrdensServicoTableAdapter();
        OS_PecasTableAdapter pecas_OS = new OS_PecasTableAdapter();
        OS_ServicosTableAdapter servicos_OS = new OS_ServicosTableAdapter();
        ServicosTableAdapter servico_tabela = new ServicosTableAdapter();
        pecas_para_OSTableAdapter peca_tabela = new pecas_para_OSTableAdapter();
        Clientes1TableAdapter cliente = new Clientes1TableAdapter();
        Veiculos1TableAdapter veiculo = new Veiculos1TableAdapter();
        Funcionarios2TableAdapter funcionario = new Funcionarios2TableAdapter();
        PecasTableAdapter pecas_tabela = new PecasTableAdapter();
        EstoqueTableAdapter estoque = new EstoqueTableAdapter();
        DataTable servicos_dt, pecas_dt, clientes_dt, veiculos_dt, funcionarios_dt;
        double totao_servicos, total_pecas;
        #endregion
        public CadastroOS()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            double subtotal_pecas = (Convert.ToDouble(textBox6.Text) * Convert.ToInt32(numericUpDown2.Value));
            total_pecas += subtotal_pecas;
            valor_pecas.Text = "R$ " + total_pecas.ToString();
            dataGridView2.Rows.Add(comboBox6.Text, numericUpDown2.Value, textBox6.Text, subtotal_pecas);
            totais();
        }

        private void CadastroOS_Load(object sender, EventArgs e)
        {
            pecas_dt = peca_tabela.informacoes_OS();
            servicos_dt = servico_tabela.informacoes_OS();
            clientes_dt = cliente.informacoes_OS();
            funcionarios_dt = funcionario.informacoes_OS();
            
            comboBox6.DisplayMember = "Nome";
            comboBox6.ValueMember = "ID_Peca";
            comboBox6.DataSource = pecas_dt;

            comboBox5.DisplayMember = "Nome";
            comboBox5.ValueMember = "ID_Servico";
            comboBox5.DataSource = servicos_dt;

            comboBox1.DisplayMember = "Nome";
            comboBox1.ValueMember = "ID_Cliente";
            comboBox1.DataSource = clientes_dt;

            comboBox3.DisplayMember = "Nome";
            comboBox3.ValueMember = "ID_Funcionario";
            comboBox3.DataSource = funcionarios_dt;

            comboBox4.SelectedIndex = 0;
            panel5.BringToFront();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(comboBox6.SelectedValue);
            int quantidade = Convert.ToInt32(estoque.pegar_quantidade(id));
            textBox6.Text = peca_tabela.pegar_preco(comboBox6.Text).ToString();
            numericUpDown2.Maximum = Convert.ToDecimal(quantidade);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            veiculos_dt = veiculo.informacoes_OS(comboBox1.Text);
            comboBox2.DataSource = veiculos_dt;
            comboBox2.DisplayMember = "Placa";
            comboBox2.ValueMember = "ID_Veiculo";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
        }

        private void label19_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            foreach (Control c in panel5.Controls)
            {
                if(c is TextBox)
                {
                    c.Text = "";
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                servico_tabela.novo_servico(textBox3.Text, textBox8.Text, Decimal.Parse(textBox4.Text), Convert.ToInt32(textBox7.Text));
                panel5.Visible = false;
                foreach (Control c in panel5.Controls)
                {
                    if (c is TextBox)
                    {
                        c.Text = "";
                    }
                }
                servicos_dt = servico_tabela.informacoes_OS();
                comboBox5.DataSource = servicos_dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow != null)
            {
                dataGridView2.Rows.Remove(dataGridView2.CurrentRow);
                totais();
            }
            else
            {
                MessageBox.Show("Não há nenhuma linha disponível para remoção");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = 0, quantidade = 0, id_servico = 0;
            string nome = "";
            decimal valor = 0;
            try
            {
               id = Convert.ToInt32(OS.Novo_OS((int)comboBox2.SelectedValue, (int)comboBox3.SelectedValue, comboBox4.Text, textBox1.Text, textBox2.Text));
                foreach (DataGridViewRow linha in dataGridView1.Rows)
                {
                    quantidade = Convert.ToInt32(Convert.ToString(linha.Cells["quantas"].Value));
                    valor = Convert.ToDecimal(Convert.ToString(linha.Cells["valor"].Value));
                    nome = Convert.ToString(linha.Cells["servico"].Value);
                    id_servico = (int)servico_tabela.pegar_id(nome);
                    MessageBox.Show($"Salvando -> ID_OS: {id} | ID_Peca: {id_servico} | Qtd: {quantidade} | Valor: {valor}");

                    servicos_OS.Novo_OS(id, id_servico, quantidade, valor);
                }
                foreach (DataGridViewRow linha in dataGridView2.Rows)
                {
                    quantidade = Convert.ToInt32(Convert.ToString(linha.Cells["quantidade"].Value));
                    valor = Convert.ToDecimal(Convert.ToString(linha.Cells["valor_peca"].Value));
                    nome = Convert.ToString(linha.Cells["peca"].Value);
                    id_servico = (int)pecas_tabela.pegar_id(nome);
                    MessageBox.Show($"Salvando -> ID_OS: {id} | ID_Peca: {id_servico} | Qtd: {quantidade} | Valor: {valor}");

                    int linhasAfetadas = pecas_OS.Novo_OS(id, id_servico, quantidade, valor);
                    MessageBox.Show("Linhas gravadas no banco: " + linhasAfetadas);
                }
                MessageBox.Show("Ordem de serviço registrada com sucesso!");
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void CadastroOS_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                totais();
            }
            else
            {
                MessageBox.Show("Não há nenhuma linha disponível para remoção");
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox5.Text = servico_tabela.pegar_preco(comboBox5.Text).ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double subtotal_servicos = (Convert.ToDouble(textBox5.Text) * Convert.ToInt32(numericUpDown1.Value));
            totao_servicos += subtotal_servicos;
            valor_servico.Text = "R$ " + totao_servicos.ToString();
            dataGridView1.Rows.Add(comboBox5.Text, numericUpDown1.Value, textBox5.Text, subtotal_servicos);
            totais();
        }

        private void totais()
        {
            double total_servicos=0, totao_pecas=0, total_todos=0;
            foreach (DataGridViewRow linha in dataGridView1.Rows)
            {
                // Ignora a linha vazia de inserção (se AllowUserToAddRows estiver ativo)
                if (!linha.IsNewRow && linha.Cells["subtotal"].Value != null)
                {
                    if (double.TryParse(linha.Cells["subtotal"].Value.ToString(), out double valor))
                    {
                        total_servicos += valor;
                    }
                }
            }
            foreach (DataGridViewRow linha in dataGridView2.Rows)
            {
                // Ignora a linha vazia de inserção (se AllowUserToAddRows estiver ativo)
                if (!linha.IsNewRow && linha.Cells["subtotal_peca"].Value != null)
                {
                    if (double.TryParse(linha.Cells["subtotal_peca"].Value.ToString(), out double valor))
                    {
                        totao_pecas += valor;
                    }
                }
            }

            total_todos = total_servicos + totao_pecas;

            valor_servico.Text = "R$ " + Convert.ToString(total_servicos);
            valor_pecas.Text = "R$ " + Convert.ToString(totao_pecas);
            valor_total.Text = "R$ " + Convert.ToString(total_todos);
        }
    }
}
