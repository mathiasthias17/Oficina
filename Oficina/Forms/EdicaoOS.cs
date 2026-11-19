using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Oficina.Dados.MecanicaDBTableAdapters;

namespace Oficina.Forms
{
    public partial class EdicaoOS : Form
    {
        #region declaração de variaveis globais
        QueriesTableAdapter queries = new QueriesTableAdapter();
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
        OS_Servicos_EdicaoTableAdapter OS_Servicos_Edicao = new OS_Servicos_EdicaoTableAdapter();
        OS_Pecas_EdicaoTableAdapter OS_Pecas_Edicao = new OS_Pecas_EdicaoTableAdapter();
        VW_OrdensCompletasTableAdapter ordenscompletasVW = new VW_OrdensCompletasTableAdapter();
        DataTable servicos_dt, pecas_dt, clientes_dt, veiculos_dt, funcionarios_dt, basico, servicos_edicao, pecas_edicao;
        List<int> pecasRemovidas = new List<int>();
        List<int> servicosRemovidos = new List<int>();
        double totao_servicos, total_pecas;
        int id;
        #endregion

        public EdicaoOS(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox5.Text = servico_tabela.pegar_preco(comboBox5.Text).ToString();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(comboBox6.SelectedValue);
            int quantidade = Convert.ToInt32(estoque.pegar_quantidade(id));
            textBox6.Text = peca_tabela.pegar_preco(comboBox6.Text).ToString();
            numericUpDown2.Maximum = Convert.ToDecimal(quantidade);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double subtotal_servicos = (Convert.ToDouble(textBox5.Text) * Convert.ToInt32(numericUpDown1.Value));
            totao_servicos += subtotal_servicos;
            valor_servico.Text = "R$ " + totao_servicos.ToString();
            dataGridView1.Rows.Add(comboBox5.Text, numericUpDown1.Value, textBox5.Text, subtotal_servicos);
            totais();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex == 3 || comboBox4.SelectedIndex == 4)
            {
                MessageBox.Show("Utilize o botão Finalizar para encerrar a OS.");
                return;
            }

            editar();
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {
            double subtotal_pecas = (Convert.ToDouble(textBox6.Text) * Convert.ToInt32(numericUpDown2.Value));
            total_pecas += subtotal_pecas;
            valor_pecas.Text = "R$ " + total_pecas.ToString();
            dataGridView2.Rows.Add(comboBox6.Text, numericUpDown2.Value, textBox6.Text, subtotal_pecas);
            totais();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                if (dataGridView1.CurrentRow.Cells["id_os_servico"].Value != DBNull.Value && dataGridView1.CurrentRow.Cells["id_os_servico"].Value != null)
                {
                    servicosRemovidos.Add(Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_os_servico"].Value));
                }
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);                
                totais();
            }
            else
            {
                MessageBox.Show("Não há nenhuma linha disponível para remoção");
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow != null)
            {
                if (dataGridView2.CurrentRow.Cells["id_os_peca"].Value != DBNull.Value && dataGridView2.CurrentRow.Cells["id_os_peca"].Value != null)
                {
                    pecasRemovidas.Add(Convert.ToInt32(dataGridView2.CurrentRow.Cells["id_os_peca"].Value));
                }
                dataGridView2.Rows.Remove(dataGridView2.CurrentRow);
                totais();
            }
            else
            {
                MessageBox.Show("Não há nenhuma linha disponível para remoção");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if(comboBox4.SelectedIndex != 3 && comboBox4.SelectedIndex != 4)
            {
                comboBox4.SelectedIndex = 3;
                finalizar_ou_cancelar();
            }
            else if (comboBox4.SelectedIndex == 3 || comboBox4.SelectedIndex == 4)
            {
                finalizar_ou_cancelar();
            }
        }

        private void EdicaoOS_Load(object sender, EventArgs e)
        {
            carregardados();
        }

        private void carregardados()
        {
            double subtotal_servicos = 0, subtotal_pecas = 0;
            basico = ordenscompletasVW.Mostrar_ordem(id);
            servicos_edicao = OS_Servicos_Edicao.pegar_servicos(id);
            pecas_edicao = OS_Pecas_Edicao.pegar_pecas(id);
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


            if (basico.Rows.Count > 0)
            {
                comboBox1.SelectedIndex = comboBox1.FindStringExact(basico.Rows[0]["Cliente"].ToString());
                comboBox2.SelectedIndex = comboBox2.FindStringExact(basico.Rows[0]["Placa"].ToString());
                comboBox3.SelectedIndex = comboBox3.FindStringExact(basico.Rows[0]["Funcionario"].ToString());
                comboBox4.SelectedIndex = comboBox4.FindStringExact(basico.Rows[0]["Status_OS"].ToString());
                textBox1.Text = basico.Rows[0]["Problema_Relatado"].ToString();
                textBox2.Text = basico.Rows[0]["Observacoes"].ToString();
                if (servicos_edicao.Rows.Count > 0)
                {
                    for (int i = 0; i < servicos_edicao.Rows.Count; i++)
                    {
                        subtotal_servicos = (Convert.ToDouble(servicos_edicao.Rows[i]["Preco_Unitario"].ToString()) * Convert.ToDouble(servicos_edicao.Rows[i]["quantidade"].ToString()));
                        

                        dataGridView1.Rows.Add(servicos_edicao.Rows[i]["Nome"].ToString(), servicos_edicao.Rows[i]["quantidade"], servicos_edicao.Rows[i]["Preco_Unitario"], subtotal_servicos, servicos_edicao.Rows[i]["ID_OS_Servico"].ToString());
                    }
                }
                if (pecas_edicao.Rows.Count > 0)
                {
                    for (int i = 0; i < pecas_edicao.Rows.Count; i++)
                    {
                        subtotal_pecas = (Convert.ToDouble(pecas_edicao.Rows[i]["Preco_Unitario"].ToString()) * Convert.ToDouble(pecas_edicao.Rows[i]["quantidade"].ToString()));
                        dataGridView2.Rows.Add(pecas_edicao.Rows[i]["Nome"].ToString(), pecas_edicao.Rows[i]["quantidade"], pecas_edicao.Rows[i]["Preco_Unitario"], subtotal_pecas, pecas_edicao.Rows[i]["ID_OS_Peca"].ToString());
                    }
                }

                comboBox2.DisplayMember = "Placa";
                comboBox2.ValueMember = "ID_Veiculo";
                veiculos_dt = veiculo.informacoes_OS(comboBox1.Text);
                comboBox2.DataSource = veiculos_dt;
                totais();
            }
            panel5.BringToFront();
        }

        private void totais()
        {
            double total_servicos = 0, totao_pecas = 0, total_todos = 0;
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

        private void editar()
        {
            int quantidade = 0, id_servico = 0;
            string nome = "";
            decimal valor = 0;
            try
            {
                OS.atualizar_OS((int)comboBox3.SelectedValue, comboBox4.Text, textBox1.Text, textBox2.Text, id);
                foreach (DataGridViewRow linha in dataGridView1.Rows)
                {
                    if (linha.Cells["id_os_servico"].Value == null || linha.Cells["id_os_servico"].Value == DBNull.Value)
                    {
                        quantidade = Convert.ToInt32(Convert.ToString(linha.Cells["quantas"].Value));
                        valor = Convert.ToDecimal(Convert.ToString(linha.Cells["valor"].Value));
                        nome = Convert.ToString(linha.Cells["servico"].Value);
                        id_servico = (int)servico_tabela.pegar_id(nome);
                        servicos_OS.Novo_OS(id, id_servico, quantidade, valor);
                    }
                }
                foreach (DataGridViewRow linha in dataGridView2.Rows)
                {
                    if (linha.Cells["id_os_peca"].Value == null || linha.Cells["id_os_peca"].Value == DBNull.Value)
                    {
                        quantidade = Convert.ToInt32(Convert.ToString(linha.Cells["quantidade"].Value));
                        valor = Convert.ToDecimal(Convert.ToString(linha.Cells["valor_peca"].Value));
                        nome = Convert.ToString(linha.Cells["peca"].Value);
                        id_servico = (int)pecas_tabela.pegar_id(nome);
                        pecas_OS.Novo_OS(id, id_servico, quantidade, valor);
                    }
                }
                foreach (int i in pecasRemovidas)
                {
                    queries.remover_peca(id.ToString(), i);
                }
                foreach (int i in servicosRemovidos)
                {
                    servicos_OS.remover_servicos(i);
                }
                MessageBox.Show("Ordem de serviço registrada com sucesso!");
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void finalizar_ou_cancelar()
        {
            if (MessageBox.Show($"Você está prestes a finalizar/cancelar uma ordem de serviço,{Environment.NewLine} após isso, não sera mais possível abri-la novamente, nem editar ela{Environment.NewLine}{Environment.NewLine} Deseja realmente finalizar/cancelar essa OS?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int quantidade = 0, id_servico = 0;
                string nome = "";
                decimal valor = 0;
                try
                {
                    foreach (DataGridViewRow linha in dataGridView1.Rows)
                    {
                        if (linha.Cells["id_os_servico"].Value == null || linha.Cells["id_os_servico"].Value == DBNull.Value)
                        {
                            quantidade = Convert.ToInt32(Convert.ToString(linha.Cells["quantas"].Value));
                            valor = Convert.ToDecimal(Convert.ToString(linha.Cells["valor"].Value));
                            nome = Convert.ToString(linha.Cells["servico"].Value);
                            id_servico = (int)servico_tabela.pegar_id(nome);
                            servicos_OS.Novo_OS(id, id_servico, quantidade, valor);
                        }
                    }
                    foreach (DataGridViewRow linha in dataGridView2.Rows)
                    {
                        if (linha.Cells["id_os_peca"].Value == null || linha.Cells["id_os_peca"].Value == DBNull.Value)
                        {
                            quantidade = Convert.ToInt32(Convert.ToString(linha.Cells["quantidade"].Value));
                            valor = Convert.ToDecimal(Convert.ToString(linha.Cells["valor_peca"].Value));
                            nome = Convert.ToString(linha.Cells["peca"].Value);
                            id_servico = (int)pecas_tabela.pegar_id(nome);
                            pecas_OS.Novo_OS(id, id_servico, quantidade, valor);
                        }
                    }
                    foreach (int i in pecasRemovidas)
                    {
                        queries.remover_peca(id.ToString(), i);
                    }
                    foreach (int i in servicosRemovidos)
                    {
                        servicos_OS.remover_servicos(i);
                    }
                    OS.finalizar_ou_cancelar_OS((int)comboBox3.SelectedValue, comboBox4.Text, textBox1.Text, textBox2.Text, id);
                    MessageBox.Show("Ordem de serviço finalizada/cancelada com sucesso!");
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

    }

}
