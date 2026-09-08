using Oficina.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Oficina
{
    public partial class inicio : Form
    {

        public inicio()
        {
            InitializeComponent();
            panel1.BackColor = Color.FromArgb(120, 10, 10, 10);
            label1.BackColor = Color.FromArgb(120, 10, 10, 10);
            panel3.BackColor = Color.FromArgb(150, 225, 225, 225);
            pictureBox8.BackColor = pictureBox9.BackColor = Color.FromArgb(140, 255, 255, 255);
            pictureBox10.BackColor = Color.FromArgb(180, 205, 205, 255);
            panel3.Visible = false;


            var loginForm = System.Windows.Forms.Application.OpenForms.OfType<login>().FirstOrDefault();
            if (loginForm != null)
            {
                if (loginForm.nivel == 1)
                {
                    MessageBox.Show("Bem-vindo Administrador");
                    veiculosToolStripMenuItem.Visible = false;
                    informativosToolStripMenuItem.Visible = false;
                    pictureBox1.Image = Oficina.Properties.Resources.funcionarios;
                    label2.Text = "Funcionários";
                    pictureBox2.Image = Oficina.Properties.Resources.Finanças;
                    label3.Text = "Financeiro";
                    pictureBox3.Image = Oficina.Properties.Resources.Fornecedores1;
                    label4.Text = "Fornecedores";
                }
                else if (loginForm.nivel == 2)
                {
                    MessageBox.Show("Bem-vindo Funcionário");
                    veiculosToolStripMenuItem.Visible = false;
                    informativosToolStripMenuItem.Visible = false;
                    funcionáriosToolStripMenuItem.Visible = false;
                    pictureBox1.Image = Oficina.Properties.Resources.estoque;
                    label2.Text = " Estoque";
                    pictureBox2.Image = Oficina.Properties.Resources.Peças;
                    label3.Text = "Peças";
                    pictureBox3.Image = Oficina.Properties.Resources.Fornecedores;
                    label4.Text = "Fornecedores";
                }
                else if (loginForm.nivel == 3)
                {
                    reposiçãoToolStripMenuItem.Visible = false;
                    peçasToolStripMenuItem.Visible = false;
                    fornecedoresToolStripMenuItem.Visible = false;
                    funcionáriosToolStripMenuItem.Visible = false;
                    finanaceiroToolStripMenuItem.Visible = false;
                    MessageBox.Show("Bem-vindo Cliente");
                    pictureBox1.Image = Oficina.Properties.Resources.pedir_serviço;
                    label2.Text = " Pedir Serviço";
                    pictureBox2.Image = Oficina.Properties.Resources.Peças;
                    label3.Text = "Peças";
                    pictureBox3.Image = Oficina.Properties.Resources.estoque;
                    label4.Text = "Estoque";
                }
                pictureBox5.ForeColor = ColorTranslator.FromHtml("#FFFFFF");
            }
        }

        private void veiculosToolStripMenuItem1_Click(object sender, EventArgs e)
        {


        }

        private void inicio_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = Oficina.Properties.Resources.quadro;

            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = Oficina.Properties.Resources.quadro1;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }



        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Oficina.Properties.Resources.quadro;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Oficina.Properties.Resources.quadro1;
            this.label3.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackgroundImage = Oficina.Properties.Resources.quadro;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }


        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {

            pictureBox3.BackgroundImage = Oficina.Properties.Resources.quadro1;
            this.label4.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void veiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (panel3.Visible == false)
            {
                panel3.Visible = true;
                panel1.Visible = false;
                this.panel3.Location = new System.Drawing.Point(265, 31);
            }
            else
            {
                this.panel3.Location = new System.Drawing.Point(321, 585);
                panel3.Visible = false;
                panel1.Visible = true;
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Close();
            login loginForm = new login();
            loginForm.Show();

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            var loginForm = System.Windows.Forms.Application.OpenForms.OfType<login>().FirstOrDefault();
            if (loginForm.nivel == 1)
            {
                label2.Text = "Funcionários";
            }
            else if (loginForm.nivel == 2)
            {
                label2.Text = "Estoque";
            }
            else if (loginForm.nivel == 3)
            {
                label2.Text = "Pedidos";
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
