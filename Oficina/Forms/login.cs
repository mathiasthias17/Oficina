using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Oficina.Dados.MecanicaDBTableAdapters;

namespace Oficina.Forms
{
    public partial class login : Form
    {
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
    }
}