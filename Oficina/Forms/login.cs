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

namespace Oficina.Forms
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            panel1.BackColor = Color.FromArgb(120, 255, 255, 255);
            button1.BackColor = Color.FromArgb(120, 225, 225, 225);
            pictureBox1.BackColor = Color.FromArgb(120, 225, 225, 225);
        }
        public int nivel = -1;


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "Oficina100")
            {
                pictureBox2.BackgroundImage = Oficina.Properties.Resources.correto;
                pictureBox2.Image = Oficina.Properties.Resources.circle_check_regular;
                pictureBox3.BackgroundImage = Oficina.Properties.Resources.circle_check_regular;
                nivel = 1;
            }
            else if (textBox1.Text == "funcionario" && textBox2.Text == "B@lcão08")
            {
                pictureBox2.BackgroundImage = Oficina.Properties.Resources.correto;
                pictureBox2.Image = Oficina.Properties.Resources.circle_check_regular;
                pictureBox3.BackgroundImage = Oficina.Properties.Resources.circle_check_regular;
                nivel = 2;
            }
            else if (textBox1.Text == "user" && textBox2.Text == "Peça05")
            {
                pictureBox2.BackgroundImage = Oficina.Properties.Resources.correto;
                pictureBox2.Image = Oficina.Properties.Resources.circle_check_regular;
                pictureBox3.BackgroundImage = Oficina.Properties.Resources.circle_check_regular;
                nivel = 3;
            }
            else
            {
                pictureBox2.BackgroundImage = Oficina.Properties.Resources.erro;
                pictureBox2.Image = Oficina.Properties.Resources.circle_xmark_regular;
                pictureBox3.BackgroundImage = Oficina.Properties.Resources.circle_xmark_regular;
                label1.Text = label2.Text = "acesso negado!";
                label1.Font = label2.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout | System.Drawing.FontStyle.Italic))));
                label1.ForeColor = label2.ForeColor = Color.Red;
                nivel = 0;
                MessageBox.Show("Usuário ou senha inválidos.");
            }
            if (pictureBox2.Image == Oficina.Properties.Resources.circle_check_regular)
            {
                MessageBox.Show("Login bem sucedido!");
                label1.Text = label2.Text = "Valido!";
                label1.Font = label2.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
                label1.ForeColor = label2.ForeColor = Color.DarkGreen;
            }
            if (pictureBox2.Image != null)
            {
                button1.Visible = pictureBox1.Visible = false;
                pictureBox2.BackColor = Color.Transparent;
                textBox1.Enabled = textBox2.Enabled = false;
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (nivel > 0)
            {
                inicio inicio = new inicio();
                inicio.Show();
                Close();

            }
            else if (nivel == 0)
            {
                SplashScreen splashScreen = new SplashScreen();
                splashScreen.Show();
                Close();
            }
            else if (nivel < 0)
            {
                MessageBox.Show("logue para obter acesso.");
            }

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "Oficina100")
            {
                pictureBox2.BackgroundImage = Oficina.Properties.Resources.correto;
                pictureBox2.Image = Oficina.Properties.Resources.circle_check_regular;
                pictureBox3.BackgroundImage = Oficina.Properties.Resources.circle_check_regular;
                nivel = 1;
            }
            else if (textBox1.Text == "funcionario" && textBox2.Text == "B@lcão08")
            {
                pictureBox2.BackgroundImage = Oficina.Properties.Resources.correto;
                pictureBox2.Image = Oficina.Properties.Resources.circle_check_regular;
                pictureBox3.BackgroundImage = Oficina.Properties.Resources.circle_check_regular;
                nivel = 2;
            }
            else if (textBox1.Text == "user" && textBox2.Text == "Peça05")
            {
                pictureBox2.BackgroundImage = Oficina.Properties.Resources.correto;
                pictureBox2.Image = Oficina.Properties.Resources.circle_check_regular;
                pictureBox3.BackgroundImage = Oficina.Properties.Resources.circle_check_regular;
                nivel = 3;
            }
            else
            {
                pictureBox2.BackgroundImage = Oficina.Properties.Resources.erro;
                pictureBox2.Image = Oficina.Properties.Resources.circle_xmark_regular;
                pictureBox3.BackgroundImage = Oficina.Properties.Resources.circle_xmark_regular;
                label1.Text = label2.Text = "acesso negado!";
                label1.Font = label2.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout | System.Drawing.FontStyle.Italic))));
                label1.ForeColor = label2.ForeColor = Color.Red;
                nivel = 0;
                MessageBox.Show("Invalid usuário ou senha.");
            }
            if (pictureBox2.Image == Oficina.Properties.Resources.circle_check_regular)
            {
                MessageBox.Show("Login bem sucedido!");
                label1.Text = label2.Text = "Valido!";
                label1.Font = label2.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
                label1.ForeColor = label2.ForeColor = Color.DarkGreen;
            }
            if (pictureBox2.Image != null)
            {
                button1.Visible = pictureBox1.Visible = false;
                pictureBox2.BackColor = Color.Transparent;
                textBox1.Enabled = textBox2.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabPage1.Show();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            int hoje = Convert.ToInt32(DateTime.Today.Year);
            hoje = hoje - 18;
            if (dateTimePicker1.Value.Year > hoje)
            {
                MessageBox.Show("Você não tem idade suficiente para acessar o sistema.");
                dateTimePicker1.Value = DateTime.Today;
                textBox3.Enabled = textBox4.Enabled = false;
                radioButton1.Enabled = radioButton2.Enabled = radioButton3.Enabled = false;
                pictureBox1.Enabled = button1.Enabled = false;
            }
            if (dateTimePicker1.Value.Year < hoje)
            {
                textBox3.Enabled = textBox4.Enabled = true;
                radioButton1.Enabled = radioButton2.Enabled = radioButton3.Enabled = true;
                pictureBox1.Enabled = button1.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Preencha Nome e Senha é obrigatórios.");

            }
            else
            {
                MessageBox.Show("Cadastro realizado com sucesso!");
                nivel = 3;
                tabPage1.Hide();
            }
        }
    }
}