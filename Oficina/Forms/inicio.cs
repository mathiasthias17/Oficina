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
namespace Oficina
{
    public partial class inicio : Form
    {

        public inicio()
        {
            InitializeComponent();
            panel1.BackColor = Color.FromArgb(120, 10, 10, 10);
            panel4.BackColor = Color.FromArgb(120, 225, 225, 225);
            label1.BackColor = Color.FromArgb(120, 10, 10, 10);
            panel3.BackColor = Color.FromArgb(150, 225, 225, 225);
            pictureBox8.BackColor = pictureBox9.BackColor = Color.FromArgb(140, 255, 255, 255);
            pictureBox10.BackColor = Color.FromArgb(180, 205, 205, 255);
            panel3.Visible = false;
            dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy HH:mm";
            dateTimePicker2.Value = DateTime.Today;
            pictureBox3.BackgroundImage = Oficina.Properties.Resources.quadro3;
            pictureBox13.Image = Oficina.Properties.Resources.baixo;
            label4.BackColor = Color.FromArgb(250, 255, 128, 0);
            this.label4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            button3.BackColor = Color.FromArgb(250, 255, 255, 255);
            pictureBox6.BackColor = Color.FromArgb(120, 10, 10, 10);
            pictureBox4.BackColor = Color.FromArgb(70, 10, 10, 10);

            var loginForm = System.Windows.Forms.Application.OpenForms.OfType<login>().FirstOrDefault();
            if (loginForm != null)
            {
                if (loginForm.nivel == 1)
                {
                    MessageBox.Show("Bem-vindo Administrador");
                    veiculosToolStripMenuItem.Visible = false;
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

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = Oficina.Properties.Resources.quadro3;
            pictureBox11.Image = Oficina.Properties.Resources.baixo;
            label2.BackColor = Color.FromArgb(250,255, 128, 0);
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = Oficina.Properties.Resources.quadro11;
            pictureBox11.Image = Oficina.Properties.Resources.baixo1;
            label2.BackColor = Color.FromArgb(250, 252, 218, 136);
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }



        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Oficina.Properties.Resources.quadro3;
            pictureBox12.Image = Oficina.Properties.Resources.baixo;
            label3.BackColor = Color.FromArgb(250, 255, 128, 0);
            this.label3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Oficina.Properties.Resources.quadro11;
            pictureBox12.Image = Oficina.Properties.Resources.baixo1;
            label3.BackColor = Color.FromArgb(250, 252, 218, 136);
            this.label3.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackgroundImage = Oficina.Properties.Resources.quadro3;
            pictureBox13.Image = Oficina.Properties.Resources.baixo;
            label4.BackColor = Color.FromArgb(250, 255, 128, 0);
            this.label4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }


        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {

            pictureBox3.BackgroundImage = Oficina.Properties.Resources.quadro11;
            pictureBox13.Image = Oficina.Properties.Resources.baixo1;
            label4.BackColor = Color.FromArgb(250, 252, 218, 136);
            this.label4.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

      
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (panel3.Visible == false)
            {
                esconder();
                panel3.Visible = true;
                this.panel3.Location = new System.Drawing.Point(265, 31);
                pictureBox6.BackColor= pictureBox4.BackColor = Color.FromArgb(0, 0, 0, 0);
            }
            else
            {   esconder();
                this.panel3.Location = new System.Drawing.Point(321, 585);
                panel3.Visible = false;
                panel1.Visible = true;
                panel1.Dock = DockStyle.Fill;
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

       
        public void esconder()
        {
            panel1.Visible = panel17.Visible = panel4.Visible=panel3.Visible=panel5.Visible=panel2.Visible=panel6.Visible=panel7.Visible = panel8.Visible = panel9.Visible = panel10.Visible = panel11.Visible = panel12.Visible = panel13.Visible = panel15.Visible = false;
            panel1.Dock = panel4.Dock = DockStyle.None;
            pictureBox6.BackColor = Color.FromArgb(0, 0, 0, 0);
            pictureBox4.Visible= pictureBox5.Visible =false;
        }

        private void paginaInicialToolStripMenuItem_Click(object sender, EventArgs e)
        {
         esconder();
            panel1.Visible = true;
          panel1.Dock = DockStyle.Fill;
            
            pictureBox6.BackColor = Color.FromArgb(120, 10, 10, 10);
            pictureBox4.BackColor = Color.FromArgb(70, 10, 10, 10);
            pictureBox4.Visible =pictureBox5.Visible= true;
        }

        private void peçasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            esconder();
            panel4.Visible = true;
            panel4.Dock = DockStyle.Fill;
            panel5.Visible = true;

          
        }

        private void veículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            esconder();
            panel4.Visible = true;
            panel4.Dock = DockStyle.Fill;
            panel17.Visible = true;
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

        }

        

        private void fornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            esconder();
            panel9.Visible = true;
            panel9.Dock = DockStyle.Fill;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
           dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
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
            Double valor=0,valor1 ;//preço_unitario
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

       
    }
}
