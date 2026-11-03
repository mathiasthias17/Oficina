using Oficina.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
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
        public inicio(int nivel, string nome)
        {
            InitializeComponent();
            panel4.BackColor = Color.FromArgb(120, 225, 225, 225);
            panel3.BackColor = Color.FromArgb(150, 225, 225, 225);
            pictureBox8.BackColor = pictureBox9.BackColor = Color.FromArgb(140, 255, 255, 255);
            pictureBox10.BackColor = Color.FromArgb(180, 205, 205, 255);
            panel3.Visible = false;
            dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
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
                this.panel3.Location = new System.Drawing.Point(265, 31);
                pictureBox6.BackColor = pictureBox4.BackColor = Color.FromArgb(0, 0, 0, 0);
            }
            else
            {
                esconder();
                this.panel3.Location = new System.Drawing.Point(321, 585);
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
            foreach(Control c in this.Controls)
            {
                if(c is Panel)
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
            int nada;
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
            string nome = textBox3.Text, cpf = maskedTextBox3.Text, telefone = maskedTextBox4.Text, cargo = textBox4.Text, email = textBox11.Text, senha = maskedTextBox5.Text;
            decimal salario = valor;
            DateTime data = dateTimePicker2.Value;
            int nivele = comboBox2.SelectedIndex + 1;
            funcionarios.adicionar_funcionario(nome, cpf, cargo, telefone, salario, data.ToString(), senha, email, nivele);
            panel10.Invalidate();
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
            dataGridView2.Columns[0].Visible = false;
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
                string Nome = textBox7.Text, CNPJ = maskedTextBox2.Text, Telefone = maskedTextBox1.Text, Email = textBox13.Text, Endereco = textBox14.Text;
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

        private void dataGridView5_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

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
