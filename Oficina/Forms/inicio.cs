using Oficina.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MeusMetodos;
using System.Windows.Forms;
using Oficina.Dados.MecanicaDBTableAdapters;

namespace Oficina
{
    public partial class inicio : Form
    {

        FuncionariosTableAdapter funcionarios = new FuncionariosTableAdapter();
        pecasTableAdapter pecas = new pecasTableAdapter();
        PecasTableAdapter Pecas = new PecasTableAdapter();
        Pecas1TableAdapter Pegar_ID = new Pecas1TableAdapter();
        ClientesTableAdapter clientes = new ClientesTableAdapter();
        veiculosTableAdapter veiculos = new veiculosTableAdapter();
        EstoqueTableAdapter estoque = new EstoqueTableAdapter();
        FornecedoresTableAdapter fornecedores = new FornecedoresTableAdapter();
        FinanceiroTableAdapter financeiro = new FinanceiroTableAdapter();
        DataTable fornecedor = new DataTable();
        VW_OrdensCompletasTableAdapter ordensCompletasVW = new VW_OrdensCompletasTableAdapter();
        int id;
        public inicio(int nivel, string nome)
        {
            InitializeComponent();
            panel4.BackColor = Color.FromArgb(120, 225, 225, 225);
            panel3.BackColor = Color.FromArgb(150, 225, 225, 225);
            pictureBox8.BackColor = pictureBox9.BackColor = Color.FromArgb(140, 255, 255, 255);
            pictureBox10.BackColor = Color.FromArgb(180, 205, 205, 255);
            panel3.Visible = false;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy HH:mm";
            dateTimePicker2.Value = DateTime.Today;
            button3.BackColor = Color.FromArgb(250, 255, 255, 255);
            pictureBox6.BackColor = Color.FromArgb(120, 10, 10, 10);
            pictureBox4.BackColor = Color.FromArgb(70, 10, 10, 10);
            label5.Text = nome;
            esconder();
            if (nivel == 1)
            {
                MessageBox.Show("Bem-vindo Administrador");
            }
            else if (nivel == 2)
            {
                MessageBox.Show("Bem-vindo Funcionário");
                funcionáriosToolStripMenuItem.Visible = false;
                adicionarFornecedorToolStripMenuItem.Visible = false;
            }
            pictureBox5.ForeColor = ColorTranslator.FromHtml("#FFFFFF");
        }


        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (panel3.Visible == false)
            {
                esconder();
                panel3.Visible = true;
                this.panel3.Location = new Point(265, 31);
                pictureBox6.BackColor = pictureBox4.BackColor = Color.FromArgb(0, 0, 0, 0);
            }
            else
            {
                esconder();
                this.panel3.Location = new Point(321, 585);
                panel3.Visible = false;
                pictureBox6.BackColor = Color.FromArgb(120, 10, 10, 10);
                pictureBox4.BackColor = Color.FromArgb(70, 10, 10, 10);
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Close();
            login loginForm = new login();
            loginForm.Show();

        }
        public void esconder()
        {
            foreach (Control c in this.Controls)
            {
                if (c is Panel)
                {
                    c.Dock = DockStyle.None;
                    c.Visible = false;
                }
            }
        }

        private void peçasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            esconder();
            panel5.Visible = true;
            panel5.Dock = DockStyle.Fill;
            button13.Visible = false;
            button14.Visible = false;
        }

        private void veículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            esconder();
            panel17.Visible = true;
            panel17.Dock = DockStyle.Fill;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm";
            dateTimePicker1.Value = DateTime.Today;
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            esconder();
            panel6.Visible = true;
            panel7.Visible = false;
            panel6.Dock = DockStyle.Fill;
        }

        private void reposiçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel7.Visible = true;
        }

        private void finanaceiroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            esconder();
            panel8.Visible = true;
            panel8.Dock = DockStyle.Fill;
            dataGridView5.Visible = true;
            dataGridView5.DataSource = null;
            dataGridView5.DataSource = financeiro.pegar_financeiro();
        }



        private void fornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            esconder();
            panel20.Visible = false;
            panel9.Visible = true;
            panel9.Dock = DockStyle.Fill;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy HH:mm";
            dateTimePicker2.Value = DateTime.Today;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(250, 200, 200, 200);
            button3.ForeColor = Color.White;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(250, 255, 255, 255);
            button3.ForeColor = Color.Black;
        }

        private void funcionáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            esconder();
            panel10.Visible = true;
            panel10.Dock = DockStyle.Fill;

        }

        private void adicionarFuncionarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            esconder();
            panel10.Visible = true;
            panel10.Dock = DockStyle.Fill;
            panel11.Visible = true;
        }

        private void veiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            esconder();
            panel12.Visible = true;
            panel12.Dock = DockStyle.Fill;
            dataGridView8.DataSource = ordensCompletasVW.Mostrar_ordens();
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(250, 200, 200, 200);
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(250, 255, 255, 255);
        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            Double valor = 0, valor1;//preço_unitario
            valor1 = valor * Convert.ToDouble(numericUpDown7.Value);
            label22.Text = valor.ToString("valor1");
        }

        private void peçasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            esconder();
            panel13.Visible = true;
            panel13.Dock = DockStyle.Fill;
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            button5.BackColor = Color.FromArgb(250, 200, 200, 200);
            button5.ForeColor = Color.White;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.FromArgb(250, 255, 255, 255);
            button5.ForeColor = Color.Black;
        }

        private void serviçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            esconder();
            panel15.Visible = true;
            panel15.Dock = DockStyle.Fill;
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                DataTable dt = funcionarios.mostrar_funcionarios();

                dataGridView7.AutoGenerateColumns = true;
                dataGridView7.DataSource = null;
                dataGridView7.DataSource = dt;
                dataGridView7.AllowUserToAddRows = false;
                dataGridView7.RowHeadersVisible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        decimal valor = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            string cpf = "";
            if (Documentos.ValidarCPF(maskedTextBox3.Text)){
                cpf = maskedTextBox3.Text;
            }
            else
            {
                MessageBox.Show("esse CPF não pode existir");
            }
                string nome = textBox3.Text, telefone = maskedTextBox4.Text, cargo = textBox4.Text, email = textBox11.Text, senha = maskedTextBox5.Text;
            decimal salario = valor;
            DateTime data = dateTimePicker2.Value;
            int nivele = comboBox2.SelectedIndex + 1;
            funcionarios.adicionar_funcionario(nome, cpf, cargo, telefone, salario, data.ToString(), senha, email, nivele);
            dataGridView7.DataSource = null;
            dataGridView7.DataSource = funcionarios.mostrar_funcionarios();
        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {
            textBox5.TextChanged -= textBox5_TextChanged_1;
            string numeros = new string(textBox5.Text.Where(char.IsDigit).ToArray());

            if (numeros == "") numeros = "0";

            try
            {
                valor = decimal.Parse(numeros) / 100;
            }
            catch
            {
                MessageBox.Show("Esse valor é muito grande.");
            }

            textBox5.Text = valor.ToString("C");
            textBox5.SelectionStart = textBox5.Text.Length;
            textBox5.TextChanged += textBox5_TextChanged_1;
        }

        private void panel17_Paint(object sender, PaintEventArgs e)
        {
            dataGridView11.DataSource = veiculos.Mostrar_Veiculos();
            dataGridView11.Columns[0].Visible = false;
            dataGridView11.Columns[1].Visible = false;
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            dataGridView2.DataSource = clientes.Mostrar_Clientes();
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.RowHeadersVisible = false;
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            dataGridView4.DataSource = pecas.Mostrar_Pecas();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                panel18.Enabled = true;
                panel19.Enabled = false;
            }
            else
            {
                panel18.Enabled = false;
                panel19.Enabled = true;
            }
        }

        private void inicio_Load(object sender, EventArgs e)
        {
            try
            {
                panel6.Visible = true;
                panel6.Dock = DockStyle.Fill;
                radioButton2.Checked = true;
                fornecedor = fornecedores.Pegar_Fornecedor();

                comboBox1.DataSource = fornecedor;
                comboBox1.DisplayMember = fornecedor.Columns[1].ColumnName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                try
                {
                    int id_peca = int.Parse(numericUpDown1.Value.ToString());
                    int quantidade = int.Parse(numericUpDown2.Value.ToString());
                    DateTime atualizacao = dateTimePicker1.Value;
                    estoque.Atualizar_Peca(quantidade, atualizacao.ToString(), id_peca);
                    panel6.Invalidate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    //Adicionar a peca na tabela Pecas
                    string nome = textBox6.Text, codigo = textBox10.Text;
                    decimal valor_compra = decimal.Parse(textBox8.Text), valor_venda = decimal.Parse(textBox9.Text);
                    int quantidade = int.Parse(numericUpDown9.Value.ToString()), quantidade_minima = int.Parse(numericUpDown10.Value.ToString());
                    int ID_fornecedor = comboBox1.SelectedIndex + 1;
                    DateTime atualizacao = dateTimePicker1.Value;
                    Pecas.Adicionar_Peca(ID_fornecedor, nome, codigo, valor_compra, valor_venda);

                    //Adicionar a peca na tabela Estoque

                    DataTable ID_peca = Pegar_ID.Pegar_ID_Nova(nome);
                    int id_peca = Convert.ToInt32(ID_peca.Rows[0]["ID_Peca"]);
                    estoque.Adicionar_Peca(id_peca, quantidade, quantidade_minima, atualizacao.ToString());
                    panel6.Invalidate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void label25_Click(object sender, EventArgs e)
        {
            panel7.Visible = false;
        }

        private void label33_Click(object sender, EventArgs e)
        {
            panel20.Visible = false;
        }

        private void adicionarFornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel20.Visible = true;
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                dataGridView6.DataSource = fornecedores.Mostrar_Fornecedores();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string CNPJ = "";
                if (Documentos.ValidarCnpj(maskedTextBox2.Text))
                {
                    CNPJ = maskedTextBox2.Text;
                }
                else
                {
                    MessageBox.Show("esse CNPJ não pode existir");
                    return;
                }
                string Nome = textBox7.Text, Telefone = maskedTextBox1.Text, Email = textBox13.Text, Endereco = textBox14.Text;
                fornecedores.Adicionar_Fornecedor(Nome, CNPJ, Telefone, Email, Endereco);
                panel9.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label40_Click(object sender, EventArgs e)
        {
            panel11.Visible = false;
        }

        private void label50_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void panel1_VisibleChanged(object sender, EventArgs e)
        {
            foreach (Control c in panel1.Controls)
            {
                if (c is TextBox) c.Text = null;
                if (c is MaskedTextBox) c.Text = null;
                if (c is DateTimePicker) c.Text = null;
            }
            comboBox2.SelectedIndex = -1;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            { 
                string cpf;
                if (Documentos.ValidarCPF(maskedTextBox8.Text)){
                    cpf = maskedTextBox8.Text;
                }
                else
                {
                    MessageBox.Show("esse CPF não pode existir");
                    return;
                }
                string nome = textBox17.Text, cargo = textBox16.Text, telefone = maskedTextBox7.Text,
                data_admissao = dateTimePicker3.Text, email = textBox12.Text, senha = maskedTextBox6.Text;
                decimal salario = Convert.ToDecimal(textBox15.Text);
                int nivele = Math.Abs(comboBox3.SelectedIndex + 1);
                funcionarios.Atualizar_funcionario(nome, cpf, cargo, telefone, salario, data_admissao, email, senha, nivele, id);
                panel1.Visible = false;
                dataGridView7.DataSource = null;
                dataGridView7.DataSource = funcionarios.mostrar_funcionarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel11.Visible = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel11.Visible = false;
            panel1.Visible = true;

            try
            {
                DataTable funcionario = funcionarios.mostrar_funcionario(id);
                if (funcionario.Rows.Count > 0)
                {
                    int nivel = Convert.ToInt32(funcionario.Rows[0]["nivel"]);
                    textBox17.Text = funcionario.Rows[0]["Nome"].ToString();
                    maskedTextBox8.Text = funcionario.Rows[0]["CPF"].ToString();
                    textBox16.Text = funcionario.Rows[0]["Cargo"].ToString();
                    maskedTextBox7.Text = funcionario.Rows[0]["Telefone"].ToString();
                    textBox15.Text = funcionario.Rows[0]["Salario"].ToString();
                    dateTimePicker3.Value = Convert.ToDateTime(funcionario.Rows[0]["Data_Admissao"]);
                    textBox12.Text = funcionario.Rows[0]["email"].ToString();
                    maskedTextBox6.Text = funcionario.Rows[0]["senha"].ToString();
                    comboBox3.SelectedIndex = nivel - 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show($"Deseja realmente excluir o funcionario {dataGridView7.CurrentRow.Cells["Cargo"].Value} {dataGridView7.CurrentRow.Cells["Nome"].Value}", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                
                    funcionarios.excluir_funcionario(id);
                    dataGridView7.DataSource = null;
                    dataGridView7.DataSource = funcionarios.mostrar_funcionarios();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView7_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button10.Visible = true;
            button11.Visible = true;
            id = (int)dataGridView7.CurrentRow.Cells["ID_Funcionario"].Value;
        }

        private void dataGridView7_Paint(object sender, PaintEventArgs e)
        {

            id = (int)dataGridView7.CurrentRow.Cells["ID_Funcionario"].Value;
        }

        private void dataGridView7_MouseClick(object sender, MouseEventArgs e)
        {
            button10.Visible = true;
            button11.Visible = true;
            id = (int)dataGridView7.CurrentRow.Cells["ID_Funcionario"].Value;
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            button13.Visible = true;
            button14.Visible = true;
            id = Convert.ToInt32(dataGridView2.CurrentRow.Cells["ID_Cliente"].Value);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            panel23.Visible = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            panel23.Visible = false;
            panel24.Visible = true;
            try
            {
                DataTable Clientes = clientes.Mostrar_Cliente(id);
                if (Clientes.Rows.Count > 0)
                {
                    textBox23.Text = Clientes.Rows[0]["Nome"].ToString();
                    maskedTextBox11.Text = Clientes.Rows[0]["CPF"].ToString();
                    textBox22.Text = Clientes.Rows[0]["Email"].ToString();
                    maskedTextBox12.Text = Clientes.Rows[0]["Telefone"].ToString();
                    textBox21.Text = Clientes.Rows[0]["Endereco"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show($"Deseja realmente excluir o cliente {dataGridView2.CurrentRow.Cells["Nome"].Value}", " ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                clientes.excluir_clientes(id);
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = clientes.Mostrar_Clientes();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string cpf = "";
            if (Documentos.ValidarCPF(maskedTextBox10.Text))
            {
                cpf = maskedTextBox10.Text;
            }
            else
            {
                MessageBox.Show("Esse CPF não pode existir");
                return;
            }
            string nome = textBox18.Text, telefone = maskedTextBox9.Text, email = textBox19.Text, endereco = textBox20.Text, data_cadastro = Convert.ToString(DateTime.Now);
            foreach (Control c in panel23.Controls)
            {
                if (string.IsNullOrWhiteSpace(c.Text))
                {
                    MessageBox.Show("nenhum campo pode estar vazio");
                    return;
                }
            }
            clientes.adicionarCliente(nome, cpf, telefone, email, endereco, data_cadastro);
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = clientes.Mostrar_Clientes();
            foreach (Control c in panel24.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
                if (c is MaskedTextBox)
                {
                    c.Text = "";
                }
            }

            panel23.Visible = false;
        }

        private void label57_Click(object sender, EventArgs e)
        {
            foreach(Control c in panel23.Controls)
            {
                if(c is TextBox)
                {
                    c.Text = "";
                }
                if(c is MaskedTextBox)
                {
                    c.Text = "";
                }
            }
            panel23.Visible = false;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string cpf = "";
            if (Documentos.ValidarCPF(maskedTextBox11.Text))
            {
                cpf = maskedTextBox11.Text;
            }
            else
            {
                MessageBox.Show("Esse CPF não pode existir");
                return;
            }
            string nome = textBox23.Text, telefone = maskedTextBox12.Text, email = textBox22.Text, endereco = textBox21.Text;
            foreach (Control c in panel24.Controls)
            {
                if (c is MaskedTextBox || c is TextBox)
                {
                    if (string.IsNullOrEmpty(c.Text))
                    {
                        MessageBox.Show("Nenhum campo pode estar vazio");
                        return;
                    }
                }
            }
            clientes.Atualizar_cliente(nome, cpf, telefone, email, endereco, id);
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = clientes.Mostrar_Clientes();
            foreach (Control c in panel24.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
                if (c is MaskedTextBox)
                {
                    c.Text = "";
                }
            }
            panel24.Visible = false;
        }

        private void label58_Click(object sender, EventArgs e)
        {
            foreach (Control c in panel24.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
                if (c is MaskedTextBox)
                {
                    c.Text = "";
                }
            }

            panel24.Visible = false;
        }

        private void inicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Historico historico = new Historico(id);
            historico.Show();
        }

        private void dataGridView8_MouseClick(object sender, MouseEventArgs e)
        {
            button19.Visible = true;
            id = Convert.ToInt32(dataGridView8.CurrentRow.Cells["ID_OS"].Value);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            CadastroOS cadastro = new CadastroOS();
            cadastro.Show();
        }
        //try
        //    {
        //        var dados = pecas.Mostrar_Pecas();

        //MessageBox.Show(
        //            "Linhas: " + dados.Rows.Count +
        //            "\nColunas: " + dados.Columns.Count
        //        );

        //        dataGridView11.DataSource = dados;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}
    }
}
