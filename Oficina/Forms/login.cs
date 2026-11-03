using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oficina.Dados.MecanicaDBTableAdapters;

namespace Oficina.Forms
{
    public partial class login : Form
    {
        FuncionariosTableAdapter funcionarios = new FuncionariosTableAdapter();
        Funcionarios1TableAdapter funcionarios1 = new Funcionarios1TableAdapter();
        public login()
        {
            InitializeComponent();
            panel1.BackColor = Color.FromArgb(120, 255, 255, 255);
            button1.BackColor = Color.FromArgb(120, 225, 225, 225);
            pictureBox1.BackColor = Color.FromArgb(120, 225, 225, 225);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = funcionarios1.login_normal(textBox1.Text, textBox2.Text);
                if (dt.Rows.Count > 0)
                {
                    int nivel = Convert.ToInt32(dt.Rows[0][0]);
                    string nome = Convert.ToString(dt.Rows[0][1]);
                    inicio inicio = new inicio(nivel, nome);
                    this.Hide();
                    inicio.Show();
                }
                else
                {
                    MessageBox.Show("Nome ou senha incorretos!");
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Oficina.Properties.Resources.circle_down_regular1;
            button1.BackColor = Color.FromArgb(140, 69, 69, 69);
            pictureBox1.BackColor = Color.FromArgb(80, 69, 69, 69);
            button1.ForeColor = Color.White;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Oficina.Properties.Resources.circle_down_regular;
            button1.BackColor = Color.FromArgb(120, 225, 225, 225);
            pictureBox1.BackColor = Color.FromArgb(120, 225, 225, 225);
            button1.ForeColor = Color.Black;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Oficina.Properties.Resources.circle_down_regular1;
            button1.BackColor = Color.FromArgb(140, 69, 69, 69);
            pictureBox1.BackColor = Color.FromArgb(80, 69, 69, 69);
            button1.ForeColor = Color.White;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Oficina.Properties.Resources.circle_down_regular;
            button1.BackColor = Color.FromArgb(120, 225, 225, 225);
            pictureBox1.BackColor = Color.FromArgb(120, 225, 225, 225);
            button1.ForeColor = Color.Black;

        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.Image = null;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = pictureBox3.BackgroundImage;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabPage1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool verificado = false;
            foreach(Control c in this.Controls)
            {
                if(c is MaskedTextBox && string.IsNullOrEmpty(c.Text))
                {
                    MessageBox.Show("Ainda há informações pendentes!");
                    return;
                }
                else if(c is TextBox && string.IsNullOrEmpty(c.Text))
                {
                    MessageBox.Show("Ainda há informações pendentes!");
                    return;
                }
                else if(c is DateTimePicker && string.IsNullOrEmpty(c.Text))
                {
                    MessageBox.Show("Ainda há informações pendentes!");
                    return;
                }
                verificado = true;
            }

            if (verificado)
            {
                string nome = textBox3.Text, cpf = maskedTextBox2.Text, cargo = textBox7.Text,
                telefone = maskedTextBox3.Text, data_admissao = dateTimePicker1.Text, senha = maskedTextBox4.Text,
                email = textBox8.Text;
                funcionarios.login_novo_funcionario(nome, cpf, cargo, telefone, data_admissao, senha, email);
            }
        }

        private void maskedTextBox4_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox4.Text != maskedTextBox1.Text)
            {
                label11.ForeColor = Color.Red;
                label11.Text = "Essa senha está diferente!";
                button2.Enabled = false;
            }
            else
            {
                label11.ForeColor = Color.Green;
                label11.Text = "Tudo Correto";
                button2.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach(Control c in this.Controls)
            {
                if (c is MaskedTextBox && !string.IsNullOrEmpty(c.Text))
                {
                    c.Text = null;
                }
                else if (c is TextBox && !string.IsNullOrEmpty(c.Text))
                {
                    c.Text = null;
                }
                else if (c is DateTimePicker && !string.IsNullOrEmpty(c.Text))
                {
                    c.Text = DateTime.Now.ToString();
                }
            }
        }
    }
}